using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Filtros;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cod3rsGrowth.Infra.Repositorios
{
    public class RepositorioEstudioMusical 
    {
        private readonly BdCod3rsGrowth _bd;

        public RepositorioEstudioMusical(BdCod3rsGrowth bdCod3RsGrowth)
        {
            _bd = bdCod3RsGrowth;
        }

        public void Adicionar(EstudioMusical estudioMusical)
        {
            _bd.Insert(estudioMusical);
        }

        public void Atualizar(EstudioMusical estudioParaAtualizar)
        {
            _bd.Update(estudioParaAtualizar);
        }

        public void Deletar(int id)
        {
            _bd.Delete(id);
        }

        public EstudioMusical ObterPorId(int id)
        {
            var listaObtida = _bd.GetTable<EstudioMusical>().FirstOrDefault(estudio => estudio.Id == id);
            return listaObtida;
        }

        public List<EstudioMusical> ObterTodos(FiltroEstudioMusical? filtro = null)
        {
            var listaEstudioMusical = _bd.GetTable<EstudioMusical>().AsQueryable();

            if (filtro?.EstaAberto != null)
            {
                listaEstudioMusical = listaEstudioMusical.Where(estudioMusical => estudioMusical.EstaAberto == filtro.EstaAberto);
            }
            if (!string.IsNullOrEmpty(filtro?.Nome))
            {
                listaEstudioMusical = listaEstudioMusical.Where(estudioMusical => estudioMusical.Nome.Contains(filtro.Nome, StringComparison.OrdinalIgnoreCase));
            }

            return listaEstudioMusical.ToList();
        }

        public bool VerificaSeEstudioTemNomeRepetido(EstudioMusical estudioMusical)
        {
            var estudioRepetido = !_bd.GetTable<EstudioMusical>().Any(estudio => estudio.Nome == estudioMusical.Nome && estudio.Id != estudioMusical.Id);
                return estudioRepetido;
        }
    }
}