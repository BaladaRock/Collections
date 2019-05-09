namespace CollectionsClasses
{
    public class SortedIntArray : IntArray
    {
        public SortedIntArray(int capacity = 4)
            : base(capacity) { }

        public override int this[int index]
        {
            set
            {
                if (CheckSetElement(index, value))
                    array[index] = value;
            }
        }

        public override void Add(int element)
        {
            int index = FindOrderedPosition(element);
            Insert(index, element);
        }

        public override void Insert(int index, int element)
        {
            if (CheckInsertion(index, element))
                InsertElement(index, element);
        }

        private bool CheckInsertion(int index, int element)
        {
            return 0 <= index && index <= Count
                && (index == 0 || array[index - 1] <= element)
                && (index == Count || element <= array[index]);
        }

        private bool CheckSetElement(int index, int element)
        {
            int upperLimit = index + 1;
            return 0 <= index && index < Count
                && (index == 0 || array[index - 1] <= element)
                && (upperLimit == Count || element <= array[upperLimit]);
        }

        private int FindOrderedPosition(int element)
        {
            int index = Count;
            for (int i = 0; i < Count; i++)
            {
                if (element <= array[i])
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
    }
}