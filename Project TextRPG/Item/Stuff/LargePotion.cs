using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class LargePotion : Stuff
    {
        public LargePotion()
        {
            point = 30;
            name = "큰포션";
            description = $"커다란 포션, 플레이어의 체력을 {point}회복시킨다.";
            price = 10;
            type = ItemType.Stuff;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("        ████████        ");
            sb.AppendLine("    ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒    ");
            sb.AppendLine("    ▒▒▒▒████████▒▒▒▒    ");
            sb.AppendLine("      ▒▒        ▒▒      ");
            sb.AppendLine("      ▒▒        ▒▒      ");
            sb.AppendLine("    ▒▒            ▒▒    ");
            sb.AppendLine("  ▒▒                ▒▒  ");
            sb.AppendLine("▒▒                    ▒▒");
            sb.AppendLine("▒▒        HEAL        ▒▒");
            sb.AppendLine("▒▒                ▒▒  ▒▒");
            sb.AppendLine("▒▒                ▒▒  ▒▒");
            sb.AppendLine("▒▒              ▒▒  ▒▒▒▒");
            sb.AppendLine("▒▒              ▒▒  ▒▒▒▒");
            sb.AppendLine("    ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒    ");
            image = sb.ToString();
        }

        public override bool Use()
        {
            Console.Clear();

            if (Data.player.curHp >= Data.player.maxHp)
            {
                Console.WriteLine("이미 체력이 전부 차있습니다.");
                Thread.Sleep(1000);
                return false;
            }
            else
            {
                Console.WriteLine("포션을 사용합니다.");
                Thread.Sleep(1000);
                Console.WriteLine($"플레이어의 체력이 {point}만큼 회복됩니다.");
                Thread.Sleep(1000);
                Data.player.curHp += point;

                if (Data.player.curHp > Data.player.maxHp)
                    Data.player.curHp = Data.player.maxHp;

                Console.WriteLine($"현재 체력 : {Data.player.curHp} / {Data.player.maxHp}");
                Thread.Sleep(1000);
                return true;
            }
        }
    }
}
