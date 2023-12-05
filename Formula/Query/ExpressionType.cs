namespace Formula
{
    public static partial class Query
    {
        public static ExpressionType ExpressionType(string value)
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                return global::Formula.ExpressionType.Undefined; 
            }

            string value_Temp = value.Trim();

            int index;
            
            if(value_Temp.StartsWith(Operator.Parameter_Start))
            {
                index = value_Temp.IndexOf(Operator.Parameter_End, 0, true);
                if (index != -1)
                {
                    return global::Formula.ExpressionType.Parameter;
                }
            }

            if (value_Temp.StartsWith(Operator.Array_Start))
            {
                index = value_Temp.IndexOf(Operator.Array_End, 0, true);
                if (index != -1)
                {
                    return global::Formula.ExpressionType.Array;
                }
            }

            index = value_Temp.IndexOf(Operator.Formula_Start, 0, true);
            if (index > 1)
            {
                string name = value_Temp.Substring(0, index);
                if(ValidFormulaName(name))
                {
                    index = value_Temp.IndexOf(Operator.Formula_End, index, true);
                    if (index > 1)
                    {
                        return global::Formula.ExpressionType.Formula;
                    }
                }
            }

            return global::Formula.ExpressionType.Operation;

        }
    }
}