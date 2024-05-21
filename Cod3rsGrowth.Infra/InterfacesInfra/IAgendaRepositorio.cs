namespace Cod3rsGrowth.Testes.RepositorioMock
{
    public interface IAgendaRepositorio
    {
        public void ObterTodos();
        void Adicionar();
        void Atualizar();
        void Deletar();
        void BuscarPorTipo();
        void BuscarPorId();
    }
}