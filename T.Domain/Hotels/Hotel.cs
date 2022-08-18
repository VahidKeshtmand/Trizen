using T.Domain.Attributes;
using T.Domain.Comments;
using T.Domain.Common;
using T.Domain.Discounts;

namespace T.Domain.Hotels
{
    [Auditable]
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int RoomsCount { get; set; }
        public int MaximumRoomPrice { get; set; }
        public int MinimumRoomPrice { get; set; }
        public string? Description { get; set; }
        public MinimumDaysStay MinimumDaysStay { get; set; }
        public Housekeeping Housekeeping { get; set; }
        public HousekeepingFrequency HousekeepingFrequency { get; set; }
        public Bathroom Bathroom { get; set; }
        public ConfirmStatus ConfirmStatus { get; set; } = ConfirmStatus.Pending;
        public ExtraPeople ExtraPeople { get; set; }
        public Cancellation Cancellation { get; set; }
        public int StarsCount { get; set; }
        public string Slug { get; set; }


        public PersonalInformation PersonalInformation { get; set; }
        public int? PersonalInformationId { get; set; }

        public Country Country { get; set; }
        public int CountryId { get; set; }

        public Contact Contact { get; set; }
        public int ContactId { get; set; }

        public Currency Currency { get; set; }
        public int CurrencyId { get; set; }

        public List<AmenityHotel> AmenityHotels { get; set; }
        public List<Image> Images { get; set; }
        public List<Room> Rooms { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Discount> Discounts { get; set; }


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

    public enum ConfirmStatus
    {
        Pending,
        Reject,
        Confirmed
    }

    public enum ExtraPeople
    {
        NoCharge,
        Charge
    }

    public enum Cancellation
    {
        Strict,
        NotStrict
    }
}


