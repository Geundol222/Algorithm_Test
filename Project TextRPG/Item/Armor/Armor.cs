using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class Armor : Item
    {
        public int dp { get; protected set; }

        public override void Equip()
        {
            Data.player.GetDp(dp);
        }
    }
}
