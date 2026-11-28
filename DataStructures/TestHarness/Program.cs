using Algorithms;
using DS = DataStructures;

namespace LinkedLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TestLinkedLists();
            //TestArrayBasedStacks();
            //TestLinkedListBasedStacks();
            //TestArrayBasedQueues();
            TestLinkedListBasedQueues();
        }

        private static void TestLinkedLists(bool runAll = false)
        {
            Console.WriteLine(".: Singly Linked List :.");
            Console.WriteLine();

            var ll = new DS.LinkedList<int>();

            Console.WriteLine("Inserting...");
            ll.InsertAtHead(1);
            ll.InsertAtTail(3);
            //ll.InsertAtIndex(5, 1); // Insert 5 at index 1
            ll.InsertAtTail(5);
            ll.InsertAtTail(7);
            ll.InsertAtTail(9);
            ll.InsertAtTail(11);

            Console.WriteLine(ll.ToString());
            Console.WriteLine();

            Console.WriteLine("Reversed...");
            ll.Reverse();

            Console.WriteLine(ll.ToString());
            Console.WriteLine();

            Console.WriteLine("Sort Ascending...");
            ll.SortAscending();

            Console.WriteLine(ll.ToString());
            Console.WriteLine();

            Console.WriteLine("Sort Descending...");
            ll.SortDescending();

            Console.WriteLine(ll.ToString());
            Console.WriteLine();

            if (runAll)
            {
                Console.WriteLine(ll.ToString());
                Console.WriteLine($"Size: {ll.Size()}");
                Console.WriteLine();

                var t = ll.GetByIndex(5);
                Console.WriteLine("Value at index 5: " + t);
                try { t = ll.GetByIndex(7); } catch { Console.WriteLine("Exception caught accessing index 7"); }
                //Console.WriteLine("Value at index 7: " + t);
                Console.WriteLine();

                var s = ll.SearchByValue(7);
                Console.WriteLine("Index of value 7: " + s);
                Console.WriteLine();

                Console.WriteLine("Deleting...");
                ll.DeleteByIndex(2);
                ll.DeleteByValue(7); // Attempt to delete a value that doesn't exist
                ll.DeleteByValue(5);

                Console.WriteLine(ll.ToString());
                Console.WriteLine($"Size: {ll.Size()}");
                Console.WriteLine();
            }

            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine();
        }

        private static void TestArrayBasedStacks()
        {
            Console.WriteLine(".: Array-Based Stack :.");
            Console.WriteLine();

            var stack = new DS.AStack<int>();

            Console.WriteLine(stack.ToString());
            Console.WriteLine();

            Console.WriteLine("Pushing...");
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Console.WriteLine(stack.ToString());
            Console.WriteLine();

            Console.WriteLine("Peeking...");
            Console.WriteLine(stack.Peek());
            Console.WriteLine();

            Console.WriteLine("Popping...");
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.ToString());
            Console.WriteLine();


            try
            {
                Console.WriteLine(stack.Pop());
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Exception caught: {ex.Message}");
                Console.WriteLine();
            }

            var binary = Conversions.IntegerToBinary(11);
            Console.WriteLine($"Binary of 11: {binary}");
            Console.WriteLine();

            var infix = "(7 - 8 / 2 / 2) * ((7 - 2) * 3 - 6)";
            var postfix = Conversions.InfixToPostfix(infix);
            Console.WriteLine($"Postfix of '{infix}':\n {postfix}");

            var result = Conversions.EvalPostfix(postfix);
            Console.WriteLine($"Result: {result}");

            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine();
        }

        private static void TestLinkedListBasedStacks()
        {
            Console.WriteLine(".: Linked List Stack :.");
            Console.WriteLine();

            var stack = new DS.LLStack<int>();

            Console.WriteLine(stack.ToString());
            Console.WriteLine();

            Console.WriteLine("Pushing...");
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Console.WriteLine(stack.ToString());
            Console.WriteLine();

            Console.WriteLine("Peeking...");
            Console.WriteLine(stack.Peek());
            Console.WriteLine();

            Console.WriteLine("Popping...");
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.ToString());
            Console.WriteLine();


            try
            {
                Console.WriteLine(stack.Pop());
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Exception caught: {ex.Message}");
                Console.WriteLine();
            }

            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine();
        }

        private static void TestArrayBasedQueues()
        {
            Console.WriteLine(".: Array-Based Queue :.");
            Console.WriteLine();

            var queue = new DS.AQueue<int>(2);
            Console.WriteLine(queue.ToString());
            Console.WriteLine();

            Console.WriteLine("Enqueuing...");
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            Console.WriteLine(queue.ToString());
            Console.WriteLine();

            Console.WriteLine("Peeking...");
            Console.WriteLine(queue.Peek());
            Console.WriteLine();

            Console.WriteLine("Dequeuing...");
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.ToString());
            Console.WriteLine();

            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine();
        }

        private static void TestLinkedListBasedQueues()
        {
            Console.WriteLine(".: Linked List-Based Queue :.");
            Console.WriteLine();

            var queue = new DS.LLQueue<int>();
            Console.WriteLine(queue.ToString());
            Console.WriteLine();

            Console.WriteLine("Enqueuing...");
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            Console.WriteLine(queue.ToString());
            Console.WriteLine();

            Console.WriteLine("Peeking...");
            Console.WriteLine(queue.Peek());
            Console.WriteLine();

            Console.WriteLine("Dequeuing...");
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.ToString());
            Console.WriteLine();

            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine();
        }
    } // END CLASS
} // END NAMESPACE
