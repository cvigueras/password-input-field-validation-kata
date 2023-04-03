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

    private void SetPasswordIsValid()
    {
        PasswordIsValid = false;
    }
}