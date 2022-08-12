using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using T.Application.Dtos.Account;
using T.Application.Services.Account;
using T.Website.Endpoint.Utilities.Filters;

namespace T.Website.Endpoint.Controllers
{
    // [ServiceFilter(typeof(SaveVisitorInfoFilter))]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public IActionResult Register(RegisterDto model)
        {
            if (!ModelState.IsValid)
                return new JsonResult(new { status = "Error" });

            var registerResult = _accountService.Register(model);
            var signInResult = _accountService.Login(model.Email, model.Password, false);

            if (registerResult.Succeeded && signInResult.Succeeded)
                return new JsonResult(new { status = "Success" });

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
            if (!result.Succeeded)
                return new JsonResult(new { status = "Error" });
            return new JsonResult(new { status = "Success" });
        }

    }
}
