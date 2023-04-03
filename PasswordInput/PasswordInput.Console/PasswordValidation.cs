namespace PasswordInput.Console;

public class PasswordValidation
{
    public bool CheckConditions(string password, out string errorMessage)
    {
        if (!CheckLength(password, out errorMessage)) return false;

        return true;
    }

    private static bool CheckLength(string password, out string errorMessage)
    {
        errorMessage = string.Empty;
        if (string.IsNullOrEmpty(password) || password.Length < 8)
        {
            errorMessage = "Password must be at least 8 characters";
            return false;
        }
        return true;
    }
}