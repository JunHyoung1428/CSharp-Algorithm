using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* <백준 17219>
 * 첫째 줄에 저장된 사이트 주소의 수 N(1 ≤ N ≤ 100,000)과 비밀번호를 찾으려는 사이트 주소의 수 M(1 ≤ M ≤ 100,000)이 주어진다.
두번째 줄부터 N개의 줄에 걸쳐 각 줄에 사이트 주소와 비밀번호가 공백으로 구분되어 주어진다.
사이트 주소는 알파벳 소문자, 알파벳 대문자, 대시('-'), 마침표('.')로 이루어져 있고, 중복되지 않는다.
비밀번호는 알파벳 대문자로만 이루어져 있다. 모두 길이는 최대 20자이다.
N+2번째 줄부터 M개의 줄에 걸쳐 비밀번호를 찾으려는 사이트 주소가 한줄에 하나씩 입력된다.
이때, 반드시 이미 저장된 사이트 주소가 입력된다.
 */
namespace _07._Hashtable
{
    internal class Task2
    {
        static void Main2()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            string[] input = new string[2];
            input = Console.ReadLine().Split();

            int numOfTotalSite = int.Parse(input[0]);
            int numOfFindSite = int.Parse(input[1]);

            for(int i = 0; i < numOfTotalSite; i++)
            {
                input = Console.ReadLine().Split();
                dict.Add(input[0], input[1]);
            }

            for(int i=0; i < numOfFindSite; i++)
            {
                FindPassWord(dict, Console.ReadLine());
            }

        }

        static void FindPassWord(Dictionary<string,string> dict, string input)
        {
            Console.WriteLine(dict[input]);
        }
    }
}
