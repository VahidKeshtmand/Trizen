using Microsoft.EntityFrameworkCore;
using T.Domain;
using T.Domain.Baskets;
using T.Domain.Comments;
using T.Domain.Common;
using T.Domain.Discounts;
using T.Domain.Flight;
using T.Domain.Hotels;

namespace OS.Application.Interfaces.Contexts
{
    public interface IDatabaseContext
    {
        DbSet<Hotel> Hotels { get; set; }
        DbSet<Amenity> Amenities { get; set; }
        DbSet<Contact> Contacts { get; set; }
        DbSet<Country> Countries { get; set; }
        DbSet<Currency> Currencies { get; set; }
        DbSet<PersonalInformation> PersonalInformations { get; set; }
        DbSet<JobTitle> JobTitles { get; set; }
        DbSet<AmenityHotel> AmenityHotels { get; set; }
        DbSet<Image> Images { get; set; }
        DbSet<Room> Rooms { get; set; }
        DbSet<AmenityRoom> AmenityRooms { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<Discount> Discounts { get; set; }
        DbSet<Basket> Baskets { get; set; }
        DbSet<BasketItem> BasketItems { get; set; }
        DbSet<AirlineCompany> AirlineCompanies { get; set; }
        DbSet<Flight> Flights { get; set; }
        DbSet<Seat> Seats { get; set; }


        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = new CancellationToken());
    }
}
