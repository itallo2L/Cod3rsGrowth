using Cod3rsGrowth.Dominio.Servicos;
using Cod3rsGrowth.Servico.Servicos;

namespace Cod3rsGrowth.Forms
{
    public partial class FormAgendamentoEmEstudioMusical : Form
    {
        private readonly ServicoAgendamento _servicoAgendamento;
        private readonly ServicoEstudioMusical _servicoEstudioMusical;
        public FormAgendamentoEmEstudioMusical(ServicoAgendamento servicoAgendamento, ServicoEstudioMusical servicoEstudioMusical)
        {
            _servicoAgendamento = servicoAgendamento;
            _servicoEstudioMusical = servicoEstudioMusical;
            InitializeComponent();
            dataGridAgendamento.DataSource = _servicoAgendamento.ObterTodos();
            dataGridEstudioMusical.DataSource = _servicoEstudioMusical.ObterTodos();
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            DialogResult retorno = MessageBox
                .Show("Tem certeza que deseja deletar o Objeto?", "Deletar Objeto", MessageBoxButtons.YesNo);

            if (retorno == DialogResult.Yes)
            {
                MessageBox.Show("Clicou em Sim");
            }
            else if (retorno == DialogResult.No)
            {
                MessageBox.Show("Clicou em Não");
            }
        }
    }
}