using MongoDB.Driver;
using T.Application.Interfaces.Contexts;

namespace T.Persistence.Contexts.MongoDb;

public class MongoDbContext<T> : IMongoDbContext<T>
{
    private readonly IMongoDatabase _database;
    private readonly IMongoCollection<T> _collection;

    public MongoDbContext()
    {
        var client = new MongoClient();
        _database = client.GetDatabase("TrizenVisitorDb");
        _collection = _database.GetCollection<T>(typeof(T).Name);
    }

    public IMongoCollection<T> GetCollection()
    {
        return _collection;
    }
}
