using System;

namespace CollectionsClasses
{
    public class SortedIntArray : IntArray
    {

        public SortedIntArray()
        {
            Count = 0;
            array = new int[4];
        }

        public override void Add(int element)
        {

            if (Count == 0 || element >= array[Count - 1])
            {
                array[Count++] = element;
                return;
            }


            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (element <= array[i])
                {
                    Insert(i, element);
                    break;
                }
            }

        }

        public override int this[int index]
        {
            set
            {
              if(CheckSetElement(index,value))
                array[index] = value;
            }
        }

        public override void Insert(int index, int element)
        {
            if (CheckInsertion(index, element))
                InsertElement(index, element);
        }

        private bool CheckInsertion(int index, int element)
        {
            return CheckSetElement(index, element);
        }

        private bool CheckSetElement(int index, int element)
        {
            if (index == 0)
                return Count <= 1 || element <= array[0];
            return CheckNeighbours(index, element);
        }

        private bool CheckNeighbours(int index, int element)
        {
             return (element <= array[index + 1] || element <= array[index])
                 && element >= array[index - 1];
        }
    }
}
