// more information
// https://devblogs.microsoft.com/dotnet/preview-features-in-net-6-generic-math/

using System.Runtime.Versioning;

RepeatSequence str = new();

for (int i = 0; i < 10; i++)
{
    Console.WriteLine(str++);
}


Vector<double> v1 = new Vector<double>(1, 2, 3);
Vector<double> v2 = new Vector<double>(4, 5, 6);
Vector<double> v3 = v1 + v2;
Console.WriteLine(v3);

public struct RepeatSequence : IGetNext<RepeatSequence>
{
    public RepeatSequence() { }

    private const char Ch = 'A';
    public string Text = new string(Ch, 1);
    public static RepeatSequence operator ++(RepeatSequence other) =>
        other with { Text = other.Text + Ch };

    public override string ToString() => Text;
}

public interface IGetNext<T>
    where T : IGetNext<T>
{
    static abstract T operator ++(T other);
}

//public struct Vector<T> : IAdditionOperators<Vector<T>, Vector<T>, Vector<T>>
//    where T : IAdditionOperators<T, T, T>
//{
//    public Vector(T x, T y, T z)
//    {
//        X = x;
//        Y = y;
//        Z = z;
//    }
//    public Vector(Vector<T> v)
//    {
//        X = v.X;
//        Y = v.Y;
//        Z = v.Z;
//    }
//    public readonly T X;
//    public readonly T Y;
//    public readonly T Z;
//    public static Vector<T> operator+ (Vector<T> left, Vector<T> right)
//    {
//        return new Vector<T>(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
//    }
//}

public record struct Vector<T>(T X, T Y, T Z) : IAdditionOperators<Vector<T>, Vector<T>, Vector<T>>
    where T : IAdditionOperators<T, T, T>
{
    public static Vector<T> operator +(Vector<T> left, Vector<T> right)
    {
        return new Vector<T>(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
    }
}


