using System.Reflection.Metadata.Ecma335;

namespace Formula
{
    public static partial class Formulas
    {
        public static object? Lookup(object? value, IEnumerable<object>? input, IEnumerable<object>? output, object? notFoundValue)
        {
            if (input == null || output == null)
            {
                return notFoundValue;
            }

            int index = -1;
            for (int i = 0; i < input.Count(); i++)
            {
                if (input.ElementAt(i) == value)
                {
                    index = i;
                    break;
                }
            }

            if(index == -1)
            {
                return notFoundValue;
            }


            if(output.Count() == 0  || output.Count() < index)
            {
                return notFoundValue;
            }

            return output.ElementAt(index);
        }

        public static object? Lookup(object? value, IEnumerable<object>? input, IEnumerable<object>? output)
        {
            return Lookup(value, input, output);
        }

    }
}
