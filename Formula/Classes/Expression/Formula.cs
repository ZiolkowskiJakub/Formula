using System.Collections.Generic;

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

        public override List<Expression> GetExpressions()
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

                Expression expression = Create.Expression(Text.Substring(index_Start + 1, index_End - index_Start - 1));
                return expression == null ? null : new List<Expression>() { expression };
            }

            index_Start = Text.IndexOf(Operator.Formula_Start, 0, true);
            if (index_Start == -1)
            {
                return null;
            }

            string text_Temp = Text.Substring(index_Start + 1, Text.Length - index_Start - 2);

            return Create.Expressions(text_Temp, Operator.Formula_Start, Operator.Formula_End, Operator.Formula_Separartor);
        }

        public override bool TryGetValue(IFormulaObject formulaObject, out object result)
        {
            List<Expression> expressions = GetExpressions();
            if (expressions == null)
            {
                return Query.TryParse(Text, out result);
            }

            List<object> values = expressions.Values(formulaObject);

            return CommandManager.TryGetValue(Name, values, out result);
        }
    }
}
