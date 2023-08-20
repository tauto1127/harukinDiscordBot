using System.Diagnostics;
using System.Net.Sockets;
using Discord.WebSocket;

namespace firstDiscord.Net;

public class ServerCommands
{
    private static Process ServerProcess;
    public static async Task ServerCommandsHandler(SocketSlashCommand command)
    {
        switch (command.Data.Options.First().Name)
        {
            case "start":
                await StartServerCommand(command);
                break;
            case "stop":
                await StopServerCommand(command);
                break;
        }
    }

    private static async Task StartServerCommand(SocketSlashCommand command)
    {
        if (ServerProcess == null)
        {
           ServerProcess = Process.Start(initializeServerProcess());
           command.RespondAsync("started");
        }
        else
        {
            if (!ServerProcess.HasExited)
            {
                await command.RespondAsync("すでに起動しています");
            }
        }
    }

    static ProcessStartInfo initializeServerProcess()
    {
        ProcessStartInfo psInfo = new ProcessStartInfo();
        psInfo.FileName = "dotnet"; //コマンド
        psInfo.Arguments = "run"; //引数
        psInfo.CreateNoWindow = true; // コンソール・ウィンドウを開かない
        psInfo.UseShellExecute = false; // シェル機能を使用しない
        psInfo.RedirectStandardOutput = true; // 標準出力をリダイレクト
        psInfo.WorkingDirectory = "/home/takuto1127/Rider/harukinDiscordBot/TestConsoleAppForServerCommands";
        return psInfo;
    }

    private static async Task StopServerCommand(SocketSlashCommand command)
    {
        Console.WriteLine(await ServerProcess.StandardOutput.ReadLineAsync());
        command.RespondAsync("end");
    }

    private static async Task aaa()
    {
        Console.WriteLine(ServerProcess.StandardOutput.ReadLine());
    }
}