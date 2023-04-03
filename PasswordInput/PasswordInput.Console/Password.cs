namespace PasswordInput.Console;

public class Password
{
    public string Value { get; }
    public string ErrorMessage { get; }
    private Password(string password)
    {
        Value = password;
        ErrorMessage = string.Empty;
    }

    public static Password Create(string password)
    {
        return new Password(password);
    }

}