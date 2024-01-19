using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.DesignTechnique
{
	internal class DynamicProgramming
	{
		/******************************************************
		 * 동적계획법 (Dynamic Programming)													분할정복
		 * 
		 * 작은문제의 해답을 큰문제의 해답의 부분으로 이용하는 상향식 접근 방식		<=>		하향식
		 * 주어진 문제를 해결하기 위해 부분 문제에 대한 답을 계속적으로 활용해 나가는 기법
		 * 부분 문제에 대한 답을 저장할 메모리 공간이 필요함
		 ******************************************************/

		// 예시 - 피보나치 수열
		int Fibonachi(int x)
		{
			int[] fibonachi = new int[x + 1];
			fibonachi[1] = 1;
			fibonachi[2] = 1;

			for (int i = 3; i <= x; i++)
			{
				fibonachi[i] = fibonachi[i - 1] + fibonachi[i - 2];
			}

			return fibonachi[x];
		}


		// 연속합 문제 1912
		/*n개의 정수로 이루어진 임의의 수열이 주어진다.
         * 우리는 이 중 연속된 몇 개의 수를 선택해서 구할 수 있는 합 중 가장 큰 합을 구하려고 한다.
         * 단, 수는 한 개 이상 선택해야 한다.


		 *예를 들어서 10, -4, 3, 1, 5, 6, -35, 12, 21, -1 이라는 수열이 주어졌다고 하자.
		 *여기서 정답은 12+21인 33이 정답이 된다.
		 */
		static void Main()
		{
			//int[] values = { 10, -4, -3, 1, 5, 6, -35, 12, 21, -1 };
			int count = int.Parse(Console.ReadLine());
			string text = Console.ReadLine();
			string[] texts = text.Split();

            int max = int.MinValue;

            List<int> list = new List<int>();

			for (int i = 0; i < count; i++)
			{
				list.Add(int.Parse(texts[i]));
				if (max < list[i])
				{
					max = list[i];
				}
			}
			//{2,4} 2~4를 더한 값
			int[,] result = new int[list.Count,list.Count];
			for(int i=0; i<list.Count; i++)
			{
				result[i,i] = list[i];
			}

			for (int start = 0; start < list.Count-1; start++)
			{
				for(int end = start+1; end< list.Count; end++)
				{
					result[start,end] = result[start, end - 1] + list[end];
					if (max < result[start, end])
					{
						max = result[start,end];
					}
				}
			}
			Console.WriteLine(max);

		}
	}
}
