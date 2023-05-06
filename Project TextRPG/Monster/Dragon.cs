using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class Dragon : Monster
    {
        private int moveCount;

        public Dragon()
        {
            icon = '♠';

            name = "드래곤";
            curHp = 1000;
            maxHp = 1000;
            ap = 100;
            dp = 50;
            speed = 7;
            gold = 3000;
            exp = 300;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("                        ██████████  ████████                                                                ");
            sb.AppendLine("                      ██▒▒▒▒▒▒▒▒▒▒██▒▒▒▒▒▒▒▒██████                                                          ");
            sb.AppendLine("                        ██▒▒▒▒▒▒▒▒▒▒██▒▒▒▒▒▒▒▒▒▒▒▒████                                                      ");
            sb.AppendLine("                    ██    ██▒▒▒▒██████▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒████                                                  ");
            sb.AppendLine("                  ████    ██████▒▒██▒▒▒▒████▒▒▒▒██▒▒▒▒▒▒▒▒████                                              ");
            sb.AppendLine("                ██▒▒██████▒▒▒▒▒▒██▒▒▒▒██▒▒▒▒██▒▒▒▒██▒▒▒▒██▒▒▒▒██                                            ");
            sb.AppendLine("      ██      ████▒▒██▒▒▒▒▒▒▒▒▒▒▒▒▒▒██▒▒▒▒▒▒▒▒██▒▒▒▒██▒▒▒▒██▒▒▒▒██                                          ");
            sb.AppendLine("      ██████  ████▒▒██▒▒▒▒▒▒████▒▒▒▒▒▒▒▒▒▒▒▒▒▒████▒▒████▒▒▒▒██▒▒▒▒██                                        ");
            sb.AppendLine("      ██▒▒████▒▒██▒▒██▒▒████▒▒██▒▒▒▒▒▒▒▒▒▒▒▒██▒▒▒▒████▒▒██▒▒████▒▒██                                        ");
            sb.AppendLine("      ██▒▒▒▒██▒▒██▒▒▒▒██▒▒▒▒██▒▒██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██▒▒██▒▒██  ██▒▒██                                      ");
            sb.AppendLine("        ██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██████▒▒▒▒▒▒▒▒██▒▒▒▒▒▒▒▒▒▒██▒▒▒▒████  ██▒▒██                                      ");
            sb.AppendLine("          ██▒▒▒▒▒▒▒▒▓▓▒▒▒▒▒▒██████▒▒▒▒▒▒██▒▒▒▒▒▒████████▒▒▒▒▒▒██  ██▒▒██                                    ");
            sb.AppendLine("          ██▒▒▒▒▒▒▒▒░░▓▓▒▒████▒▒▒▒██▒▒██▒▒▒▒████▒▒▒▒▒▒▒▒██▒▒▒▒██  ██▒▒██                                    ");
            sb.AppendLine("  ██████████▒▒▒▒▒▒▒▒░░░░▒▒████▒▒▒▒██▒▒██▒▒██▒▒▒▒▒▒▒▒▒▒▒▒▒▒██▒▒▒▒██  ████                                    ");
            sb.AppendLine("    ██████████▒▒▒▒▒▒▒▒░░▒▒██  ██▒▒▒▒██████▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██▒▒▒▒██  ████                ██████████████      ");
            sb.AppendLine("            ██████▒▒▒▒▒▒▒▒██  ██▒▒▒▒██▒▒██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██▒▒██    ██          ████████▒▒▒▒▒▒▒▒▒▒▒▒██    ");
            sb.AppendLine("          ████    ██▒▒▒▒▒▒██  ██▒▒▒▒▒▒██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██              ████▒▒▒▒▒▒▒▒██████████▒▒██  ");
            sb.AppendLine("          ██      ████▒▒▒▒██  ██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██          ██████▒▒▒▒▒▒████        ████▒▒██");
            sb.AppendLine("                ██▒▒▒▒████  ██▒▒██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██▒▒██        ████▒▒▒▒▒▒▒▒██              ██████");
            sb.AppendLine("              ██▒▒▒▒▒▒▒▒██  ██▒▒▒▒██▒▒▒▒▒▒██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██▒▒▒▒██    ████▒▒▒▒▒▒▒▒██                ██████");
            sb.AppendLine("            ██▒▒▒▒▒▒▒▒██    ██▒▒▒▒▒▒████████▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██▒▒▒▒▒▒██████▒▒▒▒▒▒▒▒██                    ████");
            sb.AppendLine("          ██▒▒▒▒▒▒▒▒██    ██▒▒▒▒▒▒▒▒██      ██▒▒▒▒▒▒▒▒▒▒▒▒▒▒██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██                          ");
            sb.AppendLine("        ██▒▒▒▒▒▒▒▒██      ██▒▒▒▒▒▒██        ████▒▒▒▒▒▒▒▒▒▒▒▒██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██                            ");
            sb.AppendLine("      ██▒▒▒▒▒▒▒▒██      ██▒▒▒▒▒▒▒▒██  ██████▒▒▒▒██▒▒▒▒▒▒▒▒██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██                              ");
            sb.AppendLine("        ████████        ██▒▒▒▒▒▒██  ██▒▒▒▒▒▒▒▒▒▒▒▒████████  ████▒▒▒▒▒▒██████                                ");
            sb.AppendLine("                          ██████      ████████████              ██████                                      ");
            image = sb.ToString();

        }

        public override void MoveAction()
        {
            if (moveCount++ % 2 != 0)
                return;

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
