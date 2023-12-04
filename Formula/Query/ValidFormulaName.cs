using System.Text.RegularExpressions;

namespace Formula
{
    public static partial class Query
    {
        public static bool ValidFormulaName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }

            return Regex.IsMatch(name, @"^[a-zA-Z0-9_]+$");
        }
    }
}