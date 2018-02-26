using System;

public class Rectangle : Shape
{
    private double height;
    private double width;

    public Rectangle(double height, double width)
    {
        this.Height = Math.Abs(height);
        this.Width = Math.Abs(width);
    }

    public double Height { get => this.height; set => this.height = value; }
    public double Width { get => this.width; set => this.width = value; }

    public override double CalculatePerimeter()
    {
        return 2 * (this.Width + this.Height);
    }

    public override double CalculateArea()
    {
        return this.Height * this.Width;
    }

    public override string Draw()
    {
        return String.Empty;
    }
}