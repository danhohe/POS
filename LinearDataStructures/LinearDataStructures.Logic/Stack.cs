using System;
#nullable disable

namespace LinearDataStructures.Logic;

internal class Stack<T> : IStack<T>
{
    #region fields
    private Element<T> _head = null;
    #endregion fields

    public int Count
    {
        get
        {
            int result = 0;
            Element<T> run = _head;

            while (run != null)
            {
                result++;
                run = run.Next;
            }
            return result;
        }
    }

    public bool IsEmpty
    {
        get { return _head == null; }
    }

    public void Clear()
    {
        _head = null;
    }

    public T Peek()
    {
        if (IsEmpty) throw new InvalidOperationException("Stack is empty.");
        return _head!.Data!;
    }

    public T Pop()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("Stack is empty.");
        }

        Element<T> tmp = _head!;
        _head = _head!.Next;
        return tmp.Data;
    }

    public void Push(T item)
    {
        _head = new Element<T>(item, _head);
    }
}
