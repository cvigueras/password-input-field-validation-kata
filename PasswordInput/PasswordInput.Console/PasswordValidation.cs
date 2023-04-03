namespace PasswordInput.Console;

public class PasswordValidation
{
    public bool CheckConditions(Password password)
    {
        password.CheckHasLength();
        password.CheckHasAtLeastTwoNumbers();
        password.CheckHasCapitalLetter();
        password.CheckHasEspecialCharacter();
        return password.PasswordIsValid;
    }
}