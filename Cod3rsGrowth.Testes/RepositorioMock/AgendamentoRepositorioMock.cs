using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Singleton;
using FluentValidation;

namespace Cod3rsGrowth.Testes.RepositorioMock
{
    public class AgendamentoRepositorioMock : IRepositorioAgendamento
    {
        private AgendamentoSingleton _instanciaAgendamento;
        private readonly IValidator<Agendamento> _agendamentoValidador;

        public AgendamentoRepositorioMock(IValidator<Agendamento> agendamento)
        {
            _agendamentoValidador = agendamento;
            _instanciaAgendamento = AgendamentoSingleton.InstanciaAgendamento;
        }
        public void Adicionar(Agendamento agendamento)
        {
            _agendamentoValidador.ValidateAndThrow(agendamento);
          _instanciaAgendamento.Add(agendamento);
        }

        public void Atualizar(Agendamento agendamento)
        {
            throw new NotImplementedException();
        }

        public Agendamento ObterPorId(int id)
        {
            var objetoRetornado = _instanciaAgendamento.Find(x => x.Id == id)
                ?? throw new Exception($"Erro ao obter o objeto, o Id: {id} é inexistente!");
            return objetoRetornado;
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Agendamento> ObterTodos()
        {
            return _instanciaAgendamento;
        }
    }
}