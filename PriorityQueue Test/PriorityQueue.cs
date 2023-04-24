using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class PriorityQueue<TElement, TPriority>         // 큐에 삽입되는 값과 우선순위를 확인할 값을 밭아오기 위해 TElement,와 TPriority의 이름으로 제네릭 선언
    {
        private struct Node         //  Node 구조체를 선언하고 변수 설정
        {
            public TElement element;
            public TPriority priority;
        }

        List<Node> node;
        IComparer<TPriority> comparer;      // Node를 자료형으로 하는 List를 선언하고, 제네릭은 비교연산자를 사용할 수 없으므로, 비교를 하기 위해 IComparer 인터페이스를 사용한다.

        public PriorityQueue()
        {
            this.node = new List<Node>();
            this.comparer = Comparer<TPriority>.Default;
        }

        public PriorityQueue(IComparer<TPriority> comparer)
        {
            this.node = new List<Node>();
            this.comparer = Comparer<TPriority>.Default;
        }

        public int Count { get { return node.Count; } }

        /// <summary>
        /// 우선순위 큐에 요소를 삽입할 함수 Enqueue
        /// </summary>
        /// <param name="element"></param>
        /// <param name="priority"></param>
        public void Enqueue(TElement element, TPriority priority)
        {
            Node newNode = new Node() { element = element, priority = priority };   // 새로운 노드를 생성한다.

            node.Add(newNode);                                                      // 리스트에 생성한 노드를 삽입하고 노드의 인덱스는 맨 마지막인덱스로 저장한다.
            int newNodeIndex = node.Count - 1;

            while (newNodeIndex > 0)
            {
                int parentIndex = GetParentIndex(newNodeIndex);                     // GetParentIndex에서 받아온 newNode의 부모 노드인덱스를 저장하고 부모노드를 node[부모노드] 값으로 저장한다.
                Node parentNode = node[parentIndex];

                if (comparer.Compare(newNode.priority, parentNode.priority) < 0)    // 만약 새로운 노드의 우선순위가 더 빠르다면,
                {                                                                   // 새로운노드와 부모노드를 교체하고 새로운 노드 인덱스를 부모 노드의 인덱스로 교체한다.
                    node[newNodeIndex] = parentNode;
                    node[parentIndex] = newNode;
                    newNodeIndex = parentIndex;
                }
                else                                                                // 아니라면 반복문을 종료한다.
                    break;
            }
        }

        /// <summary>
        /// 우선순위 큐에서 맨 앞의 요소를 반환하는 함수 Dequeue
        /// </summary>
        /// <returns>rootNode.element</returns>
        public TElement Dequeue()
        {
            Node rootNode = node[0];                            // 노드리스트의 0번 인덱스를 rootNode로 설정한다.

            Node lastNode = node[node.Count - 1];               // 노드리스트의 마지막 인덱스를 lastNode로 설정하고 node의 0번 인덱스를 lastNode의 값으로 바꾼뒤 마지막 인덱스를 삭제한다.
            node[0] = lastNode;
            node.RemoveAt(node.Count - 1);

            int index = 0;                                      // 비교를 위한 인덱스를 하나 선언한다.

            while (index < node.Count)
            {
                int leftChildIndex = LeftChildIndex(index);     // 왼쪽 자식 노드와 오른쪽 자식노드를 확인하기 위한 변수를 선언하고 함수를 통해 값을 넣어준다.
                int rightChildIndex = RightChildIndex(index);

                if (rightChildIndex < node.Count)               // 만약 자식노드가 두개 다 존재한다면,
                {
                    int lessChildIndex = comparer.Compare(node[rightChildIndex].priority, node[leftChildIndex].priority) > 0 
                        ? leftChildIndex : rightChildIndex;     // 왼쪽노드와 오른쪽 노드 중 우선순위가 더 작은 노드를 저장한다.

                    if (comparer.Compare(node[index].priority, node[lessChildIndex].priority) > 0)  // 만약 자식노드의 우선순위가 부모노드보다 빠를경우
                    {                                                                               // 자식노드와 부모노드를 바꾸고 인덱스를 교체한다.
                        node[index] = node[lessChildIndex];
                        node[lessChildIndex] = lastNode;
                        index = lessChildIndex;
                    }
                    else
                        break;
                }
                else if (leftChildIndex < node.Count)           // 만약 자식노드가 하나만 존재한다면, (왼쪽만 존재)
                {
                    if (comparer.Compare(node[index].priority, node[leftChildIndex].priority) > 0)  // 자식노드의 우선순위가 부모보다 빠를경우 자식과 부모를 바꾸고 인덱스를 교체한다.
                    {
                        node[index] = node[leftChildIndex];
                        node[leftChildIndex] = lastNode;
                        index = leftChildIndex;
                    }
                    else
                        break;
                }
                else                                          // 위의 경우가 전부 아닐경우 반복을 종료한다.
                    break;
            }

            return rootNode.element;                          // 노드의 0번 인덱스를 반환한다.
        }

        /// <summary>
        /// 노드의 0번 인덱스값을 확인하고 반환하는 함수 Peek
        /// </summary>
        /// <returns></returns>
        public TElement Peek()
        {
            return node[0].element;                           // 노드의 0번 인덱스를 반환한다.
        }

        /// <summary>
        /// 부모노드의 인덱스를 확인하고 반환하는 함수 GetParentIndex
        /// </summary>
        /// <param name="childIndex"></param>
        /// <returns></returns>
        public int GetParentIndex(int childIndex)
        {
            return (childIndex - 1) / 2;
        }

        /// <summary>
        /// 왼쪽 자식노드의 인덱스를 확인하고 반환하는 함수 LeftChildIndex
        /// </summary>
        /// <param name="parentIndex"></param>
        /// <returns></returns>
        public int LeftChildIndex(int parentIndex)
        {
            return parentIndex * 2 + 1;
        }

        /// <summary>
        /// 오른쪽 자식노드의 인덱스를 확인하고 반환하는 함수 RightChildIndex
        /// </summary>
        /// <param name="parentIndex"></param>
        /// <returns></returns>
        public int RightChildIndex(int parentIndex)
        {
            return parentIndex * 2 + 2;
        }
    }
}
