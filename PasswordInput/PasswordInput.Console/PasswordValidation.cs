namespace PasswordInput.Console;

public class PasswordValidation
{
    public bool CheckConditions(string password, out string errorMessage)
    {
        errorMessage = string.Empty;
        if (password == null)
        {
            errorMessage = "Password must be at least 8 characters";
            return false;
        }
        if (password == "")
        {
            errorMessage = "Password must be at least 8 characters";
            return false;
        }

        return true;
    }
}