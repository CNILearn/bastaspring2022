ADevice dev = new();
//var enumerable = dev.GetSomeDataAsync();
//await using var enumerator = enumerable.GetAsyncEnumerator();
//while (await enumerator.MoveNextAsync())
//{
//    var item = enumerator.Current;
//    Console.WriteLine($"{item.Number}, {item.Text}");
//}

CancellationTokenSource cts = new(TimeSpan.FromSeconds(10));

try
{

    await foreach (var item in dev.GetSomeDataAsync().WithCancellation(cts.Token))
    {
        Console.WriteLine($"{item.Number}, {item.Text}");
    }

}
catch (OperationCanceledException ex)
{
    Console.WriteLine(ex.Message);
}
