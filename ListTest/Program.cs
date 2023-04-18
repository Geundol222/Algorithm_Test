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
            list.Add(5);
            list.Add(6);
            list.Add(7);
            list.Add(8);
            list.Add(9);
            list.Add(10);

            list.Insert(6, 105);
        }
    }
}