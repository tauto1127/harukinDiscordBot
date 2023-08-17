using Discord.WebSocket;

namespace firstDiscord.Net;

public class SettingCommands
{
    public static string FieldA { get; set; } = "test";
    public static int FieldB { get; set; } = 10;
    public static bool FieldC { get; set; } = true;

    public static async Task HandleSettingsCommand(SocketSlashCommand command)
    {
        // First lets extract our variables
        var fieldName = command.Data.Options.First().Name;
        var getOrSet = command.Data.Options.First().Options.First().Name;
        // Since there is no value on a get command, we use the ? operator because "Options" can be null.
        var value = command.Data.Options.First().Options.First().Options?.FirstOrDefault().Value;

        switch (fieldName)
        {
            case "field-a":
            {
                if(getOrSet == "get")
                {
                    await command.RespondAsync($"The value of `field-a` is `{FieldA}`");
                }
                else if (getOrSet == "set")
                {
                    FieldA = (string)value;
                    await command.RespondAsync($"`field-a` has been set to `{FieldA}`");
                }
            }
                break;
            case "field-b":
            {
                if (getOrSet == "get")
                {
                    await command.RespondAsync($"The value of `field-b` is `{FieldB}`");
                }
                else if (getOrSet == "set")
                {
                    FieldB = (int)value;
                    await command.RespondAsync($"`field-b` has been set to `{FieldB}`");
                }
            }
                break;
            case "field-c":
            {
                if (getOrSet == "get")
                {
                    await command.RespondAsync($"The value of `field-c` is `{FieldC}`");
                }
                else if (getOrSet == "set")
                {
                    FieldC = (bool)value;
                    await command.RespondAsync($"`field-c` has been set to `{FieldC}`");
                }
            }
                break;
        }
    }
}