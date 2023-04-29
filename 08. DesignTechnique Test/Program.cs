using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;

namespace _08._DesignTechnique_Test
{
    internal class Program
    {
        static int whiteCount = 0;
        static int blueCount = 0;
        static int[,] paper;

        static void ColorPaper(int x , int y, int n)
        {
            if (ColorCheck(x, y, n))
            {
                if (paper[x, y] == 0)
                    whiteCount++;
                else
                    blueCount++;

                return;
            }

            int newSize = n / 2;
            
            ColorPaper(x, y, newSize);
            ColorPaper(x, y + newSize, newSize);
            ColorPaper(x + newSize, y, newSize);
            ColorPaper(x + newSize, y + newSize, newSize);
        }

        static bool ColorCheck(int x, int y, int n)
        {
            int color = paper[x, y];

            for (int i = x; i < x + n; i++)
            {
                for (int j = y; j < y + n; j++)
                {
                    if (paper[i, j] != color)
                        return false;
                }
            }

            return true;
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            paper = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    paper[i, j] = int.Parse(Console.ReadLine());
                }
            }

            ColorPaper(0, 0, n);

            Console.WriteLine(whiteCount);
            Console.WriteLine(blueCount);
        }
    }
}