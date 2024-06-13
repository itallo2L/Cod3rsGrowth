using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.EnumEstiloMusical;
using FluentValidation;
using System;

namespace Cod3rsGrowth.Servico.Validacoes
{
    public class ValidadorAgendamento : AbstractValidator<Agendamento>
    {
        public ValidadorAgendamento()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(Agendamento => Agendamento.NomeResponsavel)
                .NotEmpty().WithMessage("O campo nome do responsável é obrigatório, por favor digite o nome do responsável pelo agendamento.")
                .MaximumLength(30).WithMessage("O nome do responsável excedeu o limite de 30 caracteres, digite um nome menor.");

            RuleFor(Agendamento => Agendamento.CpfResponsavel).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("O campo CPF é obrigatório, por favor digite o CPF do responsável pelo agendamento.")
                .Length(11).WithMessage("Um CPF contém 11 digitos, digite um CPF válido.");

            RuleFor(Agendamento => Agendamento.DataEHoraDeEntrada).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("O campo data e hora de entrada é obrigatório, por favor digite uma data e hora de entrada.")
                .GreaterThanOrEqualTo(DateTime.Today).WithMessage("A data de entrada inserida é menor do que a data atual, por favor digite uma data de entrada válida.")
                .GreaterThan(DateTime.Now).WithMessage("A hora de entrada inserida é menor ou igual ao horário atual, por favor digite um horário de entrada válido.");

            RuleFor(Agendamento => Agendamento.DataEHoraDeSaida)
                .NotEmpty().WithMessage("O campo data e hora de saída é obrigatório, por favor digite uma data e hora de saída.")
                .GreaterThan(DateTime.Today).WithMessage("A data de saída inserida é menor do que a data atual, por favor digite uma data de saída válida.")
                .GreaterThan(DateTime.Now).WithMessage("A hora de saída inserida é menor ou igual ao horário atual, por favor digite um horário de saída válido.")
                .NotEqual(agendamento => agendamento.DataEHoraDeEntrada).WithMessage("A data e hora de saída não pode ser igual a data e hora de entrada.");

            RuleFor(Agendamento => Agendamento)
                .Must(agendamento => agendamento.DataEHoraDeSaida >= agendamento.DataEHoraDeEntrada.AddHours(1)).WithMessage("A quantidade de tempo mínima para agendamento é de uma hora.");

            RuleFor(Agendamento => Agendamento.ValorTotal)
            .PrecisionScale(5, 2, true).WithMessage("O Valor Total excedeu o limite de 5 algarismos totais com duas casas decimais, por favor digite no formato exigido.");

            RuleFor(Agendamento => Agendamento.EstiloMusical)
                .IsInEnum().WithMessage("O Estilo Musical não foi encontrado, digite um Estilo Musical válido.");

            RuleFor(Agendamento => Agendamento)
                .Must(agendamento => VerificarEnumIndefinido(agendamento.EstiloMusical) != VerificarEnumIndefinido(EstiloMusical.EnumIndefinido)).WithMessage("Estilo Musical indefinido, por favor defina o Estilo Musical");
        }
        public static bool VerificarEnumIndefinido(EstiloMusical enumIndefinido)
        {
            return !(enumIndefinido == EstiloMusical.EnumIndefinido);
        }
    }
}