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
        public void get_all_errors_messages_when_does_not_meet_any_condition(string input)
        {
            var passwordValidation = new PasswordValidation();

            var errorMessage = string.Empty;
            var result = passwordValidation.CheckConditions(input, ref errorMessage);

            errorMessage.Should().Be("Password must be at least 8 characters\nThe password must contain at least 2 numbers\nPassword must contain at least one capital letter");
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

            errorMessage.Should().Be("The password must contain at least 2 numbers\nPassword must contain at least one capital letter");
            result.Should().Be(false);
        }

        [TestCase("hgf3ya7nb")]
        [TestCase("hk2dddya7zs")]
        [TestCase("gbaf6hja9lkahjabva")]
        public void get_error_message_and_false_when_password_not_contains_a_capital_letter(string input)
        {
            var passwordValidation = new PasswordValidation();

            var errorMessage = string.Empty;
            var result = passwordValidation.CheckConditions(input, ref errorMessage);

            errorMessage.Should().Be("Password must contain at least one capital letter");
            result.Should().Be(false);
        }

        [Test]
        public void get_error_message_and_false_when_password_not_constains_special_character()
        {
            var passwordValidation = new PasswordValidation();

            var errorMessage = string.Empty;
            var result = passwordValidation.CheckConditions("hGf3ya7nb", ref errorMessage);

            errorMessage.Should().Be("Password must contain at least one special character");
            result.Should().Be(false);
        }
    }
}