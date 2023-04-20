namespace IteratorTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Iterator.List<int> list = new Iterator.List<int>();
            for (int i = 5; i >= 1; i--) list.Add(i);

            foreach(int i in list)
                Console.WriteLine(i);

            Console.WriteLine();

            Iterator.LinkedList<int> linkedList = new Iterator.LinkedList<int>();
            for (int i = 5; i >= 1; i--) linkedList.AddLast(i);

            foreach (int i in linkedList)
                Console.WriteLine(i);

            Console.WriteLine();

            int[] listArr = Sort(list);
            int[] linkedListArr = Sort(linkedList);
            int[] array = { 2, 3, 4, 5, 8, 6, 7 };

            int[] sortedArr = Sort(array);

            double arrAvg = Average(array);
            double listAvg = Average(list);
            double linkedListAvg = Average(linkedList);

            Console.WriteLine(arrAvg);
        }

        static T[] Sort<T>(IEnumerable<T> list) where T : IComparable
        {
            T[] array = list.ToArray();

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i; j < array.Length; j++)
                {
                    if (array[i].CompareTo(array[j]) > 0)
                    {
                        T temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }

            return array;
        }

        static double Average(IEnumerable<int> list)
        {
            int sum = 0;
            double avg = 0;
            int[] array = list.ToArray();

            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum / array.Length;
        }
    }
}