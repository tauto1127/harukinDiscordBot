namespace firstDiscord.Net.Model;

public class WayPoint
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Location Location { get; set; }
    public int WayPointCategoryId { get; set; }
    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }
}
