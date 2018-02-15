using System;

public class Square : Shape
{
    private int size;

    public Square(int size)
    {
        this.size = size;
    }

    public override void Draw()
    {
        for (int i = 0; i < this.size; i++)
        {
            if (i == 0 || i == this.size - 1)
            {
                Console.WriteLine($"|{new string('-', this.size)}|");
                continue;
            }

            Console.WriteLine($"|{new string(' ', this.size)}|");
        }
    }
}
