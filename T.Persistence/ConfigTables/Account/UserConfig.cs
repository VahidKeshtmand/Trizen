using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using T.Domain.Account;

namespace T.Persistence.ConfigTables.Account
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", "idt");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Fullname).HasMaxLength(100).IsRequired();
            builder.Property(u => u.UserName).HasMaxLength(100).IsRequired();
            builder.Property(u => u.NormalizedUserName).HasMaxLength(100);
            builder.Property(u => u.Email).HasMaxLength(200);
            builder.Property(u => u.NormalizedEmail).HasMaxLength(200);
            builder.Property(u => u.PhoneNumber).HasMaxLength(100).IsRequired();
            builder.Property(u => u.PasswordHash).IsRequired();

            // builder.HasMany(x => x.Comments).WithOne(x => x.User).HasForeignKey(x => x.UserId);
        }
    }
}
