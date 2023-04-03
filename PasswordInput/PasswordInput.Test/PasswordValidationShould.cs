using FluentAssertions;
using PasswordInput.Console;

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

        [Test]
        public void get_error_message_and_false_when_password_is_empty()
        {
            var passwordValidation = new PasswordValidation();

            var result = passwordValidation.CheckConditions(string.Empty, out var errorMessage);

            errorMessage.Should().Be("Password must be at least 8 characters");
            result.Should().Be(false);
        }
    }
}