using Microsoft.AspNetCore.SignalR;

using System.Runtime.CompilerServices;

namespace SignalRStreaming.Hubs;

public record SensorData(int Val1, int Val2, DateTime TimeStamp);

public class StreamingHub : Hub
{
    public async IAsyncEnumerable<SensorData> GetSensorData([EnumeratorCancellation] CancellationToken cancellationToken)
    {
        for (int i = 0; i < 1000; i++)
        {
            yield return new SensorData(Random.Shared.Next(20), Random.Shared.Next(20), DateTime.Now);
            await Task.Delay(1000, cancellationToken);
        }
    }
}
