using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    public class List<T> : IEnumerable<T>
    {
        private const int DefaultCapacity = 10;

        private T[] items;
        private int size;

        public List()
        {
            this.items = new T[DefaultCapacity];
            this.size = 0;
        }

        public int Count { get { return size; } }
        public int Capacity { get { return items.Length; } }
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= size) throw new ArgumentOutOfRangeException("index");

                return items[index];
            }
            set
            {
                if (index < 0 || index >= size)
                    throw new ArgumentOutOfRangeException("index");

                items[index] = value;
            }
        }

        public void Add(T item)
        {
            if (size < items.Length)
            {
                items[size++] = item;
            }
            else
            {
                Grow(); items[size++] = item;
            }
        }

        private void Grow()
        {
            int newCap = items.Length * 2;
            T[] newItems = new T[newCap];
            Array.Copy(items, 0, newItems, 0, size);
            items = newItems;
        }

        public bool Remove(T item)
        {
            int index = IndexOF(item); if (index >= 0)
            {
                RemoveAt(index); return true;
            }
            else
            {
                return false;
            }
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= items.Length) throw new IndexOutOfRangeException();

            size--;
            Array.Copy(items, index + 1, items, index, size - index);
        }

        public int IndexOF(T item)
        {
            return Array.IndexOf(items, item, 0, size);
        }

        public T? Find(Predicate<T> match)
        {
            if (match == null)
                throw new ArgumentNullException("match");
            for (int i = 0; i < size; i++)
            {
                if (match(items[i])) return items[i];
            }

            return default(T);
        }

        public int FindIndex(int startIndex, int count, Predicate<T> match)
        {
            if (match == null)
                throw new ArgumentNullException("match");
            for (int i = startIndex; i < count; i++)
            {
                if (match(items[i])) return i;
            }

            return -1;
        }

        public void Clear()
        {
            int clearCap = items.Length; T[] clearItems = new T[clearCap]; items = clearItems;
        }

        public bool Contains(T item)
        {
            int index = IndexOF(item); if (index >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public T? FindLast(Predicate<T> match)
        {
            if (match == null)
                throw new ArgumentNullException("match");
            for (int i = size; i >= 0; i--)
            {
                if (match(items[i]))
                    return items[i];
            }

            return default(T);
        }

        public int FindLastIndex(Predicate<T> match)
        {
            if (match == null)
                throw new ArgumentNullException("match");
            for (int i = size; i >= 0; i--)
            {
                if (match(items[i]))
                    return i;
            }

            return -1;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException();

            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException("index");

            Array.Copy(items, 0, array, arrayIndex, size);
        }

        public T[] ToArray()
        {
            T[] copiedArr = new T[size];
            Array.Copy(items, 0, copiedArr, 0, size);

            return copiedArr;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > items.Length)
                throw new ArgumentOutOfRangeException("index");

            if (size < items.Length)
            {
                size++;
                Array.Copy(items, index, items, index + 1, size - 1);
                for (int i = 0; i < size; i++)
                {
                    if (i == index)
                        items[i] = item;
                }
            }
            else
            {
                Grow();
                size++;
                Array.Copy(items, index, items, index + 1, size - 1);
                for (int i = 0; i < size; i++)
                {
                    if (i == index)
                        items[i] = item;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }

        public struct Enumerator : IEnumerator<T>
        {
            private List<T> list;
            private int index;
            private T current;

            public Enumerator(List<T> list)
            {
                this.list = list;
                this.index = 0;
                this.current = default(T);
            }

            public T Current { get { return current; } }

            object IEnumerator.Current { get { return Current; } }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                if (index < list.Count)
                {
                    current = list[index++];
                    return true;
                }
                else
                {
                    current = default(T);
                    return false;
                }
            }

            public void Reset()
            {
                current = default(T);
                index = 0;
            }
        }
    }
}
