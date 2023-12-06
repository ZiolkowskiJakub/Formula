namespace Formula
{
    public static partial class Create
    {
        public static Command Command(string text)
        {
            if(string.IsNullOrWhiteSpace(text))
            {
                return null;
            }

            string text_Temp = text.Trim();
            text_Temp = text_Temp.Trim();

            if (!text_Temp.StartsWith(Operator.Command_Start))
            {
                return null;
            }

            return new Command(text_Temp);
        }
    }
}