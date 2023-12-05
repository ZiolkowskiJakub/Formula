using System.Reflection;

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
                    string? name = methodInfo?.Name?.ToUpper();
                    if (string.IsNullOrWhiteSpace(name))
                    {
                        continue;
                    }

                    if(!dictionary.TryGetValue(name, out List<MethodInfo>? methodInfos_Name))
                    {
                        methodInfos_Name = new List<MethodInfo>();
                        dictionary[name] = methodInfos_Name;
                    }

                    methodInfos_Name.Add(methodInfo);
                }
            }
        }

        public MethodInfo? FindMethodInfo(string name, IEnumerable<object?>? parameters = null)
        {
            string? name_Temp = name?.ToUpper();
            if(string.IsNullOrWhiteSpace(name_Temp))
            {
                return null;
            }

            if(!dictionary.TryGetValue(name_Temp, out List<MethodInfo>? methodInfos) || methodInfos == null || methodInfos.Count == 0)
            {
                return null;
            }

            if(parameters == null)
            {
                return methodInfos.FirstOrDefault();
            }

            foreach(MethodInfo methodInfo in methodInfos)
            {
                ParameterInfo[] parameterInfos = methodInfo.GetParameters();
                if(parameters.Count() == parameterInfos.Length)
                {
                    return methodInfo;
                }
            }

            return null;
        }

    }
}
