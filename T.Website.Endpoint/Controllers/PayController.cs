using Dto.Payment;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OS.Website.EndPoint.Utilities;
using RestSharp;
using T.Application.Dtos.Payments;
using T.Application.Services.PaymentServices;
using ZarinPal.Class;

namespace T.Website.Endpoint.Controllers;

public class PayController : Controller
{
    private readonly Payment _payment;
    private readonly Authority _authority;
    private readonly Transactions _transactions;

    private readonly IConfiguration _configuration;
    private readonly IPaymentService _paymentService;
    private readonly string MerchendId;

    public PayController(IConfiguration configuration, IPaymentService paymentService)
    {
        _configuration = configuration;
        _paymentService = paymentService;
        MerchendId = configuration["ZarinpalMerchendId"];

        var expose = new Expose();
        _payment = expose.CreatePayment();
        _authority = expose.CreateAuthority();
        _transactions = expose.CreateTransactions();
    }

    public async Task<IActionResult> Index(Guid paymentId)
    {
        var payment = _paymentService.GetPayment(paymentId);
        if (payment == null)
        {
            return NotFound();
        }
        string userId = ClaimUtility.GetUserId(User);
        if (userId != payment.UserId)
        {
            return BadRequest();
        }
        var callBackUrl = Url.Action(nameof(Verify), "pay", new { payment.Id }, protocol: Request.Scheme);
        var resultZarinpalRequest = await _payment.Request(new DtoRequest
        {
            Amount = payment.Amount,
            CallbackUrl = callBackUrl,
            Description = payment.Description,
            Email = payment.Email,
            MerchantId = MerchendId,
            Mobile = payment.PhoneNumber
        }, Payment.Mode.sandbox);
        return Redirect($"https://sandbox.zarinpal.com/pg/StartPay/{resultZarinpalRequest.Authority}");
    }
    public IActionResult Verify(Guid id, string authority)
    {
        var status = HttpContext.Request.Query["Status"];
        if (status != "" && status.ToString().ToLower() == "ok" && authority != "")
        {
            var payment = _paymentService.GetPayment(id);
            if (payment == null) return NotFound();
            // var verification = _payment.Verification(new DtoVerification
            // {
            //     Amount = payment.Amount,
            //     Authority = authority,
            //     MerchantId = MerchendId,
            // }, Payment.Mode.sandbox).Result;
            var options = new RestClientOptions("https://sandbox.zarinpal.com/pg/rest/WebGate/PaymentVerification.json")
            {
                ThrowOnAnyError = true,
                Timeout = -1
            };
            var client = new RestClient(options);
            var request = new RestRequest("", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", $"{{\"MerchantID\" :\"{MerchendId}\",\"Authority\":\"{authority}\",\"Amount\":\"{payment.Amount}\"}}", ParameterType.RequestBody);
            var response = client.Execute(request);

            VerificationPayResultDto verification =
                JsonConvert.DeserializeObject<VerificationPayResultDto>(response.Content);

            if (verification.Status == 100)
            {
                var verifyResult = _paymentService.VerifyPayment(id, authority, verification.RefId);
                if (verifyResult)
                {
                    return Redirect("/customers/orders");
                }
                else
                {
                    TempData["message"] = "پرداخت انجام شد اما ثبت نشد";
                    return RedirectToAction("checkout", "basket");
                }
            }
            else
            {
                TempData["message"] = "پرداخت شما ناموفق بوده است . لطفا مجددا تلاش نمایید یا در صورت بروز مشکل با مدیریت سایت تماس بگیرید .";
                return RedirectToAction("checkout", "basket");
            }
            TempData["message"] = "پرداخت شما ناموفق بوده است .";
            return RedirectToAction("checkout", "basket");
        }

        return View();
    }

}
