using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.InterfacesRepositorio;
using FluentValidation;
using System.Collections.Generic;

namespace Cod3rsGrowth.Servico.Servicos
{
    public class ServicoAgendamento
    {
        private readonly IValidator<Agendamento> _validadorAgendamento;
        private readonly IRepositorioAgendamento _repositorioAgendamento;

        public ServicoAgendamento(IValidator<Agendamento> valiadorAgendamento, IRepositorioAgendamento repositorioAgendamento)
        {
            _validadorAgendamento = valiadorAgendamento;
            _repositorioAgendamento = repositorioAgendamento;
        }

        public void Adicionar(Agendamento agendamento)
        {
            _validadorAgendamento.ValidateAndThrow(agendamento);
            _repositorioAgendamento.Adicionar(agendamento);
        }

        public void Atualizar(Agendamento agendamentoParaAtualizar)
        {
            _validadorAgendamento.ValidateAndThrow(agendamentoParaAtualizar);
            _repositorioAgendamento.Atualizar(agendamentoParaAtualizar);
        }

        public void Deletar(int id)
        {
            _repositorioAgendamento.Deletar(id);
        }

        public Agendamento ObterPorId(int id)
        {
            return _repositorioAgendamento.ObterPorId(id);
        }

        public List<Agendamento> ObterTodos(FiltroAgendamento? filtro = null)
        {
            return _repositorioAgendamento.ObterTodos(filtro);
        }
    }
}