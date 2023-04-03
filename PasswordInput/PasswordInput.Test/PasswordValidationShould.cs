using FluentAssertions;

namespace PasswordInput.Test
{
    public class PasswordValidationShould
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void get_error_message_and_false_when_password_is_null()
        {
            var passwordValidation = new PasswordValidation();

            var result = passwordValidation.CheckConditions(null, out var errorMessage);

            errorMessage.Should().Be("Password must be at least 8 characters");
            result.Should().Be(false);
        }
    }

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

            return true;
        }
    }
}