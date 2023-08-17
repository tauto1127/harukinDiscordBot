namespace firstDiscord.Net.Model;

public class TeleportChannel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Channel { get; set; }
    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }
    public IList<WayPoint> Inputs { get; set; }
}
