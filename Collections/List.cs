using System;
using System.Collections;
using System.Collections.Generic;

namespace CollectionsClasses
{
    public class List<T> : IEnumerable<T>
    {
        protected T[] array;

        public List(int capacity = 4)
        {
            Count = 0;
            array = new T[capacity];
        }

        public int Count { get; private set; }


        public virtual T this[int index]
        {
            get => array[index];
            set => array[index] = value;
        }

        public virtual void Add(T element)
        {
            EnsureCapacity();
            array[Count++] = element;
        }

        public bool Contains(T element)
        {
            return IndexOf(element) != -1;
        }

        public int IndexOf(T element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (CheckForNullValue(element, array[i])
                 || element?.Equals(array[i]) == true)
                {
                    return i;
                }
            }
            return -1;
        }

        public virtual void Insert(int index, T element)
        {
            InsertElement(index, element);
        }

        private void InsertElement(int index, T element)
        {
            EnsureCapacity();
            ShiftRight(index);
            array[index] = element;
            Count++;
        }

        public void Clear()
        {
            Count = 0;
        }

        public void Remove(T element)
        {
            RemoveAt(IndexOf(element));
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

        private bool CheckForNullValue(T searchedElement, T listElement)
        {
            return searchedElement == null && listElement == null;
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
    }
}
