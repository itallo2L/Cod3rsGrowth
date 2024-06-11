using Cod3rsGrowth.Dominio.Entidades;
using FluentValidation;

namespace Cod3rsGrowth.Servico.Validacoes
{
    public class ValidadorEstudioMusical : AbstractValidator<EstudioMusical>
    {
        public ValidadorEstudioMusical()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(EstudioMusical => EstudioMusical.Nome)
                .NotEmpty().WithMessage("Por favor insira o nome do Estúdio.")
                .MaximumLength(25).WithMessage("O nome do Estúdio excedeu o limite de 25 caracteres, digite um nome menor.");

            RuleFor(EstudioMusical => EstudioMusical.EstaAberto)
                .NotNull().WithMessage("Por favor informe se o estúdio está aberto ou não.");
        }
    }
}