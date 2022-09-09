using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using T.Domain.Hotels;

namespace T.Application.Dtos.Hotels;

public class RegisterDto
{
    public InformationDto? Information { get; set; }

    [Required(ErrorMessage = "لطفاً نام تجاری خود را وارد کنید !")]
    [MaxLength(200, ErrorMessage = "تعداد کاراکتر ها نباید بیشتر از 200 کاراکتر باشد !")]
    [MinLength(3, ErrorMessage = "تعداد کاراکتر ها نباید کمتر از 3 کاراکتر باشد !")]
    public string Name { get; set; }

    [Required(ErrorMessage = "لطفاً Slug خود را وارد کنید !")]
    [MaxLength(200, ErrorMessage = "تعداد کاراکتر ها نباید بیشتر از 200 کاراکتر باشد !")]
    [MinLength(3, ErrorMessage = "تعداد کاراکتر ها نباید کمتر از 3 کاراکتر باشد !")]
    public string Slug { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "لطفاً کشور خود را انتخاب کنید !")]
    public int Country { get; set; }

    [Required(ErrorMessage = "لطفاً نام شهر خود را وارد کنید !")]
    [MaxLength(200, ErrorMessage = "تعداد کاراکتر ها نباید بیشتر از 200 کاراکتر باشد !")]
    [MinLength(3, ErrorMessage = "تعداد کاراکتر ها نباید کمتر از 3 کاراکتر باشد !")]
    public string City { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "لطفاً کد کشور خود را انتخاب کنید !")]
    public int CountryCode { get; set; }

    [Required(ErrorMessage = "لطفاً آدرس هتل خود را وارد کنید !")]
    [MaxLength(200, ErrorMessage = "تعداد کاراکتر ها نباید بیشتر از 1000 کاراکتر باشد !")]
    [MinLength(3, ErrorMessage = "تعداد کاراکتر ها نباید کمتر از 3 کاراکتر باشد !")]
    public string Address { get; set; } = string.Empty;

    [Required(ErrorMessage = "لطفاً آدرس هتل خود را وارد کنید !")]
    [RegularExpression(@"(\+98|0)?9\d{9}", ErrorMessage = "فرمت شماره موبایل صحیح نمی باشد!")]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "لطفاً ایمیل خود را وارد کنید !")]
    [EmailAddress(ErrorMessage = "لطفاً ایمیلی معتبر وارد کنید !")]
    [MaxLength(200, ErrorMessage = "تعداد کاراکتر ها نباید بیشتر از 200 کاراکتر باشد !")]
    [MinLength(3, ErrorMessage = "تعداد کاراکتر ها نباید کمتر از 3 کاراکتر باشد !")]
    public string Email { get; set; }

    [RegularExpression(@"^(http(s)?://)?([\w-]+\.)+[\w-]+[-a-zA-Z0-9@:%_\+.~#?&//=]{2,256}\.[a-z]{2,4}\b(\/[-a-zA-Z0-9@:%_\+.~#?&//=]*)?$", ErrorMessage = "لطفاً آدرس وبسایت معتبر خود را وارد کنید !")]
    public string? Website { get; set; }
    public string? Facebook { get; set; }
    public string? Twitter { get; set; }
    public string? Linkedin { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "لطفاً تعداد کل اتاق های هتل خود را وارد کنید !")]
    public int RoomsCount { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "لطفاً حداکثر قیمت اتاق را وارد کنید  !")]
    public int MaximumRoomPrice { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "لطفاً حداقل قیمت اتاق را وارد کنید !")]
    public int MinimumRoomPrice { get; set; }

    [Range(1, 6, ErrorMessage = "حداکثر تعداد ستاره 6 و حداقل 1 می باشد !")]
    public int StarsCount { get; set; }

    public string? Description { get; set; }
    public MinimumDaysStay MinimumDaysStayValue { get; set; }
    public Housekeeping HousekeepingValue { get; set; }
    public HousekeepingFrequency HousekeepingFrequencyValue { get; set; }
    public Bathroom BathroomValue { get; set; }
    public ExtraPeople ExtraPeople { get; set; }
    public Cancellation Cancellation { get; set; }

    public List<IFormFile>? Images { get; set; }
    public List<string>? ImagesSrc { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "لطفاً ارز مورد نظر خود را انتخاب کنید !")]
    public int Currency { get; set; }
    public Dictionary<int, string> AmenitiesValue { get; set; }
}
