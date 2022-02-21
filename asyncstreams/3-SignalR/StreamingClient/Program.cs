using Microsoft.AspNetCore.SignalR.Client;

Console.WriteLine($"Wait for service - press return to start");
Console.ReadLine();

var connection = new HubConnectionBuilder()
    .WithUrl("https://localhost:5001/stream")
    .Build();

await connection.StartAsync();

CancellationTokenSource cts = new(10000);

try
{
    // v1
    var channel = await connection.StreamAsChannelAsync<SensorData>("GetSensorData", cts.Token);
    while (await channel.WaitToReadAsync(cts.Token))
    {
        while (channel.TryRead(out SensorData? data))
        {
            Console.WriteLine($"received {data}");
        }
    }

    // v2
    //await foreach (var data in connection.StreamAsync<SensorData>("GetSensorData").WithCancellation(cts.Token))
    //{
    //    Console.WriteLine(data);
    //}
}
catch (OperationCanceledException)
{
    Console.WriteLine("Canceled!");
}

await connection.StopAsync();

Console.WriteLine("Bye...");

public record SensorData(int Val1, int Val2, DateTime TimeStamp);