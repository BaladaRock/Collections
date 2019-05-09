using System;

namespace CollectionsClasses
{
    public class IntArray
    {
        protected int[] array;

        public IntArray(int capacity = 4)
        {
            Count = 0;
            array = new int[capacity];
        }

        public int Count { get; protected set; }
        
        public virtual int this[int index]
        {
            get => array[index];
            set => array[index] = value;
        }
        
        public virtual void Add(int element)
        {
            EnsureCapacity();
            array[Count++] = element;
        }

        public bool Contains(int element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (array[i] == element)
                    return true;
            }
            return false;
        }

        public int IndexOf(int element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (array[i] == element)
                    return i;
            }
            return -1;
        }

        public virtual void Insert(int index, int element)
        {
            InsertElement(index, element);
        }

        protected void InsertElement(int index, int element)
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

        public void Remove(int element)
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

        protected void ShiftRight(int index)
        {
            for (int i = Count; i > index; i--)
                array[i] = array[i - 1];
        }

        protected void EnsureCapacity()
        {
            if (Count == array.Length)
                Array.Resize(ref array, array.Length * 2);
        }

        

    }
}
