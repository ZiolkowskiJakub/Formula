using System.Reflection;

namespace Formula
{
    public static class CommandManager
    {
        private static FormulaCalculator formulaCalculator = new FormulaCalculator();

        public static bool TryGetValue(string name, List<object?>? parameters, out object? value)
        {
            return formulaCalculator.TryGetValue(name, parameters, out value);
        }
    }
}
