using System.Collections;
using System.Linq;

namespace Formula
{
    public static partial class Query
    {
        public static int Count(this string value, char @char, int startIndex = 0, int endIndex = -1, bool skipQuotes = true)
        {
            if (value == null || value.Length == 0)
            {
                return -1;
            }

            int length = endIndex == -1 ? value.Length - startIndex : endIndex - startIndex;

            string value_Temp = value.Substring(startIndex, length);

            if (!skipQuotes)
            {
                return value_Temp.Count(x => x == @char);
            }

            int result = 0;
            
            int index = value_Temp.IndexOf(@char);
            while(index != -1)
            {
                if(!Quoted(value_Temp, index))
                {
                    result++;
                }

                index = value_Temp.IndexOf(@char, index + 1);
            }

            return result;
        }

        public static int Count(object @object, out bool isEnumerable)
        {
            isEnumerable = false;
            if(@object == null)
            {
                return -1;
            }

            if(!(@object is IEnumerable && !(@object is string)))
            {
                return 1;
            }

            int result = 0;
            foreach(object @object_Temp in (IEnumerable)@object)
            {
                result++;
            }

            isEnumerable = true;
            return result;
        }

        public static int Count(object @object)
        {
            return Count(@object, out bool isEnumerable);
        }
    }
}