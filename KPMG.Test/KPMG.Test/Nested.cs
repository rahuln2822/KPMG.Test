using System.Collections.Generic;

namespace KPMG_Test
{
    public class Nested
    {
        private string _key;
        private string _value;
        private Nested _self;

        public Nested(string key, Nested self)
        {
            _key = key;
            _self = self;
        }

        public Nested(string key, string value)
        {
            _key = key;
            _value = value;
        }

        public List<string> GetKeys()
        {
            var keys = new List<string>();
            keys.Add(_key);

            Nested nestedObj = _self;

            while (nestedObj != null) 
            {
                keys.Add(nestedObj._key);
                nestedObj = nestedObj?._self;
            };
            
            return keys;
        }

        public string GetValue()
        {           
            Nested nestedObj = _self;

            if (nestedObj == null)
                return _value;

            while (nestedObj._value == null) 
            {    
                nestedObj = nestedObj._self;
            };

            return nestedObj?._value;
        }

        public object GetValueByKey(string key)
        {
            Nested nestedObj = _self;

            if (nestedObj == null)
                return _value;

            while (nestedObj._value == null)
            {
                if (nestedObj._key == key)
                {
                    return nestedObj;
                }
                nestedObj = nestedObj._self;
            };

            return nestedObj?._value;
        }
    }
}
