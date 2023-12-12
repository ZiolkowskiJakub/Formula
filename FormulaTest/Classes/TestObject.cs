using Formula;

namespace FormulaTest
{
    public class TestObject : IFormulaObject
    {
        public bool TryGetValue(string propertyName, out object value)
        {
            switch (propertyName)
            {
                case "ZONE AREA":
                    value = 10;
                    return true;

                case "FLOOR COVERING":
                    value = "Thin natural tiles";
                    return true;
            }

            value = null;
            return false;

        }
    }
}
