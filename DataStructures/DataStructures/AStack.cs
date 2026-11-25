namespace DataStructures
{
    public class AStack<T>
    {
        private int _index;
        private int _capacity;
        private T[] _stack;

        public AStack(int capacity = 64)
        {
            _capacity = capacity;
            _stack = new T[_capacity];
            _index = -1;
        }

        public void Push(T value)
        {
            if(_index == _capacity - 1)
            {
                Resize();
            }

            _index++;
            _stack[_index] = value;
        }

        public T Pop()
        {
            if (_index == -1)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            var value = _stack[_index];
            _index--;
            return value;
        }

        public T Peek()
        {
            if (_index == -1)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            return _stack[_index];
        }

        private void Resize()
        {
            _capacity *= 2;
            var newStack = new T[_capacity];
            
            Array.Copy(_stack, newStack, _stack.Length);
            
            _stack = newStack;
        }

        public override string ToString()
        {
            if(_index == -1)
            {
                return "Stack is empty";
            }

            var result = "";
            for(var i = 0; i <= _index; i++)
            {
                result += _stack[i];
                
                if(i < _index)
                {
                    result += " -> ";
                }
            }

            return result;
        }
    }
}
