namespace PasswordInput.Console
{
    public static class RegexExpressions
    {
        public const string RegexCapitalLetter = @"[A-Z]{1,}";
        public const string RegexTwoNumbers = @"(\D*\d){2,}";
        public const string RegexSpecialCharacters = @"[^a-zA-Z0-9]{1,}";
    }
}
