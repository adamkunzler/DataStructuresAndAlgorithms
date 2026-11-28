using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class LLQueue<T>
    {
        private LinkedList<T> _queue;

        public LLQueue()
        {
            _queue = new LinkedList<T>();
        }

        public void Enqueue(T value)
        {
            _queue.InsertAtTail(value);
        }

        public T Dequeue()
        {
            if (_queue.Size() == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }
            
            var val = _queue.GetByIndex(0);
            _queue.DeleteByIndex(0);
            
            return val;
        }

        public bool IsEmpty()
        {
            return _queue.Size() == 0;
        }

        public int Count()
        {
            return _queue.Size();
        }

        public T Peek()
        {
            if (_queue.Size() == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }
            return _queue.GetByIndex(0);
        }

        public override string ToString()
        {
            return _queue.ToString();
        }
    }
}
