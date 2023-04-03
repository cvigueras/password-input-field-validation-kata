using System.Text.RegularExpressions;

namespace PasswordInput.Console;

public class PasswordValidation
{
    public bool CheckConditions(Password password)
    {
        var hasConditions = password.CheckHasLength();
        hasConditions = password.CheckHasAtLeastTwoNumbers();
        hasConditions = password.CheckHasCapitalLetter();
        hasConditions = password.CheckHasEspecialCharacter();
        return hasConditions;
    }
}