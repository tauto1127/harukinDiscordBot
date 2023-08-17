using System.Reflection.Metadata;
using Discord;
using Discord.WebSocket;

namespace firstDiscord.Net;

public class SlashCommandInitializer
{
    private SocketGuild _guild;
    public SlashCommandInitializer(SocketGuild guild)
    {
        this._guild = guild;
    }

    public async Task Initialize()
    {
        await FirstSlashCommand();
        await ListRollCommand();
        
        Console.WriteLine("スラッシュコマンドInitialize完了");
    }
    private async Task FirstSlashCommand()
    {
        SlashCommandBuilder slashCommandBuilder = new SlashCommandBuilder()
            .WithDescription("これは初めて作ったslashcommand。\nこれを実行すると、botが挨拶してくれます。")
            .WithName("sayhello");
        try
        {
            await _guild.CreateApplicationCommandAsync(slashCommandBuilder.Build());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    private async Task ListRollCommand()
    {
        SlashCommandBuilder slashCommandBuilder = new SlashCommandBuilder()
            .WithName("list-roles")
            .WithDescription("Lists all roles of a user.")
            .AddOption("user", ApplicationCommandOptionType.User,
                "The users whos roles you want to be listed", isRequired: true);
        try
        {
            await _guild.CreateApplicationCommandAsync(slashCommandBuilder.Build());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

}