using Discord.WebSocket;

namespace firstDiscord.Net;

public class CommandDataAnalyzer
{
    /// <summary>
    /// SocketSlashCommandから引数を読み込みます
    /// </summary>
    /// <param name="command"></param>
    /// <returns>Dictionary ArgName, ArgValue</returns>
    public static Dictionary<string, string> GetArgDictionary(SocketSlashCommand command)
    {
        var value = command.Data.Options.First().Options.ToList();
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        
        foreach (var VARIABLE in value)
        {
            dictionary.Add(VARIABLE.Name, VARIABLE.Value.ToString());
        }

        return dictionary;
    }
}