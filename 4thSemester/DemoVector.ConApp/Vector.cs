namespace DemoVector.ConApp;

public class Vector
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
    public Vector()
    {
        _x = 0;
        _y = 0;
    }
    public Vector(int x, int y)
    {
        _x = x;
        _y = y;
    }
    #endregion constructors

    #region overrides
    public override string ToString()
    {
        return $"({X} | {Y})";
    }
    #endregion overrides

    #region methods
    public void Add(Vector vector)
    {
        this.X += vector._x;
        this.Y += vector._y;
    }
    public static Vector Add(Vector a, Vector b)
    {
        return new Vector(a.X + b.X , a.Y + b.Y);
    }
    #endregion methods
}
