
namespace CalendarManagement;

public class CalendarEvent
{
    #region fields
    private int _day;
    private int _month;
    private int _year;
    private string _desc;
    private string _fullDate;
    #endregion fields

    #region properties
    public int Day
    {
        get { return _day; }
        set { _day = value; }
    }
    public int Month
    {
        get { return _month; }
        set { _month = value; }
    }
    public int Year
    {
        get { return _year; }
        set { _year = value; }
    }
    public string Desc
    {
        get { return _desc; }
        set { _desc = value; }
    }
    public string FullDate
    {
        get { return _fullDate; }
        set { _fullDate = value; }
    }

    #endregion properties

    #region methods
    internal static CalendarEvent CreateNewEvent(string text)
    {
        string[] data = text.Split(';');
        CalendarEvent result = new CalendarEvent(data[0], data[1]);
        return result;
    }
    #endregion methods

    #region constructors
    private CalendarEvent(string date, string description)
    {
        Desc = description;
        FullDate = date;
        string[] dateParts = date.Split('.');
        Day = Convert.ToInt32(dateParts[0]);
        Month = Convert.ToInt32(dateParts[1]);
        Year = Convert.ToInt32(dateParts[2]);
    }
    #endregion constructors
}
