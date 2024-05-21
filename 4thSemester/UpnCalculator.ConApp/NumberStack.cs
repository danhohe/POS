namespace UpnCalculator.ConApp;

public class NumberStack<T>
{
    #region embedded class
    private class Element
    {
        public Element(T data, Element? next)
        {
            Data = data;
            Next = next;
        }
        public T Data { get; set; }
        public Element? Next { get; set; }
    }
    #endregion embedded class

    #region fields
    private Element? _head = null;
    #endregion fields

    #region properties
    public bool IsEmpty
    {
        get { return _head == null; }
    }
    #endregion properties
    #region methods
    public void Push(T data)
    {
        _head = new Element(data, _head);
    }
    public T Pop()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Stack is empty.");

        Element tmp = _head!;
        _head = _head!.Next;
        return tmp.Data;
    }
    #endregion methods
}
