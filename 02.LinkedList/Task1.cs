using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * <실습>
사용자의 입력으로 숫자를 입력 받아서 (마이너스도 허용)
음수는 앞에 추가하고, 양수는 뒤에 추가하여
음수&양수를 반으로 나누는 연결리스트 구현
입력 받을 때마다 처음부터 끝까지 출력 진행
 */


namespace _02.LinkedList
{
    internal class Task1
    {
        public static void Main2()
        {
            MyList myList = new MyList();
            while(true)
            {
                myList.GetInput();
                myList.Print();
            }
        }

        public class MyList
        {
            LinkedList<int> mylist;

            public MyList()
            {
                mylist = new LinkedList<int>();
            }


            public void GetInput()
            {
                //사용자의 입력으로 숫자 받기
                if(!int.TryParse(Console.ReadLine(), out int input))
                {
                    Console.WriteLine("올바른 숫자를 입력해주세요");
                    GetInput();
                    return;
                }
                if(input==0)
                {
                    Console.WriteLine("0은 받지 않습니다.");
                    GetInput();
                    return;
                }
                
                if (input > 0)//양수면 뒤에다 추가
                {
                    mylist.AddLast(input);
                }
                else if(input <0)//음수면 앞에다 추가
                {
                    mylist.AddFirst(input);
                }
            }

            public void  Print()
            {
                Console.Write("Items in List :");
                foreach(int i in mylist){
                    Console.Write($"{i} ");
                }
                Console.WriteLine();
            }
        }
    }
}
