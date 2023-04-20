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

        static T[] Sort<T>(IEnumerable<T> list) where T : IComparable       // IEnumerable 인터페이스를 매개변수로 지정하고 IComparable을 제한자로 두어서 비교가 가능한 자료형만 해당 함수에 들어올 수 있게 하는 Sort함수 구현
        {
            // 매개변수로 들어온 자료형을 array로 변환 후 Bubble Sort를 진행한다.
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

        static double Average(IEnumerable<int> list)    // int자료형을 가지는 IEnumerable 인터페이스로 하는 평균값 계산 함수
        {
            // 매개변수로 들어온 자료형을 array로 변환 후 평균값을 계산한다.
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