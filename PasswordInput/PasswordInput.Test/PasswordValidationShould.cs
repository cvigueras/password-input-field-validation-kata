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

        [TestCase(null)]
        [TestCase("")]
        [TestCase("abcd")]
        public void get_error_message_and_false_when_password_is_less_than_eight_character(string input)
        {
            var passwordValidation = new PasswordValidation();

            var errorMessage = string.Empty;
            var result = passwordValidation.CheckConditions(input, ref errorMessage);

            errorMessage.Should().Be("Password must be at least 8 characters\nThe password must contain at least 2 numbers");
            result.Should().Be(false);
        }

        [TestCase("1hjunbvf")]
        [TestCase("hjuytf6a")]
        [TestCase("hgatyfrtt")]
        public void get_error_message_and_false_when_password_not_contains_two_numbers(string input)
        {
            var passwordValidation = new PasswordValidation();

            var errorMessage = string.Empty;
            var result = passwordValidation.CheckConditions(input, ref errorMessage);

            errorMessage.Should().Be("The password must contain at least 2 numbers");
            result.Should().Be(false);
        }
    }
}