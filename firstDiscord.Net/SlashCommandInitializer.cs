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
        await SettingCommands();
        
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

    private async Task SettingCommands()
    {
         var slashCommandBuilder = new SlashCommandBuilder()
        .WithName("settings")
        .WithDescription("Changes some settings within the bot.")
        .AddOption(new SlashCommandOptionBuilder()
            .WithName("field-a")
            .WithDescription("Gets or sets the field A")
            .WithType(ApplicationCommandOptionType.SubCommandGroup)
            .AddOption(new SlashCommandOptionBuilder()
                .WithName("set")
                .WithDescription("Sets the field A")
                .WithType(ApplicationCommandOptionType.SubCommand)
                .AddOption("value", ApplicationCommandOptionType.String, "the value to set the field", isRequired: true)
            ).AddOption(new SlashCommandOptionBuilder()
                .WithName("get")
                .WithDescription("Gets the value of field A.")
                .WithType(ApplicationCommandOptionType.SubCommand)
            )
        ).AddOption(new SlashCommandOptionBuilder()
            .WithName("field-b")
            .WithDescription("Gets or sets the field B")
            .WithType(ApplicationCommandOptionType.SubCommandGroup)
            .AddOption(new SlashCommandOptionBuilder()
                .WithName("set")
                .WithDescription("Sets the field B")
                .WithType(ApplicationCommandOptionType.SubCommand)
                .AddOption("value", ApplicationCommandOptionType.Integer, "the value to set the fie to.", isRequired: true)
            ).AddOption(new SlashCommandOptionBuilder()
                .WithName("get")
                .WithDescription("Gets the value of field B.")
                .WithType(ApplicationCommandOptionType.SubCommand)
            )
        ).AddOption(new SlashCommandOptionBuilder()
            .WithName("field-c")
            .WithDescription("Gets or sets the field C")
            .WithType(ApplicationCommandOptionType.SubCommandGroup)
            .AddOption(new SlashCommandOptionBuilder()
                .WithName("set")
                .WithDescription("Sets the field C")
                .WithType(ApplicationCommandOptionType.SubCommand)
                .AddOption("value", ApplicationCommandOptionType.Boolean, "the value to set the fie to.", isRequired: true)
            ).AddOption(new SlashCommandOptionBuilder()
                .WithName("get")
                .WithDescription("Gets the value of field C.")
                .WithType(ApplicationCommandOptionType.SubCommand)
            )
        );
        try
        {
            await _guild.CreateApplicationCommandAsync(slashCommandBuilder.Build());
        }
        catch (Exception e)
        {
            Console.WriteLine($"oh no!{e}");
        }

    }

}