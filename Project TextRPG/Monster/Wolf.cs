using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class Wolf : Monster
    {
        int moveCount;

        public Wolf()
        {
            icon = '◆';

            name = "늑대";
            curHp = 50;
            maxHp = 50;
            ap = 10;
            dp = 2;
            speed = 7;
            gold = 150;
            exp = 20;

            StringBuilder sb = new StringBuilder();         
            sb.AppendLine("                                                             ▓▓▓▓  ▓▓▓▓░░                 ");
            sb.AppendLine("                                                           ▒▒▓▓▓▓▓▓▓▓▓▓▓▓                 ");
            sb.AppendLine("                                                           ▒▒▓▓▓▓▓▓██▓▓▓▓██               ");
            sb.AppendLine("                                                 ██████▒▒  ██░░▒▒▓▓██▓▓▓▓██               ");
            sb.AppendLine("                                             ░░██▓▓▓▓▓▓▓▓██▓▓░░░░▒▒▓▓██▓▓▓▓▒▒             ");
            sb.AppendLine("                                           ██▓▓▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░░░▒▒▓▓▓▓▒▒▓▓▒▒▒▒         ");
            sb.AppendLine("                                             ██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░░░▒▒░░░░▒▒▓▓▒▒░░       ");
            sb.AppendLine("                                             ░░██▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒░░░░░░░░░░░░░░▓▓░░       ");
            sb.AppendLine("                                                 ██▓▓▓▓▓▓▓▓░░░░░░░░░░░░░░░░▒▒░░░░▒▒▓▓▓▓   ");
            sb.AppendLine("           ▒▒▒▒▒▒▒▒▒▒▒▒                          ▓▓▓▓▓▓▓▓▓▓░░░░░░░░░░░░░░░░▓▓░░░░░░▒▒██▒▒ ");
            sb.AppendLine("   ████████▒▒▒▒▒▒▒▒▒▒▒▒▒▒████                  ▓▓▓▓▓▓▓▓▓▓▓▓██░░░░░░░░░░░░░░▒▒░░░░░░░░████ ");
            sb.AppendLine(" ██▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▓▓▓▓▓          ██░░░░████▓▓▓▓▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░██ ");
            sb.AppendLine("   ░░▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▒▒    ░░░░░░░░░░░░▓▓▓▓██▒▒▒▒░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒ ");
            sb.AppendLine("   ░░▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓████▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▓▓██░░▓▓░░░░░░░░▒▒██       ");
            sb.AppendLine("   ░░▒▒░░▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▒▒░░░░░░░░▓▓         ");
            sb.AppendLine("     ▓▓██░░░░░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒░░░░░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒░░░░▒▒██           ");
            sb.AppendLine("         ████░░░░░░▓▓▓▓▓▓░░░░░░██████▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒░░░░▒▒▒▒▓▓         ");
            sb.AppendLine("         ░░░░▓▓▓▓░░▒▒▒▒▒▒░░▓▓▓▓░░░░░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒░░░░░░░░▒▒▒▒       ");
            sb.AppendLine("                 ▒▒▒▒▒▒▒▒▒▒          ▓▓▓▓▓▓░░░░▒▒▒▒▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▓▓▒▒░░░░░░░░▓▓▒▒▓▓     ");
            sb.AppendLine("                                   ██▓▓▓▓░░░░░░░░░░▒▒▒▒▓▓▓▓░░░░░░░░▒▒▓▓▓▓░░░░░░▓▓▓▓░░▒▒   ");
            sb.AppendLine("                                   ██▓▓▒▒░░░░░░░░░░░░░░░░░░░░░░░░▓▓░░▓▓▓▓▓▓▓▓██▒▒▒▒░░░░▓▓ ");
            sb.AppendLine("                                   ██▓▓▓▓▒▒░░▓▓░░░░░░░░░░░░░░░░▓▓▓▓▓▓▓▓▓▓██░░  ██████████ ");
            sb.AppendLine("                             ░░████▓▓▓▓▓▓▒▒░░██████░░░░░░░░▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▒▒             ");
            sb.AppendLine("                             ▓▓▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓  ▓▓▓▓▓▓▓▓    ▓▓▓▓▓▓▓▓▓▓▒▒▒▒             ");
            sb.AppendLine("                           ░░░░░░▒▒▓▓▓▓▓▓██████                    ██▒▒░░░░░░██           ");
            sb.AppendLine("                           ▒▒░░░░▒▒░░▒▒                              ░░░░░░░░░░▒▒         ");
            sb.AppendLine("                         ▓▓░░░░░░▒▒                                      ██▒▒░░▓▓         ");
            sb.AppendLine("                         ██░░  ██                                            ██           ");
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
