using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Servicos;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Testes
{
    public static class ModuloDeInjecao
    {
        public static void AdicionarDependeciasNoEscopo(ServiceCollection servico) {
            servico.AddScoped<IServicoEstudioMusical, ServicoEstudioMusical>();
        }
    }
}