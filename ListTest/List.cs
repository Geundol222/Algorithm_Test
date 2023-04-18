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

        public int Count { get { return items.Length; } }
        public int Capacity { get { return size; } }

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

        public bool Remove(T item)      // bool 자료형으로 Remove 함수 선언
        {
            int index = IndexOF(item);      // 매개변수로 들어온 item 변수의 인덱스번호를 저장할 index 변수 선언
            if (index >= 0)
            {
                RemoveAt(index);        // 만약 index 번호가 존재한다면 RemoveAt 함수를 호출하고 true 반환
                return true;
            }
            else
            {
                return false;           // 위 상황이 아니라면 false 반환
            }
        }

        public void RemoveAt(int index)     // 지정한 인덱스에 있는 값을 지우기 위한 RemoveAt 함수 구현 매개변수는 인덱스 번호
        {
            if (index < 0 || index >= items.Length)     // 만약 인덱스 번호가 0보다 작거나 items의 길이보다 크다면 잘못된 것이므로 예외 출력
                throw new IndexOutOfRangeException();

            size--;
            Array.Copy(items, index + 1, items, index, size - index);       // size를 1 줄여주고 지우고자 하는 인덱스 뒤에 있는 값들을 앞으로 끌어오면서 복사
        }

        public int IndexOF(T item)     // 매개변수로 받은 item이 몇번째 인덱스에 있는지 확인하는 IndexOf 함수 선언
        {
            return Array.IndexOf(items, item, 0, size);     // Array의 IndexOf 함수를 이용하여 item의 값이 들어있는 인덱스 번호 리턴
        }
    }
}
