using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class Mage : Player
    {
        public Mage()
        {
            className = "마법사";
            level = Data.player.level;
            maxHp = Data.player.maxHp / 2;
            maxMp = Data.player.maxMp * 2;
            curHp = maxHp;
            curMp = maxMp;
            speed = Data.player.speed;
            ap = Data.player.ap + 20;
            dp = Data.player.dp + 5;
            gold = Data.player.gold;
            exp = 0;
            deathCount = Data.player.deathCount;
            description = "길드장 : 마법사.. 이것 저것 터뜨리기엔 딱이지";

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("                    ▒▒                ▓▓████                               ");
            sb.AppendLine("░░░░                                ░░▒▒▒▒██                ▒▒             ");
            sb.AppendLine("  ░░                                ▒▒▒▒▒▒░░          ░░░░  ▓▓  ░░░░       ");
            sb.AppendLine("                                  ░░▒▒▒▒▒▒              ▓▓▓▓▓▓▓▓▓▓         ");
            sb.AppendLine("                                  ▒▒▒▒▒▒                ▒▒▓▓▓▓▓▓▒▒         ");         
            sb.AppendLine("                                ██████░░            ░░▒▒▓▓▓▓▓▓▓▓▓▓▒▒       ");         
            sb.AppendLine("            ░░░░░░            ▒▒████▓▓                  ▓▓▓▓▓▓▓▓▓▓         ");         
            sb.AppendLine("            ░░░░░░            ██████                  ▒▒▒▒  ▓▓  ▒▒░░       ");         
            sb.AppendLine("            ░░░░░░          ▓▓████░░                        ▒▒             ");         
            sb.AppendLine("              ░░            ████▓▓                                         ");         
            sb.AppendLine("                          ▒▒████                                           ");         
            sb.AppendLine("                          ████▓▓              ░░░░                    ░░░░ ");         
            sb.AppendLine("                        ▒▒████                                             ");         
            sb.AppendLine("                        ████                                               ");         
            sb.AppendLine("                      ▓▓██▓▓                                               ");         
            sb.AppendLine("                      ████░░                                               ");         
            sb.AppendLine("                    ██████                                                 ");         
            sb.AppendLine("                  ░░████                                                   ");         
            sb.AppendLine("                  ████▓▓                                                   ");         
            sb.AppendLine("                ▓▓████                                                     ");       
            image = sb.ToString();
        }
    }
}
