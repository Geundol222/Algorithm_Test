namespace ListTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();

            list.Find(x => x == 1);
        }
    }
}