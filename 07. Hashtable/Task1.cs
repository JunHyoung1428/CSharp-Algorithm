using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// 치트키 문자열을 통해서 바로 함수를 탐색하여 발동시키는 치트키 머신 구현
 
namespace _07._Hashtable
{
    internal class Task1
    {
         static void Main1(string[] args)
        {
            var cheatkey = new CheatKey();
            while(true)
            {
                Console.Write("치트를 입력해주세요:");
                cheatkey.Run(Console.ReadLine());
            }
        }
    }


    public class CheatKey
    {
        private Dictionary<string, Action> cheatDic;
      

        public CheatKey()
        {
            cheatDic = new Dictionary<string, Action>();
            cheatDic.Add("show me the money", ShowMeTheMoney);
            cheatDic.Add("there is no cow level", ThereIsNoCowLevel);
            cheatDic.Add("black sheep wall", BlackSheepWall);
        }

        public void Run(string chaetKey)
        {
            //조건문 없이 탐색하여 바로 치트키 발동
            cheatDic.TryGetValue(chaetKey, out Action act);
            act?.Invoke();

            //cheatDic[chaetKey].Invoke();  
        }
        private void ShowMeTheMoney()
        {
            //골드를 늘려주는 치트키
            Console.WriteLine("골드를 늘려주는 치트키 발동!!");
        }
       
        private void ThereIsNoCowLevel()
        {
            //바로 승리하는 치트키
            Console.WriteLine("게임을 승리하는 치트키 발동!!");
        }

        private void BlackSheepWall()
        {
            //안개를 제거하는 치트키
            Console.WriteLine("안개를 제거하는 치트키 발동!!");
        }

    }
}
