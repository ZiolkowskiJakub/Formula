namespace Formula
{

    public class Array : Expression
    {
        public Array(string text)
            :base(text)
        {

        }

        public override List<Expression?>? GetExpressions()
        {
            if (string.IsNullOrWhiteSpace(Text) || Text.Length < 2)
            {
                return null;
            }

            string text_Temp = Text.Substring(1, Text.Length - 2);

            return Create.Expressions(text_Temp, Operator.Array_Start, Operator.Array_End, Operator.Array_Separartor);
        }

        public override bool TryGetValue(IFormulaObject formulaObject, out object? result)
        {
            result = null;

            List<Expression>? expressions = GetExpressions();
            if (expressions == null)
            {
                return false;
            }

            List<object?> list = new List<object?>();
            if (expressions.Count == 0)
            {
                result = list;
                return true;
            }

            foreach (Expression expression in expressions)
            {
                object? value = null;

                if (expression != null)
                {
                    expression.TryGetValue(formulaObject, out value);
                }

                list.Add(value);
            }

            result = list;
            return true;
        }
    }
}
