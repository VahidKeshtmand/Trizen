using T.Domain.Attributes;
using T.Domain.Hotels;

namespace T.Domain.Common
{
    [Auditable]
    public class Contact
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string? Facebook { get; set; }
        public string? Twitter { get; set; }
        public string? Linkedin { get; set; }

        public Hotel Hotel { get; set; }
    }
}
