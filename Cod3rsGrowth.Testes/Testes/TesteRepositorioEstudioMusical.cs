using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.InterfacesInfra;
using Cod3rsGrowth.Infra.Singleton;
using Cod3rsGrowth.Testes.InjecaoDeDependencia;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Testes.Testes
{
    internal class TesteRepositorioEstudioMusical : TesteBase
    {
        private readonly IEstudioMusicalRepositorio _estudioMusicalRepositorio;
        public TesteRepositorioEstudioMusical()
        {
            _estudioMusicalRepositorio = ServiceProvider.GetService<IEstudioMusicalRepositorio>()
            ?? throw new Exception($"Erro ao obter o serviço {nameof(IEstudioMusicalRepositorio)}");
        }

        public void CriarListasDeEstudiosMusicais()
        {
            var listasDeEstudiosMusicais = new List<EstudioMusical>
            {
                new EstudioMusical
                {
                    Id = 1,
                    NomeEstudio = "Slice",
                    EstaAberto = true
                },
                new EstudioMusical
                {
                    Id = 2,
                    NomeEstudio = "Queizy",
                    EstaAberto = false
                },
                new EstudioMusical
                {
                    Id = 3,
                    NomeEstudio = "Musik",
                    EstaAberto = true
                }
            };
            EstudioMusicalSingleton.InstanciaEstudioMusical.AddRange(listasDeEstudiosMusicais);
        }
    }
}