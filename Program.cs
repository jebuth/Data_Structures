using System;
using System.Collections;

namespace Data_Structures
{
    class MainClass
    {
        public void DoublyLinkedListTest(){
			DoublyLinkedList<int> dll = new DoublyLinkedList<int>();

			dll.InsertFirst(3);
			dll.InsertFirst(2);
			dll.InsertFirst(1);

			dll.InsertLast(4);
			dll.InsertLast(5);
			dll.InsertLast(6);

			dll.InsertLast(7);
			dll.InsertLast(8);
			dll.InsertLast(9);

			dll.RemoveHead();  // Remove 1
			dll.RemoveHead();  // Remove 2
			dll.RemoveTail();  // Remove 9

			//[3, 4, 5, 6, 7, 8]

			dll.RemoveAt(3);    // Remove 6

			//[3, 4, 5, 7, 8]

			dll.RemoveValue(7); // Remove 7

			//[3, 4, 5, 8]

			Console.WriteLine(dll.ToString());
        }

        static public void StackTest(){
            Stack<int> stk = new Stack<int>(1);

        

            stk.Pop();
            stk.Pop();

            Console.Write(stk.ToString());

        }

        static public void QueueTest(){
            Queue<int> q = new Queue<int>();

            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);

            q.Dequeue();
            q.Dequeue();
            q.Dequeue();


            Console.WriteLine(q.ToString());
        }

        static public void BSTTest(){
            BST<int> bst = new BST<int>();
            bst.Add(0);
            bst.Add(1);
            bst.Add(5);
            bst.Add(3);

            bst.PrintInOrder();
            if (bst.Contains(9))
                Console.Write("true");
            else
                Console.Write("False");
        }

        public static void Main(string[] args)
        {
            //StackTest();
            //QueueTest();
            BSTTest();
        }
    }
}
