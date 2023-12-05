

using System.Reflection;

namespace Formula
{
    public static partial class Query
    {
        public static IEnumerable<MethodInfo> MethodInfos()
        {
            MethodInfo[] result = typeof(Formulas).GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy);

            return result;
        }
    }
}