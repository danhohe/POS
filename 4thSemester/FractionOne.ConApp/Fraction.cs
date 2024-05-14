namespace FractionOne.ConApp;

public class Fraction
{
    #region fields
    private int _x;
    private int _y;
    #endregion fields

    #region properties
    public int X
    {
        get { return _x; }
        set { _x = value; }
    }
    public int Y
    {
        get { return _y; }
        set { _y = value; }
    }
    #endregion properties

    #region constructors
    public Fraction()
    {
        X = 0;
        Y = 1;
    }
    public Fraction(int a, int b)
    {
        X = a;
        Y = b;
        if (b == 0)
        {
            Y = 1;
        }
    }
    public Fraction(Fraction a)
    {
        X = a.X;
        Y = a.Y;
    }
    public Fraction(int a)
    {
        X = a;
        Y = 1;
    }
    #endregion constructors

    #region operator overloadings

    #endregion operator overloadings

    #region overrides
    public override string ToString()
    {
        return $"{X}/{Y}";
    }
    #endregion overrides

    #region methods

    public Fraction Add(int a)
    {
        X += Y * a;
        return new Fraction(X, Y);
    }
    public Fraction Add(Fraction tmp)
    {
        if (Y != tmp.Y)
        {
            Y *= tmp.Y; 
        }
        X = X * Y + tmp.X;

        return new Fraction(X, Y);
    }
    public double Value()
    {
        double result = 0;
        result = (double)X / Y;
        return result;
    }
    public Fraction Multiplier(int a)
    {
        X *= a;
        return new Fraction(X, Y);
    }
    public Fraction Multiplier(Fraction tmp)
    {
        X *= tmp.X;
        Y *= tmp.Y;
        return new Fraction(X, Y);
    }

    #endregion methods
}
