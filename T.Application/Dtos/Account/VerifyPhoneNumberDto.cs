using System.ComponentModel.DataAnnotations;

namespace T.Application.Dtos.Account
{
    public class VerifyPhoneNumberDto
    {
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        [MinLength(6)]
        [MaxLength(6)]
        public string Token { get; set; } = string.Empty;
    }
}

