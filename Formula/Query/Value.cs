using System.Reflection.Emit;

namespace Formula
{
    public static partial class Query
    {
        public static string? Value(string? @in, out string? @out, out ExpressionType expressionType)
        {
            @out = null;
            expressionType = global::Formula.ExpressionType.Undefined;

            if (string.IsNullOrWhiteSpace(@in))
            {
                return null;
            }

            expressionType = ExpressionType(@in);
            if (expressionType == global::Formula.ExpressionType.Undefined)
            {
                return null;
            }

            switch (expressionType)
            {
                case global::Formula.ExpressionType.Operation:
                    return Value_Operation(@in, out @out);

                case global::Formula.ExpressionType.Formula:
                    return Value_Formula(@in, out @out);

                case global::Formula.ExpressionType.Parameter:
                    return Value_Parameter(@in, out @out);

                case global::Formula.ExpressionType.Array:
                    return Value_Array(@in, out @out);

                default:
                    return null;

            }
        }

        private static string? Value_Operation(string @in, out string? @out)
        {
            @out = null;

            if (string.IsNullOrWhiteSpace(@in))
            {
                return null;
            }

            int index_Formula = @in.IndexOf(Operator.Formula_Start, 0, true);
            int index_Parameter = @in.IndexOf(Operator.Parameter_Start, 0, true);
            int index_Array = @in.IndexOf(Operator.Array_Start, 0, true);

            if (index_Formula == -1 && index_Parameter == -1 && index_Array == -1)
            {
                return @in;
            }

            if(index_Parameter != -1 && (index_Formula == -1 ||  index_Parameter < index_Formula) && (index_Array == -1 || index_Parameter < index_Array))
            {
                @out = @in.Substring(index_Parameter);
                return @in.Substring(0, index_Parameter);
            }

            if (index_Array != -1 && (index_Formula == -1 || index_Array < index_Formula) && (index_Parameter == -1 || index_Array < index_Parameter))
            {
                @out = @in.Substring(index_Array);
                return @in.Substring(0, index_Array);
            }

            string prefix = @in.Substring(0, index_Formula);

            int count = 1;
            string name = null;
            string name_Temp = null;
            do
            {
                name = name_Temp;
                name_Temp = prefix.Substring(prefix.Length - count, count);
                count++;

            } while (ValidFormulaName(name_Temp));

            @out = @in.Substring(index_Formula - name.Length);
            return @in.Substring(0, index_Formula - name.Length);
        }

        private static string? Value_Formula(string @in, out string? @out)
        {
            @out = null;

            if(string.IsNullOrWhiteSpace(@in))
            {
                return null;
            }

            int index_Start = @in.IndexOf(Operator.Formula_Start, 0, true);
            if(index_Start == -1)
            {
                return null;
            }


            int index_End = index_Start;
            int count_Start = -1;
            int count_End = -1;
            do
            {
                index_End = @in.IndexOf(Operator.Formula_End, index_End + 1, true);

                count_End = Count(@in, Operator.Formula_End, 0, index_End + 1, true);

                count_Start = Count(@in, Operator.Formula_Start, 0, index_End + 1, true);
                

            } while (index_End != -1 && count_Start != count_End);

            if (index_End == -1)
            {
                return null;
            }

            @out = @in.Substring(index_End + 1);

            return @in.Substring(0, index_End + 1);
        }

        private static string? Value_Parameter(string @in, out string? @out)
        {
            @out = null;

            if (string.IsNullOrWhiteSpace(@in))
            {
                return null;
            }

            int index_Start = @in.IndexOf(Operator.Parameter_Start, 0, true);
            if (index_Start == -1)
            {
                return null;
            }

            int index_End = @in.IndexOf(Operator.Parameter_End, index_Start, true);
            if (index_End == -1)
            {
                return null;
            }

            @out = @in.Substring(index_End + 1);

            return @in.Substring(0, index_End + 1);
        }

        private static string? Value_Array(string @in, out string? @out)
        {
            @out = null;

            if (string.IsNullOrWhiteSpace(@in))
            {
                return null;
            }

            int index_Start = @in.IndexOf(Operator.Array_Start, 0, true);
            if (index_Start == -1)
            {
                return null;
            }

            int index_End = @in.IndexOf(Operator.Array_End, index_Start, true);
            if (index_End == -1)
            {
                return null;
            }

            @out = @in.Substring(index_End + 1);

            return @in.Substring(0, index_End + 1);
        }
    }
}