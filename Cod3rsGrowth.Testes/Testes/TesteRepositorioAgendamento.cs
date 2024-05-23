using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.EnumEstiloMusical;
using Cod3rsGrowth.Infra.Singleton;
using Cod3rsGrowth.Testes.InjecaoDeDependencia;
using Cod3rsGrowth.Testes.RepositorioMock;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Testes.Testes
{
    public class TesteRepositorioAgendamento : TesteBase
    {
        private readonly IAgendamentoRepositorio _agendamentoRepositorio;
        public TesteRepositorioAgendamento()
        {
            _agendamentoRepositorio = ServiceProvider.GetService<IAgendamentoRepositorio>()
            ?? throw new Exception($"Erro ao obter o serviço {nameof(IAgendamentoRepositorio)}");
        }
        public void CriarListasDeAgendamentos()
        {
            var listasDeAgendamentos = new List<Agendamento>
            {
                new Agendamento
                {
                    Id = 1,
                    NomeResponsavelDoAgendamento = "Paulo",
                    CpfResponsavelDoAgendamento = "03237852811",
                    DataEHoraDeEntrada = DateTime.Parse("30/06/2024 12:00:00"),
                    DataEHoraDeSaida = DateTime.Parse("30/06/2024 14:00:00"),
                    ValorTotal = 200m,
                    EstiloMusical = EstiloMusical.Blues,
                    EstudioId = 1 },
                new Agendamento {
                    Id = 2,
                    NomeResponsavelDoAgendamento = "Rafael",
                    CpfResponsavelDoAgendamento = "52273122515",
                    DataEHoraDeEntrada = DateTime.Parse("26/06/2024 17:00:00"),
                    DataEHoraDeSaida = DateTime.Parse("26/06/2024 20:00:00"),
                    ValorTotal = 300m,
                    EstiloMusical = EstiloMusical.Jazz,
                    EstudioId = 2
                },
                new Agendamento
                {
                    Id = 1,
                    NomeResponsavelDoAgendamento = "Josué",
                    CpfResponsavelDoAgendamento = "09631009047",
                    DataEHoraDeEntrada = DateTime.Parse("30/06/2024 14:00:00"),
                    DataEHoraDeSaida = DateTime.Parse("30/06/2024 15:00:00"),
                    ValorTotal = 100,
                    EstiloMusical = EstiloMusical.Samba,
                    EstudioId = 3
                }
            };
            AgendamentoSingleton.InstanciaAgendamento.AddRange(listasDeAgendamentos);
        }
    }
}