namespace Formula
{
    public class Command : Expression
    {
        public Command(string text)
            :base(text)
        {

        }

        public override List<Expression?>? GetExpressions()
        {
            if(string.IsNullOrWhiteSpace(Text)|| Text.Length < 1)
            {
                return null;
            }

            string text_Temp = Text.Substring(1);

            return Create.Expressions(text_Temp);
        }

        public override bool TryGetValue(IFormulaObject formulaObject, out object? result)
        {
            result = null;

            List<Expression?>? expressions = GetExpressions();
            if (expressions == null)
            {
                return Query.TryParse(Text, out result);
            }

            List<object?>? values = expressions.Values(formulaObject);

            if(! Query.TryGetValue(values, out result))
            {
                return false;
            }

            result = Query.Evaluate(result);
            return true;
        }
    }
}
