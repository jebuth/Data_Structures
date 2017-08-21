using System;
using System.Collections;
using System.Collections.Generic;

namespace Data_Structures
{
    public class Stack<T> : IEnumerable
    {
        private List<T> List;

        public Stack()
        {
            List = new List<T>();
        }

		public Stack(T data)
		{
			List = new List<T>();
            List.Insert(0, data);
		}

        public void Push(T data){
            List.Insert(0, data);
        }

        public T Pop(){
            try{
				T victim = List[0];
				List.RemoveAt(0);
				return victim;
            } catch (ArgumentOutOfRangeException e){
                Console.Write("Exception caught: {0}", e);
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

        public IEnumerator GetEnumerator()
        {
            return List.GetEnumerator();
            throw new NotImplementedException();
        }

        public override string ToString(){
            string s = "";
            foreach(T val in List){
                s += val.ToString() + ", ";
            }
            return s;
        }
    }
}
