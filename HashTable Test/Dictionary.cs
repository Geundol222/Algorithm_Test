using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HashTable_Test
{
    public class Dictionary<TKey, TValue> where TKey : IEquatable<TKey>
    {
        private const int DefaultCapacity = 1000;

        private struct Entry
        {
            public enum State { None, Using, Deleted }

            public State state;
            public int hashcode;
            public TKey key;
            public TValue value;
        }

        private Entry[] table;

        public Dictionary()
        {
            table = new Entry[DefaultCapacity];
        }

        /// <summary>
        /// 인덱서 구현
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public TValue this[TKey key]
        {
            get
            {
                int index = GetHashedIndex(key);
                if (CanBehavior(key, table[index].value, Behavior.Get))     // 만약 CanBehavior가 true라면 index의 값을 반환한다.
                    return table[index].value;
                else
                    throw new KeyNotFoundException();                       // 만약 false라면 KeyNotFoundException을 출력한다.
                
            }
            set
            {
                CanBehavior(key, value, Behavior.Set);                      // CanBehavior함수의 Set을 호출한다.
            }
        }

        /// <summary>
        /// 해싱된 인덱스를 받기위한 함수 GetHashedIndex
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int GetHashedIndex(TKey key) { return Math.Abs(key.GetHashCode() % table.Length); }

        /// <summary>
        /// 하려는 행동에 따라 다른 결과를 도출하기 위해 구현한 열거형과 CanBehavior 함수
        /// </summary>
        public enum Behavior { None, Add, Get, Set }         // 하려는 행동을 저장하는 열거형을 선언한다.
        public bool CanBehavior(TKey key, TValue value, Behavior behavior)
        {
            int index = GetHashedIndex(key);

            while (table[index].state == Entry.State.Using)
            {
                // 만약 key의 값이 index에 있는 key 값과 같다면,
                if (key.Equals(table[index].key))
                {
                    switch (behavior)
                    {
                        case Behavior.Add:      // c#에서는 중복된 키값을 허용하지 않으므로 예외를 출력한다.
                            throw new ArgumentException();
                        case Behavior.Get:
                            return true;
                        case Behavior.Set:      // 인덱서를 통해 받은 값을 set한다.
                            table[index].value = value;
                            return true;
                        default:
                            return false;
                    }
                }
                if (table[index].state == Entry.State.None)
                    break;

                index = ++index % table.Length;
            }
            table[index].state = Entry.State.Using;
            table[index].key = key;
            table[index].value = value;
            return true;
        }

        /// <summary>
        /// 딕셔너리에 요소를 삽입할 Add 함수
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(TKey key, TValue value)
        {
            CanBehavior(key, value, Behavior.Add);
        }

        public bool Remove(TKey key)
        {
            int index = FindIndex(key);

            if (index > 0)
            {
                table[index].state = Entry.State.Deleted;
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// 지정한 key값에 해당하는 인덱스를 찾는 FindIndex 함수
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private int FindIndex(TKey key)
        {
            int index = GetHashedIndex(key);    // 해싱된 인덱스 값을 저장한다.

            while (table[index].state == Entry.State.Using
                || table[index].state == Entry.State.Deleted)      
            {
                if (table[index].state == Entry.State.Deleted)
                {
                    index = ++index % table.Length;
                    continue;
                }

                if (key.Equals(table[index].key))
                {
                    return index;
                }
                index = ++index % table.Length;
            }
            return -1;
        }
    }
}
