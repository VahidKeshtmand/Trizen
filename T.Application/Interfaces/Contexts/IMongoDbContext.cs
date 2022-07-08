using MongoDB.Driver;

namespace T.Application.Interfaces.Contexts;

public interface IMongoDbContext<T>
{
    public IMongoCollection<T> GetCollection();
}
