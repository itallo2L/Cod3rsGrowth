using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.InterfacesRepositorio;
using Cod3rsGrowth.Dominio.Servicos;
using Cod3rsGrowth.Infra;
using Cod3rsGrowth.Infra.Migracoes;
using Cod3rsGrowth.Infra.Repositorios;
using Cod3rsGrowth.Servico.Servicos;
using Cod3rsGrowth.Servico.Validacoes;
using FluentMigrator.Runner;
using FluentValidation;
using LinqToDB;
using LinqToDB.AspNet;

namespace Cod3rsGrowth.Web.InjecaoDeDependencia
{
    public static class ModuloDeInjecao
    {
        public static void AdicionarDependenciasNoEscopo(this WebApplicationBuilder construtor)
        {
            const string nomeDaVariavelDeAmbiente = "ConexaoCod3rsGrowth";
            var stringDeConexao = Environment.GetEnvironmentVariable(nomeDaVariavelDeAmbiente)
                ?? throw new Exception($"A variável de ambiente [{nomeDaVariavelDeAmbiente}] não foi encontrada.");

            construtor.Services.AddLinqToDBContext<BdCod3rsGrowth>((provider, options) => options
            .UseSqlServer((stringDeConexao)));

            construtor.Services.AddScoped<ServicoEstudioMusical>();
            construtor.Services.AddScoped<ServicoAgendamento>();
            construtor.Services.AddScoped<IRepositorioAgendamento, RepositorioAgendamento>();
            construtor.Services.AddScoped<IRepositorioEstudioMusical, RepositorioEstudioMusical>();
            construtor.Services.AddScoped<IValidator<EstudioMusical>, ValidadorEstudioMusical>();
            construtor.Services.AddScoped<IValidator<Agendamento>, ValidadorAgendamento>();

            construtor.Services.AddFluentMigratorCore()
                .AddFluentMigratorCore().ConfigureRunner(rb => rb
                .AddSqlServer()
                .WithGlobalConnectionString(stringDeConexao)
                .ScanIn(typeof(_20240715092000_AdicionarEstudioMusical).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }
    }
}