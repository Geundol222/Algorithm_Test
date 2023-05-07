using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class Gorilla : Monster
    {
        int moveCount;

        public Gorilla()
        {
            icon = '♣';

            name = "고릴라";
            curHp = 100;
            maxHp = 100;
            ap = 20;
            dp = 5;
            speed = 4;
            gold = 300;
            exp = 40;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("                                                                              ");
            sb.AppendLine("                            ████████████████                                  ");
            sb.AppendLine("                          ██▒▒▒▒▒▒▒▒▒▒▒▒▒▒████                                ");
            sb.AppendLine("                        ▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██▓▓                              ");
            sb.AppendLine("                      ██▒▒██████████▓▓▓▓▒▒▒▒▓▓▓▓██                            ");
            sb.AppendLine("                      ████  ░░  ░░░░████▓▓▒▒▒▒▓▓▓▓██                          ");
            sb.AppendLine("                      ██░░░░░░░░░░░░▒▒██▓▓▒▒▒▒▒▒▓▓▓▓██                        ");
            sb.AppendLine("                      ██████░░░░██████████▓▓▒▒████▓▓▓▓██                      ");
            sb.AppendLine("                    ██░░██░░    ░░██░░▒▒██▓▓██░░██▒▒▓▓██                      ");
            sb.AppendLine("                    ██  ░░░░░░░░  ░░░░▒▒████▓▓████▒▒▓▓▓▓██                    ");
            sb.AppendLine("                  ██      ██░░██  ░░  ░░░░████▓▓▒▒▒▒▒▒▓▓████                  ");
            sb.AppendLine("                ██                  ░░░░░░░░██▒▒▓▓▒▒▒▒████████                ");
            sb.AppendLine("                ████████░░    ░░░░░░░░░░░░░░████▓▓▒▒▒▒████▓▓████              ");
            sb.AppendLine("                ██░░░░░░░░░░░░░░░░░░░░░░░░▒▒████▒▒▒▒██▓▓▒▒▒▒▓▓████            ");
            sb.AppendLine("                  ██░░░░░░▒▒▒▒░░▒▒▒▒▒▒▒▒▒▒████▓▓▒▒▒▒▒▒▒▒▒▒▒▒▓▓▓▓██▓▓          ");
            sb.AppendLine("                  ██████████████████████████▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓██          ");
            sb.AppendLine("                ██▒▒██▓▓▓▓██████████████▓▓▓▓▒▒▓▓▒▒▒▒▒▒▓▓▒▒▒▒▒▒▒▒▒▒████        ");
            sb.AppendLine("  ██████        ██▒▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒▒▒▒▒▒██▓▓▓▓▒▒▒▒▒▒▒▒▓▓████    ");
            sb.AppendLine("  ██    ██    ██▒▒▒▒▒▒▒▒▒▒▒▒████████████▒▒▓▓▒▒▒▒▒▒▒▒▒▒██▓▓▓▓▒▒▒▒▒▒▒▒▓▓████    ");
            sb.AppendLine("██░░  ░░░░████▒▒▒▒▒▒▒▒▒▒▒▒██░░░░░░░░░░░░████▒▒▒▒▒▒▒▒▒▒▓▓██▓▓▓▓▒▒▒▒▒▒▒▒▓▓████  ");
            sb.AppendLine("██  ░░░░██████▒▒▒▒▒▒██▒▒▒▒██░░      ░░░░░░████▒▒▒▒▒▒▒▒▓▓████▓▓▓▓▒▒▒▒▒▒▒▒▓▓██  ");
            sb.AppendLine("██░░░░▒▒██▒▒▒▒██▒▒▓▓██▒▒██░░▒▒░░██  ░░▒▒░░░░██▒▒▓▓▒▒▓▓██████████▒▒▒▒▓▓▒▒▓▓██  ");
            sb.AppendLine("  ████████▒▒▒▒▓▓▓▓▓▓██▒▒████████▒▒████████████▒▒▓▓▓▓██████████████▒▒▒▒▒▒▒▒▓▓  ");
            sb.AppendLine("  ██▒▒██▒▒▒▒▒▒▓▓▓▓████▓▓▒▒████      ░░██████▓▓▓▓▓▓██▒▒▒▒▒▒▓▓██████▓▓▒▒████▓▓  ");            
            image = sb.ToString();
        }

        public override void MoveAction()
        {
            if (moveCount++ % 2 != 0)
                return;

            if (point.x - 3 < Data.player.point.x && point.y - 3 < Data.player.point.y)
            {
                List<Point> path;
                bool result = AStar.PathFinding(Data.map, new Point(point.x, point.y),
                    new Point(Data.player.point.x, Data.player.point.y), out path);

                if (!result)
                    return;

                if (path[1].y == point.y - 1)
                    Move(Direction.Up);
                else if (path[1].y == point.y + 1)
                    Move(Direction.Down);
                else if (path[1].x == point.x - 1)
                    Move(Direction.Left);
                else
                    Move(Direction.Right);
            }            
        }
    }
}
