using Cod3rsGrowth.Dominio.Entidades;

namespace Cod3rsGrowth.Dominio.Interfaces
{
    public interface IServicoEstudioMusical
    {
        List<EstudioMusical> ObterTodos();
        EstudioMusical ObterPorId(int id);
    }
}