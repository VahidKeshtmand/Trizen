using System.ComponentModel.DataAnnotations;

namespace T.Application.Dtos.Account;

public class LoginDto
{
    [EmailAddress(ErrorMessage = "لطفا ایملیلی معتبر وارد کنید!")]
    [Display(Name = "ایمیل")]
    [Required(ErrorMessage = "وارد کردن ایمیل اجباری است!")]
    public string Email { get; set; } = string.Empty;

    [Display(Name = "رمز عبور")]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "وارد کردن رمز عبور اجباری است!")]
    [MaxLength(100, ErrorMessage = "حداکثر تعداد مجاز 100 کاراکتر است!")]
    [MinLength(8, ErrorMessage = "کلمه عبور حداقل باید شامل 8 کاراکتر باشد!")]
    public string Password { get; set; } = string.Empty;

    public bool RememberMe { get; set; }
}
