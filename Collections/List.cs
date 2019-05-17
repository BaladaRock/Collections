using System;
using System.Collections;
using System.Collections.Generic;

namespace CollectionsClasses
{
    public class List<T> : IList<T>
    {
        protected T[] array;

        public List(int capacity = 4)
        {
            Count = 0;
            array = new T[capacity];
        }

        public int Count { get; private set; }

        public bool IsReadOnly { get; }

        public virtual T this[int index]
        {
            get => array[index];
            set => array[index] = value;
        }

        public virtual void Add(T item)
        {
            EnsureCapacity();
            array[Count++] = item;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (CheckForNullValue(item, array[i])
                 || item?.Equals(array[i]) == true)
                {
                    return i;
                }
            }
            return -1;
        }

        public virtual void Insert(int index, T item)
        {
            InsertItem(index, item);
        }

        private void InsertItem(int index, T item)
        {
            EnsureCapacity();
            ShiftRight(index);
            array[index] = item;
            Count++;
        }

        public void Clear()
        {
            Count = 0;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index < 0)
                return false;
            RemoveAt(index);
            return true;
        }

        public void RemoveAt(int index)
        {
            ShiftLeft(index);
            Count--;
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < Count - 1; i++)
                array[i] = array[i + 1];
        }

        private void ShiftRight(int index)
        {
            for (int i = Count; i > index; i--)
                array[i] = array[i - 1];
        }

        private void EnsureCapacity()
        {
            if (Count == array.Length)
                Array.Resize(ref array, array.Length * 2);
        }

        private bool CheckForNullValue(T searchedItem, T listItem)
        {
            return searchedItem == null && listItem == null;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
                yield return array[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            int countElements = 0;
            if (CheckArrayCapacity(array,arrayIndex))
            {
                for (int i = arrayIndex; i < Count + arrayIndex; i++)
                    array[i] = this.array[countElements++];
            }
        }

        private bool CheckArrayCapacity(T[] array, int arrayIndex)
        {
            if (arrayIndex < 0 || arrayIndex >= array.Length)
                return false;
            return array.Length >= Count + arrayIndex;
        }

        public static (T, T) Swap(T a, T b) => (b, a);
    }
}
