using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Filtros;
using System.Collections.Generic;

namespace Cod3rsGrowth.Dominio.InterfacesRepositorio
{
    public interface IRepositorioAgendamento
    {
        List<Agendamento> ObterTodos(FiltroAgendamento? filtro = null);
        void Adicionar(Agendamento agendamento);
        void Atualizar(Agendamento agendamentoParaAtualizar);
        void Deletar(int id);
        Agendamento ObterPorId(int id);
    }
}