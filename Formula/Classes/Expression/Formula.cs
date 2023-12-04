namespace Formula
{

    public class Formula : Expression
    {
        public Formula(string text)
            : base(text)
        {

        }

        public string Name
        {
            get
            {
                return GetName();
            }
        }

        private string GetName()
        {
            if (string.IsNullOrEmpty(Text))
            {
                return null;
            }

            int index = Text.IndexOf(Operator.Formula_Start, 0, true);
            if (index == -1)
            {
                return null;
            }


            return Text.Substring(0, index);
        }

        public override List<Expression>? GetExpressions()
        {
            int index_Start;

            int index = Text.IndexOf(Operator.Formula_Separartor, 0, true);
            if(index == -1)
            {
                index_Start = Text.IndexOf(Operator.Formula_Start);
                int index_End = Text.LastIndexOf(Operator.Formula_End);
                if(index_Start == -1 || index_End == -1)
                {
                    return null;
                }

                Expression? expression = Create.Expression(Text.Substring(index_Start + 1, index_End - index_Start - 1));
                return expression == null ? null : new List<Expression>() { expression };
            }

            index_Start = Text.IndexOf(Operator.Formula_Start, 0, true);
            if (index_Start == -1)
            {
                return null;
            }

            string text_Temp = Text.Substring(index_Start + 1, Text.Length - index_Start - 2);

            List<Expression> result = new List<Expression>();


            int index_Separator;

            do
            {
                index_Separator = 0;

                int count_Start = -1;
                int count_End = -1;
                do
                {
                    index_Separator = text_Temp.IndexOf(Operator.Formula_Separartor, index_Separator + 1, true);

                    count_End = Query.Count(text_Temp, Operator.Formula_End, 0, index_Separator + 1, true);

                    count_Start = Query.Count(text_Temp, Operator.Formula_Start, 0, index_Separator + 1, true);


                } while (index_Separator != -1 && count_Start != count_End);

                string expressionString = text_Temp.Substring(0, index_Separator);

                Expression expression_Temp = Create.Expression(expressionString);
                if (expression_Temp != null)
                {
                    result.Add(expression_Temp);
                }

                text_Temp = text_Temp.Substring(index_Separator + 1);

                index_Separator = text_Temp.IndexOf(Operator.Formula_Separartor, 0, true);
                if(index_Separator == -1)
                {
                    expression_Temp = Create.Expression(text_Temp);
                    if (expression_Temp != null)
                    {
                        result.Add(expression_Temp);
                    }
                }

            } while (index_Separator != -1);

            return result;
        }
    }
}
