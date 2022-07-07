using Microsoft.AspNetCore.Identity;
using T.Domain.Attributes;

namespace T.Domain.Account
{
    [Auditable]
    public class Role : IdentityRole
    {
        public string Description { get; set; } = string.Empty;
    }
}
