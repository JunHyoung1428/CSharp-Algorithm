using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*<Josephus permutation>
 *   요세푸스 문제는 다음과 같다.
  1번부터 N번까지 N명의 사람이 원을 이루면서 앉아있고, 양의 정수 K(≤ N)가 주어진다. 이제 순서대로 K번째 사람을 제거한다.
  한 사람이 제거되면 남은 사람들로 이루어진 원을 따라 이 과정을 계속해 나간다. 이 과정은 N명의 사람이 모두 제거될 때까지 계속된다.
  원에서 사람들이 제거되는 순서를 (N, K)-요세푸스 순열이라고 한다. 예를 들어 (7, 3)-요세푸스 순열은 <3, 6, 2, 7, 5, 1, 4>이다.
  N과 K가 주어지면 (N, K)-요세푸스 순열을 구하는 프로그램을 작성하시오.
 */
namespace _02.LinkedList
{
    internal class Task2
    {
        static void Main()
        {
            Josephus josephus = new Josephus(7, 3);
        }


        class Josephus
        {
            LinkedList<int> list;
            List<int> deadList;
            int cnt;

            public Josephus(int n, int k)
            {
                list = new LinkedList<int>();
                deadList = new List<int>();
                cnt = 1;
                for(int i=1; i<=n; i++)
                {
                    list.AddLast(i);
                }
                Kill(k);
                Print();
            }

            private void Kill(int k)
            {
                /*
                LinkedListNode<int> temp;
                temp = list.First;
                list.First = list.Last;
                list.Last = temp;*/

                LinkedListNode<int> current = list.First;
                while(list.Count > 0)
                {
                    for(int i=1; i<k; i++)
                    {
                        current = current.Next ?? list.First;
                    }

                    LinkedListNode<int> next = current.Next ?? list.First;
                    deadList.Add(current.Value);
                    list.Remove(current);
                    current = next;
                }     
            }

            private void Print()
            {
                Console.Write("<");
                foreach(int i in deadList)
                {
                    Console.Write($"{i} ");
                }
                Console.Write(">");
            }
        }

    }
}
