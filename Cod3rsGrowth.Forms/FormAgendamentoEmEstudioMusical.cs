using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.EnumEstiloMusical;
using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Servicos;
using Cod3rsGrowth.Servico.Servicos;
using System.Text.RegularExpressions;

namespace Cod3rsGrowth.Forms
{
    public partial class FormAgendamentoEmEstudioMusical : Form
    {
        private readonly ServicoAgendamento _servicoAgendamento;
        private readonly ServicoEstudioMusical _servicoEstudioMusical;
        private readonly FiltroAgendamento _filtroAgendamento = new FiltroAgendamento();
        private readonly FiltroEstudioMusical _filtroEstudioMusical = new FiltroEstudioMusical();

        public FormAgendamentoEmEstudioMusical(ServicoAgendamento servicoAgendamento, ServicoEstudioMusical servicoEstudioMusical)
        {
            _servicoAgendamento = servicoAgendamento;
            _servicoEstudioMusical = servicoEstudioMusical;

            InitializeComponent();
            CarregarListas();
            GerarColunaChaveEstrangeira();

            const int iniciarNaOpcaoTodos = 0;
            cbEstiloMusical.SelectedIndex = iniciarNaOpcaoTodos;
        }

        private void CarregarListas()
        {
            dataGridAgendamento.DataSource = _servicoAgendamento.ObterTodos();
            dataGridEstudioMusical.DataSource = _servicoEstudioMusical.ObterTodos();
        }

        private void EventoDeFiltroAoBuscarEstudioMusical(object sender, EventArgs e)
        {
            _filtroEstudioMusical.Nome = txtBuscarEstudio.Text;
            dataGridEstudioMusical.DataSource = _servicoEstudioMusical.ObterTodos(_filtroEstudioMusical);
        }

        private void EventoAoClicarNoBotaoDeLimparFiltroDeBuscaEEstaAberto(object sender, EventArgs e)
        {
            txtBuscarEstudio.Clear();
            checkBoxEstaAbertoSim.Checked = false;
            checkBoxNaoEstaAberto.Checked = false;
        }

        private void EventoDeCheckBoxEstaAbertoAoSelecionarSim(object sender, EventArgs e)
        {
            _filtroEstudioMusical.EstaAberto = GaranteQueSomenteUmaCheckBoxEstejaMarcada(checkBoxEstaAbertoSim, checkBoxNaoEstaAberto);
            dataGridEstudioMusical.DataSource = _servicoEstudioMusical.ObterTodos(_filtroEstudioMusical);
        }
        private void EventoDeCheckBoxEstaAbertoAoSelecionarNao(object sender, EventArgs e)
        {
            _filtroEstudioMusical.EstaFechado = GaranteQueSomenteUmaCheckBoxEstejaMarcada(checkBoxNaoEstaAberto, checkBoxEstaAbertoSim);
            dataGridEstudioMusical.DataSource = _servicoEstudioMusical.ObterTodos(_filtroEstudioMusical);
        }

        private void EventoDeFiltroAoBuscarAgendamento(object sender, EventArgs e)
        {
            _filtroAgendamento.NomeResponsavel = txtBuscarAgendamento.Text;
            dataGridAgendamento.DataSource = _servicoAgendamento.ObterTodos(_filtroAgendamento);
        }

        private void EventoAoClicarNoBotaoDeLimparFiltroDeBuscaEDEEstiloMusical(object sender, EventArgs e)
        {
            txtBuscarAgendamento.Clear();
            const int voltarParaOpcaoTodos = 0;
            cbEstiloMusical.SelectedIndex = voltarParaOpcaoTodos;
        }

        private void EventoDeFiltroDaDataMinimaDoAgendamento(object sender, EventArgs e)
        {
            _filtroAgendamento.DataMinima = dataMinima.Value;
            dataGridAgendamento.DataSource = _servicoAgendamento.ObterTodos(_filtroAgendamento);
        }

        private void EventoDeFiltroDeDataMaximaDoAgendamento(object sender, EventArgs e)
        {
            _filtroAgendamento.DataMaxima = dataMaxima.Value;
            dataGridAgendamento.DataSource = _servicoAgendamento.ObterTodos(_filtroAgendamento);
        }

        private void EventoDeLimparFiltroDeData(object sender, EventArgs e)
        {
            dataMaxima.Value = DateTime.Now;
            dataMinima.Value = DateTime.Now;

            _filtroAgendamento.DataMinima = null;
            _filtroAgendamento.DataMaxima = null;

            dataGridAgendamento.DataSource = _servicoAgendamento.ObterTodos(_filtroAgendamento);
        }

        private void EventoDaCaixaNumericaValorMinimo(object sender, EventArgs e)
        {
            _filtroAgendamento.ValorMinimo = numericValorMinimo.Value;
            dataGridAgendamento.DataSource = _servicoAgendamento.ObterTodos(_filtroAgendamento);
        }

        private void EventoDaCaixaNumericaValorMaximo(object sender, EventArgs e)
        {
            _filtroAgendamento.ValorMaximo = numericValorMaximo.Value;
            dataGridAgendamento.DataSource = _servicoAgendamento.ObterTodos(_filtroAgendamento);
        }

        private void EventoAoClicarNoBotaoDeLimparFiltroDeValor(object sender, EventArgs e)
        {
            const int limparValores = 0;
            numericValorMaximo.Value = limparValores;
            numericValorMinimo.Value = limparValores;
        }

        private void EventoDaComboBoxAoFiltrarPeloEstiloMusical(object sender, EventArgs e)
        {
            _filtroAgendamento.EstiloMusical = (EstiloMusical)cbEstiloMusical.SelectedIndex;
            dataGridAgendamento.DataSource = _servicoAgendamento.ObterTodos(_filtroAgendamento);
        }

        private bool GaranteQueSomenteUmaCheckBoxEstejaMarcada(CheckBox marcada, CheckBox desmarcada)
        {
            if (marcada.CheckState is CheckState.Checked)
                if (desmarcada.CheckState is CheckState.Checked)
                {
                    desmarcada.Checked = false;
                }
            return marcada.Checked;
        }

        private void GerarColunaChaveEstrangeira()
        {
            dataGridAgendamento.AutoGenerateColumns = false;
            dataGridAgendamento.CellFormatting += EventoDeFormatacaoDoDataGridAgendamento;
        }

        private void EventoDeFormatacaoDoDataGridAgendamento(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var nomeDaColuna = "Estúdio";
            if (dataGridAgendamento.Columns[e.ColumnIndex].HeaderText == nomeDaColuna)
            {
                var agendamento = dataGridAgendamento.Rows[e.RowIndex].DataBoundItem as Agendamento;
                if (agendamento != null)
                {
                    var estudioMusical = _servicoEstudioMusical.ObterPorId(agendamento.IdEstudio);
                    if (estudioMusical != null)
                    {
                        e.Value = estudioMusical.Nome;
                    }
                }
            }

            nomeDaColuna = "CPF do Responsável";
            if (dataGridAgendamento.Columns[e.ColumnIndex].HeaderText == nomeDaColuna)
            {
                var linhaDoAgendamento = dataGridAgendamento.Rows[e.RowIndex].DataBoundItem as Agendamento;
                if (linhaDoAgendamento != null)
                {
                    var agendamento = _servicoAgendamento.ObterPorId(linhaDoAgendamento.Id);
                    if (agendamento != null)
                    {
                        e.Value = Regex.Replace(agendamento.CpfResponsavel, "(\\d{3})(\\d{3})(\\d{3})(\\d{2})", "$1.$2.$3-$4");
                    }
                }
            }
        }

        private void EventoAoClicarEmCadastrarEstudio(object sender, EventArgs e)
        {
            var cadastrarEstudioMusical = new FormCadastrarEstudioMusical(_servicoAgendamento, _servicoEstudioMusical);
            cadastrarEstudioMusical.ShowDialog();
            dataGridEstudioMusical.DataSource = _servicoEstudioMusical.ObterTodos();
        }

        private void EventoAoClicarEmCadastrarAgendamento(object sender, EventArgs e)
        {
            var cadastrarAgendamento = new FormCadastroDeAgendamento(_servicoAgendamento, _servicoEstudioMusical);
            cadastrarAgendamento.ShowDialog();
        }
    }
}