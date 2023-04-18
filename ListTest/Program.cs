using System.Security.Cryptography.X509Certificates;

namespace ListTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataStructure.List<int> list = new DataStructure.List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            int[] intArr = new int[10];

            list.CopyTo(intArr, 2);
        }
    }
}