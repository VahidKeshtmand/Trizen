namespace T.Application.Dtos.Visitor;

public class ResultTodayReportDto
{
    public GeneralStatsDto GeneralStats { get; set; } = new();
    public TodayDto Today { get; set; } = new();
    public List<BrowserVisitCountDto> BrowserVisitCount { get; set; } = new();
}
