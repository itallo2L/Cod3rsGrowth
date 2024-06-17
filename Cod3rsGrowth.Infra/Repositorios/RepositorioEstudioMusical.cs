using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.InterfacesRepositorio;
using LinqToDB;
using System;
using System.Collections.Generic;

namespace Cod3rsGrowth.Infra.Repositorios
{
    public class RepositorioEstudioMusical : IRepositorioEstudioMusical
    {
        private readonly BdCod3rsGrowth _bd;

        public RepositorioEstudioMusical(BdCod3rsGrowth bdCod3RsGrowth)
        {
            _bd = bdCod3RsGrowth;
            _bd.GetTable<EstudioMusical>();
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
            throw new NotImplementedException();
        }
    }
}