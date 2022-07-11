using MongoDB.Driver;
using T.Application.Dtos.Visitor;
using T.Application.Interfaces.Contexts;
using T.Domain.Visitor;

namespace T.Application.Services.Visitor;

public interface IVisitorService
{
    void SaveVisitorInforamation(VisitorDto visitorData);
    ResultTodayReportDto GetTodayReport();
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

    public ResultTodayReportDto GetTodayReport()
    {
        var startDate = DateTime.Now.Date;
        var endDate = DateTime.Now.Date.AddDays(1);

        var todayViewPagesCount = _collection.AsQueryable()
            .Where(t => t.VisitDate >= startDate && t.VisitDate < endDate).LongCount();
         
        var todayVisitorsCount = _collection.AsQueryable()
            .Where(t => t.VisitDate >= startDate && t.VisitDate < endDate)
            .GroupBy(t => t.VisitorId).LongCount();

        var allPagesViewCount = _collection.AsQueryable().LongCount();

        var allVisitorsCount = _collection.AsQueryable()
            .GroupBy(t => t.VisitorId).LongCount();

        var visitCountPerHour = GetStatsOfVisitPerHour(startDate, endDate);

        var visitCountPerDay = GetStatsOfVisitPerDay();

        var chromeCount = 0;
        var edgeCount = 0;
        var firefoxCount = 0;
        var safariCount = 0;
        var operaCount = 0;

        var browserList = _collection.AsQueryable().Select(b => b.Browser);
        foreach (var item in browserList)
        {
            switch (item.Family)
            {
                case "Chrome":
                    chromeCount++;
                    break;
                case "Edge":
                    edgeCount++;
                    break;
                case "Firefox":
                    firefoxCount++;
                    break;
                case "Opera":
                    safariCount++;
                    break;
                case "Safari":
                    operaCount++;
                    break;
            }
        }
        return new ResultTodayReportDto
        {
            BrowserVisitCount = new List<BrowserVisitCountDto>
            {
                new BrowserVisitCountDto
                {
                    Name = "کروم",
                    VisitCount = chromeCount
                },
                new BrowserVisitCountDto
                {
                    Name = "فایرفاکس",
                    VisitCount = firefoxCount
                },
                new BrowserVisitCountDto
                {
                    Name = "ماکروسافت ادج",
                    VisitCount = edgeCount
                },
                new BrowserVisitCountDto
                {
                    Name = "سافاری",
                    VisitCount = safariCount
                },
                new BrowserVisitCountDto
                {
                    Name = "اوپرا",
                    VisitCount = operaCount
                },
            },

            GeneralStats = new GeneralStatsDto
            {
                TotalPageViews = allPagesViewCount,
                TotalVisitors = allVisitorsCount,
                PageViewsPerVisit = GetAverage(allPagesViewCount, allVisitorsCount),
                VisitPerDay = visitCountPerDay
            },
            Today = new TodayDto
            {
                PageViews = todayViewPagesCount,
                Visitors = todayVisitorsCount,
                ViewsPerVisitors = GetAverage(todayViewPagesCount, todayVisitorsCount),
                VisitCount = new VisitorCountForChartDto
                {
                    Display = visitCountPerHour.Display,
                    Values = visitCountPerHour.Values,
                }
            }
        };
    }

    private VisitorCountForChartDto GetStatsOfVisitPerDay()
    {
        var startMonth = DateTime.Now.Date.AddDays(-30);
        var endMonth = DateTime.Now.Date.AddDays(1);
        var visitDayList = _collection.AsQueryable()
            .Where(v => v.VisitDate >= startMonth && v.VisitDate < endMonth)
            .Select(v => v.VisitDate).ToList();
        var visitCountPerDay = new VisitorCountForChartDto
        {
            Display = new string[31],
            Values = new int[31]
        };
        for (var i = 0; i <= 30; i++)
        {
            var currentDay = DateTime.Now.Date.AddDays(i * (-1));
            visitCountPerDay.Display[i] = i.ToString();
            visitCountPerDay.Values[i] = visitDayList.Count(v => v.Date == currentDay);
        }

        return visitCountPerDay;
    }

    private VisitorCountForChartDto GetStatsOfVisitPerHour(DateTime startDate, DateTime endDate)
    {
        var visitListPerDay = _collection.AsQueryable()
                    .Where(t => t.VisitDate >= startDate && t.VisitDate < endDate)
                    .Select(v => v.VisitDate).ToList();
        var visitCountPerHour = new VisitorCountForChartDto
        {
            Display = new string[24],
            Values = new int[24]
        };
        for (var i = 0; i <= 23; i++)
        {
            visitCountPerHour.Display[i] = i.ToString();
            visitCountPerHour.Values[i] = visitListPerDay.Count(v => v.Hour == i);
        }

        return visitCountPerHour;
    }

    private static float GetAverage(long visitPage, long visitor)
    {
        if (visitor == 0)
            return 0;
        return visitPage / visitor;
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