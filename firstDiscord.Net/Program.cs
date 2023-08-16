// See https://aka.ms/new-console-template for more information

//Console.WriteLine("Hello, World!");

using Discord;

public class Program
{
    public static Task Main(string[] args) 
        => new Program().MainAsync();

    public async Task MainAsync()
    {
        
    }

    private Task Log(LogMessage msg)
    {
        Console.WriteLine(msg.ToString());
        return Task.CompletedTask;
    }
}