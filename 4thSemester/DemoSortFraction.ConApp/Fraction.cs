using System.Reflection.Emit;

namespace DemoSortFraction.ConApp;

public class Fraction : IComparable<Fraction>
{
    private int _nominator;
    public int Nominator
    {
        get { return _nominator; }
        set { _nominator = value; }
    }
    private int _denominator;
    public int Denominator
    {
        get { return _denominator; }
        set
        {
            if (value != 0)
            {
                _denominator = value;
            }
        }
    }
    public Fraction()
    {
        _nominator = 0;
        _denominator = 1;
    }
    public Fraction(int nominator, int denominator)
    {
        _nominator = nominator;
        _denominator = denominator != 0 ? denominator : 1;
    }
    public double GetValue()
    {
        return (double)Nominator / Denominator;
    }
    public override string ToString()
    {
        return $"{Nominator} / {Denominator}";
    }

    public int CompareTo(Fraction? other)
    {
        if (other == null)
        {
            throw new ArgumentNullException("other");
        }
        return GetValue().CompareTo(other.GetValue()) * (-1);
    }
}


