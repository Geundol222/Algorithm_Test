using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack___Queue_Test
{
    public class Player
    {
        Random rand = new Random();
        private int speed;

        public Player()
        {
            speed = rand.Next(1, 100);
        }

        public int Speed { get { return speed; } }
    }
}
