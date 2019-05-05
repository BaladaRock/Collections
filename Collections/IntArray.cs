using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionsClasses
{
    public class IntArray
    {
        private int capacity;
        private int numberOfElements;
        private int[] array;

        public IntArray()
        {
            capacity = 4;
            numberOfElements = 0;
            array = new int[capacity];
        }

        public void Add(int element)
        {
            // adaugă un nou element la sfârșitul șirului

            if (numberOfElements == capacity - 1)
            {
                capacity = 2 * capacity;
                int[] tempArray = new int[capacity];
                for (int i = 0; i < numberOfElements; i++)
                    tempArray[i] = array[i];
                array = tempArray;
            }
            array[numberOfElements++] = element;
        }

        public int Count()
        {
            // întorce numărul de elemente din șir
            return numberOfElements;
        }

        public int Element(int index)
        {
            // întoarce elementul de la indexul dat
            if (index < 0 || index >= numberOfElements)
                return -1;
            return array[index];
        }

        public void SetElement(int index, int element)
        {
            // modifică valoarea elementul de la indexul dat
            if(index>=0 && index<numberOfElements)
                array[index] = element;
        }

        public bool Contains(int element)
        {
            // întoarce true dacă elementul dat există în șir
            for(int i=0;i<numberOfElements;i++)
            {
                if(array[i]==element)
                    return true;
            }
            return false;
        }

        public int IndexOf(int element)
        {
            // întoarce indexul elementului sau -1 dacă elementul nu se
            // regăsește în șir
            return 0;
        }

        public void Insert(int index, int element)
        {
            // adaugă un nou element pe poziția dată
        }

        public void Clear()
        {
            // șterge toate elementele din șir
        }

        public void Remove(int element)
        {
            // șterge prima apariție a elementului din șir	
        }

        public void RemoveAt(int index)
        {
            // șterge elementul de pe poziția dată
        }
    }
}
