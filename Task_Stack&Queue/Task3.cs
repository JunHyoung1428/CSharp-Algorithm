/* <과제 3>
            작업 프로세스
배열로 각 작업이 몇시간이 걸리는지 있다.
예시 : [4, 4, 12, 10, 2, 10]

하루에 8시간씩 일할 수 있는 회사가 있음.
남는시간없이 주어진 일을 계속한다고 했을때.
각각의 작업이 끝나는 날짜를 결과 배열로 출력

int[] ProcessJob(int[] jobList) {}

결과 : [1, 1, 3, 4, 4, 6]
 */
namespace Task_Stack_Queue
{
    internal class Task3
    {

        static void Main()
        {
            int[] jobList = new int[] { 4, 4, 12, 10, 2, 10 };
            Console.Write("[");
            foreach (var i in ProcessJob(jobList))
            {
                Console.Write($"{i}, ");  //결과 : [1, 1, 3, 4, 4, 6]
            }
            Console.WriteLine("]");
        }

        static int[] ProcessJob(int[] jobList)
        {
            Queue<int> queue = new Queue<int>();
            List<int> result = new List<int>();
            int dayProcess = 8;
            int dayCount = 1;

            foreach (var i in jobList)
            {
                queue.Enqueue(i);
            }

            while (queue.Count > 0)
            {
                int toDo = queue.Peek();
                while (toDo > dayProcess)
                {
                    toDo-=dayProcess;
                    dayCount++;
                    dayProcess = 8;
                }
                dayProcess -= toDo;
                queue.Dequeue();
                result.Add(dayCount);

                /* 시도해본거
                if (queue.Peek() - dayProcess <= 0)
                {
                    dayProcess = dayProcess - queue.Peek();
                    processJob.Add(dayCount);
                    queue.Dequeue();
                }
                else
                {
                    dayCount++;
                    dayProcess = 8;
                    남은일을어케저장함??
                }*/
                
            }

            return result.ToArray();
        }
    }


}
