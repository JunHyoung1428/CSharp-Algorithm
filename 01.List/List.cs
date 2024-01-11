using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//리스트 클래스 구현해보기
namespace Datastructure
{
    public class List<T>
    {
        private const int DefaultCapacity = 4;
         
        private T[] items;
        private int count;



        public List()
        {
            items = new T[DefaultCapacity];
            count = 0;
        }

        public List(int capacity)
        {
            items = new T[capacity];
            count = 0;
        }

        public int Capacity { get { return items.Length; } }
        public int Count { get { return count; } }

       
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                    throw new IndexOutOfRangeException();

                return items[index];
            }
            set
            {
                if (index < 0 || index >= count)
                    throw new IndexOutOfRangeException();

                items[index] = value;
            }
        }

        public void Add(T item)
        {
            if (count < DefaultCapacity)
            {
                this.Grow();
            }
            items[count++] = item; 
        }

        public void Insert(int index, T item)
        {
            if(index<0 || index > count)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (count>=items.Length)
            {
                this.Grow();
            }
            if (index < count)
            {
                Array.Copy(items, index, items, index + 1, count - index);
            }

            items[index] = item;
            count++;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index >=0)
            {
                RemoveAt(index);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RemoveAt(int index)
        {  
            if (index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException();
            }
            //해당 인덱스 뒷 배열을 복사해서 떙겨와 덮어 씌움
            count--;
            Array.Copy(items, index + 1, items, index,count-index);
        }

        public void Clear() 
        {
            items = new T[DefaultCapacity]; //items에 새 인스턴스 할당, 이전 인스턴스는 다음 GC 동작 때 수거
            count=0;
        }

        public int IndexOf(T item)
        {
            if (item == null)
            {
                for (int i = 0; i < count; i++)
                {
                    if (null == items[i])
                    {
                        return i;
                    }
                }
            }
            else
            {
                for(int i=0; i<count; i++)
                {
                    if (item.Equals(items[i])) // == 자료형마다 정의가 다르기 때문에 -  대신 주소값을 비교하는 Equals() 사용
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

       
        public int FindIndex(Predicate<T> match)
        {
            for(int i=0; i < count; i++)
            {
                if (match(items[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        //리스트의 크기를 두배로 늘려주는 메소드
        private void Grow()
        {
            int newCapacity = items.Length * 2;
            T[] newItems = new T[newCapacity];
            Array.Copy(items, newItems,  count);
            items = newItems;
        }
    }
}
