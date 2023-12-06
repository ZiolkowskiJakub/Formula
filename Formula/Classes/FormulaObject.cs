using System.Collections.Generic;

namespace Formula
{
    public class FormulaObject : IFormulaObject
    {
        private Dictionary<string, object> dictionary = new Dictionary<string, object>();

        public FormulaObject(Dictionary<string, object> dictionary) 
        { 
            if(dictionary != null)
            {
                foreach(KeyValuePair<string, object> keyValuePair in dictionary)
                {
                    dictionary[keyValuePair.Key] = keyValuePair.Value;
                }
            }
        }

        public FormulaObject()
        {

        }

        public object this[string name]
        {
            get
            {
                if(dictionary == null || name == null)
                {
                    return null;
                }

                if(!dictionary.TryGetValue(name, out object result))
                {
                    return null;
                }

                return result;
            }

            set
            {
                if (name == null)
                {
                    return;
                }

                if(dictionary == null)
                {
                    dictionary = new Dictionary<string, object>();
                }

                dictionary[name] = value;
            }
        }

        public bool Add(string name, object value)
        {
            if(name == null)
            {
                return false;
            }

            if(dictionary == null)
            {
                dictionary = new Dictionary<string, object>();
            }

            dictionary[name] = value;
            return true;
        }

        public bool Remove(string name)
        {
            if(dictionary != null || !dictionary.ContainsKey(name))
            {
                return false;
            }

            return dictionary.Remove(name);
        }

        public bool Contains(string name)
        {
            if(name == null || dictionary == null || dictionary.Count == 0)
            {
                return false;
            }

            return dictionary.ContainsKey(name);
        }

        public bool TryGetValue(string propertyName, out object value)
        {
            value = null;
            if(dictionary == null || dictionary.Count == 0)
            {
                return false;
            }

            return dictionary.TryGetValue(propertyName, out value);
        }
    }
}
