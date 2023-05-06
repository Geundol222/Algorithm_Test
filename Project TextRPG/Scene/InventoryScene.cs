using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class InventoryScene : Scene
    {
        public InventoryScene(Game game) : base(game) { }

        public override void Render()
        {
            PrintInventory();
        }

        public override void Update()
        {
            ConsoleKeyInfo input = Console.ReadKey();

            switch (input.Key)
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
                    game.currentScene = game.sceneDic["마을"];
                    break;
                case ConsoleKey.Z:
                    Data.player.UseItem(Data.inven[Data.inventory.itemIndex]);
                    break;
            }
        }

        public void PrintInventory()
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
            Console.WriteLine(" Z      : 아이템 사용");

            Console.SetCursorPosition(Data.inventory.point.x, Data.inventory.point.y);
            Console.Write(Data.inventory.icon);
        }
    }
}
