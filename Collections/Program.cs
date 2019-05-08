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
            System.Console.WriteLine(sortedIntArray[0]);

            Console.ReadLine();
        }
    }
}
