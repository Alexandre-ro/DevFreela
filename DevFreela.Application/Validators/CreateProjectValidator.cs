using DevFreela.Application.Commands.Projects.CreateProject;
using FluentValidation;

namespace DevFreela.Application.Validators
{
    public class CreateProjectValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectValidator()
        {
            RuleFor(p => p.Title)
                .MaximumLength(20)
                .WithMessage("O tamanho máximo do Título é de 30 caracteres.");

            RuleFor(p => p.Description)
                .MaximumLength(100)
                .WithMessage("O tamanho máximo da Descrição é de 100 caracteres.");
                
        }
    }
}
