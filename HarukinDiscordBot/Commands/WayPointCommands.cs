using Discord;
using Discord.WebSocket;
using firstDiscord.Net.Data;
using firstDiscord.Net.Model;
using Newtonsoft.Json.Linq;

namespace firstDiscord.Net;

public class WayPointCommands
{
    public async static Task WayPointCommandHandler(SocketSlashCommand command, AppDbContext _context)
    {
        var fieldName = command.Data.Options.First().Name;
        switch (fieldName)
        {
            case "addwaypoint":
                await AddWayPoint(command, _context);
                break;
        }
    }

    private async static Task AddWayPoint(SocketSlashCommand command, AppDbContext _context)
    {
        var fieldName = command.Data.Options.First().Name;
        var getOrSet = command.Data.Options.First().Options.First().Name;
        var value = command.Data.Options.First().Options.ToList();

        Dictionary<string, object> dictionary = new Dictionary<string, object>();
        foreach (var VARIABLE in value)
        {
            dictionary.Add(VARIABLE.Name, VARIABLE.Value);
        }

        foreach (var VARIABLE in dictionary)
        {
            Console.WriteLine($"{VARIABLE.Key}は：{VARIABLE.Value}");
        }

        WayPoint wayPoint;
        if (dictionary["description"] == null)
        {
            wayPoint = new WayPoint(
                dictionary["waypointname"].ToString(),
                dictionary["x"].ToString(),
                dictionary["y"].ToString(),
                dictionary["z"].ToString());
        }
        else
        {
            wayPoint = new WayPoint(
                dictionary["waypointname"].ToString(),
                dictionary["x"].ToString(),
                dictionary["y"].ToString(),
                dictionary["z"].ToString(),
                dictionary["description"].ToString());
        }


        //_context.WayPoints.Add(wayPoint);
        try
        {
            _context.WayPoints.Add(wayPoint);
            await _context.SaveChangesAsync();
            command.RespondAsync($"Added {wayPoint}");
            Console.WriteLine("try実行されてる？？ ");
        }
        catch (Exception e)
        {
            //command.RespondAsync("error occured");
            command.RespondAsync(e.ToString().Substring(0,2000));
            Console.Write("oh no!");
        }
    }
}