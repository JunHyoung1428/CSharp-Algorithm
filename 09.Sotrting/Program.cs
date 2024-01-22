namespace _09.Sotrting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int count = 8;

            List<int> selectionList = new List<int>(count);
            List<int> insertionList = new List<int>(count);
            List<int> bubbleList = new List<int>(count);
            List<int> mergeList = new List<int>(count);
            List<int> quickList = new List<int>(count);
            List<int> heapList = new List<int>(count);
            List<int> introList = new List<int>(count);

            Console.WriteLine("랜덤 데이터 : ");
            for (int i = 0; i < count; i++)
            {
                 int rand = random.Next() % 100;
                Console.Write($"{rand,3}");

                selectionList.Add(rand);
                insertionList.Add(rand);
                bubbleList.Add(rand);
                heapList.Add(rand);
                mergeList.Add(rand);
                quickList.Add(rand);
                introList.Add(rand);
            }
            Console.WriteLine();
            
            Console.WriteLine("선택 정렬 결과 : ");
            MySort.SelectSort(selectionList, 0, mergeList.Count - 1);
            foreach (int i in selectionList)
            {
                Console.Write($"{i,3}");
            }
            Console.WriteLine();


            Console.WriteLine("삽입 정렬 결과 : ");
            MySort.InsertSort(insertionList, 0, mergeList.Count - 1);
            foreach (int i in insertionList)
            {
                Console.Write($"{i,3}");
            }
            Console.WriteLine();

            Console.WriteLine("버블 정렬 결과 : ");
            MySort.BubbleSort(bubbleList, 0, bubbleList.Count - 1);
            foreach (int i in bubbleList)
            {
                Console.Write($"{i,3}");
            }
            Console.WriteLine();
            
            Console.WriteLine("합병 정렬 결과 : ");
            MySort.MergedSort(mergeList, 0, mergeList.Count - 1);
            foreach (int i in mergeList)
            {
                Console.Write($"{i,3}");
            }
            Console.WriteLine();

            
            Console.WriteLine("퀵 정렬 결과 : ");
            MySort.QuickSort(quickList, 0, quickList.Count - 1);
            foreach (int i in quickList)
            {
                Console.Write($"{i,3}");
            }
            Console.WriteLine();


            Console.WriteLine("힙 정렬 결과 : ");
            MySort.HeapSort(heapList);
            foreach (int i in heapList)
            {
                Console.Write($"{i,3}");
            }
            Console.WriteLine();
            
            //인트로 정렬
            //상황에 따라 더 좋은 정렬 알고리즘을 선택해서 사용함
            //퀵정렬로 시작한 다음 최악의 상황(O(n^2))에 근접한다면
            //힙정렬로 전환
            //데이터가 일정 수(16) 이하이면 삽입정렬 사용. <- 퀵정렬과 힙정렬은 재귀알고리즘이라, 임계치 이하에서는 연산보다 함수호출이 더 시간을 잡아먹음
            Console.WriteLine("C# 인트로 정렬 결과 : ");
            introList.Sort();
            foreach (int i in introList)
            {
                Console.Write($"{i,3}");
            }
            Console.WriteLine();

            
        }
    }
}
