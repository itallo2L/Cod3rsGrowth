using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Servicos;
using Cod3rsGrowth.Servico.Servicos;

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
        }

        private void EventoAoCancelarCadastro(object sender, EventArgs e)
        {
            DialogResult retorno = MessageBox.Show("Tem certeza que deseja cancelar o cadastro?", "Cancelar Cadastro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (retorno == DialogResult.Yes)
                this.Close();
        }

        private void EventoDaComboBoxHoraInicial(object sender, EventArgs e)
        {
            comboBoxHorarioInicial.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void EventoDaComboBoxHoraFinal(object sender, EventArgs e)
        {
            comboBoxHorarioFinal.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void EventoAoSalvarAgendamento(object sender, EventArgs e)
        {
            var agendamento = new Agendamento()
            {
                NomeResponsavel = textBoxNomeDoResponsavel.Text,
                CpfResponsavel = maskedTextBoxCpfDoResponsavel.Text
            };
        }
    }
}