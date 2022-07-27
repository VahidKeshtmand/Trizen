using Microsoft.EntityFrameworkCore;
using OS.Application.Interfaces.Contexts;
using T.Domain.Attributes;
using T.Domain.Common;
using T.Domain.Hotels;
using T.Persistence.ConfigTables.Common;
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
        public DbSet<PersonalInformation> PersonalInformations { get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }
        public DbSet<AmenityHotel> AmenityHotels { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AddShadowPropertyToEachTable(modelBuilder);
            modelBuilder.ApplyConfiguration(new HotelConfig());
            modelBuilder.ApplyConfiguration(new PersonalInformationConfig());
            modelBuilder.ApplyConfiguration(new AmenityHotelConfig());

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
                    item.Property("IsRemoved").CurrentValue = false;
                }
            }
        }
    }
}
