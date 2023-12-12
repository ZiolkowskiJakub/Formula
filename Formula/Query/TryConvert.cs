

using System;

namespace Formula
{
    public static partial class Query
    {
        public static bool TryConvert<T>(this object value, out T result)
        {
            result = default(T);

            if(value is T)
            {
                result = (T)(object)value;
                return true;
            }

            if(typeof(T) == typeof(bool))
            {
                if(value == null)
                {
                    return false;
                }

                if(value is string)
                {
                    string @string = ((string)value).Trim().ToUpper();
                    if (@string == "TRUE" || @string == "Y" || @string == "YES" || @string == "+")
                    {
                        result = (T)(object)true;
                        return true;
                    }
                    if (@string == "FALSE" || @string == "N" || @string == "NO" || @string == "-" || @string == string.Empty)
                    {
                        result = (T)(object)false;
                        return true;
                    }

                    if(int.TryParse(@string, out int @int))
                    {
                        if(@int == 0 || @int == -1)
                        {
                            result = (T)(object)false;
                            return true;
                        }

                        if (@int == 1)
                        {
                            result = (T)(object)true;
                            return true;
                        }
                    }

                    return false;
                }

                if(value is int)
                {
                    int @int = (int)value;

                    if (@int == 0 || @int == -1)
                    {
                        result = (T)(object)false;
                        return true;
                    }

                    if (@int == 1)
                    {
                        result = (T)(object)true;
                        return true;
                    }
                }

                if (value is double)
                {
                    long @long = Convert.ToInt64(value);

                    if (@long == 0 || @long == -1)
                    {
                        result = (T)(object)false;
                        return true;
                    }

                    if (@long == 1)
                    {
                        result = (T)(object)true;
                        return true;
                    }
                }
            }

            return true;
        }
    }
}