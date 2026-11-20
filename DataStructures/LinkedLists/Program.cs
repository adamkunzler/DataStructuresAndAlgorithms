namespace LinkedLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ll = new LinkedList<int>();

            Console.WriteLine("Inserting...");
            ll.InsertAtHead(1);
            ll.InsertAtTail(3);
            ll.InsertAtIndex(5, 1); // Insert 5 at index 1

            Console.WriteLine(ll.ToString());
            Console.WriteLine($"Size: {ll.Size()}");

            Console.WriteLine("Deleting...");
            ll.DeleteByIndex(2);
            ll.DeleteByValue(7); // Attempt to delete a value that doesn't exist
            ll.DeleteByValue(5);

            Console.WriteLine(ll.ToString());
            Console.WriteLine($"Size: {ll.Size()}");
        }
    }

    public class LinkedList<T>
    {
        private LinkedListNode<T> _head;

        public LinkedList()
        {
            _head = null;
        }

        /// <summary>
        /// Insert a value at the head of the linked list.
        /// </summary>
        /// <param name="value"></param>
        public void InsertAtHead(T value)
        {
            var newNode = new LinkedListNode<T> { Value = value, Next = _head };
            _head = newNode;
        }

        /// <summary>
        /// Insert a value at the tail of the linked list.
        /// </summary>
        /// <param name="value"></param>
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

        /// <summary>
        /// Insert a value at a specific index in the linked list
        /// </summary>
        /// <param name="value"></param>
        /// <param name="index"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
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
        
        /// <summary>
        /// Delete the first occurrence of a value in a linked list
        /// </summary>
        /// <param name="value"></param>
        public void DeleteByValue(T value)
        {
            if (_head == null) return;
            if(_head.Value == null && value == null)
            {
                _head = _head.Next;
                return;
            }

            var current = _head;
            while(current .Next != null)
            {
                if (current.Next.Value != null && current.Next.Value.Equals(value) 
                    || (current.Next.Value == null && value == null))
                {
                    current.Next = current.Next.Next;
                    return;
                }
                current = current.Next;
            }
        }

        /// <summary>
        /// Delete the value at a specified position in the linked list
        /// </summary>
        /// <param name="index"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void DeleteByIndex(int index)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index cannot be negative.");
            }

            if (_head == null) return;

            if (index == 0)
            {
                _head = _head.Next;
                return;
            }

            var current = _head;
            for (int i = 0; i < index - 1; i++)
            {
                if (current == null || current.Next == null)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
                }

                current = current.Next;
            }

            if (current.Next != null)
            {
                current.Next = current.Next.Next;
            }
        }

        // TODO: Search - by value

        // TODO: Get - by index

        // TODO: Size/Count 
        public int Size()
        {
            if (_head == null) return 0;

            var count = 0;
            var current = _head;
            while(current != null)
            {
                count++;
                current = current.Next;
            }

            return count;
        }

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
