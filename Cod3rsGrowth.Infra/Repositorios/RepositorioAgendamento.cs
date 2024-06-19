using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.InterfacesRepositorio;
using LinqToDB;
using System;
using System.Collections.Generic;

namespace Cod3rsGrowth.Infra.Repositorios
{
    public class RepositorioAgendamento : IRepositorioAgendamento
    {
        private readonly ITable<Agendamento> _bd;

        public RepositorioAgendamento(BdCod3rsGrowth bdCodersGrowth)
        {
            _bd = bdCodersGrowth.GetTable<Agendamento>();
        }

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

        public List<Agendamento> ObterTodos(FiltroAgendamento? filtro = null)
        {
            throw new NotImplementedException();
        }
    }
}