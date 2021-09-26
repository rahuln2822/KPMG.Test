using System;

namespace KPMG_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var nestedObj = new Nested("x", new Nested("y", new Nested("z", "a")));            
            Console.WriteLine(string.Join("/", nestedObj.GetKeys()));
            Console.WriteLine(nestedObj.GetValue());
            Console.WriteLine(nestedObj.GetValueByKey("x"));
            Console.ReadLine();
        }
    }
}
