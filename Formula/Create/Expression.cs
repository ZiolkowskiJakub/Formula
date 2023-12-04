namespace Formula
{
    public static partial class Create
    {
        public static Expression? Expression(string? @in, out string? @out)
        {
            string? expressionString = Query.Value(@in, out @out, out ExpressionType expressionType);
            if (string.IsNullOrWhiteSpace(expressionString))
            {
                return null;
            }

            Expression? result = null;
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

        public static Expression? Expression(string? text)
        {
            return Expression(text, out string? @out);
        }
    }
}