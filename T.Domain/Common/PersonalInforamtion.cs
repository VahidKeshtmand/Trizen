using T.Domain.Attributes;
using T.Domain.Hotels;

namespace T.Domain.Common
{
    [Auditable]
    public class PersonalInformation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public JobTitle JobTitle { get; set; }
        public int JobTitleId { get; set; }

        public Hotel Hotel { get; set; }
    }

}
