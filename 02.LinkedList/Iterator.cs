using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.LinkedList
{
    /*******************************************************************
        * 반복기 (Iterator)
        * 
        * 자료구조에 저장되어 있는 요소들을 순차적으로 접근하기 위한 객체
        * C# 대부분의 자료구조는 반복기를 포함
        * 이를 통해 자료구조종류와 내부구조에 무관하게 순회가능
        *******************************************************************/

    // <반복기 사용>
    // 반복기 객체를 자료구조에서 생성하여 순차적으로 확인하며 순회
    // IEnumerable : 자료구조의 반복기 생성 인터페이스
    // IEnumerator : 자료구조의 반복기 객체 인터페이스
    internal class Iterator
    {
        static void Main1()
        {
            List<int> list = new List<int>();
            LinkedList<int> linkedList = new LinkedList<int>();
            SortedSet<int> sortedSet = new SortedSet<int>();

            for(int i = 0; i<10; i++)
            {
                list.Add(i);
                linkedList.AddLast(i);
            }

            for(int i = 0; i < 10; i++)
            {
                Console.Write($"{list[i]} ");
            }
            Console.WriteLine();

            for (LinkedListNode<int> node = linkedList.First; node != null; node = node.Next)  // <====  매번 자료구조에 맞춰 쓰기 번거로움
            {
                Console.Write($"{node.Value} ");
            }
            Console.WriteLine();

            foreach(var item in linkedList) // <== foreach 쓰면 구조에 무관하게 알아서 '처음'부터 '끝'까지 순회해줌
            {
                Console.Write($"{item} ");
            }

            list.Average();
            Average(list);
            Console.ReadKey();
      
        }

       

        class Book: IEnumerable<string>  // IEnumerable을 상속하여 반복이 가능함을 명시함, 이후 foreach 사용가능
        {
            public string[] text;

            public IEnumerator<string> GetEnumerator()
            {
                throw new NotImplementedException();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }

        public static float Average(IEnumerable<int> contatiner) //IEnumerable 
        {
            float average = 0;
            int count = 0;
            foreach (var item in contatiner)
            {
                average += item;
                count++;
            }

            return average / count;
        }
    }
}
