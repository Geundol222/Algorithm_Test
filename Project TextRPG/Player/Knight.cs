using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class Knight : Player
    {
        public Knight()
        {
            className = "기사";
            level = Data.player.level;
            maxHp = Data.player.maxHp * 2;
            maxMp = Data.player.maxMp / 2;
            curHp = maxHp;
            curMp = maxMp;
            speed = Data.player.speed - 2;
            ap = Data.player.ap + 5;
            dp = Data.player.dp + 10;
            gold = Data.player.gold;
            exp = 0;
            deathCount = Data.player.deathCount;
            description = "길드장 : 기사.. 좋은 직업이지 높은 방어력으로 잘 죽지 않는다네";

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("                    ▒▒                    ");
            sb.AppendLine("                  ▒▒░░▒▒                  ");
            sb.AppendLine("              ▒▒▒▒▒▒░░░░▒▒▒▒              ");
            sb.AppendLine("          ▒▒▓▓▒▒▒▒▒▒░░░░░░░░▒▒▓▓          ");
            sb.AppendLine("        ▒▒▒▒▒▒▒▒▒▒▒▒░░░░░░░░░░░░▓▓        ");
            sb.AppendLine("      ▒▒▒▒▒▒▒▒▒▒▒▒▒▒░░░░░░░░░░░░░░▒▒      ");
            sb.AppendLine("    ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░░░░░░░░░░░░░░░░▒▒    ");
            sb.AppendLine("    ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░░░░░░░░░░░░░░░░▒▒    ");
            sb.AppendLine("    ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░░░░░░░░░░░░░░░░▒▒    ");
            sb.AppendLine("  ▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░░░░░░░░░░  ░░░░▒▒  ");
            sb.AppendLine("  ▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓░░░░░░░░░░░░░░▓▓  ");
            sb.AppendLine("  ▓▓▒▒▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒  ");
            sb.AppendLine("  ▓▓▒▒▓▓▒▒▒▒▒▒▒▒▓▓██░░██▓▓░░░░░░░░░░░░▒▒  ");
            sb.AppendLine("  ▓▓▒▒██▒▒██▒▒██▒▒██░░██░░██░░██  ██░░▒▒  ");
            sb.AppendLine("  ▓▓▒▒██▒▒██▒▒██▒▒██░░██░░██░░██░░██░░▒▒  ");
            sb.AppendLine("  ▓▓▒▒██▒▒██▒▒██▒▒██░░██░░██░░██░░██▒▒▒▒  ");
            sb.AppendLine("    ▓▓██▒▒██▒▒██▒▒██░░██░░██░░██▒▒██░░▒▒  ");
            sb.AppendLine("    ▒▒▓▓▒▒██▒▒██▒▒██░░██░░██▒▒██  ██▓▓    ");
            sb.AppendLine("      ▓▓▒▒██▓▓██▒▒██▒▒██▒▒██  ██▒▒▒▒      ");
            sb.AppendLine("        ▒▒▒▒▒▒██▒▒██▒▒██░░██▒▒▒▒▒▒        ");
            sb.AppendLine("        ▓▓▒▒▒▒▒▒▒▒██░░▓▓▒▒▒▒▒▒▒▒▓▓        ");
            sb.AppendLine("      ▓▓▓▓▓▓▒▒▒▒▒▒██░░██▒▒▒▒▒▒▓▓▓▓▒▒      ");
            sb.AppendLine("    ▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒▒▒▒▓▓▓▓▒▒▒▒▒▒▒▒    ");
            sb.AppendLine("  ▓▓▓▓▒▒▒▒▓▓▓▓▓▓▓▓▒▒▒▒▒▒▓▓▒▒▒▒▓▓░░░░▒▒▒▒  ");
            image = sb.ToString();

        }
    }
}
