using System;
using System.Collections;
using System.Collections.Generic;
namespace Data_Structures
{
    public class Queue<T> : IEnumerable
    {
        private List<T> List;

        public Queue()
        {
            List = new List<T>();
        }

        public void Enqueue(T data){
            List.Add(data);    
        }

		public T Dequeue()
		{
            try{
                T victim = List[0];
                List.RemoveAt(0);
                return victim;
            } catch(ArgumentOutOfRangeException e){
                Console.WriteLine("Exception caught: {0}", e);
                return default(T);
            }
		}

        public T Peek(){
            try{
                return List[0];
            } catch(ArgumentOutOfRangeException e){
                Console.Write("Exception caught: {0}", e);
                return default(T);
            }
        }

        public int Size(){
            return List.Count;
        }

        public override string ToString(){
            string s = "";
            foreach(T val in List){
                s += val.ToString() + ", ";
            }
            return s;
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
