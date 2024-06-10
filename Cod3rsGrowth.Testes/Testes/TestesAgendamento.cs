using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.EnumEstiloMusical;
using Cod3rsGrowth.Infra.Singleton;
using Cod3rsGrowth.Testes.InjecaoDeDependencia;
using Cod3rsGrowth.Testes.RepositorioMock;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.Runtime.Intrinsics.X86;
using Xunit;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        public void deve_retornar_a_excecao_de_nome_vazio()
        {
            CriarLista();
            var listaTeste = new Agendamento
            {
                Id = 8,
                NomeResponsavel = "",
                CpfResponsavel = "40028922891",
                DataEHoraDeEntrada = DateTime.Parse("30/06/2024 12:00:00"),
                DataEHoraDeSaida = DateTime.Parse("30/06/2024 14:00:00"),
                ValorTotal = 200m,
                EstiloMusical = EstiloMusical.Blues,
                IdEstudio = 3
            };

            var mensagemDeErro = Assert.Throws<FluentValidation.ValidationException>(() => _repositorioAgendamento.Adicionar(listaTeste));

            Assert.Equal("Por favor digite o nome do responsável pelo agendamento.", mensagemDeErro.Errors.Single().ErrorMessage);
        }

        [Fact]
        public void deve_retornar_a_excecao_de_nome_maior_que_25_caracteres()
        {
            CriarLista();
            var listaNomeMaiorQueOEsperado = new Agendamento
            {
                Id = 3,
                NomeResponsavel = "aaaaaaaaaaaaaaaaaaaaaaaaaaa",
                CpfResponsavel = "40028922891",
                DataEHoraDeEntrada = DateTime.Parse("30/06/2024 12:00:00"),
                DataEHoraDeSaida = DateTime.Parse("30/06/2024 14:00:00"),
                ValorTotal = 200m,
                EstiloMusical = EstiloMusical.Blues,
                IdEstudio = 3
            };

            var mensagemDeErro = Assert.Throws<FluentValidation.ValidationException>(() => _repositorioAgendamento.Atualizar(listaNomeMaiorQueOEsperado));

            Assert.Equal("O nome do responsável excedeu o limite de 25 caracteres, digite um nome menor.", mensagemDeErro.Errors.Single().ErrorMessage);
        }

        [Fact]
        public void deve_retornar_a_excecao_de_cpf_vazio()
        {
            CriarLista();
            var listaComOCpfVazio = new Agendamento
            {
                Id = 9,
                NomeResponsavel = "Josué",
                CpfResponsavel = "",
                DataEHoraDeEntrada = DateTime.Parse("30/06/2026 14:00:00"),
                DataEHoraDeSaida = DateTime.Parse("30/06/2026 15:00:00"),
                ValorTotal = 100,
                EstiloMusical = EstiloMusical.Samba,
                IdEstudio = 3
            };

            var mensagemDeErro = Assert.Throws<FluentValidation.ValidationException>(() => _repositorioAgendamento.Adicionar(listaComOCpfVazio));

            Assert.Equal("Por favor digite o CPF do responsável pelo agendamento.", mensagemDeErro.Errors.Single().ErrorMessage);
        }

        [Fact]

        public void deve_retornar_a_execao_de_cpf_invalido()
        {
            CriarLista();
            var listaComCpfInvalido = new Agendamento
            {
                Id = 1,
                NomeResponsavel = "Yudi",
                CpfResponsavel = "40028922",
                DataEHoraDeEntrada = DateTime.Parse("30/06/2026 12:00:00"),
                DataEHoraDeSaida = DateTime.Parse("30/06/2026 14:00:00"),
                ValorTotal = 200m,
                EstiloMusical = EstiloMusical.EnumIndefinido,
                IdEstudio = 1
            };

            var mensagemDeErro = Assert.Throws<FluentValidation.ValidationException>(() => _repositorioAgendamento.Atualizar(listaComCpfInvalido));

            Assert.Equal("CPF inválido, digite um CPF válido.", mensagemDeErro.Errors.Single().ErrorMessage);
        }

        [Fact]
        public void deve_retornar_a_excecao_de_data_e_hora_de_entrada_vazia()
        {
            CriarLista();
            var listaComDataEHoraDeEntradaVazia = new Agendamento
            {
                Id = 10,
                NomeResponsavel = "Josué",
                CpfResponsavel = "03238202811",
                DataEHoraDeSaida = DateTime.Parse("30/06/2026 15:00:00"),
                ValorTotal = 100,
                EstiloMusical = EstiloMusical.Samba,
                IdEstudio = 3
            };

            var mensagemDeErro = Assert.Throws<FluentValidation.ValidationException>(() => _repositorioAgendamento.Adicionar(listaComDataEHoraDeEntradaVazia));

            Assert.Equal("Por favor digite uma data e hora de entrada.", mensagemDeErro.Errors.Single().ErrorMessage);
        }

        [Fact]
        public void deve_retornar_a_excecao_quando_a_data_de_entrada_for_menor_do_que_a_data_de_hoje()
        {
            CriarLista();
            var listaComDataMenorDoQueADataDeHoje = new Agendamento
            {
                Id = 1,
                NomeResponsavel = "Paulo",
                CpfResponsavel = "03237852816",
                DataEHoraDeEntrada = DateTime.Parse("09/06/2024"), //Encontrar uma forma de colocar a data de hoje menos um dia
                DataEHoraDeSaida = DateTime.Parse("30/06/2024 14:00:00"),
                ValorTotal = 200m,
                EstiloMusical = EstiloMusical.Blues,
                IdEstudio = 1
            };

            var mensagemDeErro = Assert.Throws<FluentValidation.ValidationException>(() => _repositorioAgendamento.Atualizar(listaComDataMenorDoQueADataDeHoje));

            Assert.Equal("Por favor digite uma data válida.", mensagemDeErro.Errors.Single().ErrorMessage);
        }

        [Fact]

        public void deve_retornar_uma_excecao_quando_a_data_for_hoje_e_a_hora_for_menor_que_a_hora_atual()
        {
            CriarLista();
            var listaComADataDeHojeEHoraMenorQueAHoraAtual = new Agendamento
            {
                Id = 1,
                NomeResponsavel = "Paulo",
                CpfResponsavel = "03237852816",
                DataEHoraDeEntrada = DateTime.Parse("10/06/2024 13:40:00"), //Encontrar uma forma automática de colocar a data de hoje e uma hora antes da hora atual
                DataEHoraDeSaida = DateTime.Parse("30/06/2024 14:00:00"),
                ValorTotal = 200m,
                EstiloMusical = EstiloMusical.Blues,
                IdEstudio = 1
            };

            var mensagemDeErro = Assert.Throws<FluentValidation.ValidationException>(() => _repositorioAgendamento.Atualizar(listaComADataDeHojeEHoraMenorQueAHoraAtual));

            Assert.Equal("Por favor digite um horário válido.", mensagemDeErro.Errors.Single().ErrorMessage);
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
                    Id = 3,
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