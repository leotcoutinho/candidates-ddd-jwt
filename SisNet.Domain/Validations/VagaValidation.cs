using FluentValidation;
using SisNet.Domain.Models;

namespace SisNet.Domain.Validations
{
    public class VagaValidation : AbstractValidator<Vaga>
    {
        public VagaValidation()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id é obrigatório!");

            RuleFor(x => x.Codigo)
                .NotEmpty().WithMessage("Código é obrigatório!");

            RuleFor(x=>x.Titulo)
                .NotEmpty().WithMessage("Título é obrigatório!")
                .Length(3,200).WithMessage("Título deve conter até 200 caracteres");

            RuleFor(x => x.Descricao).NotEmpty().WithMessage("Descrição é obrigatório!");

        }
    }
}
