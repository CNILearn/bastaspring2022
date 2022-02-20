
Position p1 = new();
Position p2 = p1 with { X = 42 };

Dimension d1 = new(20, 20);
// deconstruct
(int height, _) = d1;
Dimension d2 = d1;
int x1 = d2.GetHashCode();
d2.Width = 33;
x1 = d2.GetHashCode();
Console.ReadLine();

Size s1 = new();

// a struct
public readonly struct Position
{
    public Position(int x, int y) => (X, Y) = (x, y);

    public readonly int X { get; init; }
    public readonly int Y { get; init; }
}

// positional records - with read/write properties
public record struct Dimension(int Height, int Width)
{

}


// nominal records
public record struct Size
{
    public int Width { get; set; }
    public int Height { get; set; }
}