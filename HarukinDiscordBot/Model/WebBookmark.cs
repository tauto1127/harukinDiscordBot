namespace firstDiscord.Net.Model;

public class WebBookmark
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string URL { get; set; }
    public string? Description { get; set; }
    public int WebCategoryId { get; set; }
    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }
}
