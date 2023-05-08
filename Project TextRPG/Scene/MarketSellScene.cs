using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class MarketSellScene : Scene
    {
        int sellCount = 1;
        bool isSell = false;

        public MarketSellScene(Game game) : base(game) { }

        public override void Render()
        {
            Console.Clear();

            if (isSell)
            {
                Console.Clear();

                if (sellCount >= Data.itemCount[Data.inventory.itemIndex])
                    sellCount = Data.itemCount[Data.inventory.itemIndex];
                else if (sellCount <= Data.itemCount[Data.inventory.itemIndex])
                    sellCount = 1;

                Console.WriteLine($"몇 개 파시겠습니까? : {sellCount}");
                Console.WriteLine("위, 아래 : 1단위 증감   /   왼쪽, 오른쪽 : 10단위 증감");
                Console.WriteLine("Z : 확인");
                Console.WriteLine("Q : 취소");
            }
            else
            {
                PrintMarketchoice();
            }            
        }

        public override void Update()
        {
            ConsoleKeyInfo choice = Console.ReadKey();

            if (isSell)
            {
                switch (choice.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (sellCount >= Data.itemCount[Data.inventory.itemIndex])
                            sellCount = Data.itemCount[Data.inventory.itemIndex];
                        else
                            sellCount++;
                        break;
                    case ConsoleKey.DownArrow:
                        if (sellCount <= Data.itemCount[Data.inventory.itemIndex])
                            sellCount = 1;
                        else
                            sellCount--;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (sellCount <= Data.itemCount[Data.inventory.itemIndex])
                            sellCount = 1;
                        else
                            sellCount -= 10;
                        break;
                    case ConsoleKey.RightArrow:
                        if (sellCount >= Data.itemCount[Data.inventory.itemIndex])
                            sellCount = Data.itemCount[Data.inventory.itemIndex];
                        else
                            sellCount += 10;
                        break;
                    case ConsoleKey.Z:
                        Data.itemCount[Data.inventory.itemIndex] -= sellCount;
                        Console.WriteLine($"{Data.inven[Data.inventory.itemIndex].name}을 {sellCount}개 판매했습니다.");
                        Data.player.GetGold(Data.inven[Data.inventory.itemIndex].price);
                        if (Data.itemCount[Data.inventory.itemIndex] < 1)
                        {
                            Data.inven.Remove(Data.inven[Data.inventory.itemIndex]);
                            Data.itemCount.Remove(Data.itemCount[Data.inventory.itemIndex]);
                        }                        
                        Thread.Sleep(1000);
                        Data.inventory.itemIndex = 0;
                        Data.inventory.point.x = 0;
                        Data.inventory.point.y = 0;
                        sellCount = 1;
                        isSell = false;
                        break;
                    case ConsoleKey.Q:
                        isSell = false;
                        game.currentScene = this;
                        return;
                }
            }
            else
            {
                switch (choice.Key)
                {
                    case ConsoleKey.UpArrow:
                        Data.inventory.Search(Direction.Up);
                        break;
                    case ConsoleKey.DownArrow:
                        Data.inventory.Search(Direction.Down);
                        break;
                    case ConsoleKey.LeftArrow:
                        Data.inventory.Search(Direction.Left);
                        break;
                    case ConsoleKey.RightArrow:
                        Data.inventory.Search(Direction.Right);
                        break;
                    case ConsoleKey.Q:
                        game.currentScene = game.sceneDic["상점"];
                        return;
                    case ConsoleKey.Z:
                        isSell = true;
                        break;
                }
            }
        }

        public void PrintMarketchoice()
        {
            StringBuilder sb = new StringBuilder();

            for (int y = 0; y < Data.inventoryMap.GetLength(0); y++)
            {
                for (int x = 0; x < Data.inventoryMap.GetLength(1); x++)
                {
                    sb.Append("□");
                }
                sb.AppendLine();
            }
            Console.Write(sb.ToString());

            Console.WriteLine($"보유 골드 : {Data.player.gold}");
            Console.WriteLine();

            if (Data.inven.Count > 0)
            {
                Item item = Data.inven[Data.inventory.itemIndex];
                int count = Data.itemCount[Data.inventory.itemIndex];
                Console.WriteLine($"{item.name} X {count}");
                Console.WriteLine(item.image);
                Console.WriteLine($"{item.description}");
                Console.WriteLine($"아이템 가치 : {item.price}");
            }

            Console.WriteLine();
            Console.WriteLine(" 방향키 : 아이템 탐색");
            Console.WriteLine(" Q      : 나가기");
            Console.WriteLine(" Z      : 아이템 판매");

            Console.SetCursorPosition(Data.inventory.point.x, Data.inventory.point.y);
            Console.Write(Data.inventory.icon);
        }
    }
}
