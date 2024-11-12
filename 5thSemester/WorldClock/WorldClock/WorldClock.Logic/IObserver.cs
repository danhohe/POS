using System;

namespace WorldClock.Logic;

public interface IObserver
{
    void Update(Object sender, EventArgs e);
}
