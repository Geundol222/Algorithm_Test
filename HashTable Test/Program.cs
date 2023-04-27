namespace HashTable_Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataStructure.Dictionary<int, int> dic = new DataStructure.Dictionary<int, int>();

            dic.Add(1, 1);
            dic.Add(2, 2);
            dic.Add(3, 3);
            dic.Add(4, 4);
            dic.Add(5, 5);            
            dic.Add(6, 6);

            dic.Remove(6);

            dic.Add(6, 8);

            dic[3] = 5;

            Console.WriteLine(dic[3]);
        }
    }
}