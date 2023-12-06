namespace Formula
{
    public static partial class Formulas
    {
        public static object If(object value, object @true, object @false)
        {
            if(value == null)
            {
                return null;
            }

            if (value is bool)
            {
                return (bool)value ? @true : @false;
            }

            return null;
        }

    }
}
