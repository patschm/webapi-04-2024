using Microsoft.AspNetCore.SignalR;

namespace DuplexCommunication.Hubs;

public class ChatHub : Hub
{
    public async Task Join(string user, string channel)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, channel);
        await Clients.Group(channel).SendAsync("Join", user, channel);
    }

    public async Task SendMessage(string user, string channel, string msg)
    {
        await Clients.Group(channel).SendAsync("Message", user, msg);
    }
}
