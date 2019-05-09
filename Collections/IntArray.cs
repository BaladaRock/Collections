﻿
namespace CollectionsClasses
{
    public class IntArray
    {
        readonly ObjectArray array;

        public IntArray(int capacity = 4)
        {
            array = new ObjectArray(capacity);
        }

        public int Count => array.Count;

        public virtual int this[int index]
        {
            get => (int)array[index];
            set => array[index] = value;
        }

        public virtual void Add(int element)
        {
            array.Add(element);
        }

        public bool Contains(int element)
        {
            return array.Contains(element);
        }

        public int IndexOf(int element)
        {
            return array.IndexOf(element);
        }

        public virtual void Insert(int index, int element)
        {
            array.Insert(index, element);
        }

        public void Clear()
        {
            array.Clear();
        }

        public void Remove(int element)
        {
            array.Remove(element);
        }

        public void RemoveAt(int index)
        {
            array.RemoveAt(index);
        }
    }
}
