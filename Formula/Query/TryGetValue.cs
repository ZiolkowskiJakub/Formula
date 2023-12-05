

namespace Formula
{
    public static partial class Query
    {
        public static bool TryGetValue(this IEnumerable<object?>? values, out object? result)
        {
            result = null;

            if(values == null)
            {
                return false;
            }

            List<object?> values_Temp = new List<object?>();
            int max = -1;
            bool hasEnumerable = false;
            foreach (object? value_Temp in values)
            {
                int count = Query.Count(value_Temp, out bool isEnumerable);
                if (isEnumerable)
                {
                    hasEnumerable = true;
                }

                if (count > max)
                {
                    max = count;
                }

                values_Temp.Add(value_Temp);
            }

            if (!hasEnumerable)
            {
                result = string.Join(string.Empty, values_Temp.ConvertAll(x => x?.ToString()));
                return true;
            }

            List<List<object?>?> lists = new List<List<object?>?>();
            for (int i = 0; i < values_Temp.Count; i++)
            {
                List<object?>? list = Repeat(values_Temp[i], max);
                lists.Add(list);
            }

            values_Temp = new List<object?>();
            for (int i = 0; i < max; i++)
            {
                List<object?> values_Updated = new List<object?>();
                foreach (List<object?>? list in lists)
                {
                    values_Updated.Add(list?[i]);
                }

                values_Temp.Add(string.Join(string.Empty, values_Updated.ConvertAll(x => x?.ToString())));
            }

            result = values_Temp;
            return true;
        }
    }
}