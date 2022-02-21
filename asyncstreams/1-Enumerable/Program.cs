// get one result

using System.Diagnostics;

var watch1 = Stopwatch.StartNew();
string[] files1 = Directory.GetFiles("c:/manyfiles");
foreach (var file in files1)
{
    Console.WriteLine(file);
    watch1.Stop();
    Console.WriteLine($"{watch1.ElapsedMilliseconds} ms for first file");
    break;
}

var watch2 = Stopwatch.StartNew();
var files2 = Directory.EnumerateDirectories("c:/manyfiles");
foreach (var file in files2)
{
    Console.WriteLine(file);
    watch2.Stop();
    Console.WriteLine($"{watch2.ElapsedMilliseconds} ms for first file");
    break;
}

ADevice dev = new();
var enumerable = dev.GetSomeData();
using var enumerator = enumerable.GetEnumerator();
while (enumerator.MoveNext())
{
    var item = enumerator.Current;
    Console.WriteLine($"{item.Number}, {item.Text}");
}

foreach (var item in dev.GetSomeData())
{
    Console.WriteLine($"{item.Number}, {item.Text}");
}
