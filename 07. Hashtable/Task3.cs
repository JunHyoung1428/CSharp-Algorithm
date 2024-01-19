/* 백준 5568번
 * 입력
첫째 줄에 n이, 둘째 줄에 k가 주어진다. 셋째 줄부터 n개 줄에는 카드에 적혀있는 수가 주어진다.

출력
첫째 줄에 만들 수 있는 정수의 개수를 출력한다.
 */




using System.Text;

namespace _07._Hashtable
{
    internal class Task3
    {
        
        static void Main()
        {
            HashSet<int> set = new HashSet<int>();
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            
            string[] cards = new string[n];

            for(int i = 0; i < n; i++)
            {
                cards[i] = Console.ReadLine();
            }

            //순열

            // 합친다음에(StringBulider) 다시 int로 변환
            // HashSet에 삽입 (key가 같은건 무시되므로 HashSet 사용)

            // HashSet 요소 갯수 출력
            Console.WriteLine(set.Count);
        }
    }
}


/*
 * using System;
using System.Collections.Generic;

class Program
{
    static int n, k;
    static int[] cards;
    static bool[] visited;
    static HashSet<string> integers;

    static void Main(string[] args)
    {
        // n, k 입력 받기
        string[] nk = Console.ReadLine().Split();
        n = int.Parse(nk[0]);
        k = int.Parse(nk[1]);

        // 카드에 적힌 수 입력 받기
        cards = new int[n];
        for (int i = 0; i < n; i++)
        {
            cards[i] = int.Parse(Console.ReadLine());
        }

        visited = new bool[n];
        integers = new HashSet<string>();

        // 순열을 사용하여 가능한 정수의 개수 계산
        Permutation(0, "");

        // 결과 출력
        Console.WriteLine(integers.Count);
    }

    static void Permutation(int count, string integer)
    {
        if (count == k)
        {
            integers.Add(integer);
            return;
        }

        for (int i = 0; i < n; i++)
        {
            if (!visited[i])
            {
                visited[i] = true;
                Permutation(count + 1, integer + cards[i]);
                visited[i] = false;
            }
        }
    }
}
 */