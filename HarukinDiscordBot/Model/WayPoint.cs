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

    public WayPoint()//EFエラー回避用
    // 
    {
        
    }
    public WayPoint(string name, double X, double Y, double Z)
    {
        this.Name = name;
        this.X = (float)X;
        this.Y = (float)Y;
        this.Z = (float)Z;
        this.Created = DateTime.Now;
        this.Modified = DateTime.Now;
    }

    public WayPoint(string name, double X, double Y, double Z, string description):this(name, X, Y, Z)
    {
        this.Description = description;
    }

    public WayPoint(string name, string X, string Y, string Z) : this(
        name, Double.Parse(X.ToString()), Double.Parse(Y.ToString()), Double.Parse(Z.ToString())){}

    public WayPoint(string name, string X, string Y, string Z, string description) : this(
        name, X, Y, Z)
    {
        this.Description = description;
    }

    public override string ToString()
    {
        return $"name:{Name} | location:{X}, {Y}, {Z} \n description{Description}";
    }
}
