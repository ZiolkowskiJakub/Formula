using System.Collections;

namespace Formula
{
    public static partial class Query
    {
        public static bool CountEquals(this IEnumerable objects, out int count)
        {
            count = - 1;
            if (objects == null)
            {
                return false;
            }

            count = int.MinValue;
            foreach (object @object in objects)
            {
                int count_Temp = Count(@object);
                if(count == int.MinValue)
                {
                    count = count_Temp;
                    continue;
                }

                if(count_Temp != count)
                {
                    return false;
                }
            }

            if(count == int.MinValue)
            {
                count = -1;
                return false;
            }

            return true;
        }
    }
}