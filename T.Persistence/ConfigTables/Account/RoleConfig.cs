using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using T.Domain.Account;

namespace T.Persistence.ConfigTables.Account
{
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles", "idt");
            builder.HasKey(u => u.Id);
            builder.Property(r => r.Name).HasMaxLength(100);
            builder.Property(r => r.NormalizedName).HasMaxLength(100);
            builder.Property(r => r.Description).HasMaxLength(1000);
        }
    }
}
