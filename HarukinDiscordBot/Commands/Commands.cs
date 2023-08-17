using Discord;
using Discord.WebSocket;

namespace firstDiscord.Net;

public class Commands
{
    /// <summary>
    /// "ephemeral responce"なのでそのユーザーにしか見えないかつ
    /// 時間がたったらメッセージは消える
    /// </summary>
    /// <param name="command"></param>
    public static async Task HandleListRoleCommand(SocketSlashCommand command)
    {
        // We need to extract the user parameter from the command. since we only have one option and it's required, we can just use the first option.
        var guildUser = (SocketGuildUser)command.Data.Options.First().Value;

        // We remove the everyone role and select the mention of each role.
        var roleList = string.Join(",\n", guildUser.Roles.Where(x => !x.IsEveryone).Select(x => x.Mention));

        var embedBuiler = new EmbedBuilder()
            .WithAuthor(guildUser.ToString(), guildUser.GetAvatarUrl() ?? guildUser.GetDefaultAvatarUrl())
            .WithTitle("Roles")
            .WithDescription(roleList)
            .WithColor(Color.Green)
            .WithCurrentTimestamp();

        // Now, Let's respond with the embed.
        await command.RespondAsync(embed: embedBuiler.Build(), ephemeral: true);
    }

    public static async Task HandleFeedbackCommand(SocketSlashCommand command)
    {
        EmbedBuilder embedBuilder = new EmbedBuilder()
            .WithAuthor(command.User)
            .WithTitle("Feedback")
            .WithDescription($"Thanks for your feedback! You rated us {command.Data.Options.First().Value}/5")
            .WithColor(Color.Green)
            .WithCurrentTimestamp();
        await command.RespondAsync(embed: embedBuilder.Build());
    }
}