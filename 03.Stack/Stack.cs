using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
     /*********************************************************************************
      * 
     * 어댑터 패턴을 이용해 구현(Adapter)
     * 
     * 이미 존재하는 클래스의 인터페이스를 사용하고자 하는 다른 인터페이스로 변환하여 사용
     *
     **********************************************************************************/

     // Stack은 이미 있는 List 클래스를 사용하고자 하는 용도에 맞게 변환하여 사용함
     class Stack<T>
    {
        private List<T> container;

        public Stack() { 
            container = new List<T>();
        }


        public int Count { get { return container.Count; } }

        public void Push(T item)
        {
            container.Add(item);
        }

        public T Pop() {
            T item = container[container.Count - 1];
            container.RemoveAt(container.Count - 1);
            return item;
        }

        public T Peek()
        {
            return container[container.Count - 1];
        }
    }

  
}
