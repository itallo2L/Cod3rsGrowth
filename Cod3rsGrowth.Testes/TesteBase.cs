using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Testes
{
    public class TesteBase : IDisposable
    {
        protected ServiceProvider ServiceProvider;
        public TesteBase() 
        {
            var servico = new ServiceCollection();
            ModuloDeInjecao.AdicionarDependeciasNoEscopo(servico);
            ServiceProvider = servico.BuildServiceProvider();
        }
        public void Dispose()
        {
            ServiceProvider.Dispose();
        }
    }
}