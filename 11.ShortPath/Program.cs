using System.IO;

namespace _11.ShortPath
{
    internal class Program
    {
        const int INF = 9999;
        static void Main(string[] args)
        {
            int[,] graph = new int[9, 9]
            {
                {   0, INF,   1,   7, INF, INF, INF,   5, INF},
                { INF,   0, INF, INF, INF,   4, INF, INF, INF},
                { INF, INF,   0, INF, INF, INF, INF, INF, INF},
                {   5, INF, INF,   0, INF, INF, INF, INF, INF},
                { INF, INF,   9, INF,   0, INF, INF, INF,   2},
                {   1, INF, INF, INF, INF,   0, INF,   6, INF},
                { INF, INF, INF, INF, INF, INF,   0, INF, INF},
                {   1, INF, INF, INF,   4, INF, INF,   0, INF},
                { INF,   5, INF,   2, INF, INF, INF, INF,   0}
            };
            Dijkstra.ShortestPath(graph, 0, out bool[] visited, out int[] distance, out int[] parents);
            Console.WriteLine("<Dijkstra>");
            PrintDijkstra(distance, parents);
        }

        private static void PrintDijkstra(int[] distance, int[] path)
        {
            Console.WriteLine($"{"Vertex",10}{"Distance",10}{"Path",10}");

            for (int i = 0; i < distance.Length; i++)
            {
                Console.Write($"{i,10}");

                if (distance[i] >= INF)
                {
                    Console.Write($"{"INF",10}");
                }
                else
                {
                    Console.Write($"{distance[i],10}");
                }

                Console.WriteLine($"{path[i],10}");
            }
        }
    }
}
