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
        public static List<Monster> monsters;

        public static Inventory inventory;
        public static List<Item> inven;
        public static List<int> itemCount;
        public static bool[,] inventoryMap;

        public static bool[,] map;

        public static void Init()
        {
            player = new Player();
            monsters = new List<Monster>();

            inventory = new Inventory();
            inven = new List<Item>();
            itemCount = new List<int>();

            for (int i = 0; i < 25; i++)
            {
                itemCount.Add(1);
            }

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

        public static Monster MonsterInPos(Point point)
        {
            foreach (Monster monster in monsters)
            {
                if (monster.point.x == point.x &&
                    monster.point.y == point.y)
                {
                    return monster;
                }
            }
            return null;
        }

        public static void LoadLevel()
        {
            map = new bool[,]
            {
                { false, false, false, false, false, false, false, false, false, false, false, false, false, false },
                { false,  true,  true,  true,  true, false,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true, false,  true,  true,  true,  true, false, false,  true, false },
                { false,  true,  true,  true,  true, false,  true,  true,  true,  true, false,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true, false,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true, false, false, false, false,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false,  true, false },
                { false,  true, false,  true,  true,  true,  true,  true,  true,  true,  true, false,  true, false },
                { false,  true, false,  true,  true,  true,  true,  true,  true,  true,  true, false,  true, false },
                { false,  true, false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true, false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false, false, false, false, false, false, false, false, false, false, false, false, false, false },
            };

            player.point = new Point(2, 2);

            Slime slime1= new Slime();
            slime1.point = new Point(3, 5);
            monsters.Add(slime1);

            Slime slime2 = new Slime();
            slime2.point = new Point(7, 5);
            monsters.Add(slime2);
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
