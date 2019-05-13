using System;
using System.Collections;

namespace CollectionsClasses
{
    public class ObjectArray : IEnumerable
    {
        protected object[] array;

        public ObjectArray(int capacity = 4)
        {
            Count = 0;
            array = new object[capacity];
        }

        public int Count { get; private set; }


        public virtual object this[int index]
        {
            get => array[index];
            set => array[index] = value;
        }

        public virtual void Add(object element)
        {
            EnsureCapacity();
            array[Count++] = element;
        }

        public bool Contains(object element)
        {
            return IndexOf(element) != -1;
        }

        public int IndexOf(object element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (array[i] == element
                 ||(array[i]?.Equals(element) == true))
                {
                    return i;
                }
            }
            return -1;
        }

        public virtual void Insert(int index, object element)
        {
            InsertElement(index, element);
        }

        private void InsertElement(int index, object element)
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

        public void Remove(object element)
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

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public ObjectEnumerator GetEnumerator()
        {
            return new ObjectEnumerator(array);
        }
    }
}
