using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.EnumEstiloMusical;
using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Servicos;
using Cod3rsGrowth.Servico.Servicos;
using FluentValidation;
using LinqToDB;
using Microsoft.IdentityModel.Tokens;

namespace Cod3rsGrowth.Forms
{
    public partial class FormCadastroDeAgendamento : Form
    {
        private readonly ServicoAgendamento _servicoAgendamento;
        private readonly ServicoEstudioMusical _servicoEstudioMusical;
        private readonly Agendamento _agendamento;
        public FormCadastroDeAgendamento(ServicoAgendamento servicoAgendamento, ServicoEstudioMusical servicoEstudioMusical, Agendamento? agendamento = null)
        {
            _servicoAgendamento = servicoAgendamento;
            _servicoEstudioMusical = servicoEstudioMusical;
            _agendamento = agendamento;

            InitializeComponent();

            const int iniciarNaPrimeiraOpcao = 0;
            comboBoxHorarioInicial.SelectedIndex = iniciarNaPrimeiraOpcao;
            comboBoxHorarioFinal.SelectedIndex = iniciarNaPrimeiraOpcao;
            comboBoxEstiloMusical.SelectedIndex = iniciarNaPrimeiraOpcao;

            comboBoxListaDeEstudioMusical.DataSource = _servicoEstudioMusical.ObterTodos().Select(x => x.Nome).ToList();

            if (_agendamento != null)
                PreencherDadosAgendamento();
        }

        private void EventoDaComboBoxNomeEstudio(object sender, EventArgs e)
        {
            comboBoxListaDeEstudioMusical.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void EventoDaComboBoxHoraInicial(object sender, EventArgs e)
        {
            comboBoxHorarioInicial.Tag = dataDeAgendamento.Text;
            comboBoxHorarioInicial.DropDownStyle = ComboBoxStyle.DropDownList;

            var valorTotal = CalculaValorTotalEmRelacaoAoHorarioAgendado(comboBoxHorarioInicial.SelectedIndex, comboBoxHorarioFinal.SelectedIndex);
            textBoxValorTotal.Text = $"R$ {valorTotal},00";
        }

        private void EventoDaComboBoxHoraFinal(object sender, EventArgs e)
        {
            comboBoxHorarioFinal.Tag = dataDeAgendamento.Text;
            comboBoxHorarioFinal.DropDownStyle = ComboBoxStyle.DropDownList;

            var valorTotal = CalculaValorTotalEmRelacaoAoHorarioAgendado(comboBoxHorarioInicial.SelectedIndex, comboBoxHorarioFinal.SelectedIndex);
            textBoxValorTotal.Text = $"R$ {valorTotal},00";
        }

        private void EventoAoSalvarAgendamento(object sender, EventArgs e)
        {
            if (!ValidacaoDeTela())
            {
                return;
            }

            try
            {
                FiltroEstudioMusical filtroDoEstudio = new FiltroEstudioMusical();
                filtroDoEstudio.Nome = comboBoxListaDeEstudioMusical.SelectedItem.ToString();

                var idDoEstudio = _servicoEstudioMusical.ObterTodos(filtroDoEstudio).Select(x => x.Id).FirstOrDefault();

                maskedTextBoxCpfDoResponsavel.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                var textoDaHoraInicial = comboBoxHorarioInicial.Text.Replace(":00", "");
                var textoDaHoraFinal = comboBoxHorarioFinal.Text.Replace(":00", "");

                textoDaHoraInicial = textoDaHoraInicial == ""
                    ? "0"
                    : textoDaHoraInicial;
                var horarioDeEntrada = Convert.ToInt32(textoDaHoraInicial);

                textoDaHoraFinal = textoDaHoraFinal == ""
                    ? "0"
                    : textoDaHoraFinal;
                var horarioDeSaida = Convert.ToInt32(textoDaHoraFinal);

                var agendamento = new Agendamento()
                {
                    NomeResponsavel = textBoxNomeDoResponsavel.Text,
                    CpfResponsavel = maskedTextBoxCpfDoResponsavel.Text,
                    IdEstudio = idDoEstudio,
                    DataEHoraDeEntrada = dataDeAgendamento.Value.Date.AddHours(horarioDeEntrada),
                    DataEHoraDeSaida = dataDeAgendamento.Value.Date.AddHours(horarioDeSaida),
                    ValorTotal = CalculaValorTotalEmRelacaoAoHorarioAgendado(comboBoxHorarioInicial.SelectedIndex, comboBoxHorarioFinal.SelectedIndex),
                    EstiloMusical = (EstiloMusical)comboBoxEstiloMusical.SelectedIndex
                };

                if (_agendamento != null)
                {
                    agendamento.Id = _agendamento.Id;
                    _servicoAgendamento.Atualizar(agendamento);
                }
                else
                {
                    _servicoAgendamento.Adicionar(agendamento);
                }
                this.Close();
            }
            catch (ValidationException ve)
            {
                const string tituloDoErro = "Erro ao cadastrar";

                var listaDeErros = ve.Errors.ToList();
                var mensagemDeErro = "";
                listaDeErros.ForEach(erro => mensagemDeErro += erro.ToString() + "\n");

                MostrarMensagemErro(tituloDoErro, mensagemDeErro);
            }
        }

        private void EventoAoCancelarCadastro(object sender, EventArgs e)
        {
            DialogResult retorno = MessageBox.Show("Tem certeza que deseja cancelar?", "Cancelar Operação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (retorno == DialogResult.Yes)
                this.Close();
        }

        private int MetodoParaCompararOsHorarios(int primeiroIndex, int segundoIndex)
        {
            return segundoIndex - primeiroIndex;
        }

        private decimal CalculaValorTotalEmRelacaoAoHorarioAgendado(int primeiroIndex, int segundoIndex)
        {
            if (primeiroIndex < segundoIndex)
            {
                var quantidadeDeHoras = MetodoParaCompararOsHorarios(primeiroIndex, segundoIndex);
                const int valorDaHora = 100;
                var valorTotal = quantidadeDeHoras * valorDaHora;

                return valorTotal;
            }
            return 0;
        }
        private static void MostrarMensagemErro(string tituloDoErro, string mensagemDeErro)
        {
            MessageBox.Show(mensagemDeErro, tituloDoErro, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool ValidacaoDeTela()
        {
            const string tituloDoErro = "Erro de validação";
            const int comboBoxNaoSelecionada = 0;
            var mensagemDeErro = "";

            if (textBoxNomeDoResponsavel.Text.IsNullOrEmpty())
                mensagemDeErro += "O campo nome do responsável é obrigatório!\n";

            maskedTextBoxCpfDoResponsavel.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            if (maskedTextBoxCpfDoResponsavel.Text.IsNullOrEmpty())
                mensagemDeErro += "O campo CPF do responsável é obrigatório!\n";

            if (comboBoxHorarioInicial.SelectedIndex == comboBoxNaoSelecionada)
                mensagemDeErro += "O campo horário de entrada no estúdio é obrigatório!\n";

            if (comboBoxHorarioFinal.SelectedIndex == comboBoxNaoSelecionada)
                mensagemDeErro += "O campo horário de saída no estúdio é obrigatório!\n";

            if (comboBoxEstiloMusical.SelectedIndex == comboBoxNaoSelecionada)
                mensagemDeErro += "O campo estilo musical é obrigatório!\n";

            if (mensagemDeErro.IsNullOrEmpty())
                return true;
            MostrarMensagemErro(tituloDoErro, mensagemDeErro);
            return false;
        }

        private void PreencherDadosAgendamento()
        {
            var estudioMusical = _servicoEstudioMusical.ObterPorId(_agendamento.IdEstudio);
            comboBoxListaDeEstudioMusical.Text = estudioMusical.Nome.ToString();
            textBoxNomeDoResponsavel.Text = _agendamento.NomeResponsavel;
            maskedTextBoxCpfDoResponsavel.Text = _agendamento.CpfResponsavel;
            comboBoxHorarioInicial.Text = _agendamento.DataEHoraDeEntrada.Hour.ToString();
            dataDeAgendamento.Text = _agendamento.DataEHoraDeSaida.ToString();
            comboBoxHorarioFinal.Text = _agendamento.DataEHoraDeSaida.Hour.ToString();
            textBoxValorTotal.Text = _agendamento.ValorTotal.ToString();
            comboBoxEstiloMusical.Text = _agendamento.EstiloMusical.ToString();

            comboBoxHorarioInicial.Text = MascaraDeHorario(_agendamento.DataEHoraDeEntrada.Hour, comboBoxHorarioInicial);
            comboBoxHorarioFinal.Text = MascaraDeHorario(_agendamento.DataEHoraDeSaida.Hour, comboBoxHorarioFinal);
        }

        private string MascaraDeHorario(int DataEHoraPontoHour, ComboBox horario)
        {
            var dataHora = DataEHoraPontoHour;
            var hora = DataEHoraPontoHour.ToString().Length > 1
                ? DataEHoraPontoHour.ToString()
                : $"0{DataEHoraPontoHour}";

            return horario.Text = $"{hora}:00";
        }

        private void EventoDeComboBoxEstiloMusical(object sender, EventArgs e)
        {
           comboBoxEstiloMusical.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}