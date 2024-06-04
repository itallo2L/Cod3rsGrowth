using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Infra.Singleton;

namespace Cod3rsGrowth.Dominio.Servicos
{
    public class ServicoEstudioMusical : IServicoEstudioMusical
    {
        EstudioMusicalSingleton listaDeEstudioMusicalSingleton = EstudioMusicalSingleton.InstanciaEstudioMusical;
        public List<EstudioMusical> ObterTodos()
        {
            return listaDeEstudioMusicalSingleton;
        }

        public EstudioMusical ObterPorId(int id)
        {
            var objetoRetornado = listaDeEstudioMusicalSingleton.Find(x => x.Id == id) 
                ?? throw new Exception($"Erro ao obter o objeto, o Id: {id} é inexistente!");
            return objetoRetornado;
        }
    }
}