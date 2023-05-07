using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class MapScene : Scene
    {
        public MapScene(Game game) : base(game) { }

        public override void Render()
        {
            PrintMap();
        }

        public override void Update()
        {
            ConsoleKeyInfo input = Console.ReadKey();

            switch (input.Key)
            {
                case ConsoleKey.UpArrow:
                    Data.player.Move(Direction.Up);
                    break;
                case ConsoleKey.DownArrow:
                    Data.player.Move(Direction.Down);
                    break;
                case ConsoleKey.LeftArrow:
                    Data.player.Move(Direction.Left);
                    break;
                case ConsoleKey.RightArrow:
                    Data.player.Move(Direction.Right);
                    break;
                case ConsoleKey.Q:
                    Console.Clear();
                    Console.WriteLine("마을로 돌아갑니다.");
                    Thread.Sleep(1000);
                    game.currentScene = game.sceneDic["마을"];
                    return;
            }

            Monster monster = Data.MonsterInPos(Data.player.point);
            if (monster != null)
            {
                game.Battle(monster);
                return;
            }

            foreach (Monster mon in Data.monsters)
            {
                mon.MoveAction();
                if (mon.point.x == Data.player.point.x &&
                    mon.point.y == Data.player.point.y)
                {
                    game.Battle(mon);
                    return;
                }

            }
        }

        private void PrintMap()
        {
            Console.ForegroundColor = ConsoleColor.White;

            Console.Clear();

            StringBuilder sb = new StringBuilder();
            for (int y = 0; y < Data.map.GetLength(0); y++)
            {
                for (int x = 0; x < Data.map.GetLength(1); x++)
                {
                    if (Data.map[y, x])
                        sb.Append(' ');
                    else
                        sb.Append('■');
                }
                sb.AppendLine();
            }
            Console.WriteLine(sb.ToString());

            Console.WriteLine("방향키 : 이동");
            Console.WriteLine("Q : 마을로 돌아가기");

            Console.ForegroundColor = ConsoleColor.Green;
            foreach (Monster monster in Data.monsters)
            {
                Console.SetCursorPosition(monster.point.x, monster.point.y);
                Console.Write(monster.icon);
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(Data.player.point.x, Data.player.point.y);
            Console.Write(Data.player.icon);
        }
    }
}
