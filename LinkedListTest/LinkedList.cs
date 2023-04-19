using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    // LinkedListNode 클래스 선언, 변수와 생성자, 프로퍼티 선언
    public class LinkedListNode<T>
    {
        internal LinkedList<T> list;
        internal LinkedListNode<T> prev;
        internal LinkedListNode<T> next;
        private T item;

        public LinkedListNode(T value)
        {
            this.prev = null;
            this.next = null;
            this.item = value;
        }

        public LinkedListNode(LinkedList<T> list, T value)
        {
            this.prev = null;
            this.next = null;
            this.item = value;
        }

        public LinkedListNode(LinkedList<T> list, LinkedListNode<T> prev, LinkedListNode<T> next, T value)
        {
            this.prev = null;
            this.next = null;
            this.item = value;
        }

        public LinkedList<T> List { get { return list; } }
        public LinkedListNode<T> Prev { get { return prev; } }
        public LinkedListNode<T> Next { get { return next; } }
        public T Value { get { return item; } }

    }

    // LinkedList 클래스 선언, 변수와 생성자, 프로퍼티 선언
    public class LinkedList<T>
    {
        private LinkedListNode<T> head;
        private LinkedListNode<T> tail;
        private int count;

        public LinkedList()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }

        public LinkedListNode<T> First { get { return head; } }
        public LinkedListNode<T> Last { get { return tail; } }
        public int Count { get { return count; } }

        /// <summary>
        /// LinkedList의 맨 앞에 노드 하나를 추가하고 추가한 노드를 head로 바꾸는 함수
        /// </summary>
        /// <param name="value"></param>
        /// <returns>newNode</returns>
        public LinkedListNode<T> AddFirst(T value)
        {
            // 새 노드 생성
            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);

            // 연결구조 바꾸기
            if (head == null)       // 헤드가 null 일경우
            {
                head = newNode;
                tail = newNode;
            }
            else                    // 헤드가 null이 아닐경우
            {
                newNode.next = head;
                head.prev = newNode;
                head = newNode;
            }
            // 노드의 개수 증가
            count++;

            return newNode;
        }

        /// <summary>
        /// LinkedList의 맨 뒤에 노드 하나를 추가하고 추가한 노드를 tail로 바꾸는 함수
        /// </summary>
        /// <param name="value"></param>
        /// <returns>newNode</returns>
        public LinkedListNode<T> AddLast(T value)
        {
            // 새 노드 생성
            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);

            // 연결구조 바꾸기
            if (tail == null)       // tail이 null 일경우
            {
                head = newNode;
                tail = newNode;
            }
            else                    // tail이 null이 아닐경우
            {
                newNode.prev = tail;
                tail.next = newNode;
                tail = newNode;
            }
            // 노드의 개수 증가
            count++;

            return newNode;
        }

        /// <summary>
        /// LinkedList에서 원하는 노드 뒤에 새로운 노드를 넣어주는 함수
        /// </summary>
        /// <param name="node"></param>
        /// <param name="value"></param>
        /// <returns>newNode</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public LinkedListNode<T> AddAfter(LinkedListNode<T> node, T value)
        {
            // 새 노드 생성
            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);

            // 예외처리 => node가 null 일경우 null예외 처리, node가 이 LinkedList에 포함되지 않을 경우 Operation예외 처리
            if (node == null)
                throw new ArgumentNullException();
            if (node.list != this)
                throw new InvalidOperationException();

            // 연결구조 바꾸기
            if (node == tail)       // node가 tail 이면 AddLast 함수를 통해 tail에 노드 삽입
            {
                newNode =  AddLast(value);
            }
            else
            {
                newNode.next = node.next;
                newNode.prev = node;
                node.next.prev = newNode;
                node.next = newNode;
            }
            // 노드개수 증가
            count++;

            return newNode;
        }

        /// <summary>
        /// LinkedList에서 원하는 노드 앞에 새로운 노드를 넣어주는 함수
        /// </summary>
        /// <param name="node"></param>
        /// <param name="value"></param>
        /// <returns>newNode</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public LinkedListNode<T> AddBefore(LinkedListNode<T> node, T value)
        {
            // 새 노드 생성
            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);

            // 예외처리 => node가 null 일경우 null예외 처리, node가 이 LinkedList에 포함되지 않을 경우 Operation예외 처리
            if (node == null)
                throw new ArgumentNullException();
            if (node.list != this)
                throw new InvalidOperationException();

            // 연결구조 바꾸기
            if (node == head)       // node가 tail 이면 AddLast 함수를 통해 tail에 노드 삽입
            {
                newNode = AddFirst(value);
            }
            else
            {
                newNode.prev = node.prev;
                newNode.next = node;
                node.prev.next = newNode;
                node.prev = newNode;
            }
            // 노드개수 증가
            count++;

            return newNode;
        }

        /// <summary>
        /// 특정 노드를 제거하는 함수
        /// </summary>
        /// <param name="node"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public void Remove(LinkedListNode<T> node)
        {
            // 예외처리 => node가 null 일경우 null예외 처리, node가 이 LinkedList에 포함되지 않을 경우 Operation예외 처리
            if (node == null) 
                throw new ArgumentNullException();
            if (node.list != this)
                throw new InvalidOperationException();

            // node가 head일 경우 node의 next를 head로 바꿔주고 tail일 경우 node의 prev를 tail로 바꿔준다.
            if (node == head)
                head = node.next;
            if (node == tail)
                tail = node.prev;

            // node의 prev가 null이 아니면 node의 prev의 next를 node의 next로 바꿔주고 node의 next가 null이 아니면 node의 next의 prev를 node의 prev로 바꿔준다.
            // 참조가 없어진 노드는 메모리에서 자동으로 해제된다.
            if (node.prev != null)
                node.prev.next = node.next;
            if (node.next != null)
                node.next.prev = node.prev;

            // 노드의 개수를 줄여준다.
            count--;
        }

        /// <summary>
        /// 특정 값을 가지고 있는 노드를 찾은 후 해당 노드를 삭제하는 함수
        /// </summary>
        /// <param name="value"></param>
        /// <returns>true</returns>
        public bool Remove(T value)
        {
            LinkedListNode<T> node = Find(value);       // Find 함수를 이용하여 특정 값의 노드를 찾아 node에 저장

            if (node != null)       // node가 null이 아니면 Remove함수를 동작시켜 해당 노드를 삭제 후 true 반환
            {
                Remove(value);
                return true;
            }
            else                    // node가 null이면 false 반환
                return false;
        }

        /// <summary>
        /// 맨 첫번째 노드를 제거하는 함수
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public void RemoveFirst()
        {
            if (this == null)
                throw new InvalidOperationException();

            Remove(head);       // Remove함수를 이용하여 head를 제거한다.
        }

        /// <summary>
        /// 맨 마지막 노드를 제거하는 함수
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public void RemoveLast()
        {
            if (this == null)
                throw new InvalidOperationException();

            Remove(tail);       // Remove함수를 이용하여 head를 제거한다.
        }

        /// <summary>
        /// 원하는 특정 노드를 찾기 위해 사용하는 함수
        /// </summary>
        /// <param name="value"></param>
        /// <returns>target</returns>
        public LinkedListNode<T>? Find(T value)
        {
            LinkedListNode<T> target = head; // head부터 반복하기 위해 target에 head 저장
            EqualityComparer<T> compare = EqualityComparer<T>.Default;      // 값의 비교를 위해 EqualityComparer 클래스를 생성

            while (target != null)
            {
                // target 이 null이 아닐때 까지 반복하면서 target.Value와 value가 같을경우 target을 리턴하고, 아닐경우 target.next를 target에 저장
                if (compare.Equals(target.Value, value))
                    return target;
                else
                    target = target.next;
            }
            // 반복이 끝나도 값을 찾을 수 없으면 null 반환
            return null;            
        }

        /// <summary>
        /// 입력한 값을 가진 노드가 여러개 일경우 그 중 가장 뒤에 있는 노드를 찾기 위해 사용하는 함수
        /// </summary>
        /// <param name="value"></param>
        /// <returns>target</returns>
        public LinkedListNode<T>? FindLast(T value)
        {
            LinkedListNode<T> target = tail; // tail부터 반복하기 위해 target에 tail 저장
            EqualityComparer<T> compare = EqualityComparer<T>.Default;      // 값의 비교를 위해 EqualityComparer 클래스를 생성

            while (target != null)
            {
                // target 이 null이 아닐때 까지 반복하면서 target.Value와 value가 같을경우 target을 리턴하고, 아닐경우 target.prev를 target에 저장
                if (compare.Equals(target.Value, value))
                    return target;
                else
                    target = target.prev;
            }
            // 반복이 끝나도 값을 찾을 수 없으면 null 반환
            return null;
        }

        /// <summary>
        /// 입력한 값을 가지고 있는 노드를 찾고 노드가 존재할 경우 true를 반환하는 함수
        /// </summary>
        /// <param name="value"></param>
        /// <returns>true</returns>
        public bool Contains(T value)
        {
            LinkedListNode<T> target = Find(value);     // value의 값을 가지고 있는 노드를 Find함수로 찾은 후 target에 저장

            if (target != null)         // target이 null이 아닌경우 true 반환
                return true;
            else                        // target이 null인 경우 false 반환
                return false;
        }
    }
}
