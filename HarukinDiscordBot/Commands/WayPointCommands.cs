using Discord.WebSocket;
using firstDiscord.Net.Data;
using Newtonsoft.Json.Linq;

namespace firstDiscord.Net;

public class WayPointCommands
{
    private readonly AppDbContext _context = new AppDbContext();

    public async static Task WayPointCommandHandler(SocketSlashCommand command)
    {
        var fieldName = command.Data.Options.First().Name;
        switch (fieldName)
        {
            case "addwaypoint":
                await AddWayPoint(command);
                break;
        }
    }
    
    private async static Task AddWayPoint(SocketSlashCommand command)
    {
        
        var fieldName = command.Data.Options.First().Name;
        var getOrSet = command.Data.Options.First().Options.First().Name;
        var value = command.Data.Options.First().Options.ToList();

        command.RespondAsync($"最初の引数は：{value[0].Value}次の引数は：{value[1].Value}");
    }
}