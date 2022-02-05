ADevice dev = new();


CancellationTokenSource cts = new(TimeSpan.FromSeconds(10));

try
{

    var observer = dev.GetSomeData();
    using var d = observer.Subscribe<SomeData>(d =>
    {
        global::System.Console.WriteLine(d);
    });

    Console.ReadLine();

}
catch (OperationCanceledException ex)
{
    Console.WriteLine(ex.Message);
}
