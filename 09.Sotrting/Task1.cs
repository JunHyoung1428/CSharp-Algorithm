using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 알고리즘 정렬을 종류별로 구현해보자
선택정렬
삽입정렬
버블정렬
병합정렬
퀵  정렬

A++) 힙정렬

<CS 조사>
안정정렬과 불안정정렬을 조사 (병합정렬의 사용의의)
 ㄴ 중복된 값을 입력순서에 상관있이 정렬하는지 안하는지 여부에 따라 안정정렬과 불안정정렬이 갈림
 ㄴ 기존 정렬 형태가 유지 되는지 안되는지 

안정정렬 알고리즘 : 삽입정렬, 버블정렬, 병합정렬 <- 병합정렬이 유일하게 O(nlogn)인 정렬 알고리즘 
불안정정렬 알고리즘 : 선택정렬, 퀵정렬, 힙정렬
 */

namespace _09.Sotrting
{
    internal class MySort
    {
        private static void Swap(IList<int> list, int right, int left)
        {
            int temp = list[right];
            list[right] = list[left];
            list[left] = temp;
        }

        // <선택정렬>
        // 데이터 중 가장 작은 값부터 하나씩 선택하여 정렬
        public static void SelectSort(IList<int> list, int start, int end)
        {
            
            for(int i = start; i <= end; i++)
            {
                int minIndex = i;
                for (int  j = i+1; j <= end; j++)
                {
                    if (list[minIndex] > list[j])
                    {
                        minIndex = j;
                    }
                }
                Swap(list, minIndex, i );
            }
        }


        // <삽입정렬>
        // 데이터를 하나씩 꺼내어 정렬된 자료 중 적합한 위치에 삽입하여 정렬
        public static void InsertSort(IList<int> list, int start, int end)
        {
            for(int i= start; i<=end; i++)
            {
                for(int j= i; j>=1; j--)
                {
                    if (list[j-1] < list[j])
                    {
                        break;
                    }
                    Swap(list, j-1, j );
                }
            }
        }

        // <버블정렬>
        // 서로 인접한 데이터를 비교하여 정렬
        public static void BubbleSort(IList<int> list, int start, int end)
        {
            for(int i=start; i<=end; i++)
            {
                for(int j = start; j<end; j++)
                {
                    if (list[i] < list[j])
                    {
                        Swap(list, i, j );
                    }
                }
            }
        }

        // <병합정렬>
        // 데이터를 2분할하여 정렬 후 합병
        public static void MergedSort(IList<int> list, int start, int end)
        {
            if(start == end)
            {
                return;
            }

            int middle = (start+ end) / 2;
            MergedSort(list, start, middle);
            MergedSort(list, middle+1, end);
            Merge(list, start,middle, end);  
        }
        public static void Merge(IList<int> list, int start,int middle, int end)
        {
            List<int> newList = new List<int>();
            int left = start;
            int right = middle+1;  //중앙 다음 값
            while(left <= middle && right <=end)
            {
                if(list[left] < list[right])
                {
                    newList.Add(list[left++]);
                }
                else
                {
                    newList.Add(list[right++]);
                }
            }
            if(left > middle)
            {
                for(int i = right; i <= end; i++)
                {
                    newList.Add(list[i]);
                }
            }
            else
            { 
                for(int i = left; i <= middle; i++)
                {
                    newList.Add(list[i]);
                }
            }

            for(int i = 0; i < newList.Count; i++)
            {
                list[start+i] = newList[i]; // list[start+i] 유의하자!
            }
        }

        // <퀵정렬>
        // 하나의 피벗을 기준으로 작은값과 큰값을 2분할하여 정렬
        public static void QuickSort(IList<int> list, int start,int end)
        {
            if(start >= end)
            {
                return;
            }
            int pivot = start;
            int left = pivot + 1;
            int right = end;

            while(left<=right) //등호 조심
            {
                while (left < right && list[left] < list[pivot])
                {
                    left++;
                }
                while (list[right] > list[pivot] && left<=right)
                {
                    right--;
                }

                if (left<right)
                {
                    Swap(list, left, right);
                }
                else
                {
                    Swap(list, right, pivot);
                    break;
                }
            }
            QuickSort(list, start, right-1);
            QuickSort(list, right+1, end);    
        }

        // <힙정렬>
        // 힙을 이용하여 우선순위가 가장 높은 요소가 가장 마지막 요소와 교체된 후 제거되는 방법을 이용
        public static void HeapSort(IList<int>list)
        {
            SortedSet<int> sortedSet = new SortedSet<int>();

            foreach(int i in list)
            {
                sortedSet.Add(i);
            }

            int count = 0;
            foreach(int i in sortedSet)
            {
                list[count] = i;
                count++;
            }
        }

    }
}
