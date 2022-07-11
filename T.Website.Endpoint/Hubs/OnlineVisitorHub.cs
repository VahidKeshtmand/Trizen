using Microsoft.AspNetCore.SignalR;
using T.Application.Services.Visitor;

namespace T.Website.Endpoint.Hubs;

public class OnlineVisitorHub : Hub
{
    private readonly IOnlineVisitorService _onlineVisitorService;

    public OnlineVisitorHub(IOnlineVisitorService onlineVisitorService)
    {
        _onlineVisitorService = onlineVisitorService;
    }

    public override Task OnConnectedAsync()
    {
        //Context.ConnectionId مربوط به Signalr است.
        var visitorId = Context.GetHttpContext()?.Request.Cookies["VisitorId"];
        _onlineVisitorService.ConnectUser(visitorId);
        var count = _onlineVisitorService.GetCount(visitorId);
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        var visitorId = Context.GetHttpContext()?.Request.Cookies["VisitorId"];
        _onlineVisitorService.DisConnectUser(visitorId);
        var count = _onlineVisitorService.GetCount(visitorId);
        return base.OnDisconnectedAsync(exception);
    }
}

