﻿namespace Formula
{
    public static partial class Formulas
    {
        public static bool? Equals(object value_1, object value_2)
        {
            if(value_1 == null && value_2 == null)
            {
                return null;
            }

            return value_1 == value_2;
        }

    }
}
