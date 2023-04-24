using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class PriorityQueue<TElement, TPriority>
    {
        private struct Node
        {
            public TElement element;
            public TPriority priority;
        }

        List<Node> node;
        IComparer<TPriority> comparer;

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

        public void Enqueue(TElement element, TPriority priority)
        {
            Node newNode = new Node() { element = element, priority = priority };

            node.Add(newNode);
            int newNodeIndex = node.Count - 1;

            while (newNodeIndex > 0)
            {
                int parentIndex = GetParentIndex(newNodeIndex);
                Node parentNode = node[parentIndex];

                if (newNodeIndex < parentIndex)
                {
                    node[newNodeIndex] = parentNode;
                    node[parentIndex] = newNode;
                    newNodeIndex = parentIndex;
                }
                else
                    break;
            }
        }

        public TElement Dequeue()
        {
            Node rootNode = node[0];

            Node lastNode = node[node.Count - 1];
            node[0] = lastNode;
            node.RemoveAt(node.Count - 1);

            int index = 0;

            while (index < node.Count)
            {
                int leftChildIndex = LeftChildIndex(index);
                int rightChildIndex = RightChildIndex(index);

                if (rightChildIndex < node.Count)
                {
                    int lessChildIndex = comparer.Compare(node[rightChildIndex].priority, node[leftChildIndex].priority) > 0 
                        ? leftChildIndex : rightChildIndex;

                    if (comparer.Compare(node[index].priority, node[lessChildIndex].priority) > 0)
                    {
                        node[index] = node[lessChildIndex];
                        node[lessChildIndex] = lastNode;
                        index = lessChildIndex;
                    }
                    else
                        break;
                }
                else if (leftChildIndex < node.Count)
                {
                    if (comparer.Compare(node[index].priority, node[leftChildIndex].priority) > 0)
                    {
                        node[index] = node[leftChildIndex];
                        node[leftChildIndex] = lastNode;
                        index = leftChildIndex;
                    }
                    else
                        break;
                }
                else
                    break;
            }

            return rootNode.element;
        }

        public TElement Peek()
        {
            return node[0].element;
        }

        public int GetParentIndex(int childIndex)
        {
            return (childIndex - 1) / 2;
        }

        public int LeftChildIndex(int parentIndex)
        {
            return parentIndex * 2 + 1;
        }

        public int RightChildIndex(int parentIndex)
        {
            return parentIndex * 2 + 2;
        }
    }
}
