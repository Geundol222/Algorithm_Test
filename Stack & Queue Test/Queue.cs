using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class Queue<T>
    {
        private const int DefaultCapacity = 10;     // 기본 배열의 크기

        private T[] array;
        private int head;
        private int tail;

        public Queue()      // 새로운 배열을 생성하고 head와 tail 초기화
        {
            array = new T[DefaultCapacity];
            head = 0;
            tail = 0;
        }

        public int Count    // Count 프로퍼티 선언, 만약 head가 tail보다 작거나 같으면 tail - head를 반환한다.
        {                   // tail이 head보다 크다면, tail - head를 해준값이 음수가 된다. 여기서 배열의 길이만큼을 더해주면 현제 배열에서 사용되고 있는 길이를 구할 수 있다.
            get
            {
                if (head <= tail)
                    return tail - head;
                else
                    return tail - head + array.Length;
            }
        }

        /// <summary>
        /// Queue에 요소를 삽입하는 함수
        /// </summary>
        /// <param name="item"></param>
        public void Enqueue(T item)     
        {
            if (IsFull())       // 만약 Queue가 전부 다 찼을경우 Grow함수를 통해 배열의 크기를 증가시켜준다.
                Grow();

            array[tail] = item;     // 값이 뒤에서 부터 들어가도록 tail의 값에 매개변수로 들어온 값을 저장한 후 MoveNext 함수를 통해 tail을 한칸 이동시킨다.
            MoveNext(ref tail);
        }

        /// <summary>
        /// Queue의 배열이 다 찼을 경우 배열의 크기를 증가시켜주는 함수
        /// </summary>
        public void Grow()      
        {
            int newCap = array.Length * 2;      // Copy 를 진행할 새로운 배열 생성
            T[] newArr = new T[newCap];

            if (head <= tail)                   // 만약 head가 tail보다 작거나 같을경우 원래 배열을 그대로 새로운 배열에 옮겨준다.
                Array.Copy(array, newArr, Count);      
            else                                // 위의 상황이 아닐경우 원래 배열의 head부터 (배열의 크기 - head)만큼의 길이를 새로운 배열의 0 인덱스 부터 넣어준 후
            {                                   // 원래 배열의 0 인덱스 부터 tail 만큼의 길이를 새로운 배열의 (배열의 크기 - head)의 인덱스 부터 넣어준다.
                                                // 그 다음 head를 0으로 tail을 배열이 가진 실질적인 값의 크기 만큼으로 설정해준다.
                Array.Copy(array, head, newArr, 0, array.Length - head);
                Array.Copy(array, 0, newArr, array.Length - head, tail);
                head = 0;
                tail = Count;
            }
            array = newArr;                     // 원래 배열에 새로운 배열을 대입한다.
        }

        /// <summary>
        /// Queue 배열에서 값을 빼오는 함수 Queue에서는 배열의 첫번째 요소부터 반환한다.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public T Dequeue()
        {
            if (IsEmpty())                      // 만약 배열이 비어있을 경우의 예외를 처리한다.
                throw new InvalidOperationException();

            T item = array[head];               // 반환할 변수 item에 head의 값을 넣어준다.
            MoveNext(ref head);                 // MoveNext함수를 통해 head를 한칸 뒤로 민다.
            return item;                        // 저장한 변수를 반환한다.
        }

        /// <summary>
        /// Queue의 맨 앞의 인덱스 값을 반환하는 함수
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public T Peek() 
        {
            if (IsEmpty())                      // 만약 배열이 비어있을 경우의 예외를 처리한다.
                throw new InvalidOperationException();

            return array[head];                 // 배열의 head에 해당하는 값을 반환한다.
        }

        /// <summary>
        /// 조건에 따라 가르키고 있는 head와 tail을 한탄 뒤로 밀어주는 함수
        /// </summary>
        /// <param name="index"></param>
        public void MoveNext(ref int index)
        {
            index = (index == array.Length - 1) ? 0 : index + 1;    // 매개변수로 들어온 index가 배열의 끝에 있을 경우 해당 인덱스를 0으로 만들고, 아닐경우 인덱스에 1을 더해준다.
        }

        /// <summary>
        /// Queue의 배열이 비어있는지를 확인하는 함수
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return head == tail;    // head가 tail과 같은 위치일 경우 true를 반환한다.
        }

        /// <summary>
        /// Queue 배열이 꽉 차있는지를 확인하는 함수
        /// </summary>
        /// <returns></returns>
        public bool IsFull()
        {
            if (head > tail)
                return head == tail + 1;                    // 만약 head가 tail보다 크다면, head가 tail + 1일 때 true를 반환한다.
            else
                return head == 0 && tail == array.Length - 1;   // 위의 경우가 아닐 경우 head가 0인 동시에 tail이 배열 끝에 있을 경우 true를 반환한다.
        }
    }
}
