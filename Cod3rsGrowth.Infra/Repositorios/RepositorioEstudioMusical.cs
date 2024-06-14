using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.InterfacesRepositorio;
using System;
using System.Collections.Generic;

namespace Cod3rsGrowth.Infra.Repositorios
{
    public class RepositorioEstudioMusical : IRepositorioEstudioMusical
    {
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

        public List<EstudioMusical> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}