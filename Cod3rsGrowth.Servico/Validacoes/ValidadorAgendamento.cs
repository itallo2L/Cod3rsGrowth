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
                .MaximumLength(25).WithMessage("O nome do responsável excedeu o limite de 25 caracteres, digite um nome menor.");

            RuleFor(Agendamento => Agendamento.CpfResponsavel)
                .NotEmpty().WithMessage("Por favor digite o CPF do responsável pelo agendamento.")
                .Length(11).WithMessage("CPF inválido, digite um CPF válido.");

            RuleFor(Agendamento => Agendamento.DataEHoraDeEntrada)
                .NotEmpty().WithMessage("Por favor digite uma data e hora válida.")
                .GreaterThanOrEqualTo(DateTime.Today).WithMessage("Por favor digite uma data válida.")
                .GreaterThanOrEqualTo(DateTime.Now).WithMessage("Por favor digite um horário válido.");

            RuleFor(Agendamento => Agendamento.DataEHoraDeSaida)
                .NotEmpty().WithMessage("Por favor digite uma data e hora válida.")
                .GreaterThan(DateTime.Today).WithMessage("Por favor digite uma data válida.")
                .GreaterThan(DateTime.Now).WithMessage("Por favor digite um horário válido.")
                .NotEqual(agendamento => agendamento.DataEHoraDeEntrada).WithMessage("A data e hora de saída não pode ser igual à data e hora de entrada.");

            RuleFor(Agendamento => Agendamento)
                .Must(agendamento => agendamento.DataEHoraDeSaida >= agendamento.DataEHoraDeEntrada.AddHours(1)).WithMessage("A quantidade mínima para agendamento é de 1 hora");

            RuleFor(Agendamento => Agendamento.ValorTotal)
            .PrecisionScale(5, 2, true).WithMessage("O valor total não deve conter mais de 4 digitos no total, com duas casas decimais.");

            RuleFor(Agendamento => Agendamento.EstiloMusical)
                .IsInEnum().WithMessage("Estilo musical inválido.");

            RuleFor(Agendamento => Agendamento)
                .Must( x => x.EstiloMusical != EstiloMusical.EnumIndefinido).WithMessage("Por favor defina o Estilo Musical");
        }
    }
}