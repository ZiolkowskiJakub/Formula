﻿using System.Collections.Generic;

namespace Formula
{

    public class Parameter : Expression
    {
        public Parameter(string text)
            :base(text)
        {

        }

        public string Name
        {
            get
            {
                return GetName();
            }
        }

        private string GetName()
        {
            if(string.IsNullOrEmpty(Text) || Text.Length < 3)
            {
                return null;
            }
            return Text.Substring(1, Text.Length - 2);
        }

        public override List<Expression> GetExpressions()
        {
            return null;
        }

        public override bool TryGetValue(IFormulaObject formulaObject, out object result)
        {
            result = null;
            if(formulaObject == null)
            {
                return false;
            }

            return formulaObject.TryGetValue(Name, out result);
        }
    }
}
