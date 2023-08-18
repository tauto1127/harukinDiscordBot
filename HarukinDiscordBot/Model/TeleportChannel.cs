namespace firstDiscord.Net.Model;

public class TeleportChannel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Channel { get; set; }
    public string Type { get; set; }
    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }

    public TeleportChannel(string name, string description, int channel, string type)
    {
        this.Name = name;
        this.Description = description;
        this.Channel = channel;
        this.Type = type;
        this.Created = DateTime.Now;
        this.Modified = DateTime.Now;
    }

    public TeleportChannel()
    {
        
    }
}

enum PipeType
{
    なし,
    溶岩,
    水,
    金オイル,
    オイル,
    重油,
}