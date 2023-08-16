// See https://aka.ms/new-console-template for more information

//Console.WriteLine("Hello, World!");

using System.Net.Sockets;
using Discord;
using Discord.Net;
using Discord.WebSocket;
using Newtonsoft.Json;


public class Program
{
    private DiscordSocketClient _client;
    public static Task Main(string[] args) 
        => new Program().MainAsync();

    public async Task MainAsync()
    {
        _client = new DiscordSocketClient();

        _client.Log += Log;
        //  You can assign your bot token to a string, and pass that in to connect.
        //  This is, however, insecure, particularly if you plan to have your code hosted in a public repository.
        var token = "MTA4OTM1OTM3NTIxNjQxMDcxNA.Gcz6d5.f6jnl-vXK8oQ127Ti0Hk0Tj06x79JFJhIaC0Co";

        // Some alternative options would be to keep your token in an Environment Variable or a standalone file.
        // var token = Environment.GetEnvironmentVariable("NameOfYourEnvironmentVariable");
        // var token = File.ReadAllText("token.txt");
        // var token = JsonConvert.DeserializeObject<AConfigurationClass>(File.ReadAllText("config.json")).Token;

        //_client.Ready += firstSlashCommand;

        await _client.LoginAsync(TokenType.Bot, token);
        await _client.StartAsync();
        await Task.Delay(50000);
        SocketGuild guild = _client.GetGuild(1089360703120490618);
        Console.WriteLine(_client.Guilds.Count);
        // Block this task until the program is closed.
        await Task.Delay(-1); 
    }

    private Task Log(LogMessage msg)
    {
        Console.WriteLine(msg.ToString());
        return Task.CompletedTask;
    }

    public async Task firstSlashCommand()
    {

        var guild = _client.GetGuild(10893607031204906180);
        SlashCommandBuilder slashCommandBuilder = new SlashCommandBuilder();
        slashCommandBuilder.WithDescription("これは初めて作ったslashcommand。\nこれを実行すると、botが挨拶してくれます。");
        slashCommandBuilder.WithName("sayhello");
        Console.WriteLine(guild.Name);
        try
        {
            await guild.CreateApplicationCommandAsync(slashCommandBuilder.Build());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}