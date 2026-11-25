namespace DataStructures
{
    public class LLStack<T>
    {
        private LinkedList<T> _stack;

        public LLStack()
        {
            _stack = new LinkedList<T>();
        }

        public void Push(T value)
        {
            _stack.InsertAtHead(value);
        }

        public T Pop()
        {
            if (_stack.Size() == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            var val = _stack.GetByIndex(0);
            _stack.DeleteByIndex(0);
            return val;
        }

        public T Peek()
        {
            if(_stack.Size() == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            return _stack.GetByIndex(0);
        }

        public bool IsEmpty()
        {
            return _stack.Size() == 0;
        }

        public int Count()
        {
            return _stack.Size();
        }   

        public override string ToString()
        {
            if(_stack.Size() == 0)
            {
                return "Stack is empty";
            }

            return _stack.ToString();
        }
    }
}
