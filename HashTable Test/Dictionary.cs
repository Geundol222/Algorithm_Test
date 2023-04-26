using System;
using System.Collections.Generic;
using System.Linq;
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

        public TKey this[Index]

        /// <summary>
        /// 해싱된 인덱스를 받기위한 함수 GetHashedIndex
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int GetHashedIndex(TKey key) { return Math.Abs(key.GetHashCode() % table.Length); }            

        /// <summary>
        /// 하려는 행동에 따라 다른 결과를 도출하기 위해 구현한 열거형과 CanBehavior 함수
        /// </summary>
        public enum Behavior { None, Add, Set }         // 하려는 행동을 저장하는 열거형을 선언한다.
        public bool CanBehavior(TKey key, TValue value, Behavior behavior)
        {
            int index = GetHashedIndex(key);

            while (true)
            {
                else if (table[index].state == Entry.State.Deleted)
                    continue;

                // 만약 key의 값이 index에 있는 key 값과 같다면,
                if (key.Equals(table[index].key))
                {
                    switch (behavior)
                    {
                        case Behavior.Add:      // c#에서는 중복된 키값을 허용하지 않으므로 예외를 출력한다.
                            throw new ArgumentException();
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
    }
}
