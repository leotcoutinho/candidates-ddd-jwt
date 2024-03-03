using FluentValidation;
using SisNet.Domain.Models;

namespace SisNet.Domain.Validations
{
    public  class CandidatoValidation : AbstractValidator<Candidato>
    {
        public CandidatoValidation()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id é obrigatório.");

            RuleFor(x => x.Cpf)
                .NotEmpty().WithMessage("CPF é obrigatório.")
                .Length(11).WithMessage("CPF deve conter 11 dígitos.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-mail é obrigatório.")
                .EmailAddress().WithMessage("E-mail inválido.");

            RuleFor(x => x.DataNascimento).NotEmpty().WithMessage("Data Nascimento é obrigatório.");

            RuleFor(x => x.Link).NotEmpty().WithMessage("Link da rede social/repositório é obrigatório.");

        }
    }
}
