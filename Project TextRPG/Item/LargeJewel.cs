using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class LargeJewel : Item
    {
        public LargeJewel()
        {
            name = "큰 보석";
            description = $"큰 보석, 꽤나 가치가 있을거 같이 생겼다.";
            price = 50;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("      ██████████████      ");
            sb.AppendLine("    ██    ░░░░░░▒▒▒▒██    ");
            sb.AppendLine("  ██    ░░░░░░░░░░▒▒▒▒██  ");
            sb.AppendLine("██    ░░░░░░░░        ▒▒██");
            sb.AppendLine("██████▒▒▒▒▒▒▒▒▒▒▒▒░░░░░░██");
            sb.AppendLine("  ██████▒▒▒▒▒▒▒▒░░░░░░██  ");
            sb.AppendLine("    ██████▒▒▒▒▒▒░░░░██    ");
            sb.AppendLine("      ████▒▒▒▒░░░░██      ");
            sb.AppendLine("        ████░░░░██        ");
            sb.AppendLine("          ██░░██          ");
            sb.AppendLine("            ██            ");
            image = sb.ToString();
        }

        public override bool Use()
        {
            Console.Clear();
            Console.WriteLine("보석은 먹을 수 없어...");
            Thread.Sleep(1000);
            return false;
        }
    }
}
