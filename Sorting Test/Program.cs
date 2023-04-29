namespace Sorting_Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 9, 3, 5, 4, 2, 7, 6, 8 };

            Sorting_Test.Sort sort = new Sorting_Test.Sort();

            sort.QuickSort(arr, 0, arr.Length - 1);

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }
    }
}