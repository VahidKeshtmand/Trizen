namespace T.Application.Dtos.Visitor;

public class VisitorDto
{
    public string Ip { get; set; } = string.Empty;
    public string CurrentLink { get; set; } = string.Empty;
    public string ReferrerLink { get; set; } = string.Empty;
    public string Method { get; set; } = string.Empty;
    public string Protocol { get; set; } = string.Empty;
    public string PhysicalPath { get; set; } = string.Empty;
    public string VisitorId { get; set; } = string.Empty;
    public VisitorVersionDto Browser { get; set; } = new();
    public VisitorVersionDto OperatingSystem { get; set; } = new();
    public VisitorDeviceDto Device { get; set; } = new();
}
