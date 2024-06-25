using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.InterfacesRepositorio;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cod3rsGrowth.Infra.Repositorios
{
    public class RepositorioAgendamento : IRepositorioAgendamento
    {
        private readonly BdCod3rsGrowth _bd;

        public RepositorioAgendamento(BdCod3rsGrowth bdCodersGrowth)
        {
            _bd = bdCodersGrowth;
        }

        public void Adicionar(Agendamento agendamento)
        {
            _bd.Insert(agendamento);
        }

        public void Atualizar(Agendamento agendamentoParaAtualizar)
        {
            _bd.Update(agendamentoParaAtualizar);
        }

        public void Deletar(int id)
        {
            var objetoQueSeraDeletado = _bd.GetTable<Agendamento>().Where(agendamento => agendamento.Id == id);
            _bd.Delete(objetoQueSeraDeletado);
        }

        public Agendamento ObterPorId(int id)
        {
            var listaObtida = _bd.GetTable<Agendamento>().FirstOrDefault(agendamento => agendamento.Id == id);
            return listaObtida;
        }

        public List<Agendamento> ObterTodos(FiltroAgendamento? filtro = null)
        {
            var listaAgendamento = _bd.GetTable<Agendamento>().AsQueryable();

            if (!string.IsNullOrEmpty(filtro?.NomeResponsavel))
            {
                listaAgendamento = listaAgendamento.Where(agendamento => agendamento.NomeResponsavel.Contains(filtro.NomeResponsavel, StringComparison.OrdinalIgnoreCase));
            }
            if (filtro?.DataEHoraDeEntrada != null)
            {
                listaAgendamento = listaAgendamento.Where(agendamento => agendamento.DataEHoraDeEntrada == filtro.DataEHoraDeEntrada);
            }
            if (filtro?.ValorTotal != null)
            {
                listaAgendamento = listaAgendamento.Where(agendamento => agendamento.ValorTotal == filtro.ValorTotal);
            }
            return listaAgendamento.ToList();
        }
    }
}