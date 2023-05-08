using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public static class Data
    {
        public static bool isTest = false;

        public static Player player;
        public static List<Player> classList;
        public static List<Monster> monsters;

        public static Inventory inventory;
        public static List<Item> inven;
        public static List<int> itemCount;
        public static bool[,] inventoryMap;

        public static bool[,] map;
        public static bool enterOnce = false;

        public static List<Item> marketList;

        public static void Init()
        {
            player = new Player();
            classList = new List<Player>();
            monsters = new List<Monster>();

            inventory = new Inventory();
            inven = new List<Item>();
            itemCount = new List<int>();

            marketList = new List<Item>();

            for (int i = 0; i < 25; i++)
            {
                itemCount.Add(1);
            }

            classList.Add(new Knight());
            classList.Add(new Archer());
            classList.Add(new Mage());

            inven.Add(new Potion());

            marketList.Add(new Potion());
            marketList.Add(new LargePotion());
            marketList.Add(new ManaPotion());
            marketList.Add(new LargeManaPotion());
            marketList.Add(new IronSword());
            marketList.Add(new SilverSword());
            marketList.Add(new GoldSword());
            marketList.Add(new IronArmor());
            marketList.Add(new SilverArmor());
            marketList.Add(new GoldArmor());
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
            Random rand = new Random();

            map = new bool[,]
            {
               { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false   },
               { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false   },
               { false, false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false, false, false   },
               { false, false,  true, false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false, false,  true,  true,  true,  true, false, false, false   },
               { false, false,  true, false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false, false, false   },
               { false, false,  true, false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false, false, false   },
               { false, false,  true,  true, false, false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false, false, false   },
               { false, false,  true,  true, false, false, false, false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false, false, false   },
               { false, false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false, false, false, false, false, false,  true,  true, false, false, false   },
               { false, false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false, false, false   },
               { false, false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false, false, false   },
               { false, false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false, false, false   },
               { false, false,  true, false,  true,  true, false,  true,  true, false, false, false, false, false, false, false,  true,  true,  true,  true, false, false, false   },
               { false, false,  true, false, false, false, false,  true,  true, false, false,  true,  true, false, false, false,  true,  true,  true,  true, false, false, false   },
               { false, false,  true, false, false, false, false,  true,  true, false,  true,  true,  true,  true, false, false,  true,  true,  true,  true, false, false, false   },
               { false, false,  true, false, false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false, false, false   },
               { false, false,  true, false, false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false, false, false   },
               { false, false,  true, false, false, false, false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false, false, false   },
               { false, false,  true, false, false, false, false,  true,  true, false, false,  true,  true, false, false, false,  true,  true,  true,  true, false, false, false   },
               { false, false,  true, false, false, false, false,  true,  true, false, false,  true,  true, false, false, false,  true,  true,  true,  true, false, false, false   },
               { false, false,  true, false, false, false, false,  true,  true, false, false,  true,  true, false, false, false,  true,  true, false, false, false, false, false   },
               { false, false,  true, false, false, false, false,  true,  true, false, false, false, false, false, false, false,  true,  true, false, false, false, false, false   },
               { false, false,  true, false, false, false, false,  true,  true, false, false, false, false, false, false, false,  true,  true, false, false, false, false, false   },
               { false, false, false, false, false, false, false, false,  true, false, false, false, false, false, false, false,  true,  true, false, false, false, false, false   },
               { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false   },

            };

            if (!enterOnce || monsters.Count < 1)
            {
                player.point = new Point(2, 3);

                Slime slime1 = new Slime();
                slime1.point = new Point(16, 16);
                monsters.Add(slime1);

                Slime slime2 = new Slime();
                slime2.point = new Point(9, 9);
                monsters.Add(slime2);

                Wolf wolf1 = new Wolf();
                wolf1.point = new Point(8, 20);
                monsters.Add(wolf1);

                Wolf wolf2 = new Wolf();
                wolf2.point = new Point(7, 16);
                monsters.Add(wolf2);

                Gorilla gorilla = new Gorilla();
                gorilla.point = new Point(12, 19);
                monsters.Add(gorilla);

                Dragon dragon = new Dragon();
                dragon.point = new Point(17, 23);
                monsters.Add(dragon);

                enterOnce = true;
            }
        }

        public static void AddItem()
        {
            Random rand = new Random();

            int percent = rand.Next(0, 100);

            if (percent < 10)
            {
                inven.Add(new LargeJewel());
                Console.WriteLine("큰 보석을 얻었습니다.");
            }
            else if (percent < 30)
            {
                inven.Add(new SmallJewel());
                Console.WriteLine("작은 보석을 얻었습니다.");
            }
            else if (percent < 60)
            {
                if (percent > 30 && percent < 45)
                {
                    inven.Add(new LargePotion());
                    Console.WriteLine("큰 포션을 얻었습니다.");
                }
                else
                {
                    inven.Add(new LargeManaPotion());
                    Console.WriteLine("큰 마나포션을 얻었습니다.");
                }                
            }
            else
            {
                if (percent > 60 && percent < 80)
                {
                    inven.Add(new Potion());
                    Console.WriteLine("포션을 얻었습니다.");
                }
                else
                {
                    inven.Add(new ManaPotion());
                    Console.WriteLine("마나포션을 얻었습니다.");
                }
            }
        }

        public static void ItemChecker()
        {
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
            Console.WriteLine("게임을 종료합니다.");
            Thread.Sleep(1000);
        }
    }
}
