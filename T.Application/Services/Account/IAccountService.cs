using Microsoft.AspNetCore.Identity;
using T.Application.Dtos.Account;
using T.Domain.Account;
namespace T.Application.Services.Account
{
    public interface IAccountService
    {
        IdentityResult Register(RegisterDto model);
        User FindUserByName(string name);
        string SetPhoneNumber(string phoneNumber, string userName);
        SignInResult Login(string userName, string Password, bool isPersistent);
        bool ConfirmPhoneNumber(string userName, string token, string phoneNumber);
        void Update(User user);
    }

    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        
        public AccountService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IdentityResult Register(RegisterDto model)
        {
            var user = new User()
            {
                Fullname = model.Fullname,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                UserName = model.Email,
            };

            return _userManager.CreateAsync(user, model.Password).Result;
        }

        public User FindUserByName(string name)
        {
            return _userManager.FindByNameAsync(name).Result;
        }

        public string SetPhoneNumber(string phoneNumber, string userName)
        {
            var user = FindUserByName(userName);
            var result = _userManager.SetPhoneNumberAsync(user, phoneNumber).Result;
            var token = _userManager.GenerateChangePhoneNumberTokenAsync(user, phoneNumber).Result;
            return token;
        }

        public SignInResult Login(string userName, string Password, bool isPersistent)
        {
            var user = FindUserByName(userName);
            _signInManager.SignOutAsync();
            return _signInManager.PasswordSignInAsync(user, Password, isPersistent, true).Result;

        }

        public bool ConfirmPhoneNumber(string userName, string token, string phoneNumber)
        {
            var user = FindUserByName(userName);
            var result = _userManager.VerifyChangePhoneNumberTokenAsync(user, token, phoneNumber).Result;
            return result;
        }

        public void Update(User user)
        {
            var result = _userManager.UpdateAsync(user).Result;
            
        }
    }
}
