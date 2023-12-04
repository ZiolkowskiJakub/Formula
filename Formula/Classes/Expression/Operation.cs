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
            return null;
        }
    }
}
