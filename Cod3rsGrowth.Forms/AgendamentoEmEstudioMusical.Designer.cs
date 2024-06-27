namespace Cod3rsGrowth.Forms
{
    partial class FormAgendamentoEmEstudioMusical
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnAdicionarEstudioMusical = new Button();
            btnAtualizarEstudioMusical = new Button();
            txtNomeEstudio = new TextBox();
            tabAgendamentoEmEstudioMusical = new TabControl();
            tabEstudioMusical = new TabPage();
            lblEstaAberto = new Label();
            cbSelecione = new ComboBox();
            dataGridEstudioMusical = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nomeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            estaAbertoDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            estudioMusicalBindingSource = new BindingSource(components);
            btnDeletarEstudioMusical = new Button();
            tabAgendamento = new TabPage();
            cbAgendamento = new ComboBox();
            textBuscarAgendamento = new TextBox();
            btnDeletarAgendamento = new Button();
            btnAtualizarAgendamento = new Button();
            btnAdicionarAgendamento = new Button();
            dataGridAgendamento = new DataGridView();
            idDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            nomeResponsavelDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cpfResponsavelDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dataEHoraDeEntradaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dataEHoraDeSaidaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            valorTotalDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            estiloMusicalDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            idEstudioDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            agendamentoBindingSource = new BindingSource(components);
            bdCod3rsGrowthBindingSource = new BindingSource(components);
            tabAgendamentoEmEstudioMusical.SuspendLayout();
            tabEstudioMusical.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridEstudioMusical).BeginInit();
            ((System.ComponentModel.ISupportInitialize)estudioMusicalBindingSource).BeginInit();
            tabAgendamento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridAgendamento).BeginInit();
            ((System.ComponentModel.ISupportInitialize)agendamentoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bdCod3rsGrowthBindingSource).BeginInit();
            SuspendLayout();
            // 
            // btnAdicionarEstudioMusical
            // 
            btnAdicionarEstudioMusical.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAdicionarEstudioMusical.Location = new Point(651, 391);
            btnAdicionarEstudioMusical.Name = "btnAdicionarEstudioMusical";
            btnAdicionarEstudioMusical.Size = new Size(75, 23);
            btnAdicionarEstudioMusical.TabIndex = 0;
            btnAdicionarEstudioMusical.Text = "Adicionar";
            btnAdicionarEstudioMusical.UseVisualStyleBackColor = true;
            // 
            // btnAtualizarEstudioMusical
            // 
            btnAtualizarEstudioMusical.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAtualizarEstudioMusical.Location = new Point(732, 391);
            btnAtualizarEstudioMusical.Name = "btnAtualizarEstudioMusical";
            btnAtualizarEstudioMusical.Size = new Size(75, 23);
            btnAtualizarEstudioMusical.TabIndex = 1;
            btnAtualizarEstudioMusical.Text = "Atualizar";
            btnAtualizarEstudioMusical.UseVisualStyleBackColor = true;
            // 
            // txtNomeEstudio
            // 
            txtNomeEstudio.Location = new Point(8, 42);
            txtNomeEstudio.Name = "txtNomeEstudio";
            txtNomeEstudio.Size = new Size(213, 23);
            txtNomeEstudio.TabIndex = 3;
            txtNomeEstudio.Text = "Digite o nome do Estúdio";
            // 
            // tabAgendamentoEmEstudioMusical
            // 
            tabAgendamentoEmEstudioMusical.Controls.Add(tabEstudioMusical);
            tabAgendamentoEmEstudioMusical.Controls.Add(tabAgendamento);
            tabAgendamentoEmEstudioMusical.Dock = DockStyle.Fill;
            tabAgendamentoEmEstudioMusical.Location = new Point(0, 0);
            tabAgendamentoEmEstudioMusical.Name = "tabAgendamentoEmEstudioMusical";
            tabAgendamentoEmEstudioMusical.SelectedIndex = 0;
            tabAgendamentoEmEstudioMusical.Size = new Size(906, 450);
            tabAgendamentoEmEstudioMusical.TabIndex = 5;
            // 
            // tabEstudioMusical
            // 
            tabEstudioMusical.Controls.Add(lblEstaAberto);
            tabEstudioMusical.Controls.Add(cbSelecione);
            tabEstudioMusical.Controls.Add(dataGridEstudioMusical);
            tabEstudioMusical.Controls.Add(btnDeletarEstudioMusical);
            tabEstudioMusical.Controls.Add(txtNomeEstudio);
            tabEstudioMusical.Controls.Add(btnAtualizarEstudioMusical);
            tabEstudioMusical.Controls.Add(btnAdicionarEstudioMusical);
            tabEstudioMusical.Location = new Point(4, 24);
            tabEstudioMusical.Name = "tabEstudioMusical";
            tabEstudioMusical.Padding = new Padding(3);
            tabEstudioMusical.Size = new Size(898, 422);
            tabEstudioMusical.TabIndex = 0;
            tabEstudioMusical.Text = "Estudio Musical";
            tabEstudioMusical.UseVisualStyleBackColor = true;
            // 
            // lblEstaAberto
            // 
            lblEstaAberto.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblEstaAberto.AutoSize = true;
            lblEstaAberto.Location = new Point(301, 24);
            lblEstaAberto.Name = "lblEstaAberto";
            lblEstaAberto.Size = new Size(72, 15);
            lblEstaAberto.TabIndex = 10;
            lblEstaAberto.Text = "Está Aberto?";
            // 
            // cbSelecione
            // 
            cbSelecione.FormattingEnabled = true;
            cbSelecione.Location = new Point(301, 42);
            cbSelecione.Name = "cbSelecione";
            cbSelecione.Size = new Size(67, 23);
            cbSelecione.TabIndex = 8;
            // 
            // dataGridEstudioMusical
            // 
            dataGridEstudioMusical.AllowUserToAddRows = false;
            dataGridEstudioMusical.AllowUserToDeleteRows = false;
            dataGridEstudioMusical.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridEstudioMusical.AutoGenerateColumns = false;
            dataGridEstudioMusical.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridEstudioMusical.BackgroundColor = SystemColors.Control;
            dataGridEstudioMusical.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridEstudioMusical.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nomeDataGridViewTextBoxColumn, estaAbertoDataGridViewCheckBoxColumn });
            dataGridEstudioMusical.DataSource = estudioMusicalBindingSource;
            dataGridEstudioMusical.GridColor = Color.Black;
            dataGridEstudioMusical.Location = new Point(7, 89);
            dataGridEstudioMusical.Name = "dataGridEstudioMusical";
            dataGridEstudioMusical.ReadOnly = true;
            dataGridEstudioMusical.RowHeadersVisible = false;
            dataGridEstudioMusical.RowTemplate.Height = 25;
            dataGridEstudioMusical.Size = new Size(881, 199);
            dataGridEstudioMusical.TabIndex = 6;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            nomeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // estaAbertoDataGridViewCheckBoxColumn
            // 
            estaAbertoDataGridViewCheckBoxColumn.DataPropertyName = "EstaAberto";
            estaAbertoDataGridViewCheckBoxColumn.HeaderText = "EstaAberto";
            estaAbertoDataGridViewCheckBoxColumn.Name = "estaAbertoDataGridViewCheckBoxColumn";
            estaAbertoDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // estudioMusicalBindingSource
            // 
            estudioMusicalBindingSource.DataSource = typeof(Dominio.Entidades.EstudioMusical);
            // 
            // btnDeletarEstudioMusical
            // 
            btnDeletarEstudioMusical.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDeletarEstudioMusical.Location = new Point(813, 391);
            btnDeletarEstudioMusical.Name = "btnDeletarEstudioMusical";
            btnDeletarEstudioMusical.Size = new Size(75, 23);
            btnDeletarEstudioMusical.TabIndex = 5;
            btnDeletarEstudioMusical.Text = "Deletar";
            btnDeletarEstudioMusical.UseVisualStyleBackColor = true;
            btnDeletarEstudioMusical.Click += btnDeletar_Click;
            // 
            // tabAgendamento
            // 
            tabAgendamento.BackColor = Color.White;
            tabAgendamento.Controls.Add(cbAgendamento);
            tabAgendamento.Controls.Add(textBuscarAgendamento);
            tabAgendamento.Controls.Add(btnDeletarAgendamento);
            tabAgendamento.Controls.Add(btnAtualizarAgendamento);
            tabAgendamento.Controls.Add(btnAdicionarAgendamento);
            tabAgendamento.Controls.Add(dataGridAgendamento);
            tabAgendamento.Location = new Point(4, 24);
            tabAgendamento.Name = "tabAgendamento";
            tabAgendamento.Padding = new Padding(3);
            tabAgendamento.Size = new Size(898, 422);
            tabAgendamento.TabIndex = 1;
            tabAgendamento.Text = "Agendamento";
            // 
            // cbAgendamento
            // 
            cbAgendamento.FormattingEnabled = true;
            cbAgendamento.Location = new Point(333, 38);
            cbAgendamento.Name = "cbAgendamento";
            cbAgendamento.Size = new Size(121, 23);
            cbAgendamento.TabIndex = 12;
            // 
            // textBuscarAgendamento
            // 
            textBuscarAgendamento.Location = new Point(8, 38);
            textBuscarAgendamento.Name = "textBuscarAgendamento";
            textBuscarAgendamento.Size = new Size(239, 23);
            textBuscarAgendamento.TabIndex = 10;
            textBuscarAgendamento.Text = "Nome do responsável";
            // 
            // btnDeletarAgendamento
            // 
            btnDeletarAgendamento.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDeletarAgendamento.Location = new Point(814, 391);
            btnDeletarAgendamento.Name = "btnDeletarAgendamento";
            btnDeletarAgendamento.Size = new Size(75, 23);
            btnDeletarAgendamento.TabIndex = 8;
            btnDeletarAgendamento.Text = "Deletar";
            btnDeletarAgendamento.UseVisualStyleBackColor = true;
            btnDeletarAgendamento.Click += btnDeletar_Click;
            // 
            // btnAtualizarAgendamento
            // 
            btnAtualizarAgendamento.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAtualizarAgendamento.Location = new Point(733, 391);
            btnAtualizarAgendamento.Name = "btnAtualizarAgendamento";
            btnAtualizarAgendamento.Size = new Size(75, 23);
            btnAtualizarAgendamento.TabIndex = 7;
            btnAtualizarAgendamento.Text = "Atualizar";
            btnAtualizarAgendamento.UseVisualStyleBackColor = true;
            // 
            // btnAdicionarAgendamento
            // 
            btnAdicionarAgendamento.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAdicionarAgendamento.Location = new Point(652, 391);
            btnAdicionarAgendamento.Name = "btnAdicionarAgendamento";
            btnAdicionarAgendamento.Size = new Size(75, 23);
            btnAdicionarAgendamento.TabIndex = 6;
            btnAdicionarAgendamento.Text = "Adicionar";
            btnAdicionarAgendamento.UseVisualStyleBackColor = true;
            // 
            // dataGridAgendamento
            // 
            dataGridAgendamento.AllowUserToAddRows = false;
            dataGridAgendamento.AllowUserToDeleteRows = false;
            dataGridAgendamento.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridAgendamento.AutoGenerateColumns = false;
            dataGridAgendamento.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridAgendamento.BackgroundColor = SystemColors.Control;
            dataGridAgendamento.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridAgendamento.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridAgendamento.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn1, nomeResponsavelDataGridViewTextBoxColumn, cpfResponsavelDataGridViewTextBoxColumn, dataEHoraDeEntradaDataGridViewTextBoxColumn, dataEHoraDeSaidaDataGridViewTextBoxColumn, valorTotalDataGridViewTextBoxColumn, estiloMusicalDataGridViewTextBoxColumn, idEstudioDataGridViewTextBoxColumn });
            dataGridAgendamento.DataSource = agendamentoBindingSource;
            dataGridAgendamento.GridColor = Color.Black;
            dataGridAgendamento.Location = new Point(6, 86);
            dataGridAgendamento.Name = "dataGridAgendamento";
            dataGridAgendamento.ReadOnly = true;
            dataGridAgendamento.RowHeadersVisible = false;
            dataGridAgendamento.RowTemplate.Height = 25;
            dataGridAgendamento.Size = new Size(886, 199);
            dataGridAgendamento.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn1
            // 
            idDataGridViewTextBoxColumn1.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn1.HeaderText = "Id";
            idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
            idDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // nomeResponsavelDataGridViewTextBoxColumn
            // 
            nomeResponsavelDataGridViewTextBoxColumn.DataPropertyName = "NomeResponsavel";
            nomeResponsavelDataGridViewTextBoxColumn.HeaderText = "NomeResponsavel";
            nomeResponsavelDataGridViewTextBoxColumn.Name = "nomeResponsavelDataGridViewTextBoxColumn";
            nomeResponsavelDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cpfResponsavelDataGridViewTextBoxColumn
            // 
            cpfResponsavelDataGridViewTextBoxColumn.DataPropertyName = "CpfResponsavel";
            cpfResponsavelDataGridViewTextBoxColumn.HeaderText = "CpfResponsavel";
            cpfResponsavelDataGridViewTextBoxColumn.Name = "cpfResponsavelDataGridViewTextBoxColumn";
            cpfResponsavelDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataEHoraDeEntradaDataGridViewTextBoxColumn
            // 
            dataEHoraDeEntradaDataGridViewTextBoxColumn.DataPropertyName = "DataEHoraDeEntrada";
            dataEHoraDeEntradaDataGridViewTextBoxColumn.HeaderText = "DataEHoraDeEntrada";
            dataEHoraDeEntradaDataGridViewTextBoxColumn.Name = "dataEHoraDeEntradaDataGridViewTextBoxColumn";
            dataEHoraDeEntradaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataEHoraDeSaidaDataGridViewTextBoxColumn
            // 
            dataEHoraDeSaidaDataGridViewTextBoxColumn.DataPropertyName = "DataEHoraDeSaida";
            dataEHoraDeSaidaDataGridViewTextBoxColumn.HeaderText = "DataEHoraDeSaida";
            dataEHoraDeSaidaDataGridViewTextBoxColumn.Name = "dataEHoraDeSaidaDataGridViewTextBoxColumn";
            dataEHoraDeSaidaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // valorTotalDataGridViewTextBoxColumn
            // 
            valorTotalDataGridViewTextBoxColumn.DataPropertyName = "ValorTotal";
            valorTotalDataGridViewTextBoxColumn.HeaderText = "ValorTotal";
            valorTotalDataGridViewTextBoxColumn.Name = "valorTotalDataGridViewTextBoxColumn";
            valorTotalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // estiloMusicalDataGridViewTextBoxColumn
            // 
            estiloMusicalDataGridViewTextBoxColumn.DataPropertyName = "EstiloMusical";
            estiloMusicalDataGridViewTextBoxColumn.HeaderText = "EstiloMusical";
            estiloMusicalDataGridViewTextBoxColumn.Name = "estiloMusicalDataGridViewTextBoxColumn";
            estiloMusicalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idEstudioDataGridViewTextBoxColumn
            // 
            idEstudioDataGridViewTextBoxColumn.DataPropertyName = "IdEstudio";
            idEstudioDataGridViewTextBoxColumn.HeaderText = "IdEstudio";
            idEstudioDataGridViewTextBoxColumn.Name = "idEstudioDataGridViewTextBoxColumn";
            idEstudioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // agendamentoBindingSource
            // 
            agendamentoBindingSource.DataSource = typeof(Dominio.Entidades.Agendamento);
            // 
            // bdCod3rsGrowthBindingSource
            // 
            bdCod3rsGrowthBindingSource.DataSource = typeof(Infra.BdCod3rsGrowth);
            // 
            // FormAgendamentoEmEstudioMusical
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(906, 450);
            Controls.Add(tabAgendamentoEmEstudioMusical);
            Name = "FormAgendamentoEmEstudioMusical";
            Text = "Agendamento em Estúdio Musical";
            tabAgendamentoEmEstudioMusical.ResumeLayout(false);
            tabEstudioMusical.ResumeLayout(false);
            tabEstudioMusical.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridEstudioMusical).EndInit();
            ((System.ComponentModel.ISupportInitialize)estudioMusicalBindingSource).EndInit();
            tabAgendamento.ResumeLayout(false);
            tabAgendamento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridAgendamento).EndInit();
            ((System.ComponentModel.ISupportInitialize)agendamentoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)bdCod3rsGrowthBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnAdicionarEstudioMusical;
        private Button btnAtualizarEstudioMusical;
        private TextBox txtNomeEstudio;
        private TabControl tabAgendamentoEmEstudioMusical;
        private TabPage tabEstudioMusical;
        private TabPage tabAgendamento;
        private Button btnDeletarEstudioMusical;
        private DataGridView dataGridEstudioMusical;
        private BindingSource bdCod3rsGrowthBindingSource;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn estaAbertoDataGridViewCheckBoxColumn;
        private BindingSource estudioMusicalBindingSource;
        private DataGridView dataGridAgendamento;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn nomeResponsavelDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cpfResponsavelDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dataEHoraDeEntradaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dataEHoraDeSaidaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn valorTotalDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn estiloMusicalDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idEstudioDataGridViewTextBoxColumn;
        private BindingSource agendamentoBindingSource;
        private Button btnDeletarAgendamento;
        private Button btnAtualizarAgendamento;
        private Button btnAdicionarAgendamento;
        private Label lblEstaAberto;
        private ComboBox cbSelecione;
        private TextBox textBuscarAgendamento;
        private ComboBox cbAgendamento;
    }
}
