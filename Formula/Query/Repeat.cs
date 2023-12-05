using System.Collections;

namespace Formula
{
    public static partial class Query
    {
        public static List<object?>? Repeat(object? @object, int count)
        {
            if(count == -1)
            {
                return null;
            }

            List<object?>? result = new List<object?>();
            if (count == 0)
            {
                return result;
            }

            if (!(@object is IEnumerable && !(@object is string)))
            {
                result.Add(@object);
            }
            else
            {
                foreach(object? @object_Temp in (IEnumerable)@object)
                {
                    result.Add(object_Temp);
                }
            }

            if(result.Count == count)
            {
                return result;
            }

            if(result.Count > count)
            {
                result.GetRange(0, count);
                return result;
            }

            int index = 0;
            while(result.Count != count)
            {
                result.Add(result[index]);
                index++;
            }

            return result;
        }
    }
}