using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Testes.InjecaoDeDependencia;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Cod3rsGrowth.Testes
{
    public class DeveRetornarAListaDeMusicas : TesteBase
    {
        private readonly IServicoEstudioMusical _servicoEstudioMusical;
        public DeveRetornarAListaDeMusicas()
        {
            _servicoEstudioMusical = ServiceProvider.GetService<IServicoEstudioMusical>()
            ?? throw new Exception($"Erro ao obter o serviço {nameof(IServicoEstudioMusical)}");
        }

        [Fact]
        public void Comparando_Listas()
        {
            var listaDeComparacao = new List<EstudioMusical>
            {
                new EstudioMusical { Id = 32, NomeEstudio = "Sonzeira", EstaAberto = false },
                new EstudioMusical { Id = 23, NomeEstudio = "MUSIK", EstaAberto = true }
            };

            var listaEsperada = _servicoEstudioMusical.ObterTodos();

            Assert.Equivalent(listaDeComparacao, listaEsperada);
        }

        [Fact]
        public void Buscar_Um_Elemento_Na_Lista()
        {
            var listaEstudioMusical = new List<EstudioMusical>
            { new EstudioMusical { Id = 32, NomeEstudio = "Sonzeira", EstaAberto = false },
                new EstudioMusical { Id = 23, NomeEstudio = "MUSIK", EstaAberto = true }
            };

           var listaDoTipoEstudioMusical = _servicoEstudioMusical.ObterTodos();

            Assert.IsType<List<EstudioMusical>>(listaEstudioMusical);
        }
    }
}