using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Filtros;
using System.Collections.Generic;

namespace Cod3rsGrowth.Dominio.InterfacesRepositorio
{
    public interface IRepositorioEstudioMusical
    {
        List<EstudioMusical> ObterTodos(FiltroEstudioMusical? filtro = null);
        void Adicionar(EstudioMusical estudioMusical);
        void Atualizar(EstudioMusical estudioParaAtualizar);
        void Deletar(int id);
        EstudioMusical ObterPorId(int id);
    }
}