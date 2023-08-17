using Discord.WebSocket;
using firstDiscord.Net.Data;

namespace firstDiscord.Net;

public class WayPointCommands
{
    private readonly AppDbContext _context = new AppDbContext();

    public async static Task WayPointCommandHandler(SocketSlashCommand command)
    {
        var fieldName = command.Data.Options.First().Name;
    }
    
    private async static Task AddWayPoint(SocketSlashCommand command)
    {
        var fieldName = command.Data.Options.First().Name;


        switch (fieldName)
        {
        }
    }
}