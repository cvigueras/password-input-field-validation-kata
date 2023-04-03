using System.Text.RegularExpressions;

namespace PasswordInput.Console;

public class Password
{
    public string Value { get; }
    public string ErrorMessage { get; private set; }
    public bool PasswordIsValid { get; private set; }

    private Password(string password)
    {
        Value = password;
        ErrorMessage = string.Empty;
        PasswordIsValid = true;
    }

    public static Password Create(string password)
    {
        return new Password(password);
    }

    public void SetErrorMessage(string errorMessage)
    {
        SetPasswordIsValid();
        if (!string.IsNullOrEmpty(ErrorMessage))
        {
            ErrorMessage += "\n";
        }
        
        ErrorMessage += errorMessage;
    }


    public bool CheckHasEspecialCharacter()
    {
        var regex = new Regex("[^a-zA-Z0-9]{1,}");
        if (!string.IsNullOrEmpty(Value) && regex.IsMatch(Value)) return true;
        SetErrorMessage("Password must contain at least one special character");
        return false;
    }

    public bool CheckHasCapitalLetter()
    {
        var regex = new Regex("[A-Z]{1,}");
        if (!string.IsNullOrEmpty(Value) && regex.IsMatch(Value)) return true;
        SetErrorMessage("Password must contain at least one capital letter");
        return false;
    }

    public bool CheckHasLength()
    {
        if (!string.IsNullOrEmpty(Value) && Value.Length >= 8) return true;
        SetErrorMessage("Password must be at least 8 characters");
        return false;
    }

    public bool CheckHasAtLeastTwoNumbers()
    {
        var regex = new Regex(@"(\D*\d){2,}");
        if (!string.IsNullOrEmpty(Value) && regex.IsMatch(Value)) return true;
        SetErrorMessage("The password must contain at least 2 numbers");
        return false;
    }
    private void SetPasswordIsValid()
    {
        PasswordIsValid = false;
    }
}