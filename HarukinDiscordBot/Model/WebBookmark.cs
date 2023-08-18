namespace firstDiscord.Net.Model;

public class WebBookmark
{
    public int WebBookmarkId { get; set; }
    public string Name { get; set; }
    public string URL { get; set; }
    public string? Description { get; set; }
    public int WebCategoryId { get; set; }
    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }
    
    public WebBookmark(){}

    public WebBookmark(string name, string url)
    {
        this.Name = name;
        this.Created = DateTime.Now;
        this.Modified = DateTime.Now;
        if (getProtocol(url) == URLProtocol.none)
        {
            this.URL = "https://" + url;
        }
    }

    public WebBookmark(string name, string url, string description) : this(name, url)
    {
        this.Description = description;
    }

    private URLProtocol getProtocol(string url)
    {
        if (url.Contains("http://")) return URLProtocol.http;
        if (url.Contains("https://")) return URLProtocol.https;
        return URLProtocol.none;
    }

    public override string ToString()
    {
        return $"{Name} \n[URL]({URL})";
    }
}

enum URLProtocol: int
{
    none,
    https,
    http,
}