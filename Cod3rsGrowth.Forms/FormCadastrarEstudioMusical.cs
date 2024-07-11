using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Servicos;
using Cod3rsGrowth.Servico.Servicos;
using FluentValidation;
using Microsoft.IdentityModel.Tokens;

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

        private void EventoAoClicarEmSalvarEstudio(object sender, EventArgs e)
        {
            if (!ValidacaoDeTela())
            {
                return;
            }

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
            catch (ValidationException ve)
            {
                const string tituloDoErro = "Erro ao cadastrar";

                var listaDeErros = ve.Errors.ToList();
                var mensagemDeErro = "";
                listaDeErros.ForEach(erro => mensagemDeErro += erro.ToString() + "\n");

                MostrarMensagemErro(tituloDoErro, ve.Message);
            }
        }

        private void EventoAoClicarEmCancelarCadastro(object sender, EventArgs e)
        {
            DialogResult retorno = MessageBox.Show("Tem certeza que deseja cancelar o cadastro?", "Cancelar Cadastro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (retorno == DialogResult.Yes)
                this.Close();
        }

        private static void MostrarMensagemErro(string tituloDoErro, string mensagemDeErro)
        {
            MessageBox.Show(mensagemDeErro, tituloDoErro, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool ValidacaoDeTela()
        {
            const string tituloDoErro = "Erro de validação";
            var mensagemDeErro = "";

            if (textBoxNomeAoCadastrarEstudio.Text.IsNullOrEmpty())
                mensagemDeErro += "O campo nome do estúdio é obrigatório!";

            if (mensagemDeErro.IsNullOrEmpty())
                return true;
            MostrarMensagemErro(tituloDoErro, mensagemDeErro);
            return false;
        }
    }
}