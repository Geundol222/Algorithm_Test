using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree_Test
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        private Node root;

        public BinarySearchTree()
        {
            this.root = null;
        }

        /// <summary>
        /// 이진 탐색 트리에 값을 삽입하는 함수 Add
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            Node newNode = new Node(item, null, null, null);    // 매개변수로 받은 값을 가진 새로운 노드 생성

            if (root == null)       // 만약 root가 비어있다면 새로운 노드를 root에 삽입
                root = newNode;

            Node current = root;
            while (current != null)
            {
                // 만약 새로운 노드가 현재 노드보다 크다면 현재 노드의 오른쪽을 확인한 후, 오른쪽에 자식노드가 존재하면,
                // 현재노드를 오른쪽 자식노드로 설정하고 다시 반복, 만약 오른쪽 자식노드가 존재하지않으면, 그 노드를 새로운 노드의 자리로 한다.
                if (item.CompareTo(current.item) > 0)
                {
                    if (current.HasRightChild)
                    {
                        current = current.right;
                    }
                    else
                    {
                        current.right = newNode;
                        newNode.parent = current;
                        return;
                    }
                }
                else if (item.CompareTo(current.item) < 0)
                {
                    // 만약 새로운 노드가 현재 노드보다 작다면 현재 노드의 왼쪽을 확인한 후, 왼쪽에 자식노드가 존재하면,
                    // 현재노드를 왼쪽 자식노드로 설정하고 다시 반복, 만약 왼쪽 자식노드가 존재하지않으면, 그 노드를 새로운 노드의 자리로 한다.
                    if (current.HasLeftChild)
                    {
                        current = current.left;
                    }
                    else
                    {
                        current.left = newNode;
                        newNode.parent = current;
                        return;
                    }
                }
                else        // 만약 크지도 작지도 않다면 즉, 같은값이라면 중복된 갑이라는 뜻이므로 아무행동없이 함수를 종료한다.
                    return;
            }
        }

        /// <summary>
        /// FindNode를 통해 찾는 값이 존재하면 true 없으면 false를 반환하는 TryGetValue함수
        /// </summary>
        /// <param name="item"></param>
        /// <param name="outValue"></param>
        /// <returns></returns>
        public bool TryGetValue(T item, out T outValue)
        {
            Node findNode = FindNode(item); // FindNode함수를 통해 찾은 값의 정보를 저장한다.

            if (findNode == null)   // 만약 findNode에서 찾은 값이 없으면 outValue를 기본값으로 저장하고 false를 반환한다.
            {
                outValue = default(T);
                return false;
            }
            else                    // 만약 값을 찾았다면 outValue를 findNode의 값으로 저장하고 true를 반환한다.
            {
                outValue = findNode.item;
                return true;
            }
        }

        /// <summary>
        /// 지정한 값을 가지고 있는 노드가 있는지 찾는 FindNode함수
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private Node FindNode(T item)
        {
            if (root == null)       // 만약 root가 null이면 찾는 의미가 없으므로 null 반환
                return null;

            Node current = root;

            while (current != null)
            {
                // current가 null이 될때까지 item의 값이 현재노드보다 크면 오른쪽 작으면 왼쪽 순회를 반복하면서
                // item과 같은 값이 나오면 current의 값을 반환한다.
                if (item.CompareTo(current.item) > 0)
                    current = current.right;
                else if (item.CompareTo(current.item) < 0)
                    current = current.left;
                else
                    return current;
            }

            return null;    // 반복문이 끝났다는 것은 찾는 값이 없다는 의미이므로 null을 반환한다.
        }

        public class Node
        {
            internal T item;
            internal Node parent;
            internal Node left;
            internal Node right;

            public Node(T item, Node parent, Node left, Node right)
            {
                this.item = item;
                this.parent = parent;
                this.left = left;
                this.right = right;
            }

            public bool IsRootNode { get { return parent == null; } }
            public bool IsLeftChildNode { get { return parent != null && parent.left == this; } }
            public bool IsRightChildNode { get { return parent != null && parent.right == this; } }

            public bool HasBothChild { get { return left != null && right != null; } }
            public bool HasLeftChild { get { return left != null && right == null; } }
            public bool HasRightChild { get { return left == null && right != null; } }
        }
    }
}
