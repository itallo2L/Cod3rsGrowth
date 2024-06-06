using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Infra.InterfacesInfra;
using Cod3rsGrowth.Infra.Singleton;
using Cod3rsGrowth.Testes.InjecaoDeDependencia;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Cod3rsGrowth.Testes
{
    public class TestandoServicos : TesteBase
    {
        private readonly IServicoEstudioMusical _servicoEstudioMusical;
        public TestandoServicos()
        {
            _servicoEstudioMusical = ServiceProvider.GetService<IServicoEstudioMusical>()
            ?? throw new Exception($"Erro ao obter o serviço {nameof(IServicoEstudioMusical)}");
        }

        [Fact]
        public void Comparando_Listas()
        {
            var listaDeComparacao = new List<EstudioMusical>
            {
                new EstudioMusical
                {
                    Id = 1,
                    Nome = "Sliced",
                    EstaAberto = true
                },
                new EstudioMusical
                {
                    Id = 2,
                    Nome = "Queizy",
                    EstaAberto = false
                },
                new EstudioMusical
                {
                    Id = 3,
                    Nome = "Musik",
                    EstaAberto = true
                }
            };

            var listaEsperada = _servicoEstudioMusical.CriarLista();

            Assert.Equivalent(listaDeComparacao, listaEsperada);
        }

        [Fact]
        public void Conferir_Se_A_Lista_E_Do_Tipo_Estudio_Musical_Singleton()
        {
            var listaDoTipoEstudioMusical = _servicoEstudioMusical.CriarLista();

            Assert.IsType<List<EstudioMusical>>(listaDoTipoEstudioMusical);
        }
    }
}