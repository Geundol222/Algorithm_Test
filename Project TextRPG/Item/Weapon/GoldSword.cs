using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class GoldSword : Sword
    {
        public GoldSword()
        {
            name = "골드 소드";
            description = "금으로 만든 검, 강한 공격력을 가지고 있다.";
            price = 1000;
            ap = 60;
            type = ItemType.Weapon;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("                ░░        ▓▓▓▓▓▓");
            sb.AppendLine("    I'm Gold  ░░  ░░    ▓▓  ▒▒▓▓");
            sb.AppendLine("                ░░    ▓▓  ▒▒  ▓▓");
            sb.AppendLine("         ░░         ▓▓  ▒▒  ▓▓  ");
            sb.AppendLine("       ░░  ░░     ▓▓  ▒▒  ▓▓    ");
            sb.AppendLine("         ░░     ▓▓  ▒▒  ▓▓      ");
            sb.AppendLine("    ▓▓▓▓      ▓▓  ▒▒  ▓▓        ");
            sb.AppendLine("    ▓▓▒▒▓▓  ▓▓  ▒▒  ▓▓     ░░   ");
            sb.AppendLine("      ▓▓▒▒▓▓  ▒▒  ▓▓     ░░  ░░ ");
            sb.AppendLine("      ▓▓▒▒▓▓▒▒  ▓▓         ░░   ");
            sb.AppendLine("        ▓▓▒▒▓▓▓▓                ");
            sb.AppendLine("      ▓▓▓▓▓▓▒▒▒▒▓▓              ");
            sb.AppendLine("    ▓▓▓▓██  ▓▓▓▓▒▒▓▓            ");
            sb.AppendLine("▓▓▓▓▓▓██        ▓▓▓▓            ");
            sb.AppendLine("▓▓  ▓▓     ░░                   ");
            sb.AppendLine("▓▓▓▓▓▓   ░░  ░░                 ");
            image = sb.ToString();
        }
    }
}
