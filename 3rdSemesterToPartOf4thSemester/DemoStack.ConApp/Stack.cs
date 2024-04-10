using System.Reflection;

namespace DemoStack.ConApp;

public class Stack
{
    #region fields
    private StackElement? _head = null;
    #endregion fields

    #region properties
    public bool IsEmpty
    {
        get { return _head == null; }
    }
    #endregion properties

    #region methods
    public void Push(double data)
    {
        StackElement newElement = new StackElement();
        newElement.Data = data;
        newElement.Next = _head;
        _head = newElement;
    }
    public double Pop()
    {
        if ( IsEmpty)
        {
            throw new Exception("Stack is empty!");
        }

        StackElement? tmp = _head;
        _head = tmp.Next;
        return tmp.Data;
    }
    #endregion methods
}
