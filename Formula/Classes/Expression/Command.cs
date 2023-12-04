namespace Formula
{
    public class Command : Expression
    {
        public Command(string text)
            :base(text)
        {

        }

        public List<Expression>? GetExpressions()
        {
            if(string.IsNullOrWhiteSpace(Text)|| Text.Length < 1)
            {
                return null;
            }

            string text_Tmep = Text.Substring(1);

            return Create.Expressions(text_Tmep);
        }
    }
}
