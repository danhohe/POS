
using System.Collections;

namespace GenericSortedList.Logic
{
    public class SortedList<T> : ISortedList<T>
            where T : IComparable<T>
    {
        #region embeddedClass


        private class Element
        {
            public Element(T data, Element? next)
            {
                Data = data;
                Next = next;
            }

            public T? Data { get; set; }
            public Element? Next { get; set; }
        }

        private class Enumerator : IEnumerator<T>
        {
            #region fields
            private Element? _first;
            private Element? _run = null;
            #endregion fields
            public Enumerator(Element? first)
            {
                _first = first;

            }
            public T Current => _run!.Data!;

            object IEnumerator.Current => _run!.Data!;

            public void Dispose()
            {

            }

            public bool MoveNext()
            {
                if (_run == null)
                {
                    _run = _first;
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
        #endregion embeddedClass

        #region fields
        private Element? _first = null;
        #endregion fields

        public int Count
        {
            get
            {
                int result = 0;
                Element? run = _first;

                while (run != null)
                {
                    result++;
                    run = run!.Next;
                }
                return result;
            }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                int counter = 0;
                Element? run = _first;

                while (counter < index && run != null)
                {
                    counter++;
                    run = run!.Next;
                }
                return run!.Data!;

            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void Clear()
        {
            _first = null;
        }

        public void Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }
            if (_first == null)
            {
                _first = new Element(item, null);
            }
            else if (item.CompareTo(_first.Data) >= 0)
            {
                Element? run = _first;

                while (run.Next != null && item.CompareTo(_first.Data) < 0)
                {
                    run = run!.Next;
                }
                run.Next = new Element(item, null);
            }
            else if (item.CompareTo(_first.Data) < 0)
            {
                Element? run = _first;
                _first = new Element(item, run);
            }
        }
        public void Remove(T item)
        {
            if (_first != null)
            {
                Element run = _first;
                Element? prev = null;
                while (item.CompareTo(run.Data) != 0 && run != null)
                {
                    prev = run;
                    run = run!.Next;
                }
                if (run != null)
                {
                    if(prev == null)
                    {
                        _first = run.Next;
                    }
                    else
                    {
                        prev.Next = run.Next;
                    }
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(_first);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(_first);
        }
    }
}
