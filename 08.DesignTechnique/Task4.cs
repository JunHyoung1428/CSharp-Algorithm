using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* 백준 1932 정수삼각형 https://www.acmicpc.net/problem/1932 동적계획법 문제

        7
      3   8
    8   1   0
  2   7   4   4
4   5   2   6   5 

맨 위층 7부터 시작해서 아래에 있는 수 중 하나를 선택하여 아래층으로 내려올 때,
이제까지 선택된 수의 합이 최대가 되는 경로를 구하는 프로그램을 작성하라.
아래층에 있는 수는 현재 층에서 선택된 수의 대각선 왼쪽 또는 대각선 오른쪽에 있는 것 중에서만 선택할 수 있다.

삼각형의 크기는 1 이상 500 이하이다. 삼각형을 이루고 있는 각 수는 모두 정수이며, 범위는 0 이상 9999 이하이다.

입력
첫째 줄에 삼각형의 크기 n(1 ≤ n ≤ 500)이 주어지고, 둘째 줄부터 n+1번째 줄까지 정수 삼각형이 주어진다.

출력
첫째 줄에 합이 최대가 되는 경로에 있는 수의 합을 출력한다. 
 */
namespace _08.DesignTechnique
{
    internal class Task4
    {
        static int[,] stage;
        static int result = 0;
        static void Main4()
        {
            //최대 경로만 저장해서 다음 삼각형으로

            int count = int.Parse(Console.ReadLine());
            stage = new int[count,count];
            for(int i = 0; i < count; i++)
            {
                string[] inputs = Console.ReadLine().Split();
                for(int j = 0; j < count; j++)
                {
                    stage[i,j] = int.Parse(inputs[j]);
                }
            }

            Solution();
            for(int x=0; x < count; x++)
            {
                result = stage[count - 1, x] > result ? stage[count - 1, x] : result;
            }
            Console.WriteLine(result);
        }

        public static void Solution()
        {
            for (int i = 1; i < stage.GetLength(0); i++)
            {
                stage[i, 0] += stage[i - 1, 0];
                for(int j=1; j<stage.GetLength(1); j++)
                {
                    if (stage[i - 1, j - 1] > stage[i - 1, j])
                    {
                        stage[i, j] += stage[i - 1, j - 1];
                    }
                    else
                    {
                        stage[i, j] += stage[i - 1, j];
                    }
                }
            }          
        }
    }
}
