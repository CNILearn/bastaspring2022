public class ADevice
{
    public IEnumerable<SomeData> GetSomeData()
    {
        for (int i = 0; i < 100; i++)
        {
            int x = Random.Shared.Next(1, 200);
            yield return new SomeData($"text {x}", x);
            Thread.Sleep(100);
        }
    }
}

public record SomeData(string Text, int Number);
