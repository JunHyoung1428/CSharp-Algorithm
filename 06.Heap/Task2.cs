using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * 문제
서준이는 아빠로부터 N개의 회의를 모두 진행할 수 있는 최소 회의실 개수를 구하라는 미션을 받았다.
각 회의는 시작 시간과 끝나는 시간이 주어지고 한 회의실에서 동시에 두 개 이상의 회의가 진행될 수 없다.
단, 회의는 한번 시작되면 중간에 중단될 수 없으며 한 회의가 끝나는 것과 동시에 다음 회의가 시작될 수 있다. 
회의의 시작 시간은 끝나는 시간보다 항상 작다. N이 너무 커서 괴로워 하는 우리 서준이를 도와주자.

입력
첫째 줄에 배열의 크기 N(1 ≤ N ≤ 100,000)이 주어진다. 둘째 줄부터 N+1 줄까지 공백을 사이에 두고
회의의 시작시간과 끝나는 시간이 주어진다.
시작 시간과 끝나는 시간은 231−1보다 작거나 같은 자연수 또는 0이다.

출력
첫째 줄에 최소 회의실 개수를 출력한다.
 */


namespace _06.Heap
{
    internal class Task2
    {
        static void Main()
        {
            PriorityQueue<int, int> priorityQueue = new PriorityQueue<int, int>();

            int meetingCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < meetingCount; i++)
            {
                string[] temp = Console.ReadLine().Split();
                priorityQueue.Enqueue(int.Parse(temp[1]), int.Parse(temp[0])); // 시작시간을 우선순위로 큐 삽입
            }



            Console.WriteLine(MinimumMeetingRoom(priorityQueue));

        }

        static int MinimumMeetingRoom(PriorityQueue<int, int> priorityQueue)
        {
            PriorityQueue<int, int> newQueue = new PriorityQueue<int, int>();

            int meetingRoom = 0;
           



            return -1;
        }

    }
}
