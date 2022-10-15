namespace Domain
{
    public static class StringValidatior
    {
        public static string ValidateLength(string value, string property, int length)
        {
            if (ValidateIsNullOrWhiteSpace(value, null) == null && value.Length > length)
            {
                return property + ": Max length is 50 chars";
            }

            return null;
        }

        public static string ValidateIsNullOrWhiteSpace(string value, string property)
        {
            if (string.IsNullOrEmpty(value))
            {
                return property + ": Required Field";
            }

            return null;
        }
    }
}
