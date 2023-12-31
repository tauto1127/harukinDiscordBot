using System.Diagnostics;
using Discord.WebSocket;
using firstDiscord.Net.Data;
using firstDiscord.Net.Model;
using Microsoft.EntityFrameworkCore;

namespace firstDiscord.Net;

public class WebBookmarkCommands
{
    public async static Task WebBookmarkCommandHandler(SocketSlashCommand command, AppDbContext _context)
    {
        switch (command.Data.Options.First().Name)
        {
            case "addwebbookmark":
                AddWebbookMark(command, _context);
                break;
            case "showwebbookmarks":
                ShowWebbookMark(command, _context);
                break;
            case "deletewebbookmark":
                DeleteWebbookMark(command, _context);
                break;
        }
    }

    private async static Task AddWebbookMark(SocketSlashCommand command, AppDbContext _context)
    {
        var dictionary =  CommandDataAnalyzer.GetArgDictionary(command);
        WebBookmark webBookmark;
        if (dictionary.ContainsKey("description"))
        {
            webBookmark = new WebBookmark(dictionary["webbookmarkname"], dictionary["url"], dictionary["description"]);
        }
        else
        {
            webBookmark = new WebBookmark(dictionary["webbookmarkname"], dictionary["url"]);
        }

        _context.WebBookmarks.Add(webBookmark);
        try
        {
            _context.SaveChangesAsync();
            command.RespondAsync($"added {webBookmark}");
        }
        catch (DbUpdateException e)
        {
            command.RespondAsync("データベース更新に失敗しました");
        }
    }

    private async static Task ShowWebbookMark(SocketSlashCommand command, AppDbContext _context)
    {
        string output = "";
        foreach (var VARIABLE in _context.WebBookmarks)
        {
            output += $"{VARIABLE.WebBookmarkId}：[{VARIABLE.Name}]({VARIABLE.URL})\n";
        }

        command.RespondAsync(output);
    }

    private async static Task DeleteWebbookMark(SocketSlashCommand command, AppDbContext _context)
    {
        Console.WriteLine("aieuo");
        var dictionary = CommandDataAnalyzer.GetArgDictionary(command);
        WebBookmark webBookmark;
        if ((webBookmark = await _context.WebBookmarks.FindAsync(Int32.Parse(dictionary["id"]))) == null)
        {
            command.RespondAsync("そのブックマークは見つかりませんでした");
        }
        else
        {
            try
            {
                _context.WebBookmarks.Remove(webBookmark);
                await _context.SaveChangesAsync();
                command.RespondAsync($"deleted {webBookmark.Name}");
            }
            catch (DbUpdateException e)
            {
                command.RespondAsync("データベースの接続失敗");
            }
            catch (Exception e)
            {
                command.RespondAsync(e.ToString().Substring(0, 2000));
            }
        }
    }
}
