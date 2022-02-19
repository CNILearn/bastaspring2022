// get one result

//string[] files1 = Directory.GetFiles("c:/manyfiles");

//var files2 = Directory.EnumerateDirectories("c:/manyfiles");
//foreach (var file in files2)
//{

//}

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
