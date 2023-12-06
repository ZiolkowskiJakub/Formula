using System.Collections.Generic;

namespace Formula
{

    public class Operation : Expression
    {
        public Operation(string text)
            :base(text)
        {

        }

        public override List<Expression> GetExpressions()
        {
            List<Expression> result = Create.Expressions(Text);
            if(result != null && result.Count == 1 && result[0] != null && result[0].Text == Text)
            {
                result = null;
            }

            return result;
        }
    }
}
