using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Infra.Singleton;

namespace Cod3rsGrowth.Servico.Servicos
{
    public class ServicoAgendamento : IServicoAgendamento
    {
        AgendamentoSingleton listaDeAgendamentoSingleton = AgendamentoSingleton.InstanciaAgendamento;
        public List<Agendamento> ObterTodos()
        {
            return listaDeAgendamentoSingleton;
        }
        public Agendamento ObterPorId(int id)
        {
            var objetoRetornado = listaDeAgendamentoSingleton.Find(x => x.Id == id)
                ?? throw new Exception($"Erro ao obter o objeto, o Id: {id} é inexistente!");
            return objetoRetornado;
        }
    }
}