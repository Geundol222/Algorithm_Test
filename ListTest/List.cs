using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListTest
{
    public class List<T>        // List 클래스 선언
    {
        private int DefaultCapacity = 10;

        private T[] items;
        private int size;

        public List()       // List 생성자 선언
        {
            this.items = new T[DefaultCapacity];
            this.size = 0;
        }

        public void Add(T item)     // Add 함수 구현
        {
            if (size < items.Length)
            {
                items[size++] = item;
            }
            else
            {
                Grow();     // size가 items.Length 보다 커졌을 경우 Grow함수를 호출해 새로운 배열을 생성 후 Add 진행
                items[size++] = item;
            }
        }

        private void Grow()     // List에서 Add 도중 Capacity 범위를 벗어난 경우 새로운 배열 생성을 위한 함수
        {
            int newCap = items.Length * 2;
            T[] newItems = new T[newCap];
            Array.Copy(items, 0, newItems, 0, size);
            items = newItems;
        }

        public bool Remove(T item)
        {
            int index = IndexOF(item);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= items.Length)
                throw new IndexOutOfRangeException();

            size--;
            Array.Copy(items, index + 1, items, index, size - index);
        }

        public int IndexOF(T index)
        {
            return Array.IndexOf(items, index, 0, size);
        }
    }
}
