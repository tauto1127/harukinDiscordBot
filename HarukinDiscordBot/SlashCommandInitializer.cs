using System.Reflection.Metadata;
using Discord;
using Discord.WebSocket;
using firstDiscord.Net.Data;

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
        Console.WriteLine("スラッシュコマンドのInitialize開始");
        await FirstSlashCommand();
        await ListRollCommand();
        await SettingCommands();
        await FeedbackCommand();
        await TeleportPipeCommands();
        await WayPointCommands();
        await WebBookmarkCommands();
        await PipeChannelCommands();
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
                    .AddOption("value", ApplicationCommandOptionType.String, "the value to set the field",
                        isRequired: true)
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
                    .AddOption("value", ApplicationCommandOptionType.Integer, "the value to set the fie to.",
                        isRequired: true)
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
                    .AddOption("value", ApplicationCommandOptionType.Boolean, "the value to set the fie to.",
                        isRequired: true)
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

    private async Task FeedbackCommand()
    {
        SlashCommandBuilder slashCommandBuilder = new SlashCommandBuilder()
            .WithName("feedback")
            .WithDescription("Tell us how much you are enjoying this bot!")
            .AddOption(new SlashCommandOptionBuilder()
                .WithName("rating")
                .WithDescription("The rating your willing to give our bot")
                .WithRequired(true)
                .AddChoice("Terrible", 1)
                .AddChoice("Meh", 2)
                .AddChoice("Good", 3)
                .AddChoice("Good", 3)
                .AddChoice("Lovely", 4)
                .AddChoice("Excellent!", 5)
                .WithType(ApplicationCommandOptionType.Integer)
            );
        try
        {
            await _guild.CreateApplicationCommandAsync(slashCommandBuilder.Build());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    private async Task TeleportPipeCommands()
    {
        SlashCommandBuilder slashCommandBuilder = new SlashCommandBuilder()
            .WithName("teleportpipe")
            .WithDescription("テレポートパイプチャンネル管理用")
            .AddOption(new SlashCommandOptionBuilder()
                .WithName("addchannel")
                .WithDescription("テレポートパイプチャンネルの追加")
                .WithType(ApplicationCommandOptionType.SubCommand)
                .AddOption("name", ApplicationCommandOptionType.String, "チャンネルの名前")
            );
            
        try
        {
            _guild.CreateApplicationCommandAsync(slashCommandBuilder.Build());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    private async Task WayPointCommands()
    {
        SlashCommandBuilder slashCommandBuilder = new SlashCommandBuilder()
            .WithName("waypoint")
            .WithDescription("ウェイポイント管理用")
            .AddOption(new SlashCommandOptionBuilder()
                .WithName("addwaypoint")
                .WithDescription("ウェイポイントを追加")
                .WithType(ApplicationCommandOptionType.SubCommand)
                .AddOption("waypointname", ApplicationCommandOptionType.String, "ウェイポイントの名前", isRequired:true)
                .AddOption("x", ApplicationCommandOptionType.Number, "ウェイポイントのx座標", isRequired:true)
                .AddOption("y", ApplicationCommandOptionType.Number, "ウェイポイントのy座標", isRequired:true)
                .AddOption("z", ApplicationCommandOptionType.Number, "ウェイポイントのz座標", isRequired:true)
                .AddOption("description", ApplicationCommandOptionType.String, "ウェイポイントの説明(not required)", isRequired:false)
            )
            .AddOption(new SlashCommandOptionBuilder()
                .WithName("showwaypoint")
                .WithDescription("ウェイポイント一覧を表示")
                .WithType(ApplicationCommandOptionType.SubCommand)
            )
            .AddOption(new SlashCommandOptionBuilder()
                .WithName("deletewaypoint")
                .WithDescription("ウェイポイントを削除")
                .WithType(ApplicationCommandOptionType.SubCommand)
                .AddOption("id", ApplicationCommandOptionType.Integer, "ウェイポイントID", isRequired:true)
            )
            ;
        try
        {
            _guild.CreateApplicationCommandAsync(slashCommandBuilder.Build());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    private async Task WebBookmarkCommands()
    {
        SlashCommandBuilder slashCommandBuilder = new SlashCommandBuilder()
            .WithName("webbookmark")
            .WithDescription("ウェブブックマーク管理用")
            .AddOption(new SlashCommandOptionBuilder()
                .WithName("addwebbookmark")
                .WithDescription("ウェブブックマークを追加")
                .WithType(ApplicationCommandOptionType.SubCommand)
                .AddOption("webbookmarkname", ApplicationCommandOptionType.String, "ブックマークの名前", isRequired: true)
                .AddOption("url", ApplicationCommandOptionType.String, "URL", isRequired: true)
                .AddOption("description", ApplicationCommandOptionType.String, "ブックマークの説明")
            )
            .AddOption(new SlashCommandOptionBuilder()
                .WithName("showwebbookmarks")
                .WithDescription("ウェブブックマーク一覧を表示")
                .WithType(ApplicationCommandOptionType.SubCommand)
            )
            .AddOption(new SlashCommandOptionBuilder()
                .WithName("deletewebbookmark")
                .WithDescription("ウェブブックマークを削除")
                .WithType(ApplicationCommandOptionType.SubCommand)
                .AddOption("id", ApplicationCommandOptionType.Integer, "ID", isRequired: true)
            )
            ;
        try
        {
            _guild.CreateApplicationCommandAsync(slashCommandBuilder.Build());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    private async Task PipeChannelCommands()
    {
        SlashCommandBuilder slashCommandBuilder = new SlashCommandBuilder()
            .WithName("pipe")
            .WithDescription("パイプチャンネル管理用")
            .AddOption(new SlashCommandOptionBuilder()
                .WithName("add")
                .WithDescription("チャンネル追加")
                .WithType(ApplicationCommandOptionType.SubCommand)
                .AddOption("name", ApplicationCommandOptionType.String, "名前", isRequired: true)
                .AddOption("num", ApplicationCommandOptionType.Number, "番号", isRequired: true)
                .AddOption("description", ApplicationCommandOptionType.String, "説明")
                .AddOption("type", ApplicationCommandOptionType.String, "(液体)種類", 
                    choices:new[]
                    {
                        new ApplicationCommandOptionChoiceProperties(){Name = "lava", Value = "溶岩"},
                        new ApplicationCommandOptionChoiceProperties(){Name = "water", Value = "水"},
                        new ApplicationCommandOptionChoiceProperties(){Name = "goldoil", Value = "金オイル"},
                        new ApplicationCommandOptionChoiceProperties(){Name = "oil", Value = "オイル"},
                        new ApplicationCommandOptionChoiceProperties(){Name = "heavy oil", Value = "重油"}
                    })
            );
        try
        {
            _guild.CreateApplicationCommandAsync(slashCommandBuilder.Build());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}
    