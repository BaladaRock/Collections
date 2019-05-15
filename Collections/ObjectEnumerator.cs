using System;
using System.Collections;

namespace CollectionsClasses
{
    public class ObjectEnumerator : IEnumerator
    {
        private readonly ObjectArray array;
        private int position = -1;

        public ObjectEnumerator(ObjectArray array)
        {
            this.array = array;
        }

        public object Current
        {
            get
            {
                try
                {
                    return array[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
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
