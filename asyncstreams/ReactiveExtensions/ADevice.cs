namespace AsyncEnumerable;
public class ADevice
{
    public IObservable<SomeData> GetSomeData(CancellationToken cancellationToken = default)
    {
        return Observable.Create<SomeData>(async (IObserver<SomeData> observer) =>
        {
            Random r = new();
            for (int i = 0; i < 100; i++)
            {
                int x = r.Next(1, 200);
         
                observer.OnNext(new SomeData($"text {x}", x));
                await Task.Delay(100);
            }
            observer.OnCompleted();

        });
    }
}

public record SomeData(string Text, int Number);
