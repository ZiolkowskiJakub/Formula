namespace Formula
{

    public class Array : Expression
    {
        public Array(string text)
            :base(text)
        {

        }

        public override List<Expression>? GetExpressions()
        {
            return null;
        }
    }
}
