﻿using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.InterfacesInfra;

namespace Cod3rsGrowth.Testes.RepositorioMock
{
    public class EstudioMusicalRepositorioMock : IEstudioMusicalRepositorio
    {
        public void Adicionar(EstudioMusical estudioMusical)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(EstudioMusical estudioMusical)
        {
            throw new NotImplementedException();
        }

        public EstudioMusical BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Deletar(EstudioMusical estudioMusical)
        {
            throw new NotImplementedException();
        }

        public List<EstudioMusical> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}