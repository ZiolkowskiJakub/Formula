using System.Collections;
using System.Collections.Generic;

namespace Formula
{
    public static partial class Query
    {
        public static object Evaluate(object @object)
        {
            if(@object == null)
            {
                return null;
            }

            if(@object is string)
            {
                object? result = null;
                try
                {
                    NCalc.Expression expression = new NCalc.Expression((string)@object);
                    result = expression.Evaluate();
                }
                catch
                {
                    result = @object;
                }

                return result;
            }

            
            if(@object is IEnumerable)
            {
                List<object> result = new List<object>();
                foreach(object @object_Temp in (IEnumerable)@object)
                {
                    object object_Result = @object_Temp;
                    if (@object_Temp is string)
                    {
                        try
                        {
                            NCalc.Expression expression = new NCalc.Expression((string)@object);
                            @object_Result = expression.Evaluate();
                        }
                        catch
                        {
                            @object_Result = @object_Temp;
                        }
                    }
                    result.Add(@object_Result);
                }

                return result;
            }

            return @object;
        }
    }
}