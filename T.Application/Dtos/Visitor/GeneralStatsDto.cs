namespace T.Application.Dtos.Visitor;

public class GeneralStatsDto
{
    public long TotalPageViews { get; set; }
    public long TotalVisitors { get; set; }
    public float PageViewsPerVisit { get; set; }
    public VisitorCountForChartDto VisitPerDay { get; set; } = new();
}




