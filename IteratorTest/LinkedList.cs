using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
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

    public class LinkedList<T> : IEnumerable<T>
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

        public LinkedListNode<T> AddFirst(T value)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);

            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.next = head;
                head.prev = newNode;
                head = newNode;
            }
            count++;

            return newNode;
        }

        public LinkedListNode<T> AddLast(T value)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);

            if (tail == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.prev = tail;
                tail.next = newNode;
                tail = newNode;
            }
            count++;

            return newNode;
        }

        public LinkedListNode<T> AddAfter(LinkedListNode<T> node, T value)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);

            if (node == null)
                throw new ArgumentNullException();
            if (node.list != this)
                throw new InvalidOperationException();

            if (node == tail)
            {
                newNode = AddLast(value);
            }
            else
            {
                newNode.next = node.next;
                newNode.prev = node;
                node.next.prev = newNode;
                node.next = newNode;
            }
            count++;

            return newNode;
        }

        public LinkedListNode<T> AddBefore(LinkedListNode<T> node, T value)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);

            if (node == null)
                throw new ArgumentNullException();
            if (node.list != this)
                throw new InvalidOperationException();

            if (node == head)
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
            count++;

            return newNode;
        }

        public void Remove(LinkedListNode<T> node)
        {
            if (node == null)
                throw new ArgumentNullException();
            if (node.list != this)
                throw new InvalidOperationException();

            if (node == head)
                head = node.next;
            if (node == tail)
                tail = node.prev;

            if (node.prev != null)
                node.prev.next = node.next;
            if (node.next != null)
                node.next.prev = node.prev;

            count--;
        }

        public bool Remove(T value)
        {
            LinkedListNode<T> node = Find(value);
            if (node != null)
            {
                Remove(node);
                return true;
            }
            else return false;
        }

        public void RemoveFirst()
        {
            if (this == null)
                throw new InvalidOperationException();

            Remove(head);
        }

        public void RemoveLast()
        {
            if (this == null)
                throw new InvalidOperationException();

            Remove(tail);
        }

        public LinkedListNode<T>? Find(T value)
        {
            LinkedListNode<T> target = head; EqualityComparer<T> compare = EqualityComparer<T>.Default;
            while (target != null)
            {
                if (compare.Equals(target.Value, value))
                    return target;
                else
                    target = target.next;
            }
            return null;
        }

        public LinkedListNode<T>? FindLast(T value)
        {
            LinkedListNode<T> target = tail; EqualityComparer<T> compare = EqualityComparer<T>.Default;
            while (target != null)
            {
                if (compare.Equals(target.Value, value))
                    return target;
                else
                    target = target.prev;
            }
            return null;
        }

        public bool Contains(T value)
        {
            LinkedListNode<T> target = Find(value);
            if (target != null) return true;
            else return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }

        public struct Enumerator : IEnumerator<T>
        {
            private LinkedList<T> linkedList;
            private LinkedListNode<T> node;
            private T current;

            public Enumerator(LinkedList<T> linkedList)
            {
                this.linkedList = linkedList;
                this.node = linkedList.head;
                this.current = default(T);
            }

            public T Current { get { return current; } }

            object IEnumerator.Current { get { return Current; } }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                if (node != null)
                {
                    current = node.Value;
                    node = node.next;                    
                    return true;
                }
                else
                {
                    current = default(T);
                    return false;
                }
            }

            public void Reset()
            {
                node = linkedList.head;
                current = default(T);
            }
        }
    }
}
