using System;
using System.Linq.Expressions;

namespace MyList;

public class LinkedList : IList
{
    #region internal class
    private class Element
    {
        public Element(object data, Element? next)
        {
            Data = data;
            Next = next;
        }
        public object Data { get; set; }
        public Element? Next { get; set; }
    }

    private class Enumerator : IEnumerator<object>
    {
        public object Current => _run.Data;
        private Element? _run = null;
        private Element? _head = null;
        public Enumerator(Element? head)
        {
            _head = head;
            _run = null;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            if (_run == null)
            {
                _run = _head;
            }
            else
            {
                _run = _run.Next;
            }
            return _run != null;
        }

        public void Reset()
        {
            _run = null;
        }
    }
    #endregion internal class

    #region fields
    private Element? _head = null;
    #endregion fields
    public int Count
    {
        get
        {
            int result = 0;
            Element? run = _head;

            while (run != null)
            {
                result++;
                run = run.Next;
            }
            return result;
        }
    }

    public void Add(object item)
    {
        if (_head == null)
        {
            _head = new Element(item, null);
        }
        else
        {
            Element run = _head;

            while (run.Next != null)
            {
                run = run.Next;
            }
            run.Next = new Element(item, null);
        }
    }

    public void Clear()
    {
        _head = null;
    }

    public void Remove(object item)
    {
        if (_head != null && _head.Data == item)
        {
            _head = _head.Next;
        }
        else if (_head != null)
        {
            Element run = _head;

            while (run.Next != null && run.Next.Data != item)
            {
                run = run.Next;
            }
            if (run.Next != null && run.Next.Data == item)
            {
                run = run.Next.Next!;
            }
        }
    }

    public object this[int index]
    {
        get
        {
            CheckIsIndexOutOfRange(index);

            Element element = GetElementByIndex(index);

            return element.Data;
        }

        set
        {
            CheckIsIndexOutOfRange(index);
        }
    }

    private Element GetElementByIndex(int index)
    {
        int counter = 0;
        Element? run = _head;

        while (counter < index)
        {
            run = run!.Next;
            counter++;
        }
        return run!;
    }

    private void CheckIsIndexOutOfRange(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new IndexOutOfRangeException("index");
        }
    }

    public System.Collections.IEnumerator GetEnumerator()
    {
        return new Enumerator(_head);
    }
}
