namespace Formula
{

    public abstract class Expression
    {
        public string Text;

        public Expression(string text)
        {
            this.Text = text.Trim();
        }

        public virtual List<Expression>? GetExpressions()
        {
            return Create.Expressions(Text);
        }

        public override string ToString()
        {
            return Text?.ToString();
        }
    }
}
