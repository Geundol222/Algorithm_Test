using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class LargeManaPotion : Stuff
    {
        public LargeManaPotion()
        {
            point = 30;
            name = "마나 포션";
            description = $"커다란 마나 포션, 플레이어의 마나를 {point}회복시킨다.";
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
            sb.AppendLine("▒▒        MANA        ▒▒");
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
                Console.WriteLine("이미 마나가 전부 차있습니다.");
                Thread.Sleep(1000);
                return false;
            }
            else
            {
                Console.WriteLine("포션을 사용합니다.");
                Thread.Sleep(1000);
                Console.WriteLine($"플레이어의 마나가 {point}만큼 회복됩니다.");
                Thread.Sleep(1000);
                Data.player.curMp += point;

                if (Data.player.curMp > Data.player.maxMp)
                    Data.player.curMp = Data.player.maxMp;

                Console.WriteLine($"현재 마나 : {Data.player.curMp} / {Data.player.maxMp}");
                Thread.Sleep(1000);
                return true;
            }
        }
    }
}
