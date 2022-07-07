using Microsoft.AspNetCore.Identity;
using T.Domain.Attributes;

namespace T.Domain.Account
{
    [Auditable]
    public class User : IdentityUser
    {
        public string Fullname { get; set; } = string.Empty;
    }
}
