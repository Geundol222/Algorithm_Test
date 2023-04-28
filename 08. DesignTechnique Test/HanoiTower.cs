using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08._DesignTechnique_Test
{
    public class HanoiTower
    {
        StringBuilder sb = new StringBuilder();

        public void Move(int n, int start, int end)
        {
            if (n == 1)
            {
                sb.Append($"{start + 1} {end + 1}\n");
                return;
            }

            int remain = 3 - start - end;

            Move(n - 1, start, remain);
            Move(1, start, end);
            Move(n - 1, remain, end);
        }

        public void Main2()
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(Math.Pow(2, n) - 1);
            Move(n, 0, 2);
            Console.WriteLine(sb.ToString());
        }
    }
}
