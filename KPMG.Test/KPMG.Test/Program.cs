using Newtonsoft.Json;
using System;

namespace KPMG_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var nestedObj = new Nested("x", "a");
            //var nestedObj = new Nested("x", new Nested("y", new Nested("z", "a")));            
            Console.WriteLine(string.Join("/", nestedObj.GetKeys()));
            Console.WriteLine(nestedObj.GetValue());
            var result = nestedObj.GetValueByKey("x");
            if (result.GetType().Name == "Nested")
            {
                Console.WriteLine(JsonConvert.SerializeObject(result)); 
            }
            else
            {
                Console.WriteLine(result.ToString());
            }
           
            Console.ReadLine();
        }
    }
}
