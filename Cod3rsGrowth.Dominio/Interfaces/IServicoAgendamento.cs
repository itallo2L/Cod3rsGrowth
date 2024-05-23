using Cod3rsGrowth.Dominio.Entidades;

namespace Cod3rsGrowth.Dominio.Interfaces
{
    public interface IServicoAgendamento
    {
        public List<Agendamento> ObterTodosOsAgendamentos();
    }
}