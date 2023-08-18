// See https://aka.ms/new-console-template for more information

using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using Discord;
using Discord.WebSocket;
using firstDiscord.Net;
using firstDiscord.Net.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

public class Program
{
    private const bool isInitializeSlashCommand = true;
    
    private DiscordSocketClient _client;
    private SocketGuild _guild;
    private AppJson _appJson;
    private string _token;
    public static Task Main(string[] args) 
        => new Program().MainAsync();

    private readonly AppDbContext _context = new AppDbContext();
    public async Task MainAsync()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("tokenファイルの追加を忘れない\nコマンドからじゃないとファイル読み取れないかも");
        Console.ForegroundColor = ConsoleColor.White;
        
        _appJson = AppJson.GetJson("App.json");
        _token = _appJson.token;
        Console.WriteLine("ロード完了");
        
        _client = new DiscordSocketClient();
        _client.Log += Log;
        _client.SlashCommandExecuted += SlashCommandHandler;
        
        _client.Connected += async () =>
        {
            Console.WriteLine("Connected!");
            _guild = _client.GetGuild(1089360703120490618);
            if (_appJson.isInit)
            {
                SlashCommandInitializer _slashCommandInitializer = new SlashCommandInitializer(_guild);
                await _slashCommandInitializer.Initialize();
            }else{WriteLineColor("Initializeしません", ConsoleColor.Yellow);}
        };
        
        await _client.LoginAsync(TokenType.Bot, _token);
        await _client.StartAsync();
        
        await Task.Delay(-1); 
    }
    private async Task SlashCommandHandler(SocketSlashCommand command)
    {
        switch (command.Data.Name)
        {
            case "sayhello":
                await command.RespondAsync($"{command.User.Username}さんこんにちは");
                break;
            case "list-roles" :
                await Commands.HandleListRoleCommand(command);
                break;
            case "settings" :
                await SettingCommands.HandleSettingsCommand(command);
                break;
            case "feedback" :
                await Commands.HandleFeedbackCommand(command);
                break;
            case "waypoint":
                await WayPointCommands.WayPointCommandHandler(command, _context);
                break;
            case "webbookmark":
                await WebBookmarkCommands.WebBookmarkCommandHandler(command, _context);
                break;
        }
    }    
    private Task Log(LogMessage msg)
    {
        Console.WriteLine(msg.ToString());
        return Task.CompletedTask;
    }

    public static JsonSerializerOptions GetJsonOption()
    {
        var options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            WriteIndented = true,
        };
        return options;
    }

    public static void WriteLineColor(string label, ConsoleColor color)
    {
        ConsoleColor origin = Console.BackgroundColor;
        Console.ForegroundColor = color;
        Console.WriteLine(label);
        Console.ForegroundColor = origin;
    }
}
class AppJson
{
    public string token { get; set; }
    public bool isInit { get; set; }
    public static AppJson GetJson(string fileName)
    {
        string jsonString = "";
        try
        {
            using (var sr = new StreamReader(fileName))
            {
                jsonString = sr.ReadToEnd();
            }
        }
        catch (IOException e)
        {
            Console.WriteLine("ファイルが読み取れませんでした:");
            Console.WriteLine(e.Message);
        }
        Dictionary<string, string> dictionary = 
            JsonSerializer.Deserialize<Dictionary<string, string>>(jsonString, Program.GetJsonOption());
        
        return new AppJson()
        {
            token = dictionary["token"], isInit = Boolean.Parse(dictionary["initialize"])
        };
    }
}