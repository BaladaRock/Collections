using System;

namespace CollectionsClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            object a = 2;
            object b = 3;
            var array = new List<object> { a, b, a, b, a };

            foreach (var v in array)
                Console.WriteLine((int)v);



            Console.ReadLine();
        }
    }
}
