using System;

namespace DemoThread;

public class Counter
{

    private static readonly SemaphoreSlim semaphore = new SemaphoreSlim(1);
    private static readonly Object _locker = new Object();
    private static int _counter = 0;

    public static int Value
    {
        get { return _counter; }
    }

    public static void Increment()
    {
        lock (_locker)
        {
            semaphore.Wait();
            _counter++;
            semaphore.Release();
        }
    }

    public static void Decrement()
    {
        lock (_locker)
        {
            semaphore.Wait();
            _counter--;
            semaphore.Release();
        }
    }
}
