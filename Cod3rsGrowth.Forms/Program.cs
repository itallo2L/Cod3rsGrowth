using Cod3rsGrowth.Dominio.Servicos;
using Cod3rsGrowth.Forms.InjecaoDoBancoDeDados;
using Cod3rsGrowth.Infra.Migracoes;
using Cod3rsGrowth.Servico.Servicos;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Forms
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var serviceProvider = CriarServicos())
            using (var scope = serviceProvider.CreateScope())
            {
                AtualizarBD(scope.ServiceProvider);
            }

            ServiceProvider = ExecutarInjecao();
            ApplicationConfiguration.Initialize();
            var servicoAgendamento = ServiceProvider.GetRequiredService<ServicoAgendamento>();
            var servicoEstudioMusical = ServiceProvider.GetRequiredService<ServicoEstudioMusical>();
            Application.Run(new FormAgendamentoEmEstudioMusical(servicoAgendamento, servicoEstudioMusical));
        }
        public static IServiceProvider ServiceProvider { get; private set; }

        private static ServiceProvider CriarServicos()
        {
            const string nomeDaVariavelDeAmbiente = "ConexaoCod3rsGrowth";
            var stringDeConexao = Environment.GetEnvironmentVariable(nomeDaVariavelDeAmbiente);

            return new ServiceCollection()
                .AddFluentMigratorCore().ConfigureRunner(rb => rb
                .AddSqlServer()
                .WithGlobalConnectionString(stringDeConexao)
                .ScanIn(typeof(_20240715092000_AdicionarEstudioMusical).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }

        private static void AtualizarBD(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            runner.MigrateUp();
        }

        public static IServiceProvider ExecutarInjecao()
        {
            var servicos = new ServiceCollection();
            servicos.AdicionarDependenciasNoEscopo();
            return servicos.BuildServiceProvider();
        }
    }
}