namespace Cod3rsGrowth.Infra.InterfacesInfra
{
    public interface IEstudioMusicalRepositorio
    {
        public void ObterTodos();
        void Adicionar();
        void Atualizar();
        void Deletar();
        void BuscarPorTipo();
        void BuscarPorId();
    }
}