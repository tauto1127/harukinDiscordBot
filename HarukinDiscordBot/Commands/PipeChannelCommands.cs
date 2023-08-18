using System.Data.Common;
using System.Runtime.InteropServices;
using Discord.WebSocket;
using firstDiscord.Net.Data;
using firstDiscord.Net.Model;

namespace firstDiscord.Net;

public class PipeChannelCommands
{
    public static async Task PipeChannelCommandHandler(SocketSlashCommand command, AppDbContext _context)
    {
        switch (command.Data.Options.First().Name)
        {
            case "add":
                await AddPipeChannel(command, _context);
                break;
        }
    }

    private async static Task AddPipeChannel(SocketSlashCommand command, AppDbContext _context)
    {
        var dictionary = CommandDataAnalyzer.GetArgDictionary(command);
        string description;
        string type;
        TeleportChannel channel;
        if (dictionary.ContainsKey("description")) description = dictionary["description"];
        else description = "";
        if (dictionary.ContainsKey("type")) type = dictionary["type"];
        else type = PipeType.なし.ToString();
        channel = new TeleportChannel(dictionary["name"], description, Int32.Parse(dictionary["num"]), type);
        try
        {
            _context.Add(channel);
            await _context.SaveChangesAsync();
            command.RespondAsync($"Added {channel.Name}");
        }
        catch (DbException exception)
        {
            command.RespondAsync("データベースの接続に失敗しました");
        }
        catch (Exception e)
        {
            command.RespondAsync(e.ToString().Substring(0, 2000));
        }
    }
}