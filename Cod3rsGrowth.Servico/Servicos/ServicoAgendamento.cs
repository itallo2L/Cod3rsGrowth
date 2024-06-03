using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.EnumEstiloMusical;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Infra.Singleton;

namespace Cod3rsGrowth.Servico.Servicos
{
    public class ServicoAgendamento : IServicoAgendamento
    {
        public List<Agendamento> ObterTodos()
        {
            var listaDeAgendamentoSingleton = AgendamentoSingleton.InstanciaAgendamento;

            var listasDeAgendamentos = new List<Agendamento>
            {
                new Agendamento
                {
                    Id = 1,
                    NomeResponsavel = "Paulo",
                    CpfResponsavel = "03237852811",
                    DataEHoraDeEntrada = DateTime.Parse("30/06/2024 12:00:00"),
                    DataEHoraDeSaida = DateTime.Parse("30/06/2024 14:00:00"),
                    ValorTotal = 200m,
                    EstiloMusical = EstiloMusical.Blues,
                    IdEstudio = 1 
                },
                new Agendamento {
                    Id = 2,
                    NomeResponsavel = "Rafael",
                    CpfResponsavel = "52273122515",
                    DataEHoraDeEntrada = DateTime.Parse("26/06/2024 17:00:00"),
                    DataEHoraDeSaida = DateTime.Parse("26/06/2024 20:00:00"),
                    ValorTotal = 300m,
                    EstiloMusical = EstiloMusical.Jazz,
                    IdEstudio = 2
                },
                new Agendamento
                {
                    Id = 1,
                    NomeResponsavel = "Josué",
                    CpfResponsavel = "09631009047",
                    DataEHoraDeEntrada = DateTime.Parse("30/06/2024 14:00:00"),
                    DataEHoraDeSaida = DateTime.Parse("30/06/2024 15:00:00"),
                    ValorTotal = 100,
                    EstiloMusical = EstiloMusical.Samba,
                    IdEstudio = 3
                }
            };
            listaDeAgendamentoSingleton.AddRange(listasDeAgendamentos);
            return listaDeAgendamentoSingleton;
        }
    }
}