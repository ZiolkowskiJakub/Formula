using System.Collections.Generic;

namespace Formula
{
    public static partial class Create
    {
        public static List<Expression> Expressions(string text)
        {
            if(string.IsNullOrWhiteSpace(text))
            {
                return null;
            }
            
            List<Expression> result = null;

            string @out = null;

            string @in = text;
            do
            {
                Expression expression = Expression(@in, out @out);
                if (expression == null)
                {
                    break;
                }

                if (result == null)
                {
                    result = new List<Expression>();
                }

                result.Add(expression);

                @in = @out;
            }
            while (!string.IsNullOrWhiteSpace(@out));

            return result;
        }

        public static List<Expression> Expressions(string text, char start, char end, char separator)
        {
            List<Expression> result = new List<Expression?>();

            int index_Separator;

            string text_Temp = text;

            do
            {
                index_Separator = 0;

                int count_Start = -1;
                int count_End = -1;
                do
                {
                    index_Separator = text_Temp.IndexOf(separator, index_Separator + 1, true);

                    count_End = Query.Count(text_Temp, end, 0, index_Separator + 1, true);

                    count_Start = Query.Count(text_Temp, start, 0, index_Separator + 1, true);


                } while (index_Separator != -1 && count_Start != count_End);

                string expressionString = text_Temp.Substring(0, index_Separator);

                Expression expression_Temp = Expression(expressionString);
                if (expression_Temp != null)
                {
                    result.Add(expression_Temp);
                }

                text_Temp = text_Temp.Substring(index_Separator + 1);

                index_Separator = text_Temp.IndexOf(separator, 0, true);
                if (index_Separator == -1)
                {
                    expression_Temp = Expression(text_Temp);
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