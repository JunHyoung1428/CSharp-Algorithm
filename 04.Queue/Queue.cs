using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    internal class Queue<T>
    {
        private const int DefaultCapacity = 4;

        private T[] array;
        private int head;
        private int tail;
        private int count;

        public Queue()
        {
            array = new T[DefaultCapacity];
            head = 0;
            tail = 0;
            count = 0;
        }

        public void Enqueue(T item) //자료를 맨 뒤에 넣고 tail을 한 칸 뒤로
        {
            if (IsFull())
            {
                Grow();
            }

            array[tail]=item;

            //tail = (tail+1) % array.Length;  //나머지를 구해서 해당 범위 안에서만 돌겠금 함
            tail++;
            if(tail ==array.Length) //둘 다 역할은 같음, tail이 마지막 칸에 있을 때 맨 앞으로 보내 순환 구현.
            {
                tail = 0;
            }
            count++;
        }

        public T Dequeue() // 맨 앞 자료를 꺼내고, head를 한 칸 뒤로
        {
            
            if(count == 0)
            {
                throw new InvalidOperationException();
            }

            T item = array[head];
            head++;
            count--;
            if(head == array.Length) // head가 맨 뒤면 다시 맨 앞으로
            {
                head = 0;
            }
            //head = (head+1) %array.Length;

            return item;
        }


        // head와 tail이 일치하는 경우를 비어있는 경우로 판정
        // tail이 head 전위치에 있는 경우를 실제로는 한자리가 비어있지만 가득찬 경우로 판정
        //         th                      t h                    h           t
        //         ↓↓                      ↓ ↓                    ↓           ↓
        // ┌─┬─┬─┬─┬─┬─┬─┬─┐        ┌─┬─┬─┬─┬─┬─┬─┬─┐            ┌─┬─┬─┬─┬─┬─┬─┬─┐
        // │ │ │ │ │ │ │ │ │        │5│6│7│ │1│2│3│4│            │1│2│3│4│5│6│7│ │ 
        // └─┴─┴─┴─┴─┴─┴─┴─┘        └─┴─┴─┴─┴─┴─┴─┴─┘            └─┴─┴─┴─┴─┴─┴─┴─┘
        //   비어있는 경우         가득찬 경우(로 판정        가득찬 경우(로 판정))
        public bool IsFull()
        {
            if(head > tail) 
            {
                return head == tail + 1;
            }
            else
            {
                return head == 0 && tail == array.Length - 1;
            }

        }

        public bool IsEmpty()
        {
            return head == tail;
        }

        private void Grow()
        {
            //두배 크기의 새 배열 생성
            T[] newArray = new T[DefaultCapacity*2];

            //리스트와 다르게, 맨 처음부터가 아닌 head부터 tail까지 복사
            if (head < tail)
            {
                Array.Copy(array, head, newArray, 0, tail);
            }
            else
            {
                //한번 순환이 이뤄져 있으면 "헤드부터 배열 끝까지"+ "맨처음부터 꼬리까지" 복사해서 넣어줘야함
               Array.Copy(array, head, newArray, 0, array.Length - head);
               Array.Copy(array, 0, newArray, array.Length - head, tail);
            }
            array = newArray;
            head= 0;
            tail = count;
        }
    }
}
