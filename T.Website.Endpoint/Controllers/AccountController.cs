using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using T.Application.Dtos.Account;
using T.Application.Services.Account;
using T.Application.Services.Baskets;
using T.Application.Services.Bookings;
using T.Website.Endpoint.Utilities.Filters;

namespace T.Website.Endpoint.Controllers
{
    // [ServiceFilter(typeof(SaveVisitorInfoFilter))]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IBasketService _BasketService;
        private readonly IBookingService _bookingService;

        public AccountController(IAccountService accountService, IBasketService basketService, IBookingService bookingService)
        {
            _accountService = accountService;
            _BasketService = basketService;
            _bookingService = bookingService;
        }

        [HttpPost]
        public IActionResult Register(RegisterDto model)
        {
            if (!ModelState.IsValid)
                return new JsonResult(new { status = "Error" });

            var registerResult = _accountService.Register(model);
            var signInResult = _accountService.Login(model.Email, model.Password, false);
            var user = _accountService.FindUserByName(model.Email);
            if (registerResult.Succeeded && signInResult.IsSuccess)
            {
                TransferBasket(user.Id);
                TransferBookings(user.Id);
                return new JsonResult(new { status = "Success" });
            }


            return new JsonResult(new { status = "Error" });

        }

        public IActionResult VerifyPhoneNumber()
        {
            ViewBag.PhoneNumber = _accountService.FindUserByName(User.Identity.Name).PhoneNumber;
            return View();
        }

        [HttpPost]
        public IActionResult SendToken()
        {
            var user = _accountService.FindUserByName(User.Identity.Name);
            if (user.PhoneNumberConfirmed == true)
                return new JsonResult(new { status = "Warning", message = $" شماره {user.PhoneNumber} قبلاً تاًیید شده است." });
            var token = _accountService.SetPhoneNumber(user.PhoneNumber, user.UserName);
            return RedirectToAction("VerifyPhoneNumber");
            // var sms = new SmsService();
            // sms.Send(user.PhoneNumber, token);
        }

        [HttpPost]
        public IActionResult VerifyPhoneNumber(VerifyPhoneNumberDto model)
        {


            var result = _accountService.ConfirmPhoneNumber(User.Identity?.Name, model.Token, model.PhoneNumber);

            if (result == false)
            {
                return new JsonResult(new { status = "Error", message = $"کد وارد شده برای شماره {model.PhoneNumber} اشتباه است" });
            }
            var user = _accountService.FindUserByName(User.Identity?.Name);
            user.PhoneNumberConfirmed = true;
            _accountService.Update(user);
            return new JsonResult(new { status = "Success" });
        }

        [HttpPost]
        public IActionResult Login(LoginDto model)
        {
            if (!ModelState.IsValid)
                return new JsonResult(new { status = "Error" });

            var user = _accountService.FindUserByName(model.Email);
            var result = _accountService.Login(model.Email, model.Password, model.RememberMe);
            if (!result.IsSuccess)
                return new JsonResult(new { status = "Error" });
            TransferBasket(user.Id);
            TransferBookings(user.Id);
            return new JsonResult(new { status = "Success" });
        }

        public IActionResult UnAuthorize()
        {
            return View();
        }

        private void TransferBasket(string userId)
        {
            var cookieName = "BasketId";
            if (Request.Cookies.ContainsKey(cookieName))
            {
                var anonymousId = Request.Cookies[cookieName];
                _BasketService.TransferBasket(anonymousId, userId);
                Response.Cookies.Delete(cookieName);
            }
        }

        private void TransferBookings(string userId)
        {
            var cookieName = "bookingId";
            if (Request.Cookies.ContainsKey(cookieName))
            {
                var anonymousId = Request.Cookies[cookieName];
                _bookingService.TransferBooking(anonymousId, userId);
                Response.Cookies.Delete(cookieName);
            }
        }
    }
}
