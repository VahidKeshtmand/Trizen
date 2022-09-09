using Microsoft.EntityFrameworkCore;
using OS.Application.Interfaces.Contexts;
using T.Domain.Attributes;
using T.Domain.Baskets;
using T.Domain.Bookings;
using T.Domain.Comments;
using T.Domain.Common;
using T.Domain.Discounts;
using T.Domain.Flights;
using T.Domain.Hotels;
using T.Domain.Payments;
using T.Domain.Reserves;
using T.Persistence.ConfigTables.Comments;
using T.Persistence.ConfigTables.Hotels;

namespace T.Persistence.Contexts.SqlServerDb
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<AmenityHotel> AmenityHotels { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<AmenityRoom> AmenityRooms { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<AirlineCompany> AirlineCompanies { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<AmenityFlight> AmenityFlights { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<Reserve> Reserves { get; set; }
        public DbSet<ReserveRoom> ReserveRooms { get; set; }
        public DbSet<Payment> Payments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AddShadowPropertyToEachTable(modelBuilder);
            modelBuilder.ApplyConfiguration(new HotelConfig());
            modelBuilder.ApplyConfiguration(new CommentConfig());
            modelBuilder.Entity<AirlineCompany>().HasOne(x => x.Image).WithOne(x => x.AirlineCompany).HasForeignKey<Image>(x => x.AirlineCompanyId);
            modelBuilder.Entity<Room>().HasQueryFilter(c => EF.Property<bool>(c, "IsRemoved") == false);
            modelBuilder.Entity<Discount>().HasQueryFilter(c => EF.Property<bool>(c, "IsRemoved") == false);
            modelBuilder.Entity<BasketItem>().HasQueryFilter(c => EF.Property<bool>(c, "IsRemoved") == false);
            modelBuilder.Entity<Basket>().HasQueryFilter(c => EF.Property<bool>(c, "IsRemoved") == false);
            modelBuilder.Entity<AirlineCompany>().HasQueryFilter(c => EF.Property<bool>(c, "IsRemoved") == false);
            modelBuilder.Entity<Flight>().HasQueryFilter(c => EF.Property<bool>(c, "IsRemoved") == false);
            modelBuilder.Entity<Comment>().HasQueryFilter(c => EF.Property<bool>(c, "IsRemoved") == false);
            modelBuilder.Entity<Image>().HasQueryFilter(c => EF.Property<bool>(c, "IsRemoved") == false);



            //modelBuilder.ApplyConfiguration(new AmenityHotelConfig());

            base.OnModelCreating(modelBuilder);
        }

        private static void AddShadowPropertyToEachTable(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (!entityType.ClrType.GetCustomAttributes(typeof(AuditableAttribute), true).Any())
                    continue;
                modelBuilder.Entity(entityType.Name).Property<DateTime>("InsertDate").HasDefaultValue(DateTime.Now); ;
                modelBuilder.Entity(entityType.Name).Property<DateTime?>("UpdateDate");
                modelBuilder.Entity(entityType.Name).Property<DateTime?>("RemoveDate");
                modelBuilder.Entity(entityType.Name).Property<bool>("IsRemoved").HasDefaultValue(false);
            }
        }

        public override int SaveChanges()
        {
            InitializeShadowProperties();

            return base.SaveChanges();
        }

        private void InitializeShadowProperties()
        {
            var modifiedEntries = ChangeTracker.Entries().Where(
                e => e.State == EntityState.Modified ||
                e.State == EntityState.Added ||
                e.State == EntityState.Deleted);

            foreach (var item in modifiedEntries)
            {
                var entityType = item.Context.Model.FindEntityType(item.Entity.GetType());
                if (entityType == null)
                    continue;

                var insertDate = entityType.FindProperty("InsertDate");
                var updateDate = entityType.FindProperty("UpdateDate");
                var removeDate = entityType.FindProperty("RemoveDate");
                var isRemoved = entityType.FindProperty("IsRemoved");

                if (item.State == EntityState.Added && insertDate != null)
                {
                    item.Property("InsertDate").CurrentValue = DateTime.Now;
                }
                if (item.State == EntityState.Modified && updateDate != null)
                {
                    item.Property("UpdateDate").CurrentValue = DateTime.Now;
                }
                if (item.State == EntityState.Deleted && removeDate != null && isRemoved != null)
                {
                    item.Property("RemoveDate").CurrentValue = DateTime.Now;
                    item.Property("IsRemoved").CurrentValue = true;
                    item.State = EntityState.Modified;
                }
            }
        }
    }
}
