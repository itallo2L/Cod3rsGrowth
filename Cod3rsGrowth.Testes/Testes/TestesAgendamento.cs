using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.EnumEstiloMusical;
using Cod3rsGrowth.Infra.Singleton;
using Cod3rsGrowth.Testes.InjecaoDeDependencia;
using Cod3rsGrowth.Testes.RepositorioMock;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Cod3rsGrowth.Testes.Testes
{
    public class TestesAgendamento : TesteBase
    {
        private readonly IRepositorioAgendamento _repositorioAgendamento;
        public TestesAgendamento()
        {
            _repositorioAgendamento = ServiceProvider.GetService<IRepositorioAgendamento>()
                ?? throw new Exception($"Erro ao obter o serviço {nameof(IRepositorioAgendamento)}");
            AgendamentoSingleton.InstanciaAgendamento.Clear();
        }

        [Fact]

        public void deve_comparar_o_metodo_obter_todos_com_o_criar_lista()
        {
            var listaEsperada = CriarLista();

            var listaDoObterTodos = _repositorioAgendamento.ObterTodos();

            Assert.Equivalent(listaDoObterTodos, listaEsperada);
        }

        [Fact]

        public void deve_verificar_o_tipo_da_lista()
        {
            var listaDoTipoAgendamento = _repositorioAgendamento.ObterTodos();

            Assert.IsType<AgendamentoSingleton>(listaDoTipoAgendamento);
        }

        [Fact]
        public void deve_retornar_um_objeto_pelo_id()
        {
            var idEsperado = 2;
            CriarLista();

            var agendamentoBuscado = _repositorioAgendamento.ObterPorId(idEsperado);

            Assert.Equal(idEsperado, agendamentoBuscado.Id);
        }

        [Fact]
        public void deve_adicionar_agendamento_no_repositorio_singleton()
        {
            var agendamento = new Agendamento
            {
                Id = 4,
                NomeResponsavel = "Lucas",
                CpfResponsavel = "09636738291",
                DataEHoraDeEntrada = DateTime.Parse("30/06/2024 09:00:00"),
                DataEHoraDeSaida = DateTime.Parse("30/06/2024 10:00:00"),
                ValorTotal = 200.00m,
                EstiloMusical = EstiloMusical.Eletronica,
                IdEstudio = 5
            };

            _repositorioAgendamento.Adicionar(agendamento);

            Assert.Contains(AgendamentoSingleton.InstanciaAgendamento, agendamento1 => agendamento1 == agendamento);
        }

        [Fact]
        public void deve_atualizar_a_lista_de_agendamento()
        {
            CriarLista();
            var listaComOElementoAtualizado = new Agendamento
            {
                Id = 2,
                NomeResponsavel = "Samuel",
                CpfResponsavel = "52245622515",
                DataEHoraDeEntrada = DateTime.Parse("28/06/2025 17:00:00"),
                DataEHoraDeSaida = DateTime.Parse("28/06/2025 20:00:00"),
                ValorTotal = 300.00m,
                EstiloMusical = EstiloMusical.Gospel,
                IdEstudio = 2
            };

            _repositorioAgendamento.Atualizar(listaComOElementoAtualizado);
            var listaParaAtualizar = AgendamentoSingleton.InstanciaAgendamento
                .Where(agendamento => agendamento.Id == listaComOElementoAtualizado.Id).FirstOrDefault();

            Assert.Equivalent(listaComOElementoAtualizado, listaParaAtualizar);
        }

        [Fact]
        public void deve_deletar_um_objeto_da_lista_de_agendamento()
        {
            var listaCompleta = CriarLista();
            var listaQueSeraDeletada = new Agendamento
            {
                Id = 1,
                NomeResponsavel = "Paulo",
                CpfResponsavel = "03237852811",
                DataEHoraDeEntrada = DateTime.Parse("30/06/2024 12:00:00"),
                DataEHoraDeSaida = DateTime.Parse("30/06/2024 14:00:00"),
                ValorTotal = 200m,
                EstiloMusical = EstiloMusical.Blues,
                IdEstudio = 1
            };

            _repositorioAgendamento.Deletar(listaQueSeraDeletada.Id);

            Assert.DoesNotContain(listaCompleta, lista => lista == listaQueSeraDeletada);
        }

        [Fact]

        public void deve_retornar_uma_excecao_quando_o_id_for_inexistente()
        {
            CriarLista();

            var listaComIdInexistente = new Agendamento
            {
                Id = 10,
                NomeResponsavel = "Rodrigo",
                CpfResponsavel = "03238202811",
                DataEHoraDeEntrada = DateTime.Parse("30/06/2025 12:00:00"),
                DataEHoraDeSaida = DateTime.Parse("30/06/2025 14:00:00"),
                ValorTotal = 200m,
                EstiloMusical = EstiloMusical.Sertanejo,
                IdEstudio = 10
            };

            Assert.Throws<Exception>(() => _repositorioAgendamento.Deletar(listaComIdInexistente.Id));
        }

        [Fact]

        public void deve_retornar_a_excecao_de_enum_indefinido()
        {
            CriarLista();
            var listaComEnumIndefinido = new Agendamento
            {
                Id = 1,
                NomeResponsavel = "Paulo",
                CpfResponsavel = "03237852811",
                DataEHoraDeEntrada = DateTime.Parse("30/06/2024 12:00:00"),
                DataEHoraDeSaida = DateTime.Parse("30/06/2024 14:00:00"),
                ValorTotal = 200m,
                EstiloMusical = EstiloMusical.EnumIndefinido,
                IdEstudio = 1
            };

            var mensagemDeErro = Assert.Throws<FluentValidation.ValidationException>(() => _repositorioAgendamento.Adicionar(listaComEnumIndefinido));

            Assert.Equal("Por favor defina o Estilo Musical", mensagemDeErro.Errors.Single().ErrorMessage);
        }
        public List<Agendamento> CriarLista()
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