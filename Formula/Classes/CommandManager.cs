using System.Reflection;

namespace Formula
{
    public static class CommandManager
    {
        private static FormulaCalculator formulaCalculator = new FormulaCalculator();

        public static MethodInfo? FindMethodInfo(string name, List<object?>? parameters = null)
        {
            return formulaCalculator?.FindMethodInfo(name, parameters);
        }
    }
}
