using Microsoft.AspNetCore.SignalR;

using System.Runtime.CompilerServices;
using System.Threading.Channels;

namespace SignalRStreaming.Hubs;

public record SensorData(int Val1, int Val2, DateTime TimeStamp);

public class StreamingHub : Hub
{
    // v1 - using ChannelReader
    public ChannelReader<SensorData> GetSomeDataWithChannelReader(
        int count,
        int delay,
        CancellationToken cancellationToken)
    {
        var channel = Channel.CreateUnbounded<SensorData>();
        _ = WriteItemsAsync(channel.Writer, count, delay, cancellationToken);

        return channel.Reader;
    }

    private async Task WriteItemsAsync(
       ChannelWriter<SensorData> writer,
       int count,
       int delay,
       CancellationToken cancellationToken)
    {
        try
        {
            for (var i = 0; i < count; i++)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await writer.WriteAsync(new SensorData(i, i, DateTime.Now));

                await Task.Delay(delay, cancellationToken);
            }
        }
        catch (Exception ex)
        {
            writer.TryComplete(ex);
        }

        writer.TryComplete();
    }

    // v2 async streams
    public async IAsyncEnumerable<SensorData> GetSensorData([EnumeratorCancellation] CancellationToken cancellationToken)
    {
        for (int i = 0; i < 1000; i++)
        {
            yield return new SensorData(Random.Shared.Next(20), Random.Shared.Next(20), DateTime.Now);
            await Task.Delay(1000, cancellationToken);
        }
    }
}
