using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 백준 15651 N과 M https://www.acmicpc.net/problem/15651
 * 문제
자연수 N과 M이 주어졌을 때, 아래 조건을 만족하는 길이가 M인 수열을 모두 구하는 프로그램을 작성하시오.

1부터 N까지 자연수 중에서 M개를 고른 수열
같은 수를 여러 번 골라도 된다.

입력
첫째 줄에 자연수 N과 M이 주어진다. (1 ≤ M ≤ N ≤ 7)
3 1

출력
한 줄에 하나씩 문제의 조건을 만족하는 수열을 출력한다. 중복되는 수열을 여러 번 출력하면 안되며, 각 수열은 공백으로 구분해서 출력해야 한다.
1
2
3

중복을 허용하는 순열
수열은 사전 순으로 증가하는 순서로 출력해야 한다. 
 */

namespace _08.DesignTechnique
{
    internal class Task1
    {
        public static int[] arr;
        static int n, m;
        static StringBuilder sb = new StringBuilder();
        static void Main1()
        {
            string[] text = Console.ReadLine().Split();
             n = int.Parse(text[0]);
             m = int.Parse(text[1]);
            arr = new int[m];
            DFS(0);
            Console.WriteLine(sb.ToString());
        }

        static void DFS(int dep)
        {
            if (dep == m)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    sb.Append(arr[i] + " ");
                }
                sb.AppendLine();

                return;
            }
            for (int i = 1; i <= n; i++)
            {
                arr[dep] = i;
                DFS(dep + 1);
            }
        }
    }
}
