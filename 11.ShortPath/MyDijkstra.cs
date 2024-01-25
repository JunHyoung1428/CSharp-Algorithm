using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _11.ShortPath
{
    internal class MyDijkstra
    {
        const int INF = 99999;

        public static void ShortestPath(in int[,] graph, in int start, out bool[] visited, out int[] distance, out int[] path)
        {
            int size = graph.GetLength(0);
            visited = new bool[graph.GetLength(0)];
            distance = new int[graph.GetLength(0)];
            path = new int[graph.GetLength(0)];

            for(int i=0; i<size; i++)
            {
                visited[i] = false;
                distance[i] = INF;
            }
            distance[start] = 0;  

            for(int i=0; i<size; i++)
            {
                int next = -1;
                int minDistance = INF;
                //1. 방문하지 않은 정점 중 가장 가까운 정점 선택
                for (int j=0; j<size; j++)
                {
                    if (!visited[j]&& distance[j] <minDistance )
                    {
                        minDistance = distance[j];
                        next = j;
                    }
                }
                if(next < 0)
                {
                    break;
                }

                //2. 연결된 정점 중 더 짧아지는 경우 갱신
                for(int j=0; j < size; j++)
                {
                    if (distance[j] > graph[next,j]+ distance[next])
                    {
                        distance[j] = graph[next,j]+distance[next];
                        path[i] = next;
                    }
                }
                visited[next] = true;
            }

        }
    }
}
