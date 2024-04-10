namespace DemoStack.ConApp;

public class StackElement
{
    #region fields
    private double _data;
    private StackElement? _next = null;
    #endregion fields

    #region properties
    public double Data
    {
        get { return _data; }
        set { _data = value; }
    }
    public StackElement? Next
    {
        get { return _next; }
        set { _next = value; }
    }
    #endregion properties
}
