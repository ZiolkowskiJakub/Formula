namespace Formula
{
    public static partial class Query
    {
        public static int IndexOf(this string value, char @char, int startIndex = 0, bool skipQuotes = true)
        {
            if (value == null || value.Length == 0)
            {
                return -1;
            }

            if (!skipQuotes)
            {
                return value.IndexOf(@char, startIndex);
            }

            int result = value.IndexOf(@char, startIndex);

            while (result != -1 && Quoted(value, result, 0))
            {
                result = value.IndexOf(@char, result + 1);
            }

            return result;
        }
    }
}