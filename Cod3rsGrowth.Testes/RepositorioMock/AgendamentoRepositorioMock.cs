using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.EnumEstiloMusical;
using Cod3rsGrowth.Infra.Singleton;

namespace Cod3rsGrowth.Testes.RepositorioMock
{
    public class AgendamentoRepositorioMock : IAgendamentoRepositorio
    {
        public void Adicionar(Agendamento agendamento)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Agendamento agendamento)
        {
            throw new NotImplementedException();
        }

        public Agendamento BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Agendamento agendamento)
        {
            throw new NotImplementedException();
        }

        public List<Agendamento> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}