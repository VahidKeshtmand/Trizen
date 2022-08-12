using Microsoft.AspNetCore.Mvc.Filters;
using T.Application.Dtos.Visitor;
using T.Application.Services.Visitor;
using UAParser;

namespace T.Website.Endpoint.Utilities.Filters;

public class SaveVisitorInfoFilter : IActionFilter
{
    private readonly IVisitorService _visitorService;

    public SaveVisitorInfoFilter(IVisitorService visitorService)
    {
        _visitorService = visitorService;
    }

    public void OnActionExecuting(ActionExecutingContext context) { }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        var ip = context.HttpContext.Request.HttpContext.Connection.RemoteIpAddress!.ToString();
        var actionName = ((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor)
            .ActionName;
        var controllerName = ((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor)
            .ControllerName;

        var userAgent = context.HttpContext.Request.Headers["User-Agent"];
        var uaParser = Parser.GetDefault();
        var clientInfo = uaParser.Parse(userAgent);
        var referer = context.HttpContext.Request.Headers["Referer"].ToString();
        var currentUrl = context.HttpContext.Request.Path;
        var request = context.HttpContext.Request;
        var visitorId = context.HttpContext.Request.Cookies["VisitorId"];
        if (visitorId == null)
        {
            visitorId = Guid.NewGuid().ToString();
            context.HttpContext.Response.Cookies.Append("VisitorId", visitorId, new CookieOptions
            {
                Path = "/",
                HttpOnly = true,
                Expires = DateTime.Now.AddDays(30)
            });
        }

        _visitorService.SaveVisitorInformation(new VisitorDto
        {
            Browser = new VisitorVersionDto
            {
                Family = clientInfo.UA.Family,
                Version = $"{clientInfo.UA.Major}.{clientInfo.UA.Minor}.{clientInfo.UA.Patch}"
            },
            OperatingSystem = new VisitorVersionDto
            {
                Family = clientInfo.OS.Family,
                Version = $"{clientInfo.OS.Major}.{clientInfo.OS.Minor}.{clientInfo.OS.Patch}"
            },
            Device = new VisitorDeviceDto
            {
                Brand = clientInfo.Device.Brand,
                Family = clientInfo.Device.Family,
                IsSpider = clientInfo.Device.IsSpider,
                Model = clientInfo.Device.Model
            },
            CurrentLink = currentUrl,
            Ip = ip,
            Method = request.Method,
            ReferrerLink = referer,
            PhysicalPath = $"{controllerName}/{actionName}",
            Protocol = request.Protocol,
            VisitorId = visitorId
        });
    }


}
