using MongoDB.Driver;
using T.Application.Interfaces.Contexts;
using T.Domain.Visitor;

namespace T.Application.Services.Visitor;

public interface IOnlineVisitorService
{
    void ConnectUser(string clientId);
    void DisConnectUser(string clientId);
    int GetCount(string clientId);
}
public class OnlineVisitorService : IOnlineVisitorService
{
    private readonly IMongoDbContext<OnlineVisitor> _mongoDbContext;
    private readonly IMongoCollection<OnlineVisitor> _mongoCollection;

    public OnlineVisitorService(IMongoDbContext<OnlineVisitor> mongoDbContext)
    {
        _mongoDbContext = mongoDbContext;
        _mongoCollection = _mongoDbContext.GetCollection();
    }

    public void ConnectUser(string clientId)
    {
        _mongoCollection.InsertOne(new OnlineVisitor
        {
            ClientId = clientId,
            DateTime = DateTime.Now
        });
    }

    public void DisConnectUser(string clientId)
    {
        _mongoCollection.FindOneAndDelete(o => o.ClientId == clientId);
    }

    public int GetCount(string clientId)
    {
        return _mongoCollection.AsQueryable().Select(o => o.ClientId == clientId).Distinct().Count();
    }
}
