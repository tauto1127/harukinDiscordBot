using System.Diagnostics;
using System.Net.Sockets;
using Discord;
using Discord.WebSocket;

namespace firstDiscord.Net;

public class ServerCommands
{
    private static Process ServerProcess;
    public static async Task ServerCommandsHandler(SocketSlashCommand command, IMessageChannel messageChannel)
    {
        switch (command.Data.Options.First().Name)
        {
            case "start":
                await StartServerCommand(command, messageChannel);
                break;
            case "stop":
                await StopServerCommand(command);
                break;
        }
    }

    private static async Task StartServerCommand(SocketSlashCommand command, IMessageChannel messageChannel)
    {
        if (ServerProcess == null || ServerProcess.HasExited)
        {
           ServerProcess = Process.Start(initializeServerProcess());
           ServerProcess.Exited += ifProcessExited;
           command.RespondAsync("起動開始しました");
        }
        else
        {
            if (!ServerProcess.HasExited)
            {
                await command.RespondAsync("すでに起動しています");
            }
        }
    }

    public static void ifProcessExited(object? sender, EventArgs e)
    {
        Console.WriteLine($"イベント発火Existed {e.ToString()}");
        ServerProcess = null;
    }

    static ProcessStartInfo initializeServerProcess()
    {
        ProcessStartInfo psInfo = new ProcessStartInfo();
        psInfo.FileName = Program._appJson.processName; //コマンド
        psInfo.Arguments = Program._appJson.processArgs; //引数
        psInfo.CreateNoWindow = true; // コンソール・ウィンドウを開かない
        psInfo.UseShellExecute = false; // シェル機能を使用しない
        psInfo.RedirectStandardOutput = true; // 標準出力をリダイレクト
        psInfo.WorkingDirectory = Program._appJson.processWorkingDirectory;
        return psInfo;
    }

    private static async Task StopServerCommand(SocketSlashCommand command)
    {
        if (ServerProcess != null)
        {
            if (ServerProcess.HasExited)
            {
                command.RespondAsync($"すでに停止しています");
            }
            else
            {
                try
                {
                    ServerProcess.Kill();
                    command.RespondAsync("停止しました。");
                }
                catch (Exception e)
                {
                    command.RespondAsync(e.ToString().Substring(0, 2000));
                }
            }
        }
        else
        {
            command.RespondAsync("停止済(process null)");
        }
    }
}