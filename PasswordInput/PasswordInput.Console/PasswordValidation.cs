using System.Text.RegularExpressions;

namespace PasswordInput.Console;

public class PasswordValidation
{
    public bool CheckConditions(Password password, ref string errorMessage)
    {
        errorMessage = string.Empty;
        bool hasConditions = CheckHasLength(ref errorMessage, password);
        hasConditions = CheckHasAtLeastTwoNumbers(ref errorMessage, password);
        hasConditions = CheckHasCapitalLetter(ref errorMessage, password);
        hasConditions = CheckHasEspecialCharacter(ref errorMessage, password);
        return hasConditions;
    }

    private static bool CheckHasEspecialCharacter(ref string errorMessage, Password password)
    {
        var regex = new Regex("[^a-zA-Z0-9]{1,}");
        if (string.IsNullOrEmpty(password.Value) || !regex.IsMatch(password.Value))
        {
            if (!string.IsNullOrEmpty(errorMessage))
            {
                errorMessage += "\n";
            }
            errorMessage += "Password must contain at least one special character";
            return false;
        }
        return true;
    }

    private static bool CheckHasCapitalLetter(ref string errorMessage, Password password)
    {
        var regex = new Regex("[A-Z]{1,}");
        if (string.IsNullOrEmpty(password.Value) || !regex.IsMatch(password.Value))
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

    private static bool CheckHasLength(ref string errorMessage, Password password)
    {
        if (string.IsNullOrEmpty(password.Value) || password.Value.Length < 8)
        {
            errorMessage = "Password must be at least 8 characters";
            return false;
        }
        return true;
    }

    private static bool CheckHasAtLeastTwoNumbers(ref string errorMessage, Password password)
    {
        var regex = new Regex(@"(\D*\d){2,}");
        if (string.IsNullOrEmpty(password.Value) || !regex.IsMatch(password.Value))
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