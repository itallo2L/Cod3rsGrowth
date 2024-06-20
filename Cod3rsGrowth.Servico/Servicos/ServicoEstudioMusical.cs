using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.InterfacesRepositorio;
using FluentValidation;
using System.Collections.Generic;

namespace Cod3rsGrowth.Dominio.Servicos
{
    public class ServicoEstudioMusical
    {
        private readonly IValidator<EstudioMusical> _validadorEstudioMusical;
        private readonly IRepositorioEstudioMusical _repositorioEstudioMusical;

        public ServicoEstudioMusical(IValidator<EstudioMusical> estudioMusical, IRepositorioEstudioMusical repositorioEstudioMusical)
        {
            _validadorEstudioMusical = estudioMusical;
            _repositorioEstudioMusical = repositorioEstudioMusical;
        }

        public void Adicionar(EstudioMusical estudioMusical)
        {
            _validadorEstudioMusical.ValidateAndThrow(estudioMusical);
            _repositorioEstudioMusical.Adicionar(estudioMusical);
        }

        public void Atualizar(EstudioMusical estudioParaAtualizar)
        {
            _validadorEstudioMusical.ValidateAndThrow(estudioParaAtualizar);
            _repositorioEstudioMusical.Atualizar(estudioParaAtualizar);
        }

        public void Deletar(int id)
        {
            _repositorioEstudioMusical.Deletar(id);
        }

        public EstudioMusical ObterPorId(int id)
        {
            return _repositorioEstudioMusical.ObterPorId(id);
        }

        public List<EstudioMusical> ObterTodos(FiltroEstudioMusical? filtro = null)
        {
            return _repositorioEstudioMusical.ObterTodos(filtro);
        }
    }
}