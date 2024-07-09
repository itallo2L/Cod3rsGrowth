using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.EnumEstiloMusical;
using Cod3rsGrowth.Infra.Singleton;
using Cod3rsGrowth.Servico.Servicos;
using Cod3rsGrowth.Testes.InjecaoDeDependencia;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Cod3rsGrowth.Testes.Testes
{
    public class TesteServicoAgendamento : TesteBase
    {
        private readonly ServicoAgendamento _servicoAgendamento;
        public TesteServicoAgendamento()
        {
            _servicoAgendamento = ServiceProvider.GetService<ServicoAgendamento>()
            ?? throw new Exception($"Erro ao obter o serviço {nameof(ServicoAgendamento)}");
        }

        [Fact]
        public void teste_validacao_estudio_em_uso_deve_salva_no_banco() //corrigir nome
        {
            var estudio = new EstudioMusical
            {
                EstaAberto = true,
                Nome = "Samuel Aaaag",
                Id = 15
            };

            EstudioMusicalSingleton.InstanciaEstudioMusical.Add(estudio);

            var agendamento = new Agendamento
            {
                Id = 1,
                NomeResponsavel = "Paulo",
                CpfResponsavel = "424.977.200-45",
                DataEHoraDeEntrada = DateTime.Parse("30/07/2024 09:00:00"),
                DataEHoraDeSaida = DateTime.Parse("30/07/2024 10:00:00"),
                ValorTotal = 200m,
                EstiloMusical = EstiloMusical.Blues,
                IdEstudio = 15
            };

            _servicoAgendamento.Adicionar(agendamento);

            var itemSalvoNoBanco = _servicoAgendamento.ObterPorId(agendamento.Id);

            Assert.Equal(agendamento.NomeResponsavel, itemSalvoNoBanco.NomeResponsavel);
            Assert.Equal(agendamento.CpfResponsavel, itemSalvoNoBanco.CpfResponsavel);
        }

        [Fact]
        public void teste_validacao_estudio_em_uso_deve_retornar_erro() //corrigir nome
        {
            var estudio = new EstudioMusical
            {
                EstaAberto = true,
                Nome = "Samuel Aaaag",
                Id = 15
            };

            EstudioMusicalSingleton.InstanciaEstudioMusical.Add(estudio);
            
            var lista = CriarLista();
            AgendamentoSingleton.InstanciaAgendamento.AddRange(lista);

            var agendamento = new Agendamento
            {
                Id = 1,
                NomeResponsavel = "Paulo",
                CpfResponsavel = "424.977.200-45",
                DataEHoraDeEntrada = DateTime.Parse("30/07/2024 14:00:00"),
                DataEHoraDeSaida = DateTime.Parse("30/07/2024 15:00:00"),
                ValorTotal = 200m,
                EstiloMusical = EstiloMusical.Blues,
                IdEstudio = 15
            };

            Assert.Throws<FluentValidation.ValidationException>(() => _servicoAgendamento.Adicionar(agendamento));
        }

        [Fact]
        public void deve_comparar_a_lista_obter_todos_com_a_lista_de_comparacao()
        {
            var listaDeComparacao = new List<Agendamento>
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
                    IdEstudio = 1 },
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

            var listaEsperada = CriarLista();

            Assert.Equivalent(listaDeComparacao, listaEsperada);
        }

        [Fact]
        public void deve_conferir_se_a_lista_e_do_tipo_agendamento_singleton()
        {
            var listaDoTipoAgendamento = CriarLista();

            Assert.IsType<List<Agendamento>>(listaDoTipoAgendamento);
        }

        public List<Agendamento> CriarLista()
        {
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
                },
                new Agendamento
                {
                    Id = 1,
                    NomeResponsavel = "Sam",
                    CpfResponsavel = "09631009047",
                    DataEHoraDeEntrada = DateTime.Parse("30/07/2024 14:00:00"),
                    DataEHoraDeSaida = DateTime.Parse("30/07/2024 15:00:00"),
                    ValorTotal = 100,
                    EstiloMusical = EstiloMusical.Samba,
                    IdEstudio = 15
                },
            };
            return listasDeAgendamentos;
        }
    }
}