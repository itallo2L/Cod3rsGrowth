using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Infra.Singleton;
using Cod3rsGrowth.Testes.InjecaoDeDependencia;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Cod3rsGrowth.Testes.Testes
{
    public class TestesEstudioMusical : TesteBase
    {
        private readonly IServicoEstudioMusical _estudioMusical;
        public TestesEstudioMusical()
        {
            _estudioMusical = ServiceProvider.GetService<IServicoEstudioMusical>()
                ?? throw new Exception($"Erro ao obter serviço {nameof(IServicoEstudioMusical)}");
            EstudioMusicalSingleton.InstanciaEstudioMusical.Clear();
        }

        [Fact]
        public void deve_comparar_o_metodo_criar_lista_com_o_obter_todos()
        {
            var listaEsperada = criarLista(); 

            var listaDoObterTodos = _estudioMusical.ObterTodos();
            
            Assert.Equivalent(listaDoObterTodos, listaEsperada);
        }

        [Fact]
        public void deve_verificar_o_tipo_da_lista()
        {
            var listaDoTipoEstudioMusical = _estudioMusical.ObterTodos();

            Assert.IsType<EstudioMusicalSingleton>(listaDoTipoEstudioMusical);
        }

        [Fact]
        public void deve_retornar_o_objeto_pelo_id()
        {
            var idEsperado = 2;
            criarLista();

            var idDeComparacao = _estudioMusical.ObterPorId(idEsperado);

            Assert.Equal(idEsperado, idDeComparacao.Id);
        }
        private List<EstudioMusical> criarLista()
        {
            var listaDeEstudioMusicalSingleton = EstudioMusicalSingleton.InstanciaEstudioMusical;
            var listasDeEstudiosMusicais = new List<EstudioMusical>
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
            listaDeEstudioMusicalSingleton.AddRange(listasDeEstudiosMusicais);
            return listaDeEstudioMusicalSingleton;
        }
    }
}