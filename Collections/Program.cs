using System;

namespace CollectionsClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int> { 1, 2, 3 };
            list.RemoveAt(0);
            list.Clear();
            foreach(var number in list)
                Console.WriteLine(number);

            //Should throw ArgumentException
            Console.WriteLine(list[0]);
            Console.ReadLine();
        }
    }
}
