using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * 깊이 우선 탐색(DFS)을 했을 때 탐색되는 순서를 적으시오.  
	0 -> 3 -> 1 -> 5 -> 6 -> 2 -> (6) -> 4 -> 7
 * 너비 우선 탐색(BFS)을 했을 때 탐색되는 순서를 적으시오.  
    0 -> 3 -> 4 -> 1 -> 5 -> 7 -> 6 -> 2
* 깊이 우선 탐색을 스택을 통해 구현하시오.

* 너비 우선 탐색을 큐를 통해 구현하시오. 

 */

namespace _10.Search
{
    internal class Task1
    {
        static bool[,] newGraph = new bool[8, 8]
            {
              // 0       1      2     3       4       5      6        7
            { false,  false, false,  true,  true,   false,  false,  false}, //0
            { false, false, false,  false ,  false,  true,   true,   false}, //1
            { false, false, false,  true,  false,  true,  true,   false}, //2
            { true,  true,  false,  false,  false , true,   false,  true },  //3
            { true,  false, false,  false,  false , false,  true,   false},  //4
            { false, true,  false,  true,   false , false,  true,   true}, //5
            { false, true, true,   false,  true ,  true ,  false,  true }, //6
            { false, false, false,  true,   false , true,   true,   false}  //7
            };
        static bool[] visitedDFS = new bool[newGraph.GetLength(0)];
        static bool[] visitedBFS = new bool[newGraph.GetLength(0)];


        static void Main()
        {
            Console.WriteLine("<<RUN WITH DFS >>");
            DFS(0);

            Console.WriteLine("\n<<RUN WITH BFS >>");
            BFS(0);
        }

        static public void DFS(int start)
        {
            visitedDFS[start] = true;
            for(int i = 0; i < newGraph.GetLength(0); i++)
            {
                if (newGraph[start,i] && !visitedDFS[i])
                {
                    Console.WriteLine($"{start} --> {i}");
                    DFS(i);
                }
            }
        }

        static public void BFS(int start)
        {
            Queue<int> queue = new Queue<int>();
            visitedBFS[start] = true;
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                int next = queue.Dequeue();
                Console.WriteLine($"Deque:{next}");
                for(int i=0; i< newGraph.GetLength(0); i++)
                {
                    if (newGraph[next,i]&& !visitedBFS[i])
                    {
                        visitedBFS[i] = true;
                        Console.WriteLine($"Enque:{i}");
                        queue.Enqueue(i);
                    }
                }
            }
        }

    }
}
