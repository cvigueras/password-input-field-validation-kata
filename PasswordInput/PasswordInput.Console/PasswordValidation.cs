using System.Text.RegularExpressions;

namespace PasswordInput.Console;

public class PasswordValidation
{
    public bool CheckConditions(Password password)
    {
        bool hasConditions = CheckHasLength(password);
        hasConditions = CheckHasAtLeastTwoNumbers(password);
        hasConditions = CheckHasCapitalLetter(password);
        hasConditions = CheckHasEspecialCharacter(password);
        return hasConditions;
    }

    private static bool CheckHasEspecialCharacter(Password password)
    {
        var regex = new Regex("[^a-zA-Z0-9]{1,}");
        if (string.IsNullOrEmpty(password.Value) || !regex.IsMatch(password.Value))
        {
            password.SetErrorMessage("Password must contain at least one special character");
            return false;
        }
        return true;
    }

    private static bool CheckHasCapitalLetter(Password password)
    {
        var regex = new Regex("[A-Z]{1,}");
        if (string.IsNullOrEmpty(password.Value) || !regex.IsMatch(password.Value))
        {
            password.SetErrorMessage("Password must contain at least one capital letter");
            return false;
        }
        return true;
    }

    private static bool CheckHasLength(Password password)
    {
        if (string.IsNullOrEmpty(password.Value) || password.Value.Length < 8)
        {
            password.SetErrorMessage("Password must be at least 8 characters");
            return false;
        }
        return true;
    }

    private static bool CheckHasAtLeastTwoNumbers(Password password)
    {
        var regex = new Regex(@"(\D*\d){2,}");
        if (string.IsNullOrEmpty(password.Value) || !regex.IsMatch(password.Value))
        {
            password.SetErrorMessage("The password must contain at least 2 numbers");
            return false;

        }
        return true;
    }
}