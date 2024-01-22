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


        // <병합정렬>
        // 데이터를 2분할하여 정렬 후 합병
        // 데이터 갯수만큼의 추가적인 메모리가 필요
        // 시간복잡도 -  O(nlogn)
        // 공간복잡도 -  O(n)
        // 안정정렬   -  O
        public static void MergeSort(IList<int> list, int start, int end)
        {
            if (start == end)
            {
                return;
            }

            int mid = (start + end) / 2;
            MergeSort(list, start, mid);
            MergeSort(list, mid+1,end);
            Merge(list, start, mid, end);
        }

        private static void Merge(IList<int> list, int start, int mid, int end)
        {
            List<int> sortedList = new List<int>();
            int leftIndex = start;
            int rightIndex = mid + 1;

            // 분할 정렬된 List를 병합
            while (leftIndex <= mid && rightIndex <= end)
            {
                if (list[leftIndex] < list[rightIndex])
                {
                    sortedList.Add(list[leftIndex++]);
                }
                else
                {
                    sortedList.Add(list[rightIndex++]);
                }
            }

            if (leftIndex > mid)
            {
                for (int i = rightIndex; i <= end; i++)
                {
                    sortedList.Add(list[i]);
                }
            }
            else
            {
                for (int i = leftIndex; i <= mid; i++)
                {
                    sortedList.Add(list[i]);
                }
            }

            //원본에다 정렬된거 집어넣음
            for (int i = 0; i < sortedList.Count; i++)
            {
                list[start + i] = sortedList[i];
            }
        }

        // <퀵정렬>
        // 하나의 피벗을 기준으로 작은값과 큰값을 2분할하여 정렬
        // 최악의 경우(피벗이 최소값 또는 최대값)인 경우 시간복잡도가 O(n²)
        //      => 배열의 중앙 인덱스를 피벗으로 잡거나 배열중 3개나 9개의 원소를 뽑아 이 중 중앙값을 피벗으로 정해서 해결
        // 시간복잡도 -  평균 : O(nlogn)   최악 : O(n²)
        // 공간복잡도 -  O(1)
        // 안정정렬   -  X


        public static void QuickSort(IList<int> list, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            //피벗 설정
            int pivot = start;
            int left = pivot + 1;
            int right = end;

            while(left <= right)
            {
                while (list[left] < list[pivot]&& left<right)
                {
                    left++;
                }
                while (list[right] > list[pivot] && left <= right)
                {
                    right--;
                }

                if(left < right)
                {
                    Swap(list, left, right);
                }
                else
                {
                    Swap(list,pivot, right);
                    break;
                }
            }

            QuickSort(list, start, right-1);
            QuickSort(list, right + 1, end);
        }


        // <힙정렬>
        // 힙을 이용하여 우선순위가 가장 높은 요소가 가장 마지막 요소와 교체된 후 제거되는 방법을 이용
        // 배열에서 연속적인 데이터를 사용하지 않기 때문에 캐시 메모리를 효율적으로 사용할 수 없어 상대적으로 느림(레지스터 친화도 low)
        // 시간복잡도 -  O(nlogn)
        // 공간복잡도 -  O(1)
        // 안정정렬   -  X
        public static void HeapSort(IList<int> list)
        {
            for (int i = list.Count / 2 - 1; i >= 0; i--)
            {
                Heapify(list, i, list.Count);
            }

            for (int i = list.Count - 1; i > 0; i--)
            {
                Swap(list, 0, i);
                Heapify(list, 0, i);
            }
        }
        private static void Heapify(IList<int> list, int index, int size)
        {
            int left = index * 2 + 1;
            int right = index * 2 + 2;
            int max = index;
            if (left < size && list[left] > list[max])
            {
                max = left;
            }
            if (right < size && list[right] > list[max])
            {
                max = right;
            }
            if (max != index)
            {
                Swap(list, index, max);
                Heapify(list, max, size);
            }
        }

    }
}
