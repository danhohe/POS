using System;

namespace WorldClock.ConApp;

public class BadObserver : Logic.IObserver
{
    public void Update(object sender, EventArgs e)
    {
        Thread.Sleep(5000);
        Console.WriteLine("I am bad");
    }
}
