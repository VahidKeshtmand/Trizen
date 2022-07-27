using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using T.Domain.Hotels;


namespace T.Persistence.ConfigTables.Hotels
{
    public class AmenityHotelConfig : IEntityTypeConfiguration<AmenityHotel>
    {
        public void Configure(EntityTypeBuilder<AmenityHotel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Hotel)
                .WithMany(x => x.AmenityHotels)
                .HasForeignKey(x => x.HotelId);

            builder.HasOne(x => x.Amenity)
                .WithMany(x => x.AmenityHotels)
                .HasForeignKey(x => x.AmenityId);
        }
    }
}
