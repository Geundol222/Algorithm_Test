using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public static class Data
    {
        public static Player player;
        public static Inventory inventory;
        public static List<Item> inven;
        public static List<int> itemCount;
        public static Queue<string> itemQueue;
        public static bool[,] inventoryMap;

        public static void Init()
        {
            player = new Player();
            inventory = new Inventory();
            inven = new List<Item>();
            itemCount = new List<int>();

            for (int i = 0; i < 25; i++)
            {
                itemCount.Add(1);
            }

            inven.Add(new Potion());
            inven.Add(new LargePotion());
            inven.Add(new Potion());
        }

        public static void InventoryMap()
        {
            inventoryMap = new bool[,]
            {
                {  true,  true,  true,  true,  true},
                {  true,  true,  true,  true,  true},
                {  true,  true,  true,  true,  true},
                {  true,  true,  true,  true,  true},
                {  true,  true,  true,  true,  true},
            };

            inventory.point = new Point(0, 0);
        }

        public static void AddItem()
        {
            Random rand = new Random();

            int percent = rand.Next(0, 100);

            if (percent < 10)
            {
                // TODO : 희귀 장비
            }
            else if (percent < 30)
            {
                // TODO : 괜찮은 장비
            }
            else if (percent < 60)
            {
                inven.Add(new LargePotion());
            }
            else
            {
                inven.Add(new Potion());
            }

            for (int i = 0; i < inven.Count; i++)
            {
                for (int j = i + 1; j < inven.Count; j++)
                {
                    if (inven[i].name == inven[j].name)
                    {
                        inven.Remove(inven[j]);
                        itemCount[i]++;
                    }
                }
            }
        }

        public static void Release()
        {

        }
    }
}
