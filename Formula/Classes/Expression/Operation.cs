namespace Formula
{

    public class Operation : Expression
    {
        public Operation(string text)
            :base(text)
        {

        }

        public override List<Expression>? GetExpressions()
        {
            List<Expression>? result = Create.Expressions(Text);
            if(result != null && result.Count == 1 && result[0] != null && result[0].Text == Text)
            {
                result = null;
            }

            return result;
        }

        //public override bool TryGetValue(IFormulaObject formulaObject, out object result)
        //{
        //    result = null;

        //    List<Expression>? expressions = GetExpressions();
        //    if(expressions == null)
        //    {
        //        if(Text == null)
        //        {
        //            result = Text;
        //            return true;
        //        }

        //        if (Text.Length > 2 && Text.StartsWith('"') && Text.EndsWith('"'))
        //        {
        //            result = Text.Substring(1, Text.Length - 2);
        //            return true;
        //        }

        //        if(double.TryParse(Text, out double @double))
        //        {
        //            result = @double;
        //            return true;
        //        }

        //        result = Text;
        //        return true;
        //    }

        //    List<object?> values = new List<object?>();
        //    foreach(Expression expression in expressions)
        //    {
        //        object? value = null;
        //        if(expression != null)
        //        {
        //            expression.TryGetValue(formulaObject, out value);
        //        }

        //        values.Add(value);
        //    }

        //    result = string.Join(string.Empty, values.ConvertAll(x => x.ToString()));
        //    return true;
        //}
    }
}
