﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
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
            if (node == head)
            {
                newNode = AddFirst(value);
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
    }
}
