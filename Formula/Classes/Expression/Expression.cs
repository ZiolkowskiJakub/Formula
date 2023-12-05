namespace Formula
{

    public abstract class Expression
    {
        public string Text;

        public Expression(string text)
        {
            Text = text.Trim();
        }

        public virtual List<Expression>? GetExpressions()
        {
            return Create.Expressions(Text);
        }

        public override string ToString()
        {
            return Text?.ToString();
        }

        public virtual bool TryGetValue(IFormulaObject formulaObject, out object result)
        {
            result = null;

            List<Expression>? expressions = GetExpressions();
            if (expressions == null)
            {
                return Query.TryParse(Text, out result);
            }

            List<object?> values = expressions.Values(formulaObject);

            return Query.TryGetValue(values, out result);
        }
    }
}
