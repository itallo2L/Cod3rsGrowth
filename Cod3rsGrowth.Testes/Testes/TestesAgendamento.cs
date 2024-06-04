using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.EnumEstiloMusical;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Infra.Singleton;
using Cod3rsGrowth.Testes.InjecaoDeDependencia;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Cod3rsGrowth.Testes.Testes
{
    public class TestesAgendamento : TesteBase
    {
        private readonly IServicoAgendamento _agendamento;
        public TestesAgendamento()
        {
            _agendamento = ServiceProvider.GetService<IServicoAgendamento>()
                ?? throw new Exception($"Erro ao obter o serviço {nameof(IServicoAgendamento)}");
            AgendamentoSingleton.InstanciaAgendamento.Clear();
        }

        [Fact]

        public void deve_comparar_o_metodo_obter_todos_com_o_criar_lista()
        {
            var listaEsperada = criarLista();

            var listaDoObterTodos = _agendamento.ObterTodos();

            Assert.Equivalent(listaDoObterTodos, listaEsperada);
        }

        [Fact]

        public void deve_verificar_o_tipo_da_lista()
        {
            var listaDoTipoAgendamento = _agendamento.ObterTodos();

            Assert.IsType<AgendamentoSingleton>(listaDoTipoAgendamento);
        }

        [Fact]
        public void deve_retornar_um_objeto_pelo_id()
        {
            var idEsperado = 2;
            criarLista();

            var idDeComparacao = _agendamento.ObterPorId(idEsperado);

            Assert.Equivalent(idEsperado, idDeComparacao.Id);
        }

        public List<Agendamento> criarLista()
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