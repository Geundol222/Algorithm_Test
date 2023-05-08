using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class Archor : Player
    {
        public Archor()
        {
            className = "궁수";
            level = Data.player.level;
            maxHp = Data.player.maxHp;
            maxMp = Data.player.maxMp;
            curHp = maxHp;
            curMp = maxMp;
            speed = 10;
            ap = Data.player.ap + 10;
            dp = Data.player.dp + 10;
            gold = Data.player.gold;
            exp = 0;
            deathCount = Data.player.deathCount;
            description = "길드장 : 궁수라.. 자네는 빠릿빠릿한걸 좋아하나보지?";

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("▓▓                              ");
            sb.AppendLine("▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓                ");
            sb.AppendLine("  ░░        ████▓▓              ");
            sb.AppendLine("    ░░          ██▓▓            ");
            sb.AppendLine("      ░░          ██▓▓          ");
            sb.AppendLine("        ░░          ██▓▓        ");
            sb.AppendLine("          ░░          ██▓▓      ");
            sb.AppendLine("            ░░          ██▓▓    ");
            sb.AppendLine("              ░░          ██▓▓  ");
            sb.AppendLine("                ░░        ████  ");
            sb.AppendLine("                  ░░        ██  ");
            sb.AppendLine("                    ░░      ██  ");
            sb.AppendLine("                      ░░    ██  ");
            sb.AppendLine("                        ░░  ██  ");
            sb.AppendLine("                          ░░██  ");
            sb.AppendLine("                            ████");
            
            image = sb.ToString();
        }
    }
}
