using System;

namespace CollectionsClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            var sortedIntArray = new SortedIntArray();
            sortedIntArray.Add(1);
            sortedIntArray[0] = 2;

            var objectArray = new ObjectArray(4);
            objectArray.Add(new SortedIntArray(4));


            Console.ReadLine();
        }
    }
}
