using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.ShortPath
{
    internal class Dijkstra
    {
        /********************************************************************
       * 다익스트라 알고리즘 (Dijkstra Algorithm)
       * 
       * 특정한 노드에서 출발하여 다른 노드로 가는 각각의 최단 경로를 구함
       * 방문하지 않은 노드 중에서 최단 거리가 가장 짧은 노드를 선택 후,
       * 해당 노드를 거쳐 다른 노드로 가는 비용 계산
       ********************************************************************/

        const int INF = 99999; //충분히 큰 값, int.MaxValue 하면 나중에 연산 시 오버플로우 발생 가능

        public static void ShortestPath(in int[,] graph, in int start, out bool[] visited, out int[] distance, out int[] parents)
        {
            int size = graph.GetLength(0);
            visited = new bool[size];
            distance = new int[size];
            parents = new int[size];
           
            //초기값 세팅
            for(int i=0; i<size; i++)
            {
                visited[i] = false; 
                distance[i] = INF; // 모든 경로를 일단 무한대로 설정
                parents[i] = -1;
            }
            distance[start] = 0; // 단, 시작 지점은 0

            for(int i=0; i<size; i++)
            {
                int next = -1, minDistance = INF; 

                for(int j=0; j<size; j++)
                {
                    
                    //1. 방문하지 않은 정점 중 가장 가까운 정점 선택
                    if (distance[j] < minDistance && !visited[j] )
                    {
                        next = j;//다음 정점으로 설정
                        minDistance = distance[j];
                    }
                }
                if(next < 0) //단절되어 있어서 하나도 찾을 수 없는 경우, 혹은 다 찾은경우 break;
                {
                    break;
                }
                //2. 직접 연결된 거리보다 거쳤을 때 더 짧아지는 경우면 거리 갱신
                for(int j =0; j<size; j++)
                {
                    // distance[j] : 목적지 까지 직접 연결된 거리              A->B
                    // distance[next] : 탐색중인 정점 까지의 거리              A->C
                    // graph[next,j] : 탐색중인 정점부터 목적지 까지의 거리    B->C
                    if (distance[j] > distance[next] + graph[next, j])
                    {
                        distance[j] = distance[next]+graph[next,j]; //거리 갱신
                        parents[j] = next; //경로 저장
                    }
                }
                visited[next] = true;
            } 
        }
    }
}
