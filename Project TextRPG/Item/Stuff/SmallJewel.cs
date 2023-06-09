﻿using System.Text;

namespace Project_TextRPG
{
    public class SmallJewel : Stuff
    {
        public SmallJewel()
        {
            name = "작은 보석";
            description = $"작은 보석, 가치가 엄청 크지는 않은거 같다.";
            price = 20;
            type = ItemType.Stuff;

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
