// See https://aka.ms/new-console-template for more information

using Discord;
using Discord.WebSocket;
using firstDiscord.Net;

public class Program
{
    private const bool isInitializeSlashCommand = true;
    
    private DiscordSocketClient _client;
    private SocketGuild _guild;
    private AppJson _appJson;
    private string _token;
    public static Task Main(string[] args) 
        => new Program().MainAsync();

    public async Task MainAsync()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("tokenファイルの追加を忘れない\nコマンドからじゃないとファイル読み取れないかも");
        Console.ForegroundColor = ConsoleColor.White;
        
        _appJson = AppJson.GetJson("token");
        Console.WriteLine("ロード完了");
        
        _client = new DiscordSocketClient();
        _client.Log += Log;
        _client.SlashCommandExecuted += SlashCommandHandler;
        
        _token = _appJson.token;
        
        await _client.LoginAsync(TokenType.Bot, _token);
        await _client.StartAsync();
        
        await Task.Delay(20000);//20秒待機
        Console.WriteLine("待機完了");
        _guild = _client.GetGuild(1089360703120490618);
        //スラッシュコマンドINITIALIZE
        SlashCommandInitializer _slashCommandInitializer = new SlashCommandInitializer(_guild);
        await _slashCommandInitializer.Initialize();
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
        }
    }    
    private Task Log(LogMessage msg)
    {
        Console.WriteLine(msg.ToString());
        return Task.CompletedTask;
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
