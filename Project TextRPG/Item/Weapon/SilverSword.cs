using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class SilverSword : Sword
    {
        public SilverSword()
        {
            name = "실버 소드";
            description = "은으로 만든 검, 적당한 공격력을 가지고 있다.";
            price = 800;
            ap = 30;
            type = ItemType.Weapon;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("                          ▓▓▓▓▓▓");
            sb.AppendLine("    I'm Silver          ▓▓  ▒▒▓▓");
            sb.AppendLine("                      ▓▓  ▒▒  ▓▓");
            sb.AppendLine("           ░░       ▓▓  ▒▒  ▓▓  ");
            sb.AppendLine("         ░░  ░░   ▓▓  ▒▒  ▓▓    ");
            sb.AppendLine("           ░░   ▓▓  ▒▒  ▓▓      ");
            sb.AppendLine("    ▓▓▓▓      ▓▓  ▒▒  ▓▓        ");
            sb.AppendLine("    ▓▓▒▒▓▓  ▓▓  ▒▒  ▓▓          ");
            sb.AppendLine("      ▓▓▒▒▓▓  ▒▒  ▓▓            ");
            sb.AppendLine("      ▓▓▒▒▓▓▒▒  ▓▓      ░░      ");
            sb.AppendLine("        ▓▓▒▒▓▓▓▓      ░░  ░░    ");
            sb.AppendLine("      ▓▓▓▓▓▓▒▒▒▒▓▓      ░░      ");
            sb.AppendLine("    ▓▓▓▓██  ▓▓▓▓▒▒▓▓            ");
            sb.AppendLine("▓▓▓▓▓▓██        ▓▓▓▓            ");
            sb.AppendLine("▓▓  ▓▓                          ");
            sb.AppendLine("▓▓▓▓▓▓                          ");
            image = sb.ToString();
        }
    }
}
