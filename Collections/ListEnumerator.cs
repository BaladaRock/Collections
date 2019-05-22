using System;
using System.Collections.Generic;

namespace CollectionsClasses
{
    public class ListEnumerator<T> : IEnumerator<T>
    {
        private readonly List<T> array;
        private int position = -1;

        public ListEnumerator(List<T> array)
        {
            this.array = array;
        }

        public object Current => array[position];

        T IEnumerator<T>.Current => (T)Current;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            position++;
            return position < array.Count;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
