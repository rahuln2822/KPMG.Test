using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace KPMG_Test
{
    [Serializable]
    public class Nested
    {
        private string _key;
        private string _value;
        private Nested _self;
        
        public string Key { get { return _key; } }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get { return _value; } }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "NestedValue")]        
        public Nested Self { get { return _self; } }

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

            if (!this.ContainsKey(key))
            {
                throw new InvalidOperationException("Key not exists");
            }

            if (_key == key)
            {
                if (_value == null)
                {
                    return nestedObj;
                }
                else
                {
                    return _value;
                }
            }

            while (nestedObj._value == null)
            {
                if (nestedObj._key == key)
                {
                    return nestedObj._self;
                }
                nestedObj = nestedObj._self;
            };

            return nestedObj?._value;
        }

        public bool ContainsKey(string key)
        {
            var keys = GetKeys();
            return keys.Contains(key);
        }
    }
}
