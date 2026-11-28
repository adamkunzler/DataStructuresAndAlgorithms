namespace DataStructures
{
    public class AQueue<T>
    {
        private int _capacity;
        private T[] _queue;

        private int _head;
        private int _tail;
        private int _count;

        public AQueue(int capacity = 64)
        {            
            _capacity = capacity;
            _queue = new T[_capacity];
            _head = 0;
            _tail = 0;
            _count = 0;
        }

        public void Enqueue(T item)
        {
            if (_count == _capacity)
            {
                Resize();
            }

            _queue[_tail] = item;
            _tail = (_tail + 1) % _capacity;
            _count++;
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty");
            }

            var item = _queue[_head];
            _head = (_head + 1) % _capacity;
            _count--;
            return item;
        }

        public bool IsEmpty()
        {
            return _count == 0;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty");
            }

            return _queue[_head];
        }

        public int Count()
        {
            return _tail - _head;
        }

        private void Resize()
        {            
            var newQueue = new T[_capacity * 2];
            
            for (int i = 0; i < _count; i++)
            {
                newQueue[i] = _queue[(_head + i) % _capacity];
            }

            _queue = newQueue;
            _capacity *= 2;            
            _head = 0;
            _tail = _count;

            Console.WriteLine("*** Queue resized to capacity: " + _capacity + " ***");
        }

        public override string ToString()
        {
            if (IsEmpty())
            {
                return "Queue is empty";
            }

            var result = "";
            for (var i = 0; i < _count; i++)
            {
                var index = (_head + i) % _capacity;
                result += _queue[index];

                if (i < _count - 1)
                {
                    result += " -> ";
                }                
            }

            return result;
        }
    }
}
