using Cod3rsGrowth.Infra;
using LinqToDB;
using LinqToDB.AspNet;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Forms.InjecaoDoBancoDeDados
{
    public class ModuloDeInjecao
    {
        public static IConfiguration Configuration { get;}
        public static void AdicionarDependenciasNoEscopo(ServiceCollection servico)
        {
            servico.AddLinqToDBContext<BdCod3rsGrowth>((provider, options) => options
            .UseSqlServer(Configuration.GetConnectionString("ConexaoCod3rsGrowth")));
        }
    }
}