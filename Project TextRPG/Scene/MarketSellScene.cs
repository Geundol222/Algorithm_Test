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
                Console.WriteLine("X : 취소");
            }
            else
            {
                for (int i = 0; i < Data.inven.Count; i++)
                {
                    if (Data.inven.Count < 1)
                    {
                        Console.WriteLine("팔 수 있는 아이템이 없습니다.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"  {i} : {Data.inven[i].name} x {Data.itemCount[i]}");
                    }
                }
                Console.WriteLine();
                Console.WriteLine("방향키 위, 아래 : 아이템 선택");
                Console.WriteLine("Q : 판매 취소");
                Console.WriteLine("Z : 판매");


                Console.SetCursorPosition(Data.choice.choicePoint.x, Data.choice.choicePoint.y);
                Console.Write(Data.choice.icon);
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
                        sellCount = 1;
                        isSell = false;
                        break;
                    case ConsoleKey.X:
                        return;
                }
            }
            else
            {
                switch (choice.Key)
                {
                    case ConsoleKey.UpArrow:
                        Data.choice.Search(Direction.Up);
                        break;
                    case ConsoleKey.DownArrow:
                        Data.choice.Search(Direction.Down);
                        break;
                    case ConsoleKey.Q:
                        Console.Clear();
                        Console.WriteLine("마을로 돌아갑니다.");
                        Thread.Sleep(1000);
                        game.currentScene = game.sceneDic["마을"];
                        return;
                    case ConsoleKey.Z:
                        isSell = true;
                        break;
                }
            }
        }
    }
}
