using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using T.Application.Dtos.Account;
using T.Application.Services.Account;

namespace T.Website.Endpoint.Controllers
{
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
            {
                var token = _accountService.SetPhoneNumber(model.PhoneNumber, model.Email);
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
        public IActionResult VerifyPhoneNumber(VerifyPhoneNumberDto model)
        {
            var result = _accountService.ConfirmPhoneNumber(User.Identity?.Name, model.Token, model.PhoneNumber);
            
            var user = _accountService.FindUserByName(User.Identity?.Name);
            if(user.PhoneNumberConfirmed ==true)
                return new JsonResult(new { status = "warning", message = $" شماره {model.PhoneNumber} قبلاً تاًیید شده است." });
            
            if (result == false)
            {
                return new JsonResult(new { status = "faile", message = $"کد وارد شده برای شماره {model.PhoneNumber} اشتباه است" });
            }

            
            if(user.PhoneNumberConfirmed ==true)
                return new JsonResult(new { status = "warning", message = $" شماره {model.PhoneNumber} قبلاً تاًیید شده است." });
            user.PhoneNumberConfirmed = true;
            _accountService.Update(user);
            return new JsonResult(new { status = "Success" });
        }


    }
}
