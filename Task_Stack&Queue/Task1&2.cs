/* <과제1>
 * 아래와 같이 추가와 삭제가 순서대로 진행될 경우 스택, 큐의 출력 순서를 적어주자.(코딩없이)
        a.추가(1, 2, 3, 4, 5), 모두 꺼내기 -> 스택: 5, 4, 3, 2, 1 / 큐:1, 2, 3, 4, 5
        b.추가(1, 2, 3), 꺼내기(2번), 추가(4, 5, 6), 꺼내기(1번), 추가(7), 모두꺼내기 -> 스택: 3, 2, 6, 7, 5, 4, 1 / 큐 :1, 2, 3, 4, 5 ,6, 7
        c.추가(3, 2, 1), 꺼내기(1번), 추가(6, 5, 4), 꺼내기(3번), 추가(9, 8, 7) 모두꺼내기 -> 스택: 1, 4, 5, 6, 7, 8, 9, 2, 3 / 큐: 3, 2, 1, 6, 5, 4, 9, 8, 7
        d.추가(1, 3, 5), 꺼내기(1번), 추가(2, 4, 8), 꺼내기(2번), 추가(1, 3), 모두꺼내기 -> 스택: 5, 8, 4, 3, 1, 2, 3, 1 / 큐:1, 3, 5, 2, 4, 8, 1, 3
        e.추가(3, 2, 1), 꺼내기(2번), 추가(3, 2, 1), 꺼내기(2번), 추가(3,2,1), 모두꺼내기 -> 스택: 1, 2, 1, 2, 3, 3, 3 / 큐: 3, 2, 1, 3, 2, 1, 3, 2, 1
*/

/*
 * <과제2>
 * 괄호 검사기를 구현하자
 *   () 완성, {[) 미완성, {[()]} 완성, 과 같이 텍스트를 입력받아
 *   괄호가 바르게 짝지어졌는지, 아닌지를 검사해주는 프로그램을 작성해보자 
 *   bool IsBracketValid(string text)
 *       
 */

namespace Task_Stack_Queue
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            Console.Write("검사할 텍스트를 입력해주세요: ");
            IsBracketValid(Console.ReadLine());
        }

        static bool IsBracketValid(string text) 
        {
            var stack = new Stack<char>();

            foreach (var c in text)
            {
                if (c == ']')
                {
                    if (stack.Peek() != '[')
                        return false;
                    stack.Pop();
                }
                else if (c == '}')
                {
                    if (stack.Peek() != '{')
                        return false;
                    stack.Pop();
                }
                else if (c == ')')
                {
                    if (stack.Peek() != '(')
                        return false;
                    stack.Pop();
                }
                else
                    stack.Push(c);
            }
            if (stack.Count == 0)
            {
                Console.WriteLine(true);
                return true;
            }
            else
            {
                Console.WriteLine(false);
                return false;
            }

        }
    }
}
