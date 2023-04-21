using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class Stack<T>
    {
        private List<T> container;      // 어뎁터 패턴으로 Stack을 구현하기 위해 List를 받아온다.

        public Stack()
        {
            container = new List<T>();  // 새로운 List를 생성하여 container에 넣어준다.
        }

        /// <summary>
        /// Stack List에 값을 넣어주는 함수
        /// </summary>
        /// <param name="item"></param>
        public void Push(T item)        // 매개변수로 받아온 item을 container에 삽입한다.
        {
            container.Add(item);
        }

        /// <summary>
        /// Stack List에서 값을 빼내오는 함수, Stack의 경우 선입후출로서 맨 마지막에 들어온 값부터 반환된다.
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            T item = container[container.Count - 1];    // container List의 맨 마지막 인덱스 값을 item에 저장한다.
            container.RemoveAt(container.Count - 1);    // container List의 맨 마지막 인덱스를 삭제한다.
            return item;    // item 을 리턴한다.
        }

        /// <summary>
        /// Stack의 최상단(맨 마지막) 값을 확인하는 함수
        /// </summary>
        /// <returns></returns>
        public T Peek() 
        {
            return container[container.Count - 1];      // container List의 최상단 값을 반환한다.
        }
    }
}
