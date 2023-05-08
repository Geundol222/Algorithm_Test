using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class IronArmor : Armor
    {
        public IronArmor()
        {
            name = "아이언 아머";
            description = "철로 만든 아머, 기본적인 방어력을 가지고 있다.";
            price = 500;
            dp = 5;
            type = ItemType.Armor;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("                                        ");
            sb.AppendLine("                                        ");
            sb.AppendLine("                                        ");
            sb.AppendLine("            ████        ████            ");
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
            sb.AppendLine("            ██▒▒▒▒████▒▒▒▒██            ");
            sb.AppendLine("              ████████████              ");
            sb.AppendLine("                I'm Iron                ");
            image = sb.ToString();
        }
    }
}
