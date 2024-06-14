using Cod3rsGrowth.Dominio.Entidades;
using System.Collections.Generic;

namespace Cod3rsGrowth.Dominio.InterfacesRepositorio
{
    public interface IRepositorioEstudioMusical
    {
        List<EstudioMusical> ObterTodos();
        void Adicionar(EstudioMusical estudioMusical);
        void Atualizar(EstudioMusical estudioParaAtualizar);
        void Deletar(int id);
        EstudioMusical ObterPorId(int id);
    }
}