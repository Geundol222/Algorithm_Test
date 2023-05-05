using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public static class Data
    {
        public static Player player;

        public static void Init()
        {
            player = new Player();
        }

        public static void Release()
        {

        }
    }
}
