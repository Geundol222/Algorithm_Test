using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
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

        public int Count { get { return items.Length; } }       // Count 프로퍼티를 선언하여 items 배열의 길이를 반환
        public int Capacity { get { return size; } }            // Capacity 프로퍼티를 선언하여 size값을 반환

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

        public T? Find(Predicate<T> match)      // 반환형을 T Nullable로 하는 Find 함수 선언, Predicate : 반환형을 bool로 하는 일반화된 델리게이트
        {
            if (match == null)
                throw new ArgumentNullException("match");       // 만약 match 가 null 일경우 null 예외를 출력

            for (int i = 0; i < size; i++)
            {
                if (match(items[i]))        // 반복문을 돌면서 match에 들어온 함수에 따라(대부분 람다식) items[i]가 조건과 일치할 경우 items[i]를 반환
                    return items[i];
            }

            return default(T);      // 일치하는 것이 없을 경우 들어온 함수 자료형의 기본값을 반환
        }

        public int FindIndex(int startIndex, int count, Predicate<T> match)     // int 반환형의 FindIndex 함수 선언
        {
            if (match == null)
                throw new ArgumentNullException("match");       // 만약 match 가 null 일경우 null 예외를 출력

            for (int i = startIndex; i < count; i++)
            {
                if (match(items[i]))        // 반복문을 돌면서 match에 들어온 함수에 따라(대부분 람다식) items[i]가 조건과 일치할 경우 i를 반환
                    return i;
            }

            return -1;      // 일치하는 것이 없을 경우 -1을 반환
        }

        public void Clear()         // List를 Clear 하는 Clear 함수 선언
        {
            int clearCap = items.Length;        // items의 길이를 clearCap에 저장
            T[] clearItems = new T[clearCap];   // clearCap의 길이만큼 새로운 배열 clearItems 선언
            items = clearItems;                 // items에 clearItems를 덮어 씌워 List에 있는 모든 값을 초기화
        }

        public bool Contains(T item)        // bool 반환형의 Contains 함수 선언
        {
            int index = IndexOF(item);      // IndexOf 함수를 이용하여 item이 가지는 인덱스 번호를 저장한다.
            if (index >= 0)
            {
                return true;                // 만약 index 번호가 존재하고 0보다 크거나 같다면 true 반환
            }
            else
            {
                return false;               // 위의 상황이 아니라면 false를 반환
            }
        }

        public T? FindLast(Predicate<T> match)      // 배열에서 입력한 요소의 마지막 값을 찾는 FindLast 함수 선언 
        {
            if (match == null)
                throw new ArgumentNullException("match");       // 만약 match 가 null 일경우 null 예외를 출력

            for (int i = size; i >= 0; i--)         // 마지막 값을 찾아야 하므로 배열의 맨 뒤 부터 반복문을 돌린다.
            {
                if (match(items[i]))
                    return items[i];
            }

            return default(T);
        }

        public int FindLastIndex(Predicate<T> match)      // 배열에서 입력한 요소의 마지막 값의 인덱스를 찾는 FindLastIndex 함수 선언 
        {
            if (match == null)
                throw new ArgumentNullException("match");       // 만약 match 가 null 일경우 null 예외를 출력

            for (int i = size; i >= 0; i--)         // 마지막 값을 찾아야 하므로 배열의 맨 뒤 부터 반복문을 돌린다.
            {
                if (match(items[i]))
                    return i;
            }

            return -1;
        }

        public void CopyTo(T[] array, int arrayIndex)       // 배열에 매개변수로 설정한 인덱스 부터 List에 있는 요소를 카피하는 CopyTo 함수 선언
        {
            if (array == null)
                throw new ArgumentNullException();

            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException("index");

            Array.Copy(items, 0, array, arrayIndex, size);
        }

        public T[] ToArray()            // List를 Array로 바꿔줄 ToArray 함수 선언
        {
            T[] copiedArr = new T[items.Length];        // 복사한 배열을 리턴할 새로운 배열 copiedArr 선언

            Array.Copy(items, 0, copiedArr, 0, size);   // items의 요소를 copiedArr에 복사

            return copiedArr;       // copiedArr 반환
        }
    }
}
