using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.EnumEstiloMusical;
using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Servicos;
using Cod3rsGrowth.Servico.Servicos;

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

        private void EventoDeFiltroAoBuscarAgendamento(object sender, EventArgs e)
        {
            _filtroAgendamento.NomeResponsavel = txtBuscarAgendamento.Text;
            dataGridAgendamento.DataSource = _servicoAgendamento.ObterTodos(_filtroAgendamento);
        }

        private void EventoDeFiltroAoBuscarEstudioMusical(object sender, EventArgs e)
        {
            _filtroEstudioMusical.Nome = txtBuscarEstudio.Text;
            dataGridEstudioMusical.DataSource = _servicoEstudioMusical.ObterTodos(_filtroEstudioMusical);
        }

        private void EventoDaComboBoxAoFiltrarPeloEstiloMusical(object sender, EventArgs e)
        {
            _filtroAgendamento.EstiloMusical = (EstiloMusical)cbEstiloMusical.SelectedIndex;
            dataGridAgendamento.DataSource = _servicoAgendamento.ObterTodos(_filtroAgendamento);
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
            numericValorMaximo.Value = 0;
            numericValorMinimo.Value = 0;
        }

        private void EventoAoClicarNoBotaoDeLimparPesquisaAgendamento(object sender, EventArgs e)
        {
            txtBuscarAgendamento.Clear();
        }
        private void EventoAoClicarNoBotaoDeLimparPesquisaEstudioMusical(object sender, EventArgs e)
        {
            txtBuscarEstudio.Clear();
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

        private bool GaranteQueSomenteUmaCheckBoxEstejaMarcada(CheckBox marcada, CheckBox desmarcada)
        {
            if (marcada.CheckState == CheckState.Checked)
                if (desmarcada.CheckState == CheckState.Checked)
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
            //Formatando Nome dos Estúdios na lista de Agendamento
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

            //Formatando CPF
            nomeDaColuna = "CPF do Responsável";
            if (dataGridAgendamento.Columns[e.ColumnIndex].HeaderText == nomeDaColuna)
            {
                var linhaDoAgendamento = dataGridAgendamento.Rows[e.RowIndex].DataBoundItem as Agendamento;
                if (linhaDoAgendamento != null)
                {
                    var agendamento = _servicoAgendamento.ObterPorId(linhaDoAgendamento.Id);
                    if (agendamento != null)
                    {
                        var cpfFormatadoComMascara = agendamento.CpfResponsavel.Insert(3, ".").Insert(7, ".").Insert(11, ".").Insert(12, "-");
                        e.Value = cpfFormatadoComMascara;
                    }
                }
            }
        }
    }
}