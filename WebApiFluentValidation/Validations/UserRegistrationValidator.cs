using FluentValidation;
using WebApiFluentValidation.Models;

namespace WebApiFluentValidation.Validations
{
    public class UserRegistrationValidator : AbstractValidator<UserRegistrationRequest>
    {
        public UserRegistrationValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().MinimumLength(4);
            RuleFor(x => x.SobreNome).NotEmpty().MaximumLength(10);
            RuleFor(x => x.Email).EmailAddress().WithMessage("{PropertyName} inválida! Favor verificar!");
            RuleFor(x => x.Senha).Equal(z => z.ConfirmaSenha).WithMessage("Senhas não são iguais!");
        }
    }
}
