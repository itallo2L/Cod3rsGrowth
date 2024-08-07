﻿using Cod3rsGrowth.Dominio.Entidades;
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
            _bd.Agendamento
                .Delete(agendamento => agendamento.Id == id);
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
                listaAgendamento = listaAgendamento.Where(agendamento => agendamento.NomeResponsavel.Contains(filtro.NomeResponsavel, StringComparison.OrdinalIgnoreCase));

            if (filtro?.DataMinima != null)
                listaAgendamento = listaAgendamento.Where(agendamento => agendamento.DataEHoraDeEntrada >= filtro.DataMinima);

            if (filtro?.DataMaxima != null)
                listaAgendamento = listaAgendamento.Where(agendamento => agendamento.DataEHoraDeEntrada <= filtro.DataMaxima);

            const int naoPodeSerNegativo = 0;
            if (filtro?.ValorMinimo != null && filtro?.ValorMinimo != naoPodeSerNegativo)
                listaAgendamento = listaAgendamento.Where(agendamento => agendamento.ValorTotal >= filtro.ValorMinimo);

            if (filtro?.ValorMaximo != null && filtro?.ValorMaximo != naoPodeSerNegativo)
                listaAgendamento = listaAgendamento.Where(agendamento => agendamento.ValorTotal <= filtro.ValorMaximo);

            const int indexDoEnumIndefinido = 0;
            if (filtro?.EstiloMusical != null && filtro?.EstiloMusical > indexDoEnumIndefinido)
                listaAgendamento = listaAgendamento.Where(agendamento => agendamento.EstiloMusical == filtro.EstiloMusical);

            return listaAgendamento.ToList();
        }
    }
}