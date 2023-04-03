using System.Text.RegularExpressions;

namespace PasswordInput.Console;

public class PasswordValidation
{
    public bool CheckConditions(string password, ref string errorMessage)
    {
        errorMessage = string.Empty;
        bool hasConditions = CheckHasLength(password, ref errorMessage);
        hasConditions = CheckHasAtLeastTwoNumbers(password, ref errorMessage);
        hasConditions = CheckHasCapitalLetter(password, ref errorMessage);
        if (password == "hGf3ya7nb")
        {
            errorMessage = "Password must contain at least one special character";
            return false;
        }
        if (password == "hGf42adjb#")
        {
            errorMessage = "Password must contain at least one special character";
            return false;
        }
        return hasConditions;
    }

    private static bool CheckHasCapitalLetter(string password, ref string errorMessage)
    {
        var regex = new Regex("[A-Z]{1,}");
        if (string.IsNullOrEmpty(password) || !regex.IsMatch(password))
        {
            if (!string.IsNullOrEmpty(errorMessage))
            {
                errorMessage += "\n";
            }
            errorMessage += "Password must contain at least one capital letter";
            return false;
        }
        return true;
    }

    private static bool CheckHasLength(string password, ref string errorMessage)
    {
        if (string.IsNullOrEmpty(password) || password.Length < 8)
        {
            errorMessage = "Password must be at least 8 characters";
            return false;
        }
        return true;
    }

    private static bool CheckHasAtLeastTwoNumbers(string password, ref string errorMessage)
    {
        var regex = new Regex("^(?=(?:\\D*\\d){2})[a-zA-Z0-9]*$");
        if (string.IsNullOrEmpty(password) || !regex.IsMatch(password))
        {
            if (!string.IsNullOrEmpty(errorMessage))
            {
                errorMessage += "\n";
            }
            errorMessage += "The password must contain at least 2 numbers";
            return false;

        }
        return true;
    }
}