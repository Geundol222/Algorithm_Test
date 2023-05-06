using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class Slime : Monster
    {
        private Random rand = new Random();
        private int moveTurn = 0;

        public Slime()
        {
            name = "슬라임";
            curHp = 25;
            maxHp = 25;
            ap = 5;
            dp = 1;
            speed = 3;
            gold = 20;
            exp = 20;

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("             ░░░░░░░░░░              ");
            sb.AppendLine("        ░░░░        ░░░░░░           ");
            sb.AppendLine("      ░░                  ░░         ");
            sb.AppendLine("    ░░                    ░░░░       ");
            sb.AppendLine("  ░░                      ░░░░░░     ");
            sb.AppendLine("  ░░                        ░░░░     ");
            sb.AppendLine("░░                ░░    ░░  ░░░░░░   ");
            sb.AppendLine("░░                ██░░  ██    ░░░░   ");
            sb.AppendLine("░░                ██░░  ██    ░░░░   ");
            sb.AppendLine("░░            ░░            ░░░░░░   ");
            sb.AppendLine("░░░░░░                      ░░░░░░   ");
            sb.AppendLine("  ░░░░░░                  ░░░░░░     ");
            sb.AppendLine("  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░     ");
            sb.AppendLine("      ░░░░░░░░░░░░░░░░░░░░░░         ");
            image = sb.ToString();
        }

        public override void MoveAction()
        {
            if (moveTurn++ < 3)
            {
                return;
            }
            moveTurn = 0;

            switch (rand.Next(0, 4))
            {
                case 0:
                    Move(Direction.Up);
                    break;
                case 1:
                    Move(Direction.Down);
                    break;
                case 2:
                    Move(Direction.Left);
                    break;
                case 3:
                    Move(Direction.Right);
                    break;
            }
        }
    }
}
