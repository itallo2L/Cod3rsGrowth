﻿using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Singleton;
using FluentValidation;

namespace Cod3rsGrowth.Testes.RepositorioMock
{
    public class AgendamentoRepositorioMock : IRepositorioAgendamento
    {
        private AgendamentoSingleton _instanciaAgendamento;
        private readonly IValidator<Agendamento> _agendamentoValidador;

        public AgendamentoRepositorioMock(IValidator<Agendamento> agendamento)
        {
            _agendamentoValidador = agendamento;
            _instanciaAgendamento = AgendamentoSingleton.InstanciaAgendamento;
        }

        public void Adicionar(Agendamento agendamento)
        {
            _agendamentoValidador.ValidateAndThrow(agendamento);
          _instanciaAgendamento.Add(agendamento);
        }

        public void Atualizar(Agendamento agendamentoParaAtualizar)
        {
            _agendamentoValidador.ValidateAndThrow(agendamentoParaAtualizar);
            var verificarSeOIdExiste = _instanciaAgendamento.Find(lista => lista.Id == agendamentoParaAtualizar.Id)
                ?? throw new Exception($"Não foi possível encontrar o agendamento com o ID: {agendamentoParaAtualizar.Id}");
            var indice = _instanciaAgendamento.IndexOf(verificarSeOIdExiste);
            _instanciaAgendamento[indice] = agendamentoParaAtualizar;
        }

        public Agendamento ObterPorId(int id)
        {
            var objetoRetornado = _instanciaAgendamento.Find(x => x.Id == id)
                ?? throw new Exception($"Erro ao obter o objeto, o ID: {id} é inexistente!");
            return objetoRetornado;
        }

        public void Deletar(int id)
        {
            var objetoQueSeraRemovido = _instanciaAgendamento.Find(agendamento => agendamento.Id == id)
                ?? throw new Exception($"Não foi possível encontrar o ID: {id}");
            _instanciaAgendamento.Remove(objetoQueSeraRemovido);
        }

        public List<Agendamento> ObterTodos()
        {
            return _instanciaAgendamento;
        }
    }
}