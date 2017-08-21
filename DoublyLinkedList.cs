using System;
using System.Collections;

namespace Data_Structures
{
    public class DoublyLinkedList<T> : IEnumerable
    {
        private int size;
        private Node<T> head;
        private Node<T> tail;

        // private Node class ======================
        private class Node<T>{
            public T data;
            public Node<T> next, prev;

            public Node(T data, Node<T> prev, Node<T> next){
                this.data = data;
                this.prev = prev;
                this.next = next;
            }

            public override string ToString()
            {
                return data.ToString();

            }
        }
		// =========================================


		public DoublyLinkedList()
        {
            size = 0;
            head = tail = null;
        }

        // Add to beginning to list
        public void InsertFirst(T data){
            if(IsEmpty()){
                head = tail = new Node<T>(data, null, null);            
            } else {
                head.prev = new Node<T>(data, null, head);
                head = head.prev;
            }
            size++;
        }

        // Add to end of list
        public void InsertLast(T data){
            if(IsEmpty()){
                head = tail = new Node<T>(data, null, null);
            } else {
                tail.next = new Node<T>(data, tail, null);
                tail = tail.next;
            }
            size++;
        }

        // Insert at index
        public void InsertAt(T data, int index)
        {
            if (index < 0 || index > this.size)
            {
                Console.Write("Out of bounds");
            }
            else if (index == 0)
                InsertFirst(data);
            else {
                Node<T> Iterator = head;
                for (int i = 0; i < index-1; i++){
                    Iterator = Iterator.next;
                }

                Node<T> NewNode = new Node<T>(data, Iterator, Iterator.next);
                Iterator.next = NewNode;
                NewNode.next.prev = NewNode;
            }
        }

        // Remove from beginning
        public T RemoveHead(){
            if(IsEmpty()){
                throw new Exception("Empty list");
            } else {
                T VictimData = head.data;
                head = head.next;

                size--;

                if (IsEmpty())
                    tail = null;
                else
                    head.prev = null;
                
                return VictimData;
            }
        }

        // Remove from end
        public T RemoveTail(){
            if (IsEmpty())
                throw new Exception("Empty list");
            else{
                T VictimData = tail.data;
                tail = tail.prev;
                size--;

                if (IsEmpty())
                    head = null;
                else
                    tail.next = null;
                
                return VictimData;
            }
        }

        // Remove at index
        public T RemoveAt(int index){
            if (index < 0 || index >= size)
                throw new IndexOutOfRangeException();
            else if (index == 0)
            {
                return RemoveHead();
            }
            else if (index == size - 1)
            {
                return RemoveTail();
            }
            else{
                Node<T> trav = head;
                for (int i = 0; i < index; i++){
                    trav = trav.next;
                }
                trav.next.prev = trav.prev;
                trav.prev.next = trav.next;
                size--;
                return trav.data;
            }

        }

        // Remove by data (first)
        public T RemoveValue(T data){
            if (head.data.Equals(data))
                return RemoveHead();
            else if (tail.data.Equals(data))
                return RemoveTail();
            else {
                //Search the list for match
                Node<T> trav = head;
                for (int i = 0; i < size - 1; i++){
                    trav = trav.next;
                    if(trav.data.Equals(data)){
						trav.next.prev = trav.prev;
						trav.prev.next = trav.next;
						size--;
						return trav.data;
					}
                }


            }
            return default(T);
        }


        public Boolean IsEmpty(){
            return Count() == 0;
        }

        public int Count(){
            return this.size;
        }

        public override string ToString(){
            if (!IsEmpty())
            {
                string sb = "[";
                Node<T> trav = head;
                while (trav != null)
                {
                    sb += trav.data.ToString() + ",";
                    trav = trav.next;
                }
                sb += "]";
                return sb;
            } else {
                return "Empty";
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
