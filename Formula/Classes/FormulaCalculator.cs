using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;

namespace Formula
{
    public class FormulaCalculator
    {
        Dictionary<string, List<MethodInfo>> dictionary = new Dictionary<string, List<MethodInfo>>();

        public FormulaCalculator() 
        {
            IEnumerable<MethodInfo> methodInfos = Query.MethodInfos();
            if(methodInfos != null)
            {
                foreach(MethodInfo methodInfo in methodInfos)
                {
                    string name = methodInfo?.Name?.ToUpper();
                    if (string.IsNullOrWhiteSpace(name))
                    {
                        continue;
                    }

                    if(!dictionary.TryGetValue(name, out List<MethodInfo> methodInfos_Name))
                    {
                        methodInfos_Name = new List<MethodInfo>();
                        dictionary[name] = methodInfos_Name;
                    }

                    if(methodInfos_Name == null)
                    {
                        continue;
                    }

                    methodInfos_Name.Add(methodInfo);
                }
            }
        }

        public bool TryGetValue(string name, IEnumerable<object> parameters, out object value)
        {
            value = null;
            
            string? name_Temp = name?.ToUpper();
            if (string.IsNullOrWhiteSpace(name_Temp))
            {
                return false;
            }

            if (!dictionary.TryGetValue(name_Temp, out List<MethodInfo> methodInfos) || methodInfos == null || methodInfos.Count == 0)
            {
                return false;
            }

            List<object> values = parameters?.ToList();
            if (values != null)
            {
                for (int i = 0; i < values.Count; i++)
                {
                    values[i] = Query.Evaluate(values[i]);
                }
            }

            MethodInfo methodInfo = null;

            if (Query.CountEquals(values, out int count) && count > 1)
            {
                foreach (MethodInfo methodInfo_Temp in methodInfos)
                {
                    ParameterInfo[] parameterInfos = methodInfo_Temp?.GetParameters();
                    if (parameterInfos == null || parameterInfos.Length == 0)
                    {
                        continue;
                    }

                    if (parameters.Count() == values.Count && !Query.AllEnumerables(parameterInfos))
                    {
                        methodInfo = methodInfo_Temp;
                        break;
                    }
                }

                List<List<object>> values_Transformed = new List<List<object>>();
                for (int i = 0; i < count; i++)
                {
                    values_Transformed.Add(new List<object>());
                }

                foreach (IEnumerable enumerable in values)
                {
                    int count_Temp = 0;
                    foreach (object @object in enumerable)
                    {
                        values_Transformed[count_Temp].Add(@object);
                        count_Temp++;
                    }
                }

                values = new List<object>();
                foreach (List<object> values_Temp in values_Transformed)
                {
                    object value_Temp = null;
                    try
                    {
                        value_Temp = methodInfo.Invoke(null, values_Temp?.ToArray());
                    }
                    catch
                    {
                        return false;
                    }
                    values.Add(value_Temp);
                }

                value = values;
                return true;
            }

            foreach (MethodInfo methodInfo_Temp in methodInfos)
            {
                ParameterInfo[] parameterInfos = methodInfo_Temp?.GetParameters();
                if(parameterInfos == null || parameterInfos.Length == 0)
                {
                    if(values == null || values.Count == 0)
                    {
                        methodInfo = methodInfo_Temp;
                        break;
                    }

                    continue;
                }

                if (values == null)
                {
                    continue;
                }

                if (values.Count == parameterInfos.Length)
                {
                    methodInfo = methodInfo_Temp;
                    break;
                }
            }

            if(methodInfo != null)
            {
                try
                {
                    value = methodInfo.Invoke(null, values?.ToArray());
                    return true;
                }
                catch
                {

                }
            }

            return false;
        }

    }
}
