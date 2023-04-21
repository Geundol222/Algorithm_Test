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

        public void Push(T item)        // 매개변수로 받아온 item을 container에 삽입한다.
        {
            container.Add(item);
        }

        public T Pop()
        {
            T item = container[container.Count - 1];    // container List의 맨 마지막 인덱스 값을 item에 저장한다.
            container.RemoveAt(container.Count - 1);    // container List의 맨 마지막 인덱스를 삭제한다.
            return item;    // item 을 리턴한다.
        }

        public T Peek() 
        {
            return container[container.Count - 1];      // container List의 최상단 값을 반환한다.
        }
    }
}
