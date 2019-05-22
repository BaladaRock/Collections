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

        public bool IsReadOnly { get; private set; }

        public virtual T this[int index]
        {
            get
            {
                CheckIfListIsEmpty();
                CheckParameter(index);
                return array[index];
            }
            set
            {
                CheckIfListIsEmpty();
                CheckParameter(index);
                CheckIfListIsReadonly();
                array[index] = value;
            }
        }

        public virtual void Add(T item)
        {
            CheckIfListIsReadonly();
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
            CheckParameter(index);
            CheckIfListIsReadonly();
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
            CheckIfListIsReadonly();
            Count = 0;
        }

        public bool Remove(T item)
        {
            CheckIfListIsReadonly();
            int index = IndexOf(item);
            if (index < 0)
                return false;

            RemoveAt(index);
            return true;
        }

        public void RemoveAt(int index)
        {
            CheckParameter(index);
            CheckIfListIsReadonly();
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
            CheckIfArrayIsNull(array);
            CheckArrayIndex(arrayIndex);
            CheckArrayCapacity(array, arrayIndex);

            int countElements = 0;
            for (int i = arrayIndex; i < Count + arrayIndex; i++)
                array[i] = this.array[countElements++];
        }

        private static void CheckArrayIndex(int arrayIndex)
        {
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException(paramName: nameof(arrayIndex), message: "Index does not exist!");
        }

        private void CheckIfArrayIsNull(T[] array)
        {
            if (array == null)
                throw new ArgumentNullException(paramName: nameof(array));
        }

        private void CheckArrayCapacity(T[] array, int arrayIndex)
        {
            if (arrayIndex < 0 || arrayIndex >= array.Length)
                throw new ArgumentException(message: "Given index does not exist!", paramName: nameof(arrayIndex));
            if (array.Length < Count + arrayIndex)
                throw new ArgumentException(message: "Copying proccess cannot be initialised", paramName: nameof(array));
        }

        private void CheckParameter(int index)
        {
            if (index < 0 || index > Count)
                throw new ArgumentOutOfRangeException(paramName: nameof(index), message: "Index does not exist!");
        }

        private void CheckIfListIsReadonly()
        {
            if (IsReadOnly)
                throw new NotSupportedException("List is readonly!");
        }

        private void CheckIfListIsEmpty()
        {
            if (Count == 0)
                throw new ArgumentException(message: "List is empty!");
        }

        public List<T> AsReadOnly()
        {
            List<T> newList = new List<T>(Count);
            for (int i = 0; i < Count; i++)
                newList.Insert(i, array[i]);

            newList.IsReadOnly = true;
            return newList;
        }

        public static (T, T) Swap(T a, T b) => (b, a);
    }
}
