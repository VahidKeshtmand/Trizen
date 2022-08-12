using T.Domain.Attributes;
using T.Domain.Hotels;

namespace T.Domain.Common
{
    [Auditable]
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;

        public List<Hotel> Hotels { get; set; }

    }
}
