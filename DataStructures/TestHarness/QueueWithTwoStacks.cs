using DataStructures;

namespace TestHarness
{
    public class QueueWithTwoStacks<T>
    {
        private AStack<T> _stackA;
        private AStack<T> _stackB;

        public QueueWithTwoStacks()
        {
            _stackA = new AStack<T>();
            _stackB = new AStack<T>();
        }

        public void Enqueue(T item)
        {
            _stackA.Push(item);
        }

        public T Dequeue()
        {
            if (_stackB.IsEmpty())
            {
                while (!_stackA.IsEmpty())
                {
                    _stackB.Push(_stackA.Pop());
                }
            }

            if (_stackB.IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty");
            }

            return _stackB.Pop();
        }   
    }
}
