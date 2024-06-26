using Cod3rsGrowth.Dominio.Migracoes;
using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Cod3rsGrowth.Dominio
{
    class Program
    {
        public static IConfiguration? Configuration { get; }
        static void Main(string[] args)
        {
            using (var serviceProvider = CreateServices())
            using (var scope = serviceProvider.CreateScope())
            {
                UpdateDatabase(scope.ServiceProvider);
            }

        }

        private static ServiceProvider CreateServices()
        {
            var stringDeConexao = Configuration.GetConnectionString(Environment.GetEnvironmentVariable("ConexaoCod3rsGrowth"));

            return new ServiceCollection()
                .AddFluentMigratorCore().ConfigureRunner(rb => rb.AddSqlServer()
                .WithGlobalConnectionString(stringDeConexao)
                .ScanIn(typeof(_20240625131800_AdicionarEstudioMusical).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }

        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            runner.MigrateUp();
        }
    }
}