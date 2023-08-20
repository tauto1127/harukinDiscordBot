// See https://aka.ms/new-console-template for more information

public class Program
{
    public static Task Main(string[] args) 
        => new Program().MainAsync();

    public async Task MainAsync()
    {
        tokidoki();
        for(int i = 0; i < 100; i++)
        {
            Console.WriteLine("iueoi");
            await Task.Delay(10000);
            Console.WriteLine($"あいうえお {i}ばんめ");
        }

        Task.Delay(-1);
    }

    public async Task tokidoki()
    {
        for (int i = 0; i < 100; i++)
        {
            await Task.Delay(5000);
            Console.WriteLine($"かきくけここここ: {i}ばんめ");
        }
    }
}