using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;

namespace _08._DesignTechnique_Test
{
    internal class Program
    {
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