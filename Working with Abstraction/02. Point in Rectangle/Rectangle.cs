public class Rectangle
{
    private Point topLeftCorner;
    private Point bottomRightCorner;

    public Rectangle(Point topLeftCoordinates, Point bottomRightCoordinates)
    {
        this.topLeftCorner = topLeftCoordinates;
        this.bottomRightCorner = bottomRightCoordinates;
    }
    public bool Contains(Point point)
    {
        return this.topLeftCorner.X <= point.X
               && this.bottomRightCorner.X >= point.X
               && this.topLeftCorner.Y <= point.Y
               && this.bottomRightCorner.Y >= point.Y;
    }
}
