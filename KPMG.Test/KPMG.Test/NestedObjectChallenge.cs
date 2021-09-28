using KPMG_Test;
using Newtonsoft.Json;
using System;

namespace KPMG.Test
{
    public interface INestedObjectChallenge
    {
        void Write(Nested nested);
        void Write(Nested nested, string key);
    }

    public class NestedObjectChallenge : INestedObjectChallenge
    {
        public void Write(Nested nested)
        {
            Console.WriteLine($"Final value : {nested.GetValue()}");
        }

        public void Write(Nested nested, string key)
        {
            var result = nested.GetValueByKey(key);
            if (result.GetType().Name == "Nested")
            {
                Console.WriteLine($"Specific {key} key value : {JsonConvert.SerializeObject(result)}");
            }
            else
            {
                Console.WriteLine($"Specific {key} value : {result}");
            }
        }
    }
}
