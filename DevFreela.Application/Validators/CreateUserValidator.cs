using DevFreela.Application.InputModels.User;
using FluentValidation;
using System.Text.RegularExpressions;

namespace DevFreela.Application.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserInputModel>
    {
        public CreateUserValidator()
        {
            RuleFor(u => u.Email)
                    .EmailAddress()
                    .WithMessage("E-mail não é válido.");

            RuleFor(u => u.Password)
                .Must(ValidPassword)
                .WithMessage("A senha deve ter pelo menos 8 caracteres, um número, uma letra maiúscula e um caractere especial.");

            RuleFor(u => u.FullName)
                .NotEmpty()
                .NotNull()
                .WithMessage("O nome é obrigatório.");

        }

        public bool ValidPassword(string password)
        {
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=].*$)");

            return regex.IsMatch(password);
        }
    }
}
