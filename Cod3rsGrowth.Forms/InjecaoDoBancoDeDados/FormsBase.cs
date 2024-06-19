using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Forms.InjecaoDoBancoDeDados
{
    public class FormsBase : IDisposable
    {
        protected ServiceProvider ServiceProvider;
        public FormsBase()
        {
            var servico = new ServiceCollection();
            ModuloDeInjecao.AdicionarDependenciasNoEscopo(servico);
            ServiceProvider = servico.BuildServiceProvider();
        }
        public void Dispose()
        {
            ServiceProvider.Dispose();
        }
    }
}