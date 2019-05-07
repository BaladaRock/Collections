using System;

namespace CollectionsClasses
{
    public class IntArray
    {
        private int numberOfElements;
        private int[] array;

        public IntArray()
        {
            numberOfElements = 0;
            array = new int[4];
        }

        public void Add(int element)
        {
            EnsureCapacity();
            array[numberOfElements++] = element;
        }

        public int Count()
        {
            return numberOfElements;
        }

        public int Element(int index)
        {
            if (index < 0 || index >= numberOfElements)
                return -1;
            return array[index];

        }

        public void SetElement(int index, int element)
        {
            if (index >= 0 && index < numberOfElements)
                array[index] = element;
        }

        public bool Contains(int element)
        {
            for (int i = 0; i < numberOfElements; i++)
            {
                if (array[i] == element)
                    return true;
            }
            return false;
        }

        public int IndexOf(int element)
        {
            for (int i = 0; i < numberOfElements; i++)
            {
                if (array[i] == element)
                    return i;
            }
            return -1;
        }

        public void Insert(int index, int element)
        {
            if (index == array.Length + 1)
                EnsureCapacity();
               
            ShiftRight(index);
            array[index] = element;
            numberOfElements++;
        }

        public void Clear()
        {
            numberOfElements = 0;
        }

        public void Remove(int element)
        {
            RemoveAt(IndexOf(element));
        }

        public void RemoveAt(int index)
        {
            ShiftLeft(index);
            numberOfElements--;
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < numberOfElements - 1; i++)
                array[i] = array[i + 1];
        }

        private void ShiftRight(int index)
        {
            for (int i = numberOfElements - 1; i > index; i--)
                array[i] = array[i - 1];
        }

        private void EnsureCapacity()
        {
            if (numberOfElements == array.Length)
                Array.Resize(ref array, array.Length * 2);
        }
    }
}
