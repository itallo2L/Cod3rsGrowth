using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Interfaces;
using Microsoft.Extensions.DependencyInjection;

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
            var valorDeComparacao = new List<EstudioMusical>
            {
                new EstudioMusical { Id = 32, NomeEstudio = "Sonzeira", EstaAberto = false },
                new EstudioMusical { Id = 23, NomeEstudio = "MUSIK", EstaAberto = true }
            };

            var resultadoEsperado = _servicoEstudioMusical.ObterTodos();

            Assert.Equivalent(valorDeComparacao, resultadoEsperado);
        }

        [Fact]
        public void Buscar_Um_Elemento_Na_Lista_Pelo_Id()
        {
            int[] vetorComparativo = { 32, 23, 47, 84 };

            var resultadoEsperado = _servicoEstudioMusical.ObterTodos();

            Assert.Equal(resultadoEsperado[0].Id, vetorComparativo[0]);
            Assert.Equal(resultadoEsperado[1].Id, vetorComparativo[1]);
        }

        [Fact]
        public void Inserindo_Um_Elemento_Na_Lista()
        {
            var listaDeComparacao = _servicoEstudioMusical.ObterTodos();
            var listaComOElementoAdicionado = new List<EstudioMusical>
            {
                new EstudioMusical { Id = 32, NomeEstudio = "Sonzeira", EstaAberto = false },
                new EstudioMusical { Id = 23, NomeEstudio = "MUSIK", EstaAberto = true },
            };

            listaComOElementoAdicionado.Add(new EstudioMusical { Id = 23, NomeEstudio = "Graves", EstaAberto = true });

            Assert.Equal(listaComOElementoAdicionado, listaDeComparacao);
        }
    }
}