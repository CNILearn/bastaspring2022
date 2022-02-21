try
{
    Previous(null!);
}
catch (ArgumentNullException ex)
{
    Console.WriteLine(ex.Message);
}
try
{
    Dotnet6(null!);
}
catch (ArgumentNullException ex)
{
    Console.WriteLine(ex.Message);
}
try
{
    CSharp11(null!);
}
catch (ArgumentNullException ex)
{
    Console.WriteLine(ex.Message);
}


void Previous(object o)
{
    if (o is null)
    {
        throw new ArgumentNullException(nameof(o));
    }
}

void Dotnet6(object o)
{
    ArgumentNullException.ThrowIfNull(o);
}

void CSharp11(object o!!)
{
    //...
}