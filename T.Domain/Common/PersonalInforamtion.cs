using T.Domain.Attributes;
using T.Domain.Hotels;

namespace T.Domain.Common
{
    [Auditable]
    public class PersonalInformation
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public JobTitle JobTitle { get; set; }
        public int JobTitleId { get; set; }

        public Hotel Hotel { get; set; }
    }

}
