namespace firstDiscord.Net.Model;

public class WayPoint
{
    public int WayPointId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }
    public int WayPointCategoryId { get; set; }
    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }
}
