#nullable disable
namespace SkiResults;

public class SkiRunner
{
    #region fields
    private string _name;
    private string _nation;
    private double _timeDG1;
    private double _timeDG2;
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
    public double TimeDG1
    {
        get { return _timeDG1; }
        set { _timeDG1 = value; }
    }
    public double TimeDG2
    {
        get { return _timeDG2; }
        set { _timeDG2 = value; }
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
    public double GetFullTime(double time1, double time2)
    {
        double result = time1 + time2;
        return result;
    }
    #endregion methods
}
