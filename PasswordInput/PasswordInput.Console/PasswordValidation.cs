using System.Text.RegularExpressions;

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
        if (!CheckHasLength(password, out errorMessage)) return false;

        if (!CheckHasAtLeastTwoNumbers(password, out errorMessage)) return false;
        return true;
    }

    private static bool CheckHasLength(string password, out string errorMessage)
    {
        errorMessage = string.Empty;
        if (string.IsNullOrEmpty(password) || password.Length < 8)
        {
            errorMessage = "Password must be at least 8 characters";
            return false;
        }

        return true;
    }

    private static bool CheckHasAtLeastTwoNumbers(string password, out string errorMessage)
    {
        errorMessage = string.Empty;
        var regex = new Regex("^(?=(?:\\D*\\d){2})[a-zA-Z0-9]*$");
        if (!regex.IsMatch(password))
        {
            errorMessage = "The password must contain at least 2 numbers";
            return false;

        }
        return true;
    }
}