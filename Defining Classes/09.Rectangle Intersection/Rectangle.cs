public class Rectangle
{
    private string id;
    private double width;
    private double height;

    private Point topLeftCorner;

    public Rectangle(string id, double width, double height, Point coordinates)
    {
        this.id = id;
        this.width = width;
        this.height = height;
        this.topLeftCorner = coordinates;
    }

    public string Id => this.id;
    public double Width => this.width;
    public double Height => this.height;

    public Point TopLeftCorner => this.topLeftCorner;
    public bool Intersect(Rectangle rectangle)
    {
        return rectangle.TopLeftCorner.X + rectangle.Width >= this.TopLeftCorner.X
               && rectangle.TopLeftCorner.X <= this.TopLeftCorner.X + this.Width
               && rectangle.TopLeftCorner.Y >= this.TopLeftCorner.Y - this.Height
               && rectangle.TopLeftCorner.Y - rectangle.Height <= this.TopLeftCorner.Y;
    }
}
