using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//A++) 인벤토리 구현 (아이템 얻기, 아이템 버리기)
namespace _01.List
{
    internal class Task2
    {
        public static void Main()
        {

        }

        //인벤토리 클래스
        class Inventory
        {
            private List<Item> items;

            public Inventory()
            {
                items = new List<Item>();
            }

            public void GetItem(Item item)
            {
                Console.WriteLine($"인벤토리에 {item.name}을 추가합니다.");
                items.Add(item);
            }
            public void DropItem(Item item)
            {
                Console.WriteLine($"인벤토리에서 {item.name}을 버립니다.");
                items.Remove(item);
            }

            public int ItemCount()
            {
                Console.WriteLine($"인벤토리의 아이템 갯수:{items.Count}");
                return items.Count;
            }

            public int FindItem(Item item)
            {
               return items.IndexOf(item);
            }
        }


        //아이템 클래스
        class Item
        {
            public int id;
            public string name;
        }
    }
}
