using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Formula
{
    public static partial class Query
    {
        public static bool AllEnumerables(this IEnumerable<ParameterInfo> parameterInfos)
        {
            if(parameterInfos == null || parameterInfos.Count() == 0)
            {
                return false;
            }

            Type type = typeof(IEnumerable);
            foreach (ParameterInfo parameterInfo in parameterInfos)
            {
                Type type_Temp = parameterInfo.ParameterType;


                if(type == null || !type.IsAssignableFrom(type_Temp))
                {
                    return false;
                }
            }

            return true;

        }
    }
}