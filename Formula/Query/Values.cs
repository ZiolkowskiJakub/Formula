

namespace Formula
{
    public static partial class Query
    {
        public static List<object?>? Values(this Expression? expression, IFormulaObject formulaObject)
        {
            if(expression == null)
            {
                return null;
            }

            List<Expression?>? expressions = expression.GetExpressions();
            if(expressions == null)
            {
                if(!TryParse(expression.Text, out object? value))
                {
                    return null;    
                }

                return new List<object?>() { value };
            }

            return Values(expressions, formulaObject);
        }

        public static List<object?>? Values(this IEnumerable<Expression?>? expressions, IFormulaObject formulaObject)
        {
            if(expressions == null)
            {
                return null;
            }

            List<object?> result = new List<object?>();
            foreach (Expression expression_Temp in expressions)
            {
                object? value = null;
                if (expression_Temp != null)
                {
                    expression_Temp.TryGetValue(formulaObject, out value);
                }

                result.Add(value);
            }

            return result;
        }
    }
}