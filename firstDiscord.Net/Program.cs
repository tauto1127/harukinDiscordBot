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
        _appJson = await AppJson.GetJson("app.json");
        Console.WriteLine("ロード完了");
        _client = new DiscordSocketClient();

        _client.Log += Log;
        //  You can assign your bot token to a string, and pass that in to connect.
        //  This is, however, insecure, particularly if you plan to have your code hosted in a public repository.
        var token = _appJson.Token;

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
    public string Token { get; set; }

    public static async Task<AppJson> GetJson(string fileName)
    {
        string jsonString = "";
        using (StreamReader sr = new StreamReader(new FileStream("app.json", FileMode.OpenOrCreate)))
        {
            // Read and display lines from the file until the end of
            // the file is reached.
            while (sr.Peek() > 0)
            {
                jsonString += sr.ReadLine();
            }
        }
        //string jsonString = r.ReadToEnd();
        Console.WriteLine("1");
        AppJson m = JsonConvert.DeserializeObject<AppJson>(jsonString);
        return m;
    }

}