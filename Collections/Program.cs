using System;

namespace CollectionsClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            object a = (object)2;
            object b = (object)3;
            var array = new ObjectArray { a, b, a, b, a };

            foreach (var v in array)
                Console.WriteLine((int)v);
            


            Console.ReadLine();
        }
    }
}
