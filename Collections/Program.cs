using System;

namespace CollectionsClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            object a = 2;
            object b = 3;
            foreach (var v in new List<object> { a, b, a, b, a })
               Console.WriteLine((int)v);

            Console.ReadLine();
        }
    }
}
