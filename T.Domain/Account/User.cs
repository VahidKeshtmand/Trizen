using Microsoft.AspNetCore.Identity;
using T.Domain.Attributes;
using T.Domain.Comments;

namespace T.Domain.Account
{
    [Auditable]
    public class User : IdentityUser
    {
        public string Fullname { get; set; } = string.Empty;

        public List<Comment> Comments { get; set; }
    }
}
