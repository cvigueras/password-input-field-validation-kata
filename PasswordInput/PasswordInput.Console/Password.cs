using System.Text.RegularExpressions;

namespace PasswordInput.Console;

public class Password
{
    private readonly int _minPasswordLength;
    public string Value { get; }
    public string ErrorMessage { get; private set; }
    public bool PasswordIsValid { get; private set; }

    private Password(string password)
    {
        Value = password;
        ErrorMessage = string.Empty;
        PasswordIsValid = true;
        _minPasswordLength = 8;
    }

    public static Password Create(string password)
    {
        return new Password(password);
    }

    public bool CheckHasEspecialCharacter()
    {
        var regex = new Regex("[^a-zA-Z0-9]{1,}");
        if (!string.IsNullOrEmpty(Value) && regex.IsMatch(Value)) return true;
        SetErrorMessage(ErrorMessages.NotSpecialCharacters);
        return PasswordIsValid;
    }

    public bool CheckHasCapitalLetter()
    {
        var regex = new Regex("[A-Z]{1,}");
        if (!string.IsNullOrEmpty(Value) && regex.IsMatch(Value)) return true;
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
        var regex = new Regex(@"(\D*\d){2,}");
        if (!string.IsNullOrEmpty(Value) && regex.IsMatch(Value)) return true;
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
}