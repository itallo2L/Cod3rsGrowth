using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Servicos;
using Cod3rsGrowth.Infra.InterfacesInfra;
using Cod3rsGrowth.Servico.Servicos;
using Cod3rsGrowth.Servico.Validacoes;
using Cod3rsGrowth.Testes.RepositorioMock;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Testes.InjecaoDeDependencia
{
    public static class ModuloDeInjecao
    {
        public static void AdicionarDependeciasNoEscopo(ServiceCollection servico)
        {
            servico.AddScoped<IServicoEstudioMusical, ServicoEstudioMusical>();
            servico.AddScoped<IServicoAgendamento, ServicoAgendamento>();
            servico.AddScoped<IRepositorioAgendamento,AgendamentoRepositorioMock>();
            servico.AddScoped<IRepositorioEstudioMusical, EstudioMusicalRepositorioMock>();
            servico.AddScoped<IValidator<EstudioMusical>, ValidadorEstudioMusical>();
            servico.AddScoped<IValidator<Agendamento>, ValidadorAgendamento>();
        }
    }
}