using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.EnumEstiloMusical;
using Cod3rsGrowth.Infra.Singleton;
using Cod3rsGrowth.Servico.Servicos;
using Cod3rsGrowth.Testes.InjecaoDeDependencia;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Cod3rsGrowth.Testes.Testes
{
    public class TestesAgendamento : TesteBase
    {
        private readonly ServicoAgendamento _repositorioAgendamento;
        public TestesAgendamento()
        {
            _repositorioAgendamento = ServiceProvider.GetService<ServicoAgendamento>()
                ?? throw new Exception($"Erro ao obter o serviço {nameof(ServicoAgendamento)}");
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

        [Theory]
        [InlineData(2)]
        [InlineData(1)]
        [InlineData(3)]
        public void deve_retornar_um_objeto_pelo_id(int id)
        {
            var idEsperado = id;
            CriarLista();

            var agendamentoBuscado = _repositorioAgendamento.ObterPorId(idEsperado);

            Assert.Equal(idEsperado, agendamentoBuscado.Id);
        }

        [Fact]
        public void deve_adicionar_agendamento_no_repositorio_singleton()
        {
            CriarLista();
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
        public void deve_retornar_a_excecao_de_id_inexistente()
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
            var excecaoDeNomeVazio = "O campo Nome do Responsável é obrigatório, por favor digite o nome do responsável pelo agendamento.";
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

            Assert.Equal(excecaoDeNomeVazio, mensagemDeErro.Errors.Single().ErrorMessage);
        }

        [Fact]
        public void deve_retornar_a_excecao_de_nome_maior_que_trinta_caracteres()
        {
            CriarLista();
            var excecaoDeNomeMaiorQueTrintaCaracteres = "O nome do responsável excedeu o limite de 30 caracteres, digite um nome menor.";
            var listaNomeMaiorQueOEsperado = new Agendamento
            {
                Id = 3,
                NomeResponsavel = "Jõao Ribeiro Da Silva Morais Junior",
                CpfResponsavel = "40028922891",
                DataEHoraDeEntrada = DateTime.Parse("30/06/2024 12:00:00"),
                DataEHoraDeSaida = DateTime.Parse("30/06/2024 14:00:00"),
                ValorTotal = 200m,
                EstiloMusical = EstiloMusical.Blues,
                IdEstudio = 3
            };

            var mensagemDeErro = Assert.Throws<FluentValidation.ValidationException>(() => _repositorioAgendamento.Atualizar(listaNomeMaiorQueOEsperado));

            Assert.Equal(excecaoDeNomeMaiorQueTrintaCaracteres, mensagemDeErro.Errors.Single().ErrorMessage);
        }

        [Fact]
        public void deve_retornar_a_excecao_de_cpf_vazio()
        {
            CriarLista();
            var excecaoDeCpfVazio = "O campo CPF é obrigatório,por favor digite o CPF do responsável pelo agendamento.";
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

            Assert.Equal(excecaoDeCpfVazio, mensagemDeErro.Errors.Single().ErrorMessage);
        }

        [Fact]

        public void deve_retornar_a_execao_de_cpf_invalido()
        {
            CriarLista();
            var excecaoDeCpfInvalido = "Um CPF contém ao menos 11 digitos, digite um CPF válido.";
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

            Assert.Equal(excecaoDeCpfInvalido, mensagemDeErro.Errors.Single().ErrorMessage);
        }

        [Fact]
        public void deve_retornar_a_excecao_de_data_e_hora_de_entrada_vazia()
        {
            CriarLista();
            var excecaoDaDataEHoraDeEntradaVazia = "O campo Data e Hora de Entrada é obrigatório, por favor digite uma data e hora de entrada.";
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

            Assert.Equal(excecaoDaDataEHoraDeEntradaVazia, mensagemDeErro.Errors.Single().ErrorMessage);
        }

        [Fact]
        public void deve_retornar_a_excecao_da_data_de_entrada_menor_do_que_a_data_de_hoje()
        {
            CriarLista();
            var excecaoDaDAtaDeEntradaMenorDoQueADataDeHoje = "A data de entrada inserida é menor do que a data atual, por favor digite uma data de entrada válida.";
            var listaComDataMenorDoQueADataDeHoje = new Agendamento
            {
                Id = 1,
                NomeResponsavel = "Paulo",
                CpfResponsavel = "03237852816",
                DataEHoraDeEntrada = DateTime.Parse("09/06/2024"),
                DataEHoraDeSaida = DateTime.Parse("30/06/2024 14:00:00"),
                ValorTotal = 200m,
                EstiloMusical = EstiloMusical.Blues,
                IdEstudio = 1
            };

            var mensagemDeErro = Assert.Throws<FluentValidation.ValidationException>(() => _repositorioAgendamento.Atualizar(listaComDataMenorDoQueADataDeHoje));

            Assert.Equal(excecaoDaDAtaDeEntradaMenorDoQueADataDeHoje, mensagemDeErro.Errors.Single().ErrorMessage);
        }

        [Fact]
        public void deve_retornar_uma_excecao_quando_a_data_for_hoje_e_a_hora_for_menor_ou_igual_a_hora_atual()
        {
            CriarLista();
            var excecaoDeHoraDeEntradaMenorQueHoraAtualDoDiaAtual = "A hora de entrada inserida é menor ou igual ao horário atual, por favor digite um horário de entrada válido.";
            var listaComADataDeHojeEHoraMenorQueAHoraAtual = new Agendamento
            {
                Id = 1,
                NomeResponsavel = "Paulo",
                CpfResponsavel = "03237852816",
                DataEHoraDeEntrada = DateTime.Today,
                DataEHoraDeSaida = DateTime.Parse("30/06/2024 14:00:00"),
                ValorTotal = 200m,
                EstiloMusical = EstiloMusical.Blues,
                IdEstudio = 1
            };

            var mensagemDeErro = Assert.Throws<FluentValidation.ValidationException>(() => _repositorioAgendamento.Atualizar(listaComADataDeHojeEHoraMenorQueAHoraAtual));

            Assert.Equal(excecaoDeHoraDeEntradaMenorQueHoraAtualDoDiaAtual, mensagemDeErro.Errors.Single().ErrorMessage);
        }

        [Fact]
        public void deve_retornar_a_excecao_da_data_e_hora_de_saida_igual_a_data_e_hora_de_entrada()
        {
            CriarLista();
            var excecaoDaDataEHoraDeSaidaIgualADataEHoraDeSaida = "A data e hora de saída não pode ser igual a data e hora de entrada.";
            var listaComDataEHoraDeEntradaIgualADataEHoraDeSaida = new Agendamento
            {
                Id = 11,
                NomeResponsavel = "Rafaela",
                CpfResponsavel = "52273122515",
                DataEHoraDeEntrada = DateTime.Parse("30/07/2026 10:00:00"),
                DataEHoraDeSaida = DateTime.Parse("30/07/2026 10:00:00"),
                ValorTotal = 300m,
                EstiloMusical = EstiloMusical.MusicaClassica,
                IdEstudio = 2
            };

            var mensagemDeErro = Assert.Throws<FluentValidation.ValidationException>(() => _repositorioAgendamento.Adicionar(listaComDataEHoraDeEntradaIgualADataEHoraDeSaida));

            Assert.Equal(excecaoDaDataEHoraDeSaidaIgualADataEHoraDeSaida, mensagemDeErro.Errors.Single().ErrorMessage);
        }

        [Fact]
        public void deve_retornar_a_excecao_de_quantidade_de_hora_do_agendamento_menor_que_uma_hora()
        {
            CriarLista();
            var excecaoDeHorarioMenorQueUmaHora = "A quantidade de tempo mínima para agendamento é de uma hora.";
            var listaComHorarioDeAgendamentoMenorDoQueUmaHora = new Agendamento
            {
                Id = 2,
                NomeResponsavel = "Rafael",
                CpfResponsavel = "52273122515",
                DataEHoraDeEntrada = DateTime.Parse("26/06/2028 17:00:00"),
                DataEHoraDeSaida = DateTime.Parse("26/06/2028 17:30:00"),
                ValorTotal = 300m,
                EstiloMusical = EstiloMusical.Jazz,
                IdEstudio = 2
            };

            var mensagemDeErro = Assert.Throws<FluentValidation.ValidationException>(() => _repositorioAgendamento.Atualizar(listaComHorarioDeAgendamentoMenorDoQueUmaHora));

            Assert.Equal(excecaoDeHorarioMenorQueUmaHora, mensagemDeErro.Errors.Single().ErrorMessage);
        }

        [Fact]
        public void deve_retornar_a_excecao_do_valor_total_maior_que_cinco_algarismos_e_duas_casas_decimais(    )
        {
            CriarLista();
            var excecaoDoValorTotalMaiorQueCincoAlgarismosEDuasCasasDecimais = "O Valor Total excedeu o limite de 5 algarismos totais com duas casas decimais, por favor digite no formato exigido.";
            var listaComValortotalMaiorQueCincoAlgarismosEDuasCasasDecimais = new Agendamento
            {
                Id = 12,
                NomeResponsavel = "Cirlaneide",
                CpfResponsavel = "09631009047",
                DataEHoraDeEntrada = DateTime.Parse("30/06/2024 14:00:00"),
                DataEHoraDeSaida = DateTime.Parse("30/06/2024 15:00:00"),
                ValorTotal = 1000.00m,
                EstiloMusical = EstiloMusical.Gospel,
                IdEstudio = 3
            };

            var mensagemDeErro = Assert.Throws<FluentValidation.ValidationException>(() => _repositorioAgendamento.Adicionar(listaComValortotalMaiorQueCincoAlgarismosEDuasCasasDecimais));

            Assert.Equal(excecaoDoValorTotalMaiorQueCincoAlgarismosEDuasCasasDecimais, mensagemDeErro.Errors.Single().ErrorMessage);
        }

        [Fact]
        public void deve_retornar_a_excecao_de_enum_inexistente()
        {
            CriarLista();
            var excecaoDeEnumInexistente = "O Estilo Musical não foi encontrado, digite um Estilo Musical válido.";
            var listaComEnumInexistente = new Agendamento
            {
                Id = 3,
                NomeResponsavel = "Cleber Da Silva Rodrigues",
                CpfResponsavel = "09631009047",
                DataEHoraDeEntrada = DateTime.Parse("30/06/2024 14:00:00"),
                DataEHoraDeSaida = DateTime.Parse("30/06/2024 15:00:00"),
                EstiloMusical = (EstiloMusical)8,
                ValorTotal = 100m,
                IdEstudio = 3
            };

            var mensagemDeErro = Assert.Throws<FluentValidation.ValidationException>(() => _repositorioAgendamento.Atualizar(listaComEnumInexistente));

            Assert.Equal(excecaoDeEnumInexistente, mensagemDeErro.Errors.Single().ErrorMessage);
        }

        [Fact]
        public void deve_retornar_a_excecao_de_enum_indefinido()
        {
            CriarLista();
            var excecaoDeEnumIndefinido = "Estilo Musical indefinido, por favor defina o Estilo Musical";
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

            Assert.Equal(excecaoDeEnumIndefinido, mensagemDeErro.Errors.Single().ErrorMessage);
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
                new Agendamento 
                {
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
                    ValorTotal = 100m,
                    EstiloMusical = EstiloMusical.Samba,
                    IdEstudio = 3
                }
            };
            listaDeAgendamentoSingleton.AddRange(listasDeAgendamentos);
            return listaDeAgendamentoSingleton;
        }
    }
}