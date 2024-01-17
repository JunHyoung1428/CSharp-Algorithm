using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
/*
 * 첫 줄에 정수 N (1 ≤ N ≤ 1,000)이 주어진다.
 * 다음 줄부터 N개의 줄에는 각각 두 정수 d (1 ≤ d ≤ 1,000)와 w (1 ≤ w ≤ 100)가 주어진다.
 * d는 과제 마감일까지 남은 일수를 의미하며, w는 과제의 점수를 의미한다.
 * 
 Input                  Output
7                         185
4 60
4 40
1 20
2 50
3 30
4 10
6 5


4

5 100

2 2

2 2

2 2
 */
namespace _06.Heap
{
    internal class Task1
    {
        static void Main()
        {
            PriorityQueue<int,int> priorityQueue = new PriorityQueue<int,int>();
            
            int inputDay= int.Parse(Console.ReadLine());
            for(int i=0; i<inputDay; i++)
            {
                string[] temp = Console.ReadLine().Split();
                priorityQueue.Enqueue(int.Parse(temp[1]), int.Parse(temp[0]));
            } 
            /*
            priorityQueue.Enqueue(60, 4);
            priorityQueue.Enqueue(40, 4);
            priorityQueue.Enqueue(20, 1);
            priorityQueue.Enqueue(50, 2);
            priorityQueue.Enqueue(30, 3);
            priorityQueue.Enqueue(10, 4);
            priorityQueue.Enqueue(5, 6);*/

            Console.WriteLine(MaxTaskScore(priorityQueue));
        }

        static int MaxTaskScore(PriorityQueue<int,int> priorityQueue)
        {
            int score = 0;
            int count = priorityQueue.Count;
            PriorityQueue<int,int> newQueue = new PriorityQueue<int,int>();
            for (int i=1; i<count+1; i++)
            {
                priorityQueue.TryDequeue(out int element, out int prioity);
                newQueue.Enqueue(prioity, element);
                if ( newQueue.Count>prioity )
                {
                    newQueue.Dequeue();
                }
            }

            while(newQueue.Count > 0)
            {
                int val;
                newQueue.TryDequeue(out int element, out val);
                score += val;
            }

            return score ;
        }
    }
}

