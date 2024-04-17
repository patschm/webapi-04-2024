using DuplexCommunication.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace DuplexCommunication.Controllers;

[ApiController]
[Route("admin")]
public class DataController : ControllerBase
{
    private readonly ILogger<DataController> _logger;
    private readonly IHubContext<ChatHub> _myhub;

    public DataController(ILogger<DataController> logger, IHubContext<ChatHub> myhub)
    {
        _logger = logger;
        _myhub = myhub;
    }

    [HttpGet("{text}")]
    public async Task<ActionResult> GetAsync(string text)
    {
        await _myhub.Clients.All.SendAsync("Message", "Admin", text);
        return Ok();
    }
}
