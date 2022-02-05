namespace AsyncEnumerable;

public class ADevice
{
    public async IAsyncEnumerable<SomeData> GetSomeDataAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        for (int i = 0; i < 1000; i++)
        {
            int x = Random.Shared.Next(1, 200);
            yield return new SomeData($"text {x}", x);
            await Task.Delay(100, cancellationToken);
        }
    }
}

public record SomeData(string Text, int Number);

