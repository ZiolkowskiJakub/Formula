

namespace Formula
{
    public static partial class Query
    {
        public static bool TryParse(this string? value, out object? result)
        {
            if (value == null)
            {
                result = value;
                return true;
            }

            if (value.Length > 2 && value.StartsWith('"') && value.EndsWith('"'))
            {
                result = value.Substring(1, value.Length - 2);
                return true;
            }

            if (double.TryParse(value, out double @double))
            {
                result = @double;
                return true;
            }

            result = value;
            return true;
        }
    }
}