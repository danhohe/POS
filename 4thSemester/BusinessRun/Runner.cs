
using System.Xml.XPath;

namespace BusinessRun;
#nullable disable
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


    #endregion properties

    #region methods
    private static string CalculateTime(string time)
    {
        double result = 0;
        string[] timePart1 = time.Split(':');
        result += Convert.ToDouble(timePart1[0]) * 60;
        string[] timePart2 = time.Split('.');
        result += Convert.ToDouble(timePart2[0]);
        result += Convert.ToDouble(timePart2[1]) * 0.1;
        return result.ToString();
    }
    #endregion methods
}
