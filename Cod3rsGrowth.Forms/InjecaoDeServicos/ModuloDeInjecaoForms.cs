
using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.InterfacesRepositorio;
using Cod3rsGrowth.Dominio.Servicos;
using Cod3rsGrowth.Infra;
using Cod3rsGrowth.Infra.Repositorios;
using Cod3rsGrowth.Servico.Servicos;
using Cod3rsGrowth.Servico.Validacoes;
using FluentValidation;
using LinqToDB;
using LinqToDB.AspNet;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Forms.InjecaoDoBancoDeDados
{
    public static class ModuloDeInjecaoForms
    {
        public static void AdicionarDependenciasNoEscopo(this IServiceCollection servico)
        {
            const string nomeDaVariavelDeAmbiente = "ConexaoCod3rsGrowth";
            var stringDeConexao = Environment.GetEnvironmentVariable(nomeDaVariavelDeAmbiente)
                ?? throw new Exception($"A variável de ambiente [{nomeDaVariavelDeAmbiente}] não foi encontrada.");

            servico.AddLinqToDBContext<BdCod3rsGrowth>((provider, options) => options
            .UseSqlServer((stringDeConexao)));

            servico.AddScoped<ServicoEstudioMusical>();
            servico.AddScoped<ServicoAgendamento>();
            servico.AddScoped<IRepositorioAgendamento, RepositorioAgendamento>();
            servico.AddScoped<IRepositorioEstudioMusical, RepositorioEstudioMusical>();
            servico.AddScoped<IValidator<EstudioMusical>, ValidadorEstudioMusical>();
            servico.AddScoped<IValidator<Agendamento>, ValidadorAgendamento>();
            servico.AddScoped<FormAgendamentoEmEstudioMusical>();
        }
    }
}