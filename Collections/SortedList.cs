using System;

namespace CollectionsClasses
{
    public class SortedList<T> : List<T> where T : IComparable<T>
    {
        public SortedList(int capacity = 4)
            : base(capacity) { }

        public override T this[int index]
        {
            set
            {
                if (CheckSetElement(index, value))
                    base[index] = value;
            }
        }

        public override void Add(T item)
        {
            int index = FindOrderedPosition(item);
            Insert(index, item);
        }

        public override void Insert(int index, T item)
        {
            if (CheckInsertion(index, item))
                base.Insert(index, item);
        }

        private bool CheckInsertion(int index, T element)
        {
            return 0 <= index && index <= Count
                && (index == 0 || base[index - 1].CompareTo(element) < 0)
                && (index == Count || base[index].CompareTo(element) >= 0);
        }

        private bool CheckSetElement(int index, T element)
        {
            int upperLimit = index + 1;
            return 0 <= index && index < Count
                && (index == 0 || element.CompareTo(base[index - 1]) > 0)
                && (upperLimit == Count || element.CompareTo(base[upperLimit]) <= 0);
        }

        private int FindOrderedPosition(T element)
        {
            int index = Count;
            for (int i = 0; i < Count; i++)
            {
                if (element.CompareTo(base[i]) <= 0)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
    }
}