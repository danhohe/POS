using System;

namespace WorldClock.Logic;

public class DateTimeArgs : EventArgs
{
    private DateTime _dateTime = DateTime.Now;

    public DateTime Time 
    {
        get { return _dateTime; }
    }
}
