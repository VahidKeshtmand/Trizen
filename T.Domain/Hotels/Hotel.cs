using T.Domain.Attributes;
using T.Domain.Common;

namespace T.Domain.Hotels
{
    [Auditable]
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int RoomsCount { get; set; }
        public int MaximumRoomPrice { get; set; }
        public int MinimumRoomPrice { get; set; }
        public string Description { get; set; } = string.Empty;
        public MinimumDaysStay MinimumDaysStay { get; set; }
        public Housekeeping Housekeeping { get; set; }
        public HousekeepingFrequency HousekeepingFrequency { get; set; }
        public Bathroom Bathroom { get; set; }
        public string ImageAddress { get; set; } = string.Empty;

        public PersonalInformation PersonalInformation { get; set; }
        public int? PersonalInformationId { get; set; }

        public Country Country { get; set; }
        public int CountryId { get; set; }

        public Contact Contact { get; set; }
        public int ContactId { get; set; }

        public Currency Currency { get; set; }
        public int CurrencyId { get; set; }

        public List<AmenityHotel> AmenityHotels { get; set; }
    }

    public enum Bathroom
    {
        AllEnSuite,
        SomeEnSuite,
        Shared
    }

    public enum HousekeepingFrequency
    {
        Daily,
        Weekly,
        Bi_weekly,
        Nothing
    }

    public enum Housekeeping
    {
        AdditionalFee,
        IncludedInRoomRate
    }
    public enum MinimumDaysStay
    {
        LessThanThreeNights,
        MoreThanThreeNights
    }

}


