using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class SilverArmor : Armor
    {
        public SilverArmor()
        {
            name = "실버 아머";
            description = "은으로 만든 아머, 적당한 방어력을 가지고 있다.";
            price = 800;
            dp = 10;
            type = ItemType.Armor;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("                                        ");
            sb.AppendLine("      ░░                                ");
            sb.AppendLine("    ░░  ░░                              ");
            sb.AppendLine("      ░░    ████        ████            ");
            sb.AppendLine("        ████░░░░██    ██░░░░████        ");
            sb.AppendLine("      ██░░░░░░░░██    ██░░░░░░▒▒██      ");
            sb.AppendLine("      ██░░░░░░░░░░████░░░░░░░░▒▒██      ");
            sb.AppendLine("      ██▒▒░░    ░░▓▓▓▓░░░░░░▒▒▒▒██      ");
            sb.AppendLine("        ██░░  ░░░░▓▓▓▓░░░░▒▒▒▒██        ");
            sb.AppendLine("        ██▒▒░░░░░░░░░░░░░░▒▒▒▒██        ");
            sb.AppendLine("          ██░░░░░░▓▓▓▓░░░░▒▒██          ");
            sb.AppendLine("          ██░░░░░░▓▓▓▓░░▒▒▒▒██          ");
            sb.AppendLine("          ██▒▒░░░░░░░░▒▒▒▒▒▒██          ");
            sb.AppendLine("          ██▒▒▒▒▒▒████▒▒▒▒▒▒██          ");
            sb.AppendLine("            ██▒▒▒▒████▒▒▒▒██      ░░    ");
            sb.AppendLine("              ████████████      ░░  ░░  ");
            sb.AppendLine("               I'm Silver         ░░    ");
            image = sb.ToString();
        }
    }
}
