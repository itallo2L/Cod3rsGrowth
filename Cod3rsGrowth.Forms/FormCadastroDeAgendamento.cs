using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.EnumEstiloMusical;
using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Servicos;
using Cod3rsGrowth.Servico.Servicos;
using FluentValidation;
using LinqToDB;

namespace Cod3rsGrowth.Forms
{
    public partial class FormCadastroDeAgendamento : Form
    {
        private readonly ServicoAgendamento _servicoAgendamento;
        private readonly ServicoEstudioMusical _servicoEstudioMusical;
        public FormCadastroDeAgendamento(ServicoAgendamento servicoAgendamento, ServicoEstudioMusical servicoEstudioMusical)
        {
            _servicoAgendamento = servicoAgendamento;
            _servicoEstudioMusical = servicoEstudioMusical;
            InitializeComponent();
            const int iniciarNaPrimeiraOpcao = 0;
            comboBoxHorarioInicial.SelectedIndex = iniciarNaPrimeiraOpcao;
            comboBoxHorarioFinal.SelectedIndex = iniciarNaPrimeiraOpcao;
            comboBoxListaDeEstudioMusical.DataSource = _servicoEstudioMusical.ObterTodos().Select(x => x.Nome).ToList();
        }

        private void EventoAoCancelarCadastro(object sender, EventArgs e)
        {
            DialogResult retorno = MessageBox.Show("Tem certeza que deseja cancelar o cadastro?", "Cancelar Cadastro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (retorno == DialogResult.Yes)
                this.Close();
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
            try
            {
                FiltroEstudioMusical filtroDoEstudio = new FiltroEstudioMusical();
                filtroDoEstudio.Nome = comboBoxListaDeEstudioMusical.SelectedItem.ToString();

                var idDoEstudio = _servicoEstudioMusical.ObterTodos(filtroDoEstudio).Select(x => x.Id).FirstOrDefault();

                maskedTextBoxCpfDoResponsavel.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                var textoDaHoraInicial = Convert.ToString(comboBoxHorarioInicial.Text).Replace(":00", " ");
                var textoDaHoraFinal = Convert.ToString(comboBoxHorarioFinal.Text).Replace(":00", " ");
                var horarioDeEntrada = Convert.ToInt32(textoDaHoraInicial);
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

                _servicoAgendamento.Adicionar(agendamento);
                this.Close();
            } catch (ValidationException ve)
            {
                const string tituloDoErro = "Erro ao cadastrar";
                var listaDeErros = ve.Errors.ToList();
                var mensagemDeErro = "";
                listaDeErros.ForEach(erro => mensagemDeErro += erro.ToString() + "\n");

                MostrarMensagemErro(tituloDoErro, mensagemDeErro);
            }
        }

        private void EventoDaComboBoxNomeEstudio(object sender, EventArgs e)
        {
            comboBoxListaDeEstudioMusical.DropDownStyle = ComboBoxStyle.DropDownList;

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
    }
}