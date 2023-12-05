using System.Collections;
using System.Data;

namespace Formula
{
    public static partial class Query
    {
        public static object? Compute(object? @object)
        {
            if(@object == null)
            {
                return null;
            }

            DataTable dataTable = new DataTable();

            if(@object is string)
            {
                object result = null;
                try
                {
                    result = dataTable.Compute((string)@object, null);
                }
                catch
                {
                    result = @object;
                }

                return result;
            }

            
            if(@object is IEnumerable)
            {
                List<object?> result = new List<object?>();
                foreach(object? @object_Temp in (IEnumerable)@object)
                {
                    object? object_Result = @object_Temp;
                    if (@object_Temp is string)
                    {
                        try
                        {
                            @object_Result = dataTable.Compute((string)@object_Temp, null);
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