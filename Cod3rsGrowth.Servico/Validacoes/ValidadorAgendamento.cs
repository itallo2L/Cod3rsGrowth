using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.EnumEstiloMusical;
using FluentValidation;

namespace Cod3rsGrowth.Servico.Validacoes
{
    public class ValidadorAgendamento : AbstractValidator<Agendamento>
    {
        public ValidadorAgendamento()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(Agendamento => Agendamento.NomeResponsavel)
                .NotEmpty().WithMessage("Por favor digite o nome do responsável pelo agendamento.")
                .MaximumLength(25).WithMessage("O nome do responsável excedeu o limite de 25 caracteres, digite um nome menor.")
                .Matches("!@#$%¨*()_+-").WithMessage("O nome não pode conter os seguintes caracteres: !@#$%¨*()_+-");

            RuleFor(Agendamento => Agendamento.CpfResponsavel)
                .NotEmpty().WithMessage("Por favor digite o CPF do responsável pelo agendamento.")
                .Length(1, 11).WithMessage("CPF inválido, digite um CPF válido.")
                .Matches("!@#$%¨*()_+-").WithMessage("O CPF não pode conter os seguintes caracteres: !@#$%¨*()_+-");

            RuleFor(Agendamento => Agendamento.DataEHoraDeEntrada)
                .NotEmpty().WithMessage("Por favor digite uma data e hora válida.")
                .LessThan(DateTime.Today).WithMessage("Por favor digite uma data válida.")
                .LessThan(DateTime.Now).WithMessage("Por favor digite um horário válido.");

            RuleFor(Agendamento => Agendamento.DataEHoraDeSaida)
                .NotEmpty().WithMessage("Por favor digite uma data e hora válida.")
                .LessThan(DateTime.Today).WithMessage("Por favor digite uma data válida.")
                .LessThan(DateTime.Now).WithMessage("Por favor digite um horário válido.")
                .NotEqual(Agendamento => Agendamento.DataEHoraDeEntrada).WithMessage("A data e hora de saída não pode ser igual à data e hora de entrada.");

            RuleFor(Agendamento => Agendamento.ValorTotal)
            .PrecisionScale(4, 2, true).WithMessage("O valor total não deve conter mais de 4 digitos no total, com duas casas decimais.");

            RuleFor(Agendamento => Agendamento.EstiloMusical)
                .IsInEnum().WithMessage("Estilo musical inválido.")
                .Must((Agendamento, EstiloMusical) => VerificarSeOEnumEstaIndefinido(Agendamento.EstiloMusical));
        }

        private static bool VerificarSeOEnumEstaIndefinido(EstiloMusical estiloMusical)
        {
            return !(estiloMusical == EstiloMusical.EnumIndefinido);
        }
    }
}