namespace _09.Sotrting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int count = 10;

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

            Console.WriteLine("\n선택 정렬 결과 : ");
            Sorting.SelectionSort(selectionList, 0, mergeList.Count - 1);
            foreach (int i in selectionList)
            {
                Console.Write($"{i,3}");
            }
            Console.WriteLine();


            Console.WriteLine("삽입 정렬 결과 : ");
            Sorting.InsertionSort(insertionList, 0, mergeList.Count - 1);
            foreach (int i in insertionList)
            {
                Console.Write($"{i,3}");
            }
            Console.WriteLine();

            Console.WriteLine("버블 정렬 결과 : ");
            Sorting.BubbleSort(bubbleList, 0, bubbleList.Count - 1);
            foreach (int i in bubbleList)
            {
                Console.Write($"{i,3}");
            }
            Console.WriteLine();

        }
    }
}
