using static System.Net.Mime.MediaTypeNames;

namespace Formula
{
    public static partial class Create
    {
        public static List<Expression> Expressions(string text)
        {
            if(string.IsNullOrWhiteSpace(text))
            {
                return null;
            }
            
            List<Expression>? result = null;

            string? @out = null;

            string? @in = text;
            do
            {
                Expression? expression = Create.Expression(@in, out @out);
                if (expression == null)
                {
                    break;
                }

                if (result == null)
                {
                    result = new List<Expression>();
                }

                result.Add(expression);

                @in = @out;
            }
            while (!string.IsNullOrWhiteSpace(@out));

            return result;
        }
    }
}