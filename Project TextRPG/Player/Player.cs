using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class Player
    {
        public char icon = '★';
        public Point point;

        public string name { get; set; }
        public int curHp { get; set; }
        public int maxHp { get; set; }
        public int curMp { get; set; }
        public int maxMp { get; set; }
        public int level { get; set; }
        public int gold { get; set; }
        public int ap { get; set; }
        public int dp { get; set; }
        public float exp { get; set; }
    }
}
