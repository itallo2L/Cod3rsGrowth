﻿using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.InterfacesRepositorio;
using LinqToDB;
using LinqToDB.Tools;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cod3rsGrowth.Infra.Repositorios
{
    public class RepositorioEstudioMusical : IRepositorioEstudioMusical
    {
        private readonly ITable<EstudioMusical> _bd;

        public RepositorioEstudioMusical(BdCod3rsGrowth bdCod3RsGrowth)
        {
            _bd = bdCod3RsGrowth.GetTable<EstudioMusical>();
        }

        public void Adicionar(EstudioMusical estudioMusical)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(EstudioMusical estudioParaAtualizar)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public EstudioMusical ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<EstudioMusical> ObterTodos(FiltroEstudioMusical? filtro = null)
        {
            var listaEstudioMusical = _bd.AsQueryable();

            if (filtro?.EstaAberto != null)
            {
                listaEstudioMusical = listaEstudioMusical.Where(estudioMusical => estudioMusical.EstaAberto == filtro.EstaAberto);
            }
            if (!string.IsNullOrEmpty(filtro?.Nome))
            {
                listaEstudioMusical = listaEstudioMusical.Where(estudioMusical => estudioMusical.Nome.Contains(filtro.Nome, StringComparison.OrdinalIgnoreCase));
            }

            return listaEstudioMusical.ToList();
        }
    }
}