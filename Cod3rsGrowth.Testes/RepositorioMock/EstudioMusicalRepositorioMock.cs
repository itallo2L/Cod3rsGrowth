using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.InterfacesInfra;
using Cod3rsGrowth.Infra.Singleton;
using FluentValidation;

namespace Cod3rsGrowth.Testes.RepositorioMock
{
    public class EstudioMusicalRepositorioMock : IRepositorioEstudioMusical
    {
        private EstudioMusicalSingleton _instanciaEstudioMusical;
        private readonly IValidator<EstudioMusical> _estudioMusicalValidador;

        public EstudioMusicalRepositorioMock(IValidator<EstudioMusical> estudioMusical)
        {
            _estudioMusicalValidador = estudioMusical;
            _instanciaEstudioMusical = EstudioMusicalSingleton.InstanciaEstudioMusical;
        }
        public void Adicionar(EstudioMusical estudioMusical)
        {
            _estudioMusicalValidador.ValidateAndThrow(estudioMusical);
            _instanciaEstudioMusical.Add(estudioMusical);
        }

        public void Atualizar(EstudioMusical listaAtualizada)
        {
            _estudioMusicalValidador.ValidateAndThrow(listaAtualizada);
            var verificaSeOIdExiste = _instanciaEstudioMusical.Find(lista => lista.Id == listaAtualizada.Id)
                ?? throw new Exception($"Não foi possível encontrar o Estúdio com o Id: {listaAtualizada.Id}");
            var indice = _instanciaEstudioMusical.IndexOf(verificaSeOIdExiste);
            _instanciaEstudioMusical[indice] = listaAtualizada;
        }

        public EstudioMusical ObterPorId(int id)
        {
            var objetoRetornado = _instanciaEstudioMusical.Find(x => x.Id == id)
                ?? throw new Exception($"Erro ao obter o objeto, o Id: {id} é inexistente!");
            return objetoRetornado;
        }
        
        public void Deletar(int id)
        {
            var objetoQueSeraRemovido = _instanciaEstudioMusical.Find(estudio => estudio.Id == id)
                ?? throw new Exception($"Não foi possível encontrar o estúdio com o ID> {id}");
            _instanciaEstudioMusical.Remove(objetoQueSeraRemovido);
        }

        public List<EstudioMusical> ObterTodos()
        {
            return _instanciaEstudioMusical;
        }
    }
}