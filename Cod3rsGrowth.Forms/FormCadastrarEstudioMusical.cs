using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Servicos;
using Cod3rsGrowth.Servico.Servicos;

namespace Cod3rsGrowth.Forms
{
    public partial class FormCadastrarEstudioMusical : Form
    {
        private readonly ServicoAgendamento _servicoAgendamento;
        private readonly ServicoEstudioMusical _servicoEstudioMusical;
        public FormCadastrarEstudioMusical(ServicoAgendamento servicoAgendamento, ServicoEstudioMusical servicoEstudioMusical)
        {
            _servicoAgendamento = servicoAgendamento;
            _servicoEstudioMusical = servicoEstudioMusical;
            InitializeComponent();
        }

        private void EventoAoClicarEmCancelarCadastro(object sender, EventArgs e)
        {
            DialogResult retorno = MessageBox.Show("Tem certeza que deseja cancelar o cadastro?", "Cancelar Cadastro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (retorno == DialogResult.Yes)
                this.Close();
        }

        private void EventoAoclicarEmSalvar(object sender, EventArgs e)
        {
            try
            {
                var estudioMuscial = new EstudioMusical()
                {
                    Nome = textBoxNomeAoCadastrarEstudio.Text,
                    EstaAberto = checkBoxSimEstaAbertoAoCadastrarEstudio.Checked
                };

                _servicoEstudioMusical.Adicionar(estudioMuscial);
                this.Close();
            }
            catch (Exception ex) 
            {
                const string tituloDoErro = "Erro ao cadastrar:";
                MostrarMensagemErro(tituloDoErro, ex.Message);
            }
        }

        private static void MostrarMensagemErro(string tituloDoErro, string mensagemDeErro)
        {
            MessageBox.Show(mensagemDeErro, tituloDoErro, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}