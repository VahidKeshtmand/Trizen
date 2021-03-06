using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using T.Domain.Account;
using T.Persistence.ConfigTables.Account;

namespace T.Persistence.Contexts.SqlServerDb
{
    public class IdentityDatabaseContext : IdentityDbContext<User, Role, string>
    {
        public IdentityDatabaseContext(DbContextOptions<IdentityDatabaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var assembly = typeof(UserConfig).Assembly;
            builder.ApplyConfigurationsFromAssembly(assembly);
            ChangeTablesName(builder);
            PrimaryKeyDefination(builder);
        }

        private static void ChangeTablesName(ModelBuilder builder)
        {
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "idt");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "idt");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "idt");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "idt");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "idt");
        }

        private static void PrimaryKeyDefination(ModelBuilder builder)
        {
            builder.Entity<IdentityUserLogin<string>>()
                .HasKey(ul => new { ul.LoginProvider, ul.ProviderKey });
            builder.Entity<IdentityUserRole<string>>()
                .HasKey(ul => new { ul.UserId, ul.RoleId });
            builder.Entity<IdentityUserToken<string>>()
                .HasKey(ul => new { ul.LoginProvider, ul.UserId, ul.Name });    
            
            builder.Entity<IdentityRoleClaim<string>>()
                .HasKey(ul => ul.Id);
            builder.Entity<IdentityUserClaim<string>>()
                .HasKey(ul => ul.Id);
        }

    }

}
