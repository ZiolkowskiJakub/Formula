namespace Formula
{
    public static partial class Query
    {
        public static bool Quoted(string value, int charIndex, int startIndex = 0)
        {
            if(string.IsNullOrWhiteSpace(value) || charIndex == -1 || charIndex == 0 || startIndex == -1 || startIndex> charIndex || value.Length < charIndex)
            {
                return false;
            }

            int count = value.Substring(startIndex, charIndex - startIndex).Count(x => x == '"');

            return count != 0 && count % 2 != 0;
        }
    }
}