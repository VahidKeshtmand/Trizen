using MongoDB.Driver;
using T.Application.Dtos.Visitor;
using T.Application.Interfaces.Contexts;
using T.Domain.Visitor;

namespace T.Application.Services.Visitor;

public interface IVisitorService
{
    void SaveVisitorInforamation(VisitorDto visitorData);
}

public class VisitorService : IVisitorService
{
    private readonly IMongoDbContext<VisitorEntity> _context;
    private readonly IMongoCollection<VisitorEntity> _collection;

    public VisitorService(IMongoDbContext<VisitorEntity> context)
    {
        _context = context;
        _collection = _context.GetCollection();
    }
    
    public void SaveVisitorInforamation(VisitorDto visitorData)
    {
        var visitor = new VisitorEntity
        {
            Ip = visitorData.Ip,
            CurrentLink = visitorData.CurrentLink,
            Method = visitorData.Method,
            Protocol = visitorData.Protocol,
            ReferrerLink = visitorData.ReferrerLink,
            PhysicalPath = visitorData.PhysicalPath,
            VisitorId = visitorData.VisitorId,
            VisitDate = DateTime.Now,
            Browser = new VisitorVersion
            {
                Family = visitorData.Browser.Family,
                Version = visitorData.Browser.Version
            },
            OperatingSystem = new VisitorVersion
            {
                Family = visitorData.OperatingSystem.Family,
                Version = visitorData.OperatingSystem.Version
            },
            Device = new VisitorDevice
            {
                Family = visitorData.Device.Family,
                Brand = visitorData.Device.Brand,
                IsSpider = visitorData.Device.IsSpider,
                Model = visitorData.Device.Model
            }
        };
        _collection.InsertOne(visitor);
    }
}