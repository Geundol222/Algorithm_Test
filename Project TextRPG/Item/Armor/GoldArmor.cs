using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class GoldArmor : Armor
    {
        public GoldArmor()
        {
            name = "골드 아머";
            description = "금으로 만든 아머, 강한 방어력을 가지고 있다.";
            price = 1000;
            dp = 20;
            type = ItemType.Armor;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("      ████        ████      ");
            sb.AppendLine("  ████░░░░██    ██░░░░████  ");
            sb.AppendLine("██░░░░░░░░██    ██░░░░░░▒▒██");
            sb.AppendLine("██░░░░░░░░░░████░░░░░░░░▒▒██");
            sb.AppendLine("██▒▒░░    ░░▓▓▓▓░░░░░░▒▒▒▒██");
            sb.AppendLine("  ██░░  ░░░░▓▓▓▓░░░░▒▒▒▒██  ");
            sb.AppendLine("  ██▒▒░░░░░░░░░░░░░░▒▒▒▒██  ");
            sb.AppendLine("    ██░░░░░░▓▓▓▓░░░░▒▒██    ");
            sb.AppendLine("    ██░░░░░░▓▓▓▓░░▒▒▒▒██    ");
            sb.AppendLine("    ██▒▒░░░░░░░░▒▒▒▒▒▒██    ");
            sb.AppendLine("    ██▒▒▒▒▒▒████▒▒▒▒▒▒██    ");
            sb.AppendLine("      ██▒▒▒▒████▒▒▒▒██      ");
            sb.AppendLine("        ████████████        ");
            sb.AppendLine("          I'm Gold          ");
            image = sb.ToString();
        }
    }
}
