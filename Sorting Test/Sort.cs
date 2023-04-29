using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Test
{
    public class Sort
    {
        public void SelectionSort(IList<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                int changeIndex = i;
                for (int j = i; j < list.Count; j++)
                {
                    if (list[j] < list[changeIndex])
                        Swap(list, j, changeIndex);
                }
            }
        }

        public void InsertionSort(IList<int> list)
        {
            for (int i = 1; i < list.Count; i++)
            {
                int target = list[i];
                int j;
                for (j = i - 1; j >=0 && target < list[j]; j--)
                {
                    list[j + 1] = list[j];
                }
                list[j + 1] = target;
            }
        }

        public void BubbleSort(IList<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i; j < list.Count; j++)
                {
                    if (list[i] > list[j])
                        Swap(list, i, j);
                }
            }
        }

        public void HeapSort(IList<int> list)
        {
            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();

            for (int i = 0; i < list.Count; i++)
            {
                pq.Enqueue(list[i], list[i]);
            }

            for (int i = 0; i < list.Count; i++)
            {
                list[i] = pq.Dequeue();
            }
            
        }

        public void QuickSort(IList<int> list, int start, int end)
        {
            if (start >= end) return;

            int pivot = start;
            int i = pivot + 1;
            int j = end;

            while (i <= j)
            {
                while (list[i] <= list[pivot] && i < end)
                    i++;
                while (list[j] >= list[pivot] && j > start)
                    j--;

                if (i < j)
                    Swap(list, i, j);
                else
                    Swap(list, pivot, j);
            }
            QuickSort(list, start, j - 1);
            QuickSort(list, j + 1, end);
        }

        public void Swap(IList<int> list, int left, int right)
        {
            int temp = list[left];
            list[left] = list[right];
            list[right] = temp;
        }
    }
}
