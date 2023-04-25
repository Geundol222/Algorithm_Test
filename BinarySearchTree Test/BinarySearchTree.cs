using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        /// 매개변수로 받은 item의 값을 가진 노드를 찾고 그 노드를 지우는 함수 Remove
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(T item)
        {
            Node findNode = FindNode(item);

            // FindNode 함수를 통해 찾고자하는 값을 가지는 노드를 확인한 후 노드가 존재한다면 그 노드를 지우고 true를 반환한다.
            if (findNode != null)
            {
                EraseNode(findNode);
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// 찾은 노드를 지우기 위해 사용하는 함수 EraseNode
        /// </summary>
        /// <param name="node"></param>
        private void EraseNode(Node node)
        {
            // 1. 찾은 노드에 자식이 없다면
            if (node.HasNoChild)
            {
                // 노드가 왼쪽자식일 때는 노드 부모의 왼쪽 노드를 삭제하고 오른쪽 자식일때는 노드 부모의 오른쪽 노드를 삭제한다.
                // 만약 노드가 root 노드라면 root를 삭제한다.
                if (node.IsLeftChild)
                    node.parent.left = null;
                else if (node.IsRightChild)
                    node.parent.right = null;
                else
                    root = null;
            }
            // 2. 찾은 노드에 자식이 하나만 존재한다면
            else if (node.HasLeftChild || node.HasRightChild)
            {
                // 노드의 부모노드와 자식노드를 저장한다.
                // 비교 연산자를 통해 노드의 자식노드가 왼쪽인지 오른쪽인지에 따라 다른 값을 저장한다.
                Node parent = node.parent;
                Node child = node.HasLeftChild ? node.left : node.right;

                // 만약 노드가 부모의 왼쪽 자식노드라면 부모의 왼쪽을 노드의 자식 노드로 교체하고 자식노드의 부모를 노드의 부모노드로 교체한다.
                if (node.IsLeftChild)
                {
                    parent.left = child;
                    child.parent = parent;
                }
                // 만약 노드가 부모의 오른쪽 자식노드라면 부모의 오른쪽을 노드의 자식 노드로 교체하고 자식노드의 부모를 노드의 부모노드로 교체한다.
                else if (node.IsRightChild)
                {
                    parent.right = child;
                    child.parent = parent;
                }
                // 만약 노드가 root 노드라면 자식 노드를 root 노드로 바꾸고 자식 노드의 부모노드를 null로 한다.
                else
                {
                    root = child;
                    child.parent = null;
                }
            }
            // 3. 찾은 노드에 자식이 둘 다 존재한다면
            else
            {
                // 교체할 노드에 우선 현재 노드의 오른쪽 값을 저장한다.
                Node removeNode = node.right;

                // 노드의 오른쪽 값을 저장한 교체노드를 null이 아닐때까지 왼쪽으로 이동시킨 후 노드의 값과 교체노드의 값을 교체한다.
                while (removeNode != null)
                    removeNode = removeNode.left;

                // EraseNode함수를 이용하여 교체할 노드를 지운다.
                // 이 경우 자식노드가 없는 것으로 되어 1번 상황이 호출된다.
                node.item = removeNode.item;
                EraseNode(removeNode);
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
            public bool IsLeftChild { get { return parent != null && parent.left == this; } }
            public bool IsRightChild { get { return parent != null && parent.right == this; } }

            public bool HasNoChild { get { return left == null && right == null; } }
            public bool HasBothChild { get { return left != null && right != null; } }
            public bool HasLeftChild { get { return left != null && right == null; } }
            public bool HasRightChild { get { return left == null && right != null; } }
        }
    }
}
