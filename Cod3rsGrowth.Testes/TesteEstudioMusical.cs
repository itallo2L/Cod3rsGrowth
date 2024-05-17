using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Testes
{
    public class TesteEstudioMusical : TesteBase
    {
        public IServicoEstudioMusical ServicoEstudioMusical;
        public TesteEstudioMusical()
        {
            ServicoEstudioMusical = ServiceProvider.GetService<IServicoEstudioMusical>();
        }
        [Fact]
        public void ComparandoListas()
        {
            var valorDeComparacao = new List<EstudioMusical>();
            valorDeComparacao.Add(new EstudioMusical { Id = 32, NomeEstudio = "Sonzeira", EstaAberto = false });
            valorDeComparacao.Add( new EstudioMusical { Id = 23, NomeEstudio = "MUSIK", EstaAberto = true });
            var resultadoEsperado = ServicoEstudioMusical.ObterTodos();
            Assert.Equivalent(valorDeComparacao, resultadoEsperado);
        }
    }
}