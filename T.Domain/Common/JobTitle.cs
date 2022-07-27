using T.Domain.Attributes;

namespace T.Domain.Common
{
    [Auditable]
    public class JobTitle
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;

        public PersonalInformation PersonalInformation { get; set; }

    }

}
