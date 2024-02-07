using System.Diagnostics;
using CQRSExcise.Web.CommandMsg;
using Microsoft.AspNetCore.Mvc;
using CQRSExcise.Web.Models;
using MediatR;

namespace CQRSExcise.Web.Controllers;
public class HomeController : Controller
{
    private readonly IMediator _mediator;

    public HomeController(IMediator mediator)
    {
        this._mediator = mediator;
    }

    public async Task<IActionResult> Index()
    {
        await _mediator.Publish(new SomeEvent("Hello World"));
        return View();
    }

    public async Task<IActionResult> Privacy(string uname,string addr)
    {
        var result = await _mediator.Send(new UserAddMsg() { UserName = uname, UserAddr = addr });
        ViewBag.Result = result > 0 ? "Success" : "Fail";
        return View();
    }
    
    public async Task<IActionResult> About()
    {
        // example of request/response messages
        var result = await _mediator.Send(new Ping());
        ViewData["Message"] = $"Your application description page: {result}";

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

public class SomeEvent : INotification {
    public SomeEvent(string message)
    {
        Message = message;
    }
 
    public string Message { get; }
}
 
public class Handler1 : INotificationHandler<SomeEvent>
{
    private readonly ILogger<Handler1> _logger;
 
    public Handler1(ILogger<Handler1> logger)
    {
        _logger = logger;
    }
    public async Task  Handle(SomeEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogWarning($"Handled: {notification.Message}");
    }
}
public class Handler2 : INotificationHandler<SomeEvent>
{
    private readonly ILogger<Handler2> _logger;
 
    public Handler2(ILogger<Handler2> logger)
    {
        _logger = logger;
    }
    public async Task Handle(SomeEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogWarning($"Handled: {notification.Message}");
    }
}

public class Ping:IRequest<string>{}

// optional to show what happens with multiple handlers
public class Ping0Handler : IRequestHandler<Ping, string>
{
    public async Task<string> Handle(Ping request, CancellationToken cancellationToken)
    {
        return "Pong-0";
    }
}
public class PingHandler : IRequestHandler<Ping, string>
{
    public async Task<string> Handle(Ping request, CancellationToken cancellationToken)
    {
        return "Pong";
    }
}
// optional to show what happens with multiple handlers
public class Ping2Handler : IRequestHandler<Ping, string>
{
    public async Task<string> Handle(Ping request, CancellationToken cancellationToken)
    {
        return "Pong2";
    }
}