using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.InterfacesInfra;
using Cod3rsGrowth.Infra.Singleton;
using Cod3rsGrowth.Testes.InjecaoDeDependencia;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
using Xunit;

namespace Cod3rsGrowth.Testes.Testes
{
    public class TestesEstudioMusical : TesteBase
    {
        private readonly IRepositorioEstudioMusical _repositorioEstudioMusical;
        public TestesEstudioMusical()
        {
            _repositorioEstudioMusical = ServiceProvider.GetService<IRepositorioEstudioMusical>()
                ?? throw new Exception($"Erro ao obter serviço {nameof(IRepositorioEstudioMusical)}");
            EstudioMusicalSingleton.InstanciaEstudioMusical.Clear();
        }

        [Fact]
        public void deve_comparar_o_metodo_criar_lista_com_o_obter_todos()
        {
            var listaEsperada = CriarLista();

            var listaDoObterTodos = _repositorioEstudioMusical.ObterTodos();

            Assert.Equivalent(listaDoObterTodos, listaEsperada);
        }

        [Fact]
        public void deve_verificar_o_tipo_da_lista()
        {
            var listaDoTipoEstudioMusical = _repositorioEstudioMusical.ObterTodos();

            Assert.IsType<EstudioMusicalSingleton>(listaDoTipoEstudioMusical);
        }

        [Fact]
        public void deve_retornar_o_objeto_pelo_id()
        {
            var idEsperado = 2;
            CriarLista();

            var estudioMusicalBuscado = _repositorioEstudioMusical.ObterPorId(idEsperado);

            Assert.Equal(idEsperado, estudioMusicalBuscado.Id);
        }

        [Fact]
        public void deve_adicionar_estudio_musical_no_repositorio_singleton()
        {
            var estudioMusical = new EstudioMusical
            {
                Id = 5,
                Nome = "cleber",
                EstaAberto = false
            };

            _repositorioEstudioMusical.Adicionar(estudioMusical);

            Assert.Contains(EstudioMusicalSingleton.InstanciaEstudioMusical, estudioMusical1 => estudioMusical1 == estudioMusical);
        }

        [Fact]
        public void deve_atualizar_a_lista_de_estudio_musical()
        {
            var listaComElementoAtualizado = new EstudioMusical
            {
                Id = 3,
                Nome = "Samsungo",
                EstaAberto = true
            };
            CriarLista();

            _repositorioEstudioMusical.Atualizar(listaComElementoAtualizado);
            var listaParaAtualizar = EstudioMusicalSingleton.InstanciaEstudioMusical
                .Where(estudioMusical => estudioMusical.Id == listaComElementoAtualizado.Id).FirstOrDefault();

            Assert.Equivalent(listaComElementoAtualizado, listaParaAtualizar);
        }

        [Fact]
        public void deve_conferir_se_a_validacao_de_nome_esta_correta_e_caso_esteja_adicionar()
        {
            var estudioSemNome = new EstudioMusical
            {
                Id = 6,
                EstaAberto = false
            };

            var mensagemDeErro = Assert.Throws<FluentValidation.ValidationException>(() => _repositorioEstudioMusical.Adicionar(estudioSemNome));

            Assert.Equal("Por favor insira o nome do Estúdio.", mensagemDeErro.Errors.Single().ErrorMessage);
        }

        [Fact]
        public void deve_deletar_um_objeto_da_lista_de_estudio_musical()
        {
            var listaCompleta = CriarLista();
            var listaQueSeraDeletada = new EstudioMusical
            {
                Id = 2,
                Nome = "Queizy",
                EstaAberto = false
            };

            _repositorioEstudioMusical.Deletar(listaQueSeraDeletada.Id);

            Assert.DoesNotContain(listaCompleta, lista => lista == listaQueSeraDeletada);
        }

        [Fact]

        public void deve_retornar_uma_excecao_quando_o_id_for_inexistente()
        {
            CriarLista();
            
            var listaComIdInexistente = new EstudioMusical
            {
                Id = 10,
                Nome = "Estudio10",
                EstaAberto = true
            };

            Assert.Throws<Exception>(() => _repositorioEstudioMusical.Deletar(listaComIdInexistente.Id));
        }
        private List<EstudioMusical> CriarLista()
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