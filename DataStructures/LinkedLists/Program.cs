namespace LinkedLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ll = new LinkedList<int>();

            ll.InsertAtHead(1);
            ll.InsertAtTail(3);
            ll.InsertAtIndex(5, 1); // Insert 5 at index 1

            Console.WriteLine(ll.ToString());
        }
    }

    public class LinkedList<T>
    {
        private LinkedListNode<T> _head;

        public LinkedList()
        {
            _head = null;
        }

        public void InsertAtHead(T value)
        {
            var newNode = new LinkedListNode<T> { Value = value, Next = _head };
            _head = newNode;
        }

        public void InsertAtTail(T value)
        {
            var newNode = new LinkedListNode<T> { Value = value, Next = null };
            if (_head == null)
            {
                _head = newNode;
                return;
            }

            var current = _head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }

        public void InsertAtIndex(T value, int index)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index cannot be negative.");
            }

            if (index == 0)
            {
                InsertAtHead(value);
                return;
            }

            var current = _head;
            for (int i = 0; i < index - 1; i++) // note: index - 1 because we want to stop at the node before the insertion point
            {
                if (current == null)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
                }
                current = current.Next;
            }

            var newNode = new LinkedListNode<T> { Value = value, Next = current?.Next };
            if (current != null)
            {
                current.Next = newNode;
            }
        }

        // TODO: Delete - by value, by index

        // TODO: Search - by value

        // TODO: Get - by index

        // TODO: Size/Count 

        // TODO: Extras => Reverse, Sort, Merge

        public override string ToString()
        {
            var current = _head;
            var result = "";
            while (current != null)
            {
                result += current.Value + " -> ";
                current = current.Next;
            }
            return result + "null";
        }
    }

    public class LinkedListNode<T>
    {
        public T Value { get; set; }

        public LinkedListNode<T> Next { get; set; }

        public LinkedListNode()
        {
            
        }
    }
}
