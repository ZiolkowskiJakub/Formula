namespace Formula
{
    public static partial class Query
    {
        public static bool StartsWith(this string value, char @char)
        {
            if(string.IsNullOrEmpty(value))
            {
                return false;
            }

            return value[0] == @char;
        }
    }
}