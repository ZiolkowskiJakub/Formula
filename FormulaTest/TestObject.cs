using Formula;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
                    value = "Thin natural stone";
                    return true;
            }

            value = null;
            return false;

        }
    }
}
