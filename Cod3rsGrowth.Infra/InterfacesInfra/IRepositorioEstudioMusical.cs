using Cod3rsGrowth.Dominio.Entidades;

namespace Cod3rsGrowth.Infra.InterfacesInfra
{
    public interface IRepositorioEstudioMusical
    {
        List<EstudioMusical> ObterTodos();
        void Adicionar(EstudioMusical estudioMusical);
        void Atualizar(EstudioMusical estudioMusical);
        void Deletar(int id);
        EstudioMusical ObterPorId(int id);
    }
}