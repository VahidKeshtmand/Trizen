using Microsoft.EntityFrameworkCore;
using T.Domain.Account;

namespace T.Application.Interfaces.Contexts;

public interface IIdentityDatabaseContext
{
    DbSet<User> Users { get; set; }
}
