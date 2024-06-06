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

        public void Atualizar(EstudioMusical estudioMusical)
        {
            throw new NotImplementedException();
        }

        public EstudioMusical ObterPorId(int id)
        {
            var objetoRetornado = _instanciaEstudioMusical.Find(x => x.Id == id)
                ?? throw new Exception($"Erro ao obter o objeto, o Id: {id} é inexistente!");
            return objetoRetornado;
        }
        
        public void Deletar(EstudioMusical estudioMusical)
        {
            throw new NotImplementedException();
        }

        public List<EstudioMusical> ObterTodos()
        {
            return _instanciaEstudioMusical;
        }
    }
}