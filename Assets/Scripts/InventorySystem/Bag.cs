using System;
using System.Collections;
using System.Collections.Generic;

namespace InventorySystem
{
    [Serializable]
    public class Bag<T> : IEnumerable<T>, ICollection<T>
    {
        private Dictionary<T, int> _dict;

        public int Count { get; private set; }
        public bool IsReadOnly => false;

        public Bag()
        {
            _dict = new();
        }

        public Bag(IEnumerable<T> iter)
        {
            foreach (var item in iter)
            {
                Add(item);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var (item, num) in _dict)
            {
                for (int i = 0; i <= num; i++)
                {
                    yield return item;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            if (item is null) return;

            if (_dict.ContainsKey(item))
            {
                _dict[item]++;
            }
            else
            {
                _dict.Add(item, 1);
            }

            Count++;
        }

        public void Clear()
        {
            _dict.Clear();
            Count = 0;
        }

        public bool Contains(T item)
        {
            return item is not null && _dict.ContainsKey(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            foreach (T e in _dict.Keys)
                array[arrayIndex++] = e;
        }

        public bool Remove(T item)
        {
            if (item != null && _dict.ContainsKey(item))
            {
                if (_dict[item] > 0)
                {
                    _dict[item]--;
                }
                else
                {
                    _dict.Remove(item);
                }

                Count--;

                return true;
            }

            return false;
        }
    }
}