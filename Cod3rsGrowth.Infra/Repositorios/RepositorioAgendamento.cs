using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.InterfacesRepositorio;
using System;
using System.Collections.Generic;

namespace Cod3rsGrowth.Infra.Repositorios
{
    public class RepositorioAgendamento : IRepositorioAgendamento
    {
        public void Adicionar(Agendamento agendamento)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Agendamento agendamentoParaAtualizar)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public Agendamento ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Agendamento> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}