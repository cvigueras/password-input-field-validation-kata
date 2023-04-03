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

            errorMessage.Should().Be("Password must be at least 8 characters\nThe password must contain at least 2 numbers\nPassword must contain at least one capital letter\nPassword must contain at least one special character");
            result.Should().Be(false);
        }

        [TestCase("1hjunbvf")]
        [TestCase("hjuytf6a")]
        [TestCase("hgatyfrtt")]
        public void get_error_message_and_false_when_password_not_contains_two_numbers_capital_letters_or_special_characters(string input)
        {
            var passwordValidation = new PasswordValidation();

            var errorMessage = string.Empty;
            var result = passwordValidation.CheckConditions(input, ref errorMessage);

            errorMessage.Should().Be("The password must contain at least 2 numbers\nPassword must contain at least one capital letter\nPassword must contain at least one special character");
            result.Should().Be(false);
        }

        [TestCase("hgf3ya7nb")]
        [TestCase("hk2dddya7zs")]
        [TestCase("gbaf6hja9lkahjabva")]
        public void get_error_message_and_false_when_password_not_contains_a_capital_letter_or_special_character(string input)
        {
            var passwordValidation = new PasswordValidation();

            var errorMessage = string.Empty;
            var result = passwordValidation.CheckConditions(input, ref errorMessage);

            errorMessage.Should().Be("Password must contain at least one capital letter\nPassword must contain at least one special character");
            result.Should().Be(false);
        }

        [TestCase("hGf3ya7nb")]
        [TestCase("hGf42adjb")]
        [TestCase("ffKaa9sl3")]
        public void get_error_message_and_false_when_password_not_contains_special_character(string input)
        {
            var passwordValidation = new PasswordValidation();

            var errorMessage = string.Empty;
            var result = passwordValidation.CheckConditions(input, ref errorMessage);

            errorMessage.Should().Be("Password must contain at least one special character");
            result.Should().Be(false);
        }

        [TestCase("Hola33Comoestas^")]
        [TestCase("hAZg3mj4@.hja")]
        [TestCase("hy5g6*J9")]
        [TestCase("hyT90kL##77k3@")]
        public void get_error_message_empty_when_password_achieve_all_conditions(string input)
        {
            var passwordValidation = new PasswordValidation();

            var errorMessage = string.Empty;
            var result = passwordValidation.CheckConditions(input, ref errorMessage);

            errorMessage.Should().Be("");
            result.Should().Be(true);
        }
    }
}