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
                items.Add(item);
            }
            public void DropItem(Item item)
            {
                items.Remove(item);
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
