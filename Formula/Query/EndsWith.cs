namespace Formula
{
    public static partial class Query
    {
        public static bool EndsWith(this string value, char @char)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }

            return value[value.Length - 1] == @char;
        }
    }
}