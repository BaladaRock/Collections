using System.Collections;

namespace CollectionsClasses
{
    public class ObjectEnumerator : IEnumerator
    {

        private readonly ObjectArray objectArray = new ObjectArray();
        private readonly object[] array;
        private int position = -1;

        public ObjectEnumerator(object[] array)
        {
            this.array = array;
        }

        public object Current
        {
            get => array[position];
        }

        public bool MoveNext()
        {
            position++;
            return position <= objectArray.Count;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
