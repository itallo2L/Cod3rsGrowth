using Cod3rsGrowth.Dominio.Entidades;

namespace Cod3rsGrowth.Testes.RepositorioMock
{
    public interface IRepositorioAgendamento
    {
        List<Agendamento> ObterTodos();
        void Adicionar(Agendamento agendamento);
        void Atualizar(Agendamento agendamento);
        void Deletar(int id);
        Agendamento ObterPorId(int id);
    }
}