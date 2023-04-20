namespace IteratorTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Iterator.List<int> list = new Iterator.List<int>();
            for (int i = 1; i <= 5; i++) list.Add(i);

            foreach(int i in list)
            {
                Console.WriteLine(i);
            }
        }
    }
}