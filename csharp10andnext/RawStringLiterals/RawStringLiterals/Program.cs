string xml1 = """
    <books>
        <book isbn="3443874">
            <title>Professional C#</title>
        </book>
    </books>
    """;

Console.WriteLine(xml1);
Console.WriteLine();

// keep indentation
string s2 = """
    <books>
        <book isbn="3443874">
            <title>Professional C#</title>
        </book>
    </books>
""";

Console.WriteLine(s2);
Console.WriteLine();

// string interpolation
string isbn = "344343";
string title = "Professional C# and .NET";

string s3 = $"""
    <books>
        <book isbn="{isbn}">
            <title>{title}</title>
        </book>
    </books>
""";

Console.WriteLine(s3);
Console.WriteLine();

// replace { with {{ using $$
string val = "waboom";
string code1 = $$"""
public void Main()
{
    string hello = "{{val}}";
    Console.WriteLine($"This is so cool {hello}");
}
""";

Console.WriteLine(code1);
Console.WriteLine();

// generate JSON
string json1 = $$"""
    {
      "book": {
        "title": "{{title}}",
        "publisher": "Wiley"
      }
    };
    """;

Console.WriteLine(json1);
Console.WriteLine();
