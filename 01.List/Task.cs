using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*1. 사용자에게 숫자를 입력 받기
 *2. 0부터 해당 숫자까지 가지는 리스트 만들기
 *
 *3. 0 요소를 제거
 *
 *4. 리스트가 가지는 모든 요소들을 출력해주는 반복문 작성
 *
 *5. 사용자의 입력을 받아서, 없는 데이터면 추가, 있는 데이터면 삭제하는 보관함
 *      ex) 1,6,7,8,3 을 가지고 있는 case
 *      a)2 입력하면 없던 경우니까 1, 6, 7, 8, 3, 2
        b)7 입력하면 있던 경우니까 1, 6, 8, 3
 */


namespace _01.List
{
    internal class Task
    {
        static void Main()
        {
            MyList myList = new MyList();

            myList.PrintAll();
            myList.DeleteZero();
            myList.PrintAll();

            while (myList.GetInput())
            {
               
            }
        }
    }

    public class MyList
    {
        private List<int> myList;


        //1. 사용자에게 숫자를 입력 받기
        //2. 0부터 해당 숫자까지 가지는 리스트 만들기
        public MyList(){
            Console.Write("숫자를 입력해주세요: ");
            int myListSize = int.Parse(Console.ReadLine());
            myList = new List<int>(myListSize*2);
            for(int i = 0; i <= myListSize; i++)
            {
                myList.Add(i);
            }
        }

        //3. 0 요소를 제거
        public void DeleteZero()
        {
            Console.WriteLine("0을 제거하였습니다.");
            myList.Remove(0);
        }

        //4. 리스트가 가지는 모든 요소들을 출력
        public void PrintAll()
        {
            foreach(var i in myList)
            {
                Console.Write($"{i}  ");
            }
            Console.WriteLine();
        }

        //5. 사용자의 입력을 받아서, 없는 데이터면 추가, 있는 데이터면 삭제

        public bool GetInput()
        {
            Console.Write("\n숫자를 입력해주세요 | 없는 데이터면 추가하고, 있는 데이터면 삭제합니다 : ");
            if(!int.TryParse(Console.ReadLine(),out int input))
            {
                Console.WriteLine("\n *****프로그램을 종료합니다*****");
                return false;
            }

            if (myList.Contains(input))
            {
                myList.Remove(input);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{input}을 제거하였습니다.");
               
            }
            else
            {
                myList.Add(input);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{input}을 추가하였습니다.");
            }
            Console.ResetColor();
            PrintAll();
            return true;
        }

    }
}
