using Cod3rsGrowth.Dominio.Migracoes;
using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Forms
{
    public static class Program
    {
        public static IConfiguration Configuration { get; }
        [STAThread]
        static void Main()
        {
            using (var serviceProvider = CriarServicos())
            using (var scope = serviceProvider.CreateScope())
            {
                AtualizarBD(scope.ServiceProvider);
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }

        private static ServiceProvider CriarServicos()
        {
            const string nomeDaVariavelDeAmbiente = "ConexaoCod3rsGrowth";
            var stringDeConexao = Environment.GetEnvironmentVariable(nomeDaVariavelDeAmbiente);

            return new ServiceCollection()
                .AddFluentMigratorCore().ConfigureRunner(rb => rb
                .AddSqlServer()
                .WithGlobalConnectionString(stringDeConexao)
                .ScanIn(typeof(_20240626091000_AdicionarEstudioMusical).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }

        private static void AtualizarBD(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            runner.MigrateUp();
        }
    }
}