using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.EnumEstiloMusical;
using Cod3rsGrowth.Dominio.InterfacesRepositorio;
using FluentValidation;
using System;
using System.Linq;

namespace Cod3rsGrowth.Servico.Validacoes
{
    public class ValidadorAgendamento : AbstractValidator<Agendamento>
    {
        private readonly IRepositorioAgendamento _repositorioAgendamento;
        private readonly IRepositorioEstudioMusical _repositorioEstudioMusical;

        public ValidadorAgendamento(
            IRepositorioAgendamento repositorioAgendamento,
            IRepositorioEstudioMusical repositorioEstudioMusical
            )
        {
            _repositorioAgendamento = repositorioAgendamento;
            _repositorioEstudioMusical = repositorioEstudioMusical;

            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(Agendamento => Agendamento.NomeResponsavel)
                .NotEmpty()
                .WithMessage("O campo nome do responsável é obrigatório, por favor digite o nome do responsável pelo agendamento.")
                .MaximumLength(30)
                .WithMessage("O nome do responsável excedeu o limite de 30 caracteres, digite um nome menor.");

            RuleFor(Agendamento => Agendamento.CpfResponsavel).Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("O campo CPF é obrigatório, por favor digite o CPF do responsável pelo agendamento.")
                .Must((agendamento, _) => ValidaCpf(agendamento.CpfResponsavel))
                .WithMessage("CPF inválido.");

            RuleFor(Agendamento => Agendamento.DataEHoraDeEntrada).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("O campo data e hora de entrada é obrigatório, por favor digite uma data e hora de entrada.")
                .GreaterThanOrEqualTo(DateTime.Today)
                .WithMessage("A data inserida é menor do que a data atual, por favor digite uma data válida.")
                .GreaterThan(DateTime.Now)
                .WithMessage("A hora de entrada inserida é menor ou igual ao horário atual, por favor digite um horário de entrada válido.");

            RuleFor(Agendamento => Agendamento.DataEHoraDeSaida)
                .NotEmpty().WithMessage("O campo data e hora de saída é obrigatório, por favor digite uma data e hora de saída.")
                .GreaterThan(DateTime.Today).WithMessage("A data de saída inserida é menor do que a data atual, por favor digite uma data de saída válida.")
                .GreaterThan(DateTime.Now).WithMessage("A hora de saída inserida é menor ou igual ao horário atual, por favor digite um horário de saída válido.")
                .NotEqual(agendamento => agendamento.DataEHoraDeEntrada)
                .WithMessage("O horário de saída não pode ser igual ao horário de entrada.");

            RuleFor(Agendamento => Agendamento)
                .Must(agendamento => EhEstudioDisponivel(agendamento))
                .WithMessage("Já há um agendamento para esse estúdio.");

            RuleFor(Agendamento => Agendamento)
                .Must(agendamento => agendamento.DataEHoraDeSaida >= agendamento.DataEHoraDeEntrada.AddHours(1))
                .WithMessage("A quantidade de tempo mínima para agendamento é de uma hora.");

            RuleFor(Agendamento => Agendamento.ValorTotal)
            .PrecisionScale(6, 2, true)
            .WithMessage("O Valor Total excedeu o limite de 6 algarismos totais com duas casas decimais, por favor digite no formato exigido.");

            RuleFor(Agendamento => Agendamento.EstiloMusical)
                .IsInEnum()
                .WithMessage("O Estilo Musical não foi encontrado, digite um Estilo Musical válido.");

            RuleFor(Agendamento => Agendamento)
                .Must(agendamento => VerificarEnumIndefinido(agendamento.EstiloMusical) != VerificarEnumIndefinido(EstiloMusical.EnumIndefinido)).WithMessage("Estilo Musical indefinido, por favor defina o Estilo Musical");
            _repositorioEstudioMusical = repositorioEstudioMusical;
        }

        public static bool VerificarEnumIndefinido(EstiloMusical enumIndefinido)
        {
            return !(enumIndefinido == EstiloMusical.EnumIndefinido);
        }

        public static bool ValidaCpf(string? cpf)
        {
                int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                string tempCpf;
                string digito;
                int soma;
                int resto;
                cpf = cpf.Trim();
                cpf = cpf.Replace(".", "").Replace("-", "");
                if (cpf.Length != 11)
                    return false;
                tempCpf = cpf.Substring(0, 9);
                soma = 0;

                for (int i = 0; i < 9; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
                resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                digito = resto.ToString();
                tempCpf = tempCpf + digito;
                soma = 0;
                for (int i = 0; i < 10; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
                resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                digito = digito + resto.ToString();
                return cpf.EndsWith(digito);
        }

        public bool EhEstudioDisponivel(Agendamento agendamento)
        {
            var agendamentos = _repositorioAgendamento.ObterTodos();
            var estudios = _repositorioEstudioMusical.ObterTodos();

            /*
            casos que não podem
            se a data final do parâmetro for maior que a inicial do banco OU menor ou igual a final do banco
            se a data inicial do parâmetro for menor que a data final OU maior ou igual a data inicial

            casos que podem:
            se a data final do parâmetro for menor ou igual a inicial  do banco OU maior que a final do banco
            se a data inicial do parâmetro for maior ou igual a final OU menor que a data inicial
            
            para não passar:
            (data de entrada parâmetro):
            a de entrada do banco deve ser menor ou igual que a de entrada do parâmetro
            &&
            a de saida do banco deve ser maior que a de entrada do parâmetro 

            (data de saida do parâmetro):
            a data de entrada do banco deve ser maior que a de saida do parâmetro
            &&
            a data de saida do banco maior ou igual a de saida do parâmetro
             */

            //var dataDeEntrada = agendamentos.Any(x => x.DataEHoraDeEntrada.Date == agendamento.DataEHoraDeEntrada.Date);
            //var dataDeSaida = agendamentos.Any(x => x.DataEHoraDeSaida.Date == agendamento.DataEHoraDeSaida.Date);
            //if()

            var haAgendamentoEstudio = agendamentos.Any(x => x.IdEstudio == agendamento.IdEstudio);

            if (haAgendamentoEstudio)
            {
                //var ehMesmaDataeHora = agendamentos.Any(x => (x.IdEstudio == agendamento.IdEstudio) 
                //&& (x.DataEHoraDeEntrada <= agendamento.DataEHoraDeEntrada && x.DataEHoraDeSaida > agendamento.DataEHoraDeEntrada)
                //&& (x.DataEHoraDeEntrada < agendamento.DataEHoraDeSaida && x.DataEHoraDeSaida >= agendamento.DataEHoraDeSaida));
                //return !ehMesmaDataeHora;
                var ehMesmaDataeHora = agendamentos.Any(x => (x.IdEstudio == agendamento.IdEstudio)
                && (agendamento.DataEHoraDeEntrada >= x.DataEHoraDeEntrada && agendamento.DataEHoraDeEntrada < x.DataEHoraDeSaida)
                && (agendamento.DataEHoraDeSaida >= x.DataEHoraDeEntrada && agendamento.DataEHoraDeSaida <= x.DataEHoraDeSaida));
                return !ehMesmaDataeHora;
            }

            //var ehMesmaDataeHora = agendamentos.Any(x => (x.IdEstudio == agendamento.IdEstudio) 
            //&& (x.DataEHoraDeEntrada > agendamento.DataEHoraDeEntrada) 
            //&& (x.DataEHoraDeSaida < agendamento.DataEHoraDeSaida));

            return !haAgendamentoEstudio;


            //listaDeAgendamento.Find(estudio => estudio.IdEstudio == agendamento.IdEstudio && estudio.DataEHoraDeEntrada >= agendamento.DataEHoraDeEntrada && estudio.DataEHoraDeSaida <= agendamento.DataEHoraDeSaida);
        }
    }
}