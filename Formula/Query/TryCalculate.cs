namespace Formula
{
    public static partial class Query
    {
        public static bool TryCalculate(this Command command, IFormulaObject formulaObject, out object? result)
        {
            result = null;
            if(command == null || formulaObject == null)
            {
                return false;
            }

            return false;
        }
    }
}