using System.Reflection;

namespace Formula
{
    public class FormulaCalculator
    {
        Dictionary<string, List<MethodInfo?>?> dictionary = new Dictionary<string, List<MethodInfo?>?>();

        public FormulaCalculator() 
        {
            IEnumerable<MethodInfo?>? methodInfos = Query.MethodInfos();
            if(methodInfos != null)
            {
                foreach(MethodInfo? methodInfo in methodInfos)
                {
                    string? name = methodInfo?.Name?.ToUpper();
                    if (string.IsNullOrWhiteSpace(name))
                    {
                        continue;
                    }

                    if(!dictionary.TryGetValue(name, out List<MethodInfo?>? methodInfos_Name))
                    {
                        methodInfos_Name = new List<MethodInfo?>();
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

        public bool TryGetValue(string name, IEnumerable<object?>? parameters, out object? value)
        {
            value = null;
            
            string? name_Temp = name?.ToUpper();
            if (string.IsNullOrWhiteSpace(name_Temp))
            {
                return false;
            }

            if (!dictionary.TryGetValue(name_Temp, out List<MethodInfo?>? methodInfos) || methodInfos == null || methodInfos.Count == 0)
            {
                return false;
            }

            List<object?>? values = parameters?.ToList();
            if (values != null)
            {
                for (int i = 0; i < values.Count; i++)
                {
                    values[i] = Query.Evaluate(values[i]);
                }
            }

            MethodInfo? methodInfo = null;
            foreach (MethodInfo? methodInfo_Temp in methodInfos)
            {
                ParameterInfo[]? parameterInfos = methodInfo_Temp?.GetParameters();
                if(parameterInfos == null || parameterInfos.Length == 0)
                {
                    if(parameters == null || parameters.Count() == 0)
                    {
                        methodInfo = methodInfo_Temp;
                        break;
                    }

                    continue;
                }

                if (parameters == null)
                {
                    continue;
                }

                if (parameters.Count() == parameterInfos.Length)
                {
                    methodInfo = methodInfo_Temp;
                }
            }

            if(methodInfo == null)
            {
                return false;
            }

            try
            {
                value = methodInfo.Invoke(null, values?.ToArray());
            }
            catch
            {
                value = null;
                return false;
            }

            return true;
        }

    }
}
