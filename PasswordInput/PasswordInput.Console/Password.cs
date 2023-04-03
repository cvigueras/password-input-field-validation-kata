using System.Text.RegularExpressions;

namespace PasswordInput.Console;

public class Password
{
    private readonly int _minPasswordLength;
    public string Value { get; }
    public string ErrorMessage { get; private set; }
    public bool PasswordIsValid { get; private set; }
    private string Expression { get; set; }

    private Password(string value)
    {
        Value = value;
        ErrorMessage = string.Empty;
        PasswordIsValid = true;
        _minPasswordLength = 8;
    }

    public static Password Create(string value)
    {
        return new Password(value);
    }

    public bool CheckHasEspecialCharacter()
    {
        Expression = RegexExpressions.RegexSpecialCharacters;
        if (Validate()) return true;
        SetErrorMessage(ErrorMessages.NotSpecialCharacters);
        return PasswordIsValid;
    }

    public bool CheckHasCapitalLetter()
    {
        Expression = RegexExpressions.RegexCapitalLetter;
        if (Validate()) return true;
        SetErrorMessage(ErrorMessages.NoCapitalLetters);
        return PasswordIsValid;
    }

    public bool CheckHasLength()
    {
        if (!string.IsNullOrEmpty(Value) && Value.Length >= _minPasswordLength) return true;
        SetErrorMessage(ErrorMessages.NotValidLength);
        return PasswordIsValid;
    }

    public bool CheckHasAtLeastTwoNumbers()
    {
        Expression = RegexExpressions.RegexTwoNumbers;
        if (Validate()) return true;
        SetErrorMessage(ErrorMessages.NotContainsTwoDigit);
        return PasswordIsValid;
    }

    private void SetErrorMessage(string errorMessage)
    {
        PasswordIsValid = false;
        if (!string.IsNullOrEmpty(ErrorMessage))
        {
            ErrorMessage += Environment.NewLine;
        }
        
        ErrorMessage += errorMessage;
    }

    private bool Validate()
    {
        var regex = new Regex(Expression);
        return !string.IsNullOrEmpty(Value) && regex.IsMatch(Value);
    }
}