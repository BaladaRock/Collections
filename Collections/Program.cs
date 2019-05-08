using System;

namespace CollectionsClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            var intArray = new IntArray();
            intArray.Add(1);
            intArray[0] = 2;
            System.Console.WriteLine(intArray[0]);
            Console.ReadLine();
        }
    }
}
