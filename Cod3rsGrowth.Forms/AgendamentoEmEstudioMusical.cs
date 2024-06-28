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

            const int iniciarNaOpcaoTodos = 2;
            cbEstaAberto.SelectedIndex = iniciarNaOpcaoTodos;
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

        private void EventoAoFiltrarSeEstaAberto(object sender, EventArgs e)
        {
            const int valorTodos = 2;
            _filtroEstudioMusical.EstaAberto = cbEstaAberto.SelectedIndex != valorTodos
                ? Convert.ToBoolean(cbEstaAberto.SelectedIndex)
                : null;

            dataGridEstudioMusical.DataSource = _servicoEstudioMusical.ObterTodos(_filtroEstudioMusical);
        }
    }
}