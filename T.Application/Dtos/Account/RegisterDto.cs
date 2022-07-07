using System.ComponentModel.DataAnnotations;

namespace T.Application.Dtos.Account
{
    public class RegisterDto
    {
        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "وارد کردن نام ونام خانوادگی اجباری است!")]
        [MaxLength(100, ErrorMessage = "حداکثر تعداد مجاز 100 کاراکتر است!")]
        public string Fullname { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "لطفا ایملیلی معتبر وارد کنید!")]
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "وارد کردن ایمیل اجباری است!")]
        public string Email { get; set; } = string.Empty;

        [Display(Name = "شماره موبایل")]
        [Required(ErrorMessage = "وارد کردن شماره موبایل اجباری است!")]
        [MaxLength(50, ErrorMessage = "حداکثر تعداد مجاز 50 کاراکتر است!")]
        [RegularExpression(@"(\+98|0)?9\d{9}",ErrorMessage ="فرمت شماره موبایل صحیح نمی باشد!")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Display(Name = "رمز عبور")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "وارد کردن رمز عبور اجباری است!")]
        [MaxLength(100, ErrorMessage = "حداکثر تعداد مجاز 100 کاراکتر است!")]
        [MinLength(8, ErrorMessage ="کلمه عبور حداقل باید شامل 8 کاراکتر باشد!")]
        public string Password { get; set; } = string.Empty;

        [Display(Name = "تکرار رمز عبور")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "وارد کردن تکرار رمز عبور اجباری است!")]
        [MaxLength(100, ErrorMessage = "حداکثر تعداد مجاز 100 کاراکتر است!")]
        [Compare(nameof(Password), ErrorMessage = "رمز عبور و تکرار رمز عبور برابر نیستند!")]
        [MinLength(8, ErrorMessage ="کلمه عبور حداقل باید شامل 8 کاراکتر باشد!")]
        public string RePassword { get; set; } = string.Empty;
    }
}
