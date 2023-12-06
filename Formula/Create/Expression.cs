namespace Formula
{
    public static partial class Create
    {
        public static Expression Expression(string @in, out string @out)
        {
            string? expressionString = Query.Value(@in, out @out, out ExpressionType expressionType);
            if (string.IsNullOrWhiteSpace(expressionString))
            {
                return null;
            }

            Expression result = null;
            switch (expressionType)
            {
                case ExpressionType.Formula:
                    result = new Formula(expressionString);
                    break;

                case ExpressionType.Operation:
                    result = new Operation(expressionString);
                    break;

                case ExpressionType.Parameter:
                    result = new Parameter(expressionString);
                    break;

                case ExpressionType.Array:
                    result = new Array(expressionString);
                    break;
            }

            return result;
        }

        public static Expression Expression(string text)
        {
            string? text_Temp = text?.Trim();
            if(string.IsNullOrWhiteSpace(text_Temp))
            {
                return null;
            }

            Expression result = Expression(text_Temp, out string @out);
            if(result == null)
            {
                return null;
            }

            if(result.Text != text_Temp)
            {
                result = new Operation(text_Temp);
            }

            return result;
        }
    }
}