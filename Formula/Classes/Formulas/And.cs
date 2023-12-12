namespace Formula
{
    public static partial class Formulas
    {
        public static bool? And(object value_1, object value_2)
        {
            if(value_1 == null && value_2 == null)
            {
                return null;
            }

            if(!Query.TryConvert(value_1, out bool bool_1))
            {
                return null;
            }

            if (!Query.TryConvert(value_2, out bool bool_2))
            {
                return null;
            }

            return bool_1 && bool_2;
        }

    }
}
