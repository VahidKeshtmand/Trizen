using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using T.Domain.Hotels;


namespace T.Persistence.ConfigTables.Hotels
{
    public class HotelConfig : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.AmenityHotels)
                .WithOne(x => x.Hotel)
                .HasForeignKey(x => x.HotelId);

            builder.HasOne(x => x.Contact)
                .WithOne(x => x.Hotel)
                .HasForeignKey<Hotel>(x => x.ContactId);

            builder.HasOne(x => x.Country)
                .WithOne(x => x.Hotel)
                .HasForeignKey<Hotel>(x => x.CountryId);

            builder.HasOne(x => x.Currency)
                .WithOne(x => x.Hotel)
                .HasForeignKey<Hotel>(x => x.CurrencyId);

            builder.HasOne(x => x.PersonalInformation)
                .WithOne(x => x.Hotel)
                .HasForeignKey<Hotel>(x => x.PersonalInformationId);
        }
    }
}
