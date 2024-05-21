using Cod3rsGrowth.Dominio.Entidades;

namespace Cod3rsGrowth.Infra.InterfacesInfra
{
    public interface IEstudioMusicalRepositorio
    {
        List<EstudioMusical> ObterTodos(int id);
        void Adicionar(EstudioMusical estudioMusical);
        void Atualizar(EstudioMusical estudioMusical);
        void Deletar(EstudioMusical estudioMusical);
        EstudioMusical BuscarPorId(int id);
    }
}