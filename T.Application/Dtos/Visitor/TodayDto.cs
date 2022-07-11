namespace T.Application.Dtos.Visitor;

public class TodayDto
{
    public long PageViews { get; set; }
    public long Visitors { get; set; }
    public float ViewsPerVisitors { get; set; }
    public VisitorCountForChartDto VisitCount { get; set; } = new();
}
