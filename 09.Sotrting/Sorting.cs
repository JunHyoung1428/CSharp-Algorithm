using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Sotrting
{
    internal class Sorting
    {

        public static void Swap(IList<int> list, int leftIndex, int rightIndex)
        {
            int temp = list[leftIndex];
            list[leftIndex] = list[rightIndex];
            list[rightIndex] = temp;
        }

        // <선택정렬>
        // 데이터 중 가장 작은 값부터 하나씩 선택하여 정렬
        // 시간복잡도 -  O(n²)
        // 공간복잡도 -  O(1)
        // 안정정렬   -  O
        public static void SelectionSort(IList<int> list, int start, int end)//인터페이스 IList 쓰면 배열이랑 리스트 둘 다 가능해짐
        {
            for (int i = start; i <= end; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j <= end; j++) //제일 작은값을 탐색
                {
                    if (list[j] < list[minIndex])
                    {
                        minIndex = j; //더 작은 값이면 인덱스 교체
                    }
                }
                //최소값과 현재 위치 교체
                Swap(list, i, minIndex);
            }
        }

        // <삽입정렬>
        // 데이터를 하나씩 꺼내어 정렬된 자료 중 적합한 위치에 삽입하여 정렬
        // 시간복잡도 -  O(n²)
        // 공간복잡도 -  O(1)
        // 안정정렬   -  O
        public static void InsertionSort(IList<int> list, int start, int end)
        {
            for (int i = start+1; i <= end; i++)
            {
                for (int j = i; j >= 1; j--)//뒤에서 부터 탐색
                {
                    if (list[j - 1] < list[j])
                    {
                        break; //앞에꺼가 더 작으면 교체 할 필요가 없음
                    }
                    Swap(list, j - 1, j); //앞에꺼가 더 크면 교체
                }

            }
        }

        // <버블정렬>
        // 서로 인접한 데이터를 비교하여 정렬
        // 시간복잡도 -  O(n²)
        // 공간복잡도 -  O(1)
        // 안정정렬   -  O
        public static void BubbleSort(IList<int> list, int start, int end)
        {
            for(int i= start; i < end; i++)//인접한것 끼리 비교하기 때문에 처음부터 맨 끝 전까지만
            {
                for(int j=0; j < end-i; j++)//한번 돌 때마다 뒤에서 한자리씩은 이제 안봐도 됨(제일 큰놈이 가있기 때문)
                {
                    if (list[j] > list[j + 1])
                    {
                        Swap(list, j, j+1);
                    }
                }
            }
        }
    }
}
