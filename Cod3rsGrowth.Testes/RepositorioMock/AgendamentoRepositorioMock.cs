﻿using Cod3rsGrowth.Dominio.Entidades;

namespace Cod3rsGrowth.Testes.RepositorioMock
{
    public class AgendamentoRepositorioMock : IRepositorioAgendamento
    {
        public void Adicionar(Agendamento agendamento)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Agendamento agendamento)
        {
            throw new NotImplementedException();
        }

        public Agendamento BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Agendamento agendamento)
        {
            throw new NotImplementedException();
        }

        public List<Agendamento> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}