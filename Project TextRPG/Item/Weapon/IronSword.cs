using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class IronSword : Sword
    {
        public IronSword()
        {
            name = "아이언 소드";
            description = "철로 만든 검, 기본적인 공격력을 가지고 있다.";
            price = 500;
            ap = 15;
            type = ItemType.Weapon;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("                          ▓▓▓▓▓▓");  
            sb.AppendLine("    I'm Iron            ▓▓  ▒▒▓▓");  
            sb.AppendLine("                      ▓▓  ▒▒  ▓▓");  
            sb.AppendLine("                    ▓▓  ▒▒  ▓▓  ");  
            sb.AppendLine("                  ▓▓  ▒▒  ▓▓    ");  
            sb.AppendLine("                ▓▓  ▒▒  ▓▓      ");  
            sb.AppendLine("    ▓▓▓▓      ▓▓  ▒▒  ▓▓        ");  
            sb.AppendLine("    ▓▓▒▒▓▓  ▓▓  ▒▒  ▓▓          ");  
            sb.AppendLine("      ▓▓▒▒▓▓  ▒▒  ▓▓            ");  
            sb.AppendLine("      ▓▓▒▒▓▓▒▒  ▓▓              ");  
            sb.AppendLine("        ▓▓▒▒▓▓▓▓                ");  
            sb.AppendLine("      ▓▓▓▓▓▓▒▒▒▒▓▓              ");  
            sb.AppendLine("    ▓▓▓▓██  ▓▓▓▓▒▒▓▓            ");  
            sb.AppendLine("▓▓▓▓▓▓██        ▓▓▓▓            ");  
            sb.AppendLine("▓▓  ▓▓                          ");
            sb.AppendLine("▓▓▓▓▓▓                          ");  
            image = sb.ToString();
        }
    }
}
