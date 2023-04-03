using FluentAssertions;
using PasswordInput.Console;

namespace PasswordInput.Test
{
    public class PasswordValidationShould
    {
        private PasswordValidation _passwordValidation;

        [SetUp]
        public void Setup()
        {
            _passwordValidation = new PasswordValidation();
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("abcd")]
        public void get_all_errors_messages_when_does_not_meet_any_condition(string input)
        {
            var password = Password.Create(input);

            _passwordValidation.CheckConditions(password);

            password.ErrorMessage.Should().Be("Password must be at least 8 characters" + Environment.NewLine +
                                              "The password must contain at least 2 numbers" + Environment.NewLine +
                                              "Password must contain at least one capital letter" + Environment.NewLine + 
                                              "Password must contain at least one special character");

            password.PasswordIsValid.Should().Be(false);
        }

        [TestCase("1hjunbvf")]
        [TestCase("hjuytf6a")]
        [TestCase("hgatyfrtt")]
        public void get_error_message_and_false_when_password_not_contains_two_numbers_capital_letters_or_special_characters(string input)
        {
            var password = Password.Create(input);

            _passwordValidation.CheckConditions(password);

            password.ErrorMessage.Should().Be("The password must contain at least 2 numbers" + Environment.NewLine + 
                                              "Password must contain at least one capital letter" + Environment.NewLine + 
                                              "Password must contain at least one special character");

            password.PasswordIsValid.Should().Be(false);
        }

        [TestCase("hgf3ya7nb")]
        [TestCase("hk2dddya7zs")]
        [TestCase("gbaf6hja9lkahjabva")]
        public void get_error_message_and_false_when_password_not_contains_a_capital_letter_or_special_character(string input)
        {
            var password = Password.Create(input);

            _passwordValidation.CheckConditions(password);

            password.ErrorMessage.Should().Be("Password must contain at least one capital letter" + Environment.NewLine + 
                                              "Password must contain at least one special character");

            password.PasswordIsValid.Should().Be(false);
        }

        [TestCase("hGf3ya7nb")]
        [TestCase("hGf42adjb")]
        [TestCase("ffKaa9sl3")]
        public void get_error_message_and_false_when_password_not_contains_special_character(string input)
        {
            var password = Password.Create(input);

            _passwordValidation.CheckConditions(password);

            password.ErrorMessage.Should().Be("Password must contain at least one special character");

            password.PasswordIsValid.Should().Be(false);
        }

        [TestCase("Hola33Comoestas^")]
        [TestCase("hAZg3mj4@.hja")]
        [TestCase("hy5g6*J9")]
        [TestCase("hyT90kL##77k3@")]
        public void get_error_message_empty_when_password_achieve_all_conditions(string input)
        {
            var password = Password.Create(input);

            _passwordValidation.CheckConditions(password);

            password.ErrorMessage.Should().Be("");
            password.PasswordIsValid.Should().Be(true);
        }
    }
}