# nullable disable

namespace BusinessRun;

public class Runner
{
    #region fields
    private string _startNumber;
    private string _fullName;
    private string _yearOfBirth;
    private string _nation;
    private string _company;
    private string _team;
    private string _time;
    private double _timeInSeconds;
    #endregion fields

    #region properties
    public string StartNumber
    {
        get { return _startNumber; }
        set { _startNumber = value; }
    }
     public string FullName
    {
        get { return _fullName; }
        set { _fullName = value; }
    }
     public string YearOfBirth
    {
        get { return _yearOfBirth; }
        set { _yearOfBirth = value; }
    }
     public string Nation
    {
        get { return _nation; }
        set { _nation = value; }
    }
     public string Company
    {
        get { return _company; }
        set { _company = value; }
    }
     public string Team
    {
        get { return _team; }
        set { _team = value; }
    }
     public string Time
    {
        get { return _time; }
        set { _time = value; }
    }
    public double TimeInSeconds
    {
        get { return _timeInSeconds;}
        set {_timeInSeconds = value;}
    }
    #endregion properties

    #region methods
    public static double ConvertToSeconds(string time)
    {   
        double result = 0;
        string[] timePart = time.Split(':');
        result = Convert.ToInt32(timePart[0]) * 60.0;
        string[] timePart2 = timePart[1].Split(',');
        result += Convert.ToInt32(timePart2[0]);
        result += Convert.ToInt32(timePart2[1]) * 0.1;
        return result;
    }
    #endregion methods
}
