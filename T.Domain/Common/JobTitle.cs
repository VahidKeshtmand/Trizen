using T.Domain.Attributes;

namespace T.Domain.Common
{
    [Auditable]
    public class JobTitle
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public List<PersonalInformation> PersonalInformations { get; set; }

    }

}
