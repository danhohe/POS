#nullable disable
namespace SkiResults;

public class SkiRunner
{
    #region fields
    private string _name;
    private string _nation;
    private double _timeDg1;
    private double _timeDg2;
    private double _fullTime;
    private int _rank;
    #endregion fields

    #region properties
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    public string Nation
    {
        get { return _nation; }
        set { _nation = value; }
    }
    public double TimeDg1
    {
        get { return _timeDg1; }
        set { _timeDg1 = value; }
    }
    public double TimeDg2
    {
        get { return _timeDg2; }
        set { _timeDg2 = value; }
    }
    public double FullTime
    {
        get { return _fullTime; }
        set { _fullTime = value; }
    }
    public int Rank
    {
        get { return _rank; }
        set { _rank = value; }
    }
    #endregion properties

    #region methods
    public static double GetFullTime(double time1, double time2)
    {
        double result = time1 + time2;
        return result;
    }
    public static double CalculateDgTime(string time)
    {
        double result = 0;
        if (CheckTimestampFormat(time))
        {
            string[] timeParts = time.Split(':');
            result += Convert.ToDouble(timeParts[0]) * 60.0;
            time = timeParts[1];
        }
        string[] timeParts2 = time.Split('.');
        result += Convert.ToDouble(timeParts2[0]);
        result += Convert.ToDouble(timeParts2[1]) * 0.01;
        return result;
    }
   public static bool CheckTimestampFormat(string timestamp)
{
    int colonIndex = timestamp.IndexOf(':');
    int dotIndex = timestamp.IndexOf('.');
    bool result = true;
    if (colonIndex == -1 || dotIndex == -1 || timestamp.LastIndexOf(':') != colonIndex || timestamp.LastIndexOf('.') != dotIndex)
    {
        result = false;
    }
    return result;
}
    #endregion methods
}
