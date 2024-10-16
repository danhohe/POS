using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearDataStructures.Logic
{
    class UniversalQueue<T> : IUniversalQueue<T>
    {
        #region fields
        private Queue<T> _queue = new Queue<T>();
        private Stack<T> _stack = new Stack<T>();
        #endregion fields

        public bool IsEmpty
        {
            get
            {
                return _queue.Count == 0 && _stack.Count == 0;
            }
        }

        public int Count
        {
            get
            {
                return _queue.Count + _stack.Count;
            }
        }

        public void Clear()
        {
            _queue.Clear();
            _stack.Clear();
            
        }

        public T Dequeue()
        {
           return _queue.Dequeue();
        }

        public void Enqueue(T item)
        {
            _queue.Enqueue(item);
        }

        public T Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Queue is empty.");
            }
            while (_queue.Count > 0)
            {
                _stack.Push(_queue.Dequeue());
            }
            return _stack.Peek();
        }

        public T Pop()
        {
            return _stack.Pop();
        }

        public void Push(T item)
        {
            _stack.Push(item);

        }
    }
}
