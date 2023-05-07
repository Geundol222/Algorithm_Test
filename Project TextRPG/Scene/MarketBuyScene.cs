using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class MarketBuyScene : Scene
    {
        bool isChoice = false;
        bool isBuy = false;
        int itemIndex = 0;
        List<Item> items;

        public MarketBuyScene(Game game) : base(game) { }

        public override void Render()
        {
            if (isBuy)
            {
                Console.Clear();
                Console.WriteLine($"{items[itemIndex].name}을 구매하시겠습니까? 가격 : {items[itemIndex].price}");
                Console.WriteLine("1. 예");
                Console.WriteLine("2. 아니오");
            }
            else
            {
                if (!isChoice)
                {
                    Console.Clear();
                    Console.WriteLine("카테고리를 선택해주세요");
                    Console.WriteLine("1. 잡화");
                    Console.WriteLine("2. 무기");
                    Console.WriteLine("3. 방어구");
                    Console.WriteLine("4. 나가기");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("상점 주인 : 좋은 물건 많아요~");
                    Console.WriteLine(items[itemIndex].image);
                    Console.WriteLine($"{items[itemIndex].name} : {items[itemIndex].description}");
                    Console.WriteLine($"가격 : {items[itemIndex].price}");
                    Console.WriteLine("◀ Prev                                      Next ▶");
                    Console.WriteLine();
                    Console.WriteLine("방향키 오른쪽, 왼쪽 : 아이템 선택");
                    Console.WriteLine("Q : 구매 취소");
                    Console.WriteLine("Z : 구매");
                }
            }
        }

        public override void Update()
        {
            if (isBuy)
            {
                string input = Console.ReadLine();

                int command;
                if (!int.TryParse(input, out command))
                {
                    Console.WriteLine("잘못 입력하셨습니다. 다시 입력해주세요");
                    Thread.Sleep(1000);
                    return;
                }

                switch (command)
                {
                    case 1:
                        Console.Clear();
                        if (Data.player.gold >= items[itemIndex].price)
                        {
                            Console.WriteLine($"{items[itemIndex].name}을(를) 구매하였습니다.");
                            Thread.Sleep(1000);
                            Data.player.LooseGold(items[itemIndex].price);
                            Console.WriteLine($"{items[itemIndex].price}골드를 지불하였습니다.");
                            Thread.Sleep(1000);
                            Console.WriteLine();
                            Console.WriteLine("상점 주인 : 매번 감사합니다~");
                            Thread.Sleep(1000);
                            if (items[itemIndex].type == ItemType.Stuff)
                            {
                                Console.WriteLine();
                                Data.inven.Add(items[itemIndex]);
                                Console.WriteLine($"{items[itemIndex].name}이(가) 인벤토리에 추가되었습니다.");
                                Data.ItemChecker();
                                Thread.Sleep(1000);
                            }
                            else
                            {
                                Console.WriteLine();
                                Data.player.Equip(items[itemIndex]);
                                Console.WriteLine($"{items[itemIndex].name}을(를) 장비했습니다.");
                                Thread.Sleep(1000);
                            }
                        }
                        isBuy = false;
                        break;
                    case 2:
                        isBuy = false;
                        break;
                }
            }
            else
            {
                if (!isChoice)
                {
                    string input = Console.ReadLine();

                    int command;
                    if (!int.TryParse(input, out command))
                    {
                        Console.WriteLine("잘못 입력하셨습니다. 다시 입력해주세요");
                        Thread.Sleep(1000);
                        return;
                    }

                    if (command < 1 || command > 4)
                    {
                        Console.WriteLine("잘못 입력하셨습니다. 다시 입력해주세요");
                        Thread.Sleep(1000);
                        return;
                    }

                    switch (command)
                    {
                        case 1:
                            items = new List<Item>();
                            for (int i = 0; i < Data.marketList.Count; i++)
                            {
                                if (Data.marketList[i].type == ItemType.Stuff)
                                {
                                    items.Add(Data.marketList[i]);
                                }
                            }
                            isChoice = true;
                            break;
                        case 2:
                            items = new List<Item>();
                            for (int i = 0; i < Data.marketList.Count; i++)
                            {
                                if (Data.marketList[i].type == ItemType.Weapon)
                                {
                                    items.Add(Data.marketList[i]);
                                }
                            }
                            isChoice = true;
                            break;
                        case 3:
                            items = new List<Item>();
                            for (int i = 0; i < Data.marketList.Count; i++)
                            {
                                if (Data.marketList[i].type == ItemType.Armor)
                                {
                                    items.Add(Data.marketList[i]);
                                }
                            }
                            isChoice = true;
                            break;
                        case 4:
                            Console.WriteLine();
                            Console.WriteLine("상점 주인 : 다음에 또 오세요~");
                            Thread.Sleep(1000);
                            Console.WriteLine();
                            Console.WriteLine("당신은 마을로 돌아갑니다.");
                            Thread.Sleep(1000);
                            game.currentScene = game.sceneDic["마을"];
                            return;
                    }
                }
                else
                {
                    ConsoleKeyInfo info = Console.ReadKey();

                    switch (info.Key)
                    {
                        case ConsoleKey.RightArrow:
                            if (itemIndex >= items.Count - 1)
                                itemIndex = items.Count - 1;
                            else
                                itemIndex++;
                            break;
                        case ConsoleKey.LeftArrow:
                            if (itemIndex < 1)
                                itemIndex = 0;
                            else
                                itemIndex--;
                            break;
                        case ConsoleKey.Q:
                            itemIndex = 0;
                            isChoice = false;
                            return;
                        case ConsoleKey.Z:
                            isBuy = true;
                            break;
                    }
                }
            }
        }
    }
}
