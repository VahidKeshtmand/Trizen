using T.Domain.Attributes;
using T.Domain.Hotels;

namespace T.Domain.Common
{
    [Auditable]
    public class Currency
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Hotel Hotel { get; set; }
    }
}
