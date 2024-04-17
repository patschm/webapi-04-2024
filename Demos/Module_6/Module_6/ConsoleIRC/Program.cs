using Microsoft.AspNetCore.SignalR.Client;

namespace ConsoleIRC;

internal class Program
{
    static HubConnection connection;
    static async Task Main(string[] args)
    {
        Initialize();
        string? nick = Register();
        await connection.StartAsync();
        string? channel = await Join(nick!);
        connection.On<string, string>("Join", (nick, channel) => {
            Console.WriteLine($"## [{nick}] has joined channel {channel}");
        });

        connection.On<string, string>("Message", (nick, message) => {
            Console.WriteLine($"{nick}> {message}");
        });

        do
        {
            await connection.InvokeAsync("SendMessage", nick, channel, Console.ReadLine());
        }
        while (true);

        Console.ReadLine();
    }

    private static async Task<string?> Join(string nick)
    {
        Console.WriteLine("Geef een channelnaam");
        var channel = Console.ReadLine();
        await connection.InvokeAsync("Join", nick, channel);
        return channel;
    }

    private static string? Register()
    {
        Console.WriteLine("Geef uw nick");
        return Console.ReadLine();
    }

    private static void Initialize()
    {
        connection = new HubConnectionBuilder()
              .WithUrl("https://ps-ircii.azurewebsites.net/irc")
              .Build();

        connection.Closed += async (error) =>
        {
            await Task.Delay(new Random().Next(0, 5) * 1000);
            await connection.StartAsync();
        };
    }
}
