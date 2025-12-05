using System;

public interface IClonable<T> where T : class
{
    T Clone();
}

public class Point : IClonable<Point>
{
    public int x { get; set; }
    public int y { get; set; }

    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public Point(Point point)
    {
        x = point.x;
        y = point.y;
    }

    public Point Clone()
    {
        return new Point(this);
    }
}

public class Rectangle : IClonable<Rectangle>
{
    public int x { get; set; }
    public int y { get; set; }
    public int z { get; set; }

    public Rectangle(int x, int y, int z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public Rectangle(Rectangle rectangle)
    {
        x = rectangle.x;
        y = rectangle.y;
        z = rectangle.z;
    }

    public Rectangle Clone()
    {
        return new Rectangle(this);
    }
}

public class Program
{
    public static void Main()
    {
        var point = new Point(1, 2);
        var rectangle = new Rectangle(1, 2, 3);
        var point2 = point.Clone();
        var rectangle2 = rectangle.Clone();
        Console.WriteLine($"не клоны - {point.x}, {point.y}\n{rectangle.x}, {rectangle.y}, {rectangle.z}");
        Console.WriteLine($"клоны -  {point2.x}, {point2.y}\n{rectangle2.x}, {rectangle2.y}, {rectangle2.z}");
    }
}
