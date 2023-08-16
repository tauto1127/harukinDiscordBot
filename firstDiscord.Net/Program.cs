// See https://aka.ms/new-console-template for more information

//Console.WriteLine("Hello, World!");

using System.Net.Sockets;
using System.Reflection;
using System.Text.Json.Serialization;
using Discord;
using Discord.Net;
using Discord.WebSocket;
using Newtonsoft.Json;


public class Program
{
    private DiscordSocketClient _client;
    private SocketGuild _guild;
    private AppJson _appJson;
    
    [JsonPropertyName("token")] public string token { get; }
    public static Task Main(string[] args) 
        => new Program().MainAsync();

    public async Task MainAsync()
    {
        _appJson = AppJson.GetJson("token");
        Console.WriteLine("ロード完了");
        _client = new DiscordSocketClient();

        _client.Log += Log;
        //  You can assign your bot token to a string, and pass that in to connect.
        //  This is, however, insecure, particularly if you plan to have your code hosted in a public repository.
        var token = _appJson.token;

        // Some alternative options would be to keep your token in an Environment Variable or a standalone file.
        // var token = Environment.GetEnvironmentVariable("NameOfYourEnvironmentVariable");
        // var token = File.ReadAllText("token.txt");
        // var token = JsonConvert.DeserializeObject<AConfigurationClass>(File.ReadAllText("config.json")).Token;


        await _client.LoginAsync(TokenType.Bot, token);
        await _client.StartAsync();
        await Task.Delay(20000);//20秒待機
        Console.WriteLine("待機完了");
        _guild = _client.GetGuild(1089360703120490618);
        await firstSlashCommand();
        await Task.Delay(-1); 
    }

    private Task Log(LogMessage msg)
    {
        Console.WriteLine(msg.ToString());
        return Task.CompletedTask;
    }

    public async Task firstSlashCommand()
    {

        SlashCommandBuilder slashCommandBuilder = new SlashCommandBuilder();
        slashCommandBuilder.WithDescription("これは初めて作ったslashcommand。\nこれを実行すると、botが挨拶してくれます。");
        slashCommandBuilder.WithName("sayhello");
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

class AppJson
{
    public string token { get; set; }

    public static AppJson GetJson(string fileName)
    {
        string jsonString = "";
        try
        {
            // ファイルパスとファイル名を指定してStreamReaderのインスタンスを作成
            using (var sr = new StreamReader(fileName))
            {
                jsonString += sr.ReadLine();
                //Console.WriteLine(sr.ReadToEnd());
            }
        }
        catch (IOException e)
        {
            Console.WriteLine("ファイルが読み取れませんでした:");
            Console.WriteLine(e.Message);
        }
        return new AppJson(){token = jsonString};
    }

}