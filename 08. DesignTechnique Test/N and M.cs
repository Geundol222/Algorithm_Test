using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08._DesignTechnique_Test
{
    public class N_and_M
    {
        int num;
        int count;
        int[] array;
        StringBuilder sb = new StringBuilder();

        public void Run()
        {
            string str = Console.ReadLine();
            string[] number = str.Split(' ');

            num = int.Parse(number[0]);
            count = int.Parse(number[1]);
            array = new int[count];

            
        }
    }
}
