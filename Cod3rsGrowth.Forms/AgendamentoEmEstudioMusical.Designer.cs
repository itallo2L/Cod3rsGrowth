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
            txtBuscarEstudio = new TextBox();
            tabAgendamentoEmEstudioMusical = new TabControl();
            tabEstudioMusical = new TabPage();
            checkBoxNaoEstaAberto = new CheckBox();
            checkBoxEstaAbertoSim = new CheckBox();
            lblEstaAberto = new Label();
            dataGridEstudioMusical = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nomeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            estaAbertoDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            estudioMusicalBindingSource = new BindingSource(components);
            btnDeletarEstudioMusical = new Button();
            tabAgendamento = new TabPage();
            numericValorMaximo = new NumericUpDown();
            numericValorMinimo = new NumericUpDown();
            lblFiltrarPorValor = new Label();
            lblValorMaximo = new Label();
            lblValorMinimo = new Label();
            lblFiltrarPorData = new Label();
            lblDataInicial = new Label();
            lblDataFinal = new Label();
            dataFinal = new DateTimePicker();
            dataInicial = new DateTimePicker();
            label1 = new Label();
            cbEstiloMusical = new ComboBox();
            txtBuscarAgendamento = new TextBox();
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
            ((System.ComponentModel.ISupportInitialize)numericValorMaximo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericValorMinimo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridAgendamento).BeginInit();
            ((System.ComponentModel.ISupportInitialize)agendamentoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bdCod3rsGrowthBindingSource).BeginInit();
            SuspendLayout();
            // 
            // btnAdicionarEstudioMusical
            // 
            btnAdicionarEstudioMusical.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAdicionarEstudioMusical.Location = new Point(1007, 391);
            btnAdicionarEstudioMusical.Name = "btnAdicionarEstudioMusical";
            btnAdicionarEstudioMusical.Size = new Size(75, 23);
            btnAdicionarEstudioMusical.TabIndex = 0;
            btnAdicionarEstudioMusical.Text = "Adicionar";
            btnAdicionarEstudioMusical.UseVisualStyleBackColor = true;
            // 
            // btnAtualizarEstudioMusical
            // 
            btnAtualizarEstudioMusical.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAtualizarEstudioMusical.Location = new Point(1088, 391);
            btnAtualizarEstudioMusical.Name = "btnAtualizarEstudioMusical";
            btnAtualizarEstudioMusical.Size = new Size(75, 23);
            btnAtualizarEstudioMusical.TabIndex = 1;
            btnAtualizarEstudioMusical.Text = "Atualizar";
            btnAtualizarEstudioMusical.UseVisualStyleBackColor = true;
            // 
            // txtBuscarEstudio
            // 
            txtBuscarEstudio.AcceptsReturn = true;
            txtBuscarEstudio.Location = new Point(8, 42);
            txtBuscarEstudio.Name = "txtBuscarEstudio";
            txtBuscarEstudio.PlaceholderText = "Digite o nome do estúdio";
            txtBuscarEstudio.Size = new Size(213, 23);
            txtBuscarEstudio.TabIndex = 3;
            txtBuscarEstudio.TextChanged += EventoDeFiltroAoBuscarEstudioMusical;
            // 
            // tabAgendamentoEmEstudioMusical
            // 
            tabAgendamentoEmEstudioMusical.Controls.Add(tabEstudioMusical);
            tabAgendamentoEmEstudioMusical.Controls.Add(tabAgendamento);
            tabAgendamentoEmEstudioMusical.Dock = DockStyle.Fill;
            tabAgendamentoEmEstudioMusical.Location = new Point(0, 0);
            tabAgendamentoEmEstudioMusical.Name = "tabAgendamentoEmEstudioMusical";
            tabAgendamentoEmEstudioMusical.SelectedIndex = 0;
            tabAgendamentoEmEstudioMusical.Size = new Size(1262, 450);
            tabAgendamentoEmEstudioMusical.TabIndex = 5;
            // 
            // tabEstudioMusical
            // 
            tabEstudioMusical.Controls.Add(checkBoxNaoEstaAberto);
            tabEstudioMusical.Controls.Add(checkBoxEstaAbertoSim);
            tabEstudioMusical.Controls.Add(lblEstaAberto);
            tabEstudioMusical.Controls.Add(dataGridEstudioMusical);
            tabEstudioMusical.Controls.Add(btnDeletarEstudioMusical);
            tabEstudioMusical.Controls.Add(txtBuscarEstudio);
            tabEstudioMusical.Controls.Add(btnAtualizarEstudioMusical);
            tabEstudioMusical.Controls.Add(btnAdicionarEstudioMusical);
            tabEstudioMusical.Location = new Point(4, 24);
            tabEstudioMusical.Name = "tabEstudioMusical";
            tabEstudioMusical.Padding = new Padding(3);
            tabEstudioMusical.Size = new Size(1254, 422);
            tabEstudioMusical.TabIndex = 0;
            tabEstudioMusical.Text = "Estúdio Musical";
            tabEstudioMusical.UseVisualStyleBackColor = true;
            // 
            // checkBoxNaoEstaAberto
            // 
            checkBoxNaoEstaAberto.AutoSize = true;
            checkBoxNaoEstaAberto.Location = new Point(338, 46);
            checkBoxNaoEstaAberto.Name = "checkBoxNaoEstaAberto";
            checkBoxNaoEstaAberto.Size = new Size(48, 19);
            checkBoxNaoEstaAberto.TabIndex = 12;
            checkBoxNaoEstaAberto.Text = "Não";
            checkBoxNaoEstaAberto.UseVisualStyleBackColor = true;
            checkBoxNaoEstaAberto.CheckedChanged += EventoDeCheckBoxEstaAbertoAoSelecionarNao;
            // 
            // checkBoxEstaAbertoSim
            // 
            checkBoxEstaAbertoSim.AutoSize = true;
            checkBoxEstaAbertoSim.Location = new Point(295, 46);
            checkBoxEstaAbertoSim.Name = "checkBoxEstaAbertoSim";
            checkBoxEstaAbertoSim.Size = new Size(46, 19);
            checkBoxEstaAbertoSim.TabIndex = 11;
            checkBoxEstaAbertoSim.Text = "Sim";
            checkBoxEstaAbertoSim.UseVisualStyleBackColor = true;
            checkBoxEstaAbertoSim.CheckedChanged += EventoDeCheckBoxEstaAbertoAoSelecionarSim;
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
            dataGridEstudioMusical.Location = new Point(9, 118);
            dataGridEstudioMusical.Name = "dataGridEstudioMusical";
            dataGridEstudioMusical.ReadOnly = true;
            dataGridEstudioMusical.RowHeadersVisible = false;
            dataGridEstudioMusical.RowTemplate.Height = 25;
            dataGridEstudioMusical.Size = new Size(1237, 199);
            dataGridEstudioMusical.TabIndex = 6;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "ID";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            idDataGridViewTextBoxColumn.Visible = false;
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
            estaAbertoDataGridViewCheckBoxColumn.HeaderText = "Está Aberto?";
            estaAbertoDataGridViewCheckBoxColumn.Name = "estaAbertoDataGridViewCheckBoxColumn";
            estaAbertoDataGridViewCheckBoxColumn.ReadOnly = true;
            estaAbertoDataGridViewCheckBoxColumn.Resizable = DataGridViewTriState.True;
            // 
            // estudioMusicalBindingSource
            // 
            estudioMusicalBindingSource.DataSource = typeof(Dominio.Entidades.EstudioMusical);
            // 
            // btnDeletarEstudioMusical
            // 
            btnDeletarEstudioMusical.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDeletarEstudioMusical.Location = new Point(1169, 391);
            btnDeletarEstudioMusical.Name = "btnDeletarEstudioMusical";
            btnDeletarEstudioMusical.Size = new Size(75, 23);
            btnDeletarEstudioMusical.TabIndex = 5;
            btnDeletarEstudioMusical.Text = "Deletar";
            btnDeletarEstudioMusical.UseVisualStyleBackColor = true;
            // 
            // tabAgendamento
            // 
            tabAgendamento.BackColor = Color.White;
            tabAgendamento.Controls.Add(numericValorMaximo);
            tabAgendamento.Controls.Add(numericValorMinimo);
            tabAgendamento.Controls.Add(lblFiltrarPorValor);
            tabAgendamento.Controls.Add(lblValorMaximo);
            tabAgendamento.Controls.Add(lblValorMinimo);
            tabAgendamento.Controls.Add(lblFiltrarPorData);
            tabAgendamento.Controls.Add(lblDataInicial);
            tabAgendamento.Controls.Add(lblDataFinal);
            tabAgendamento.Controls.Add(dataFinal);
            tabAgendamento.Controls.Add(dataInicial);
            tabAgendamento.Controls.Add(label1);
            tabAgendamento.Controls.Add(cbEstiloMusical);
            tabAgendamento.Controls.Add(txtBuscarAgendamento);
            tabAgendamento.Controls.Add(btnDeletarAgendamento);
            tabAgendamento.Controls.Add(btnAtualizarAgendamento);
            tabAgendamento.Controls.Add(btnAdicionarAgendamento);
            tabAgendamento.Controls.Add(dataGridAgendamento);
            tabAgendamento.Location = new Point(4, 24);
            tabAgendamento.Name = "tabAgendamento";
            tabAgendamento.Padding = new Padding(3);
            tabAgendamento.Size = new Size(1254, 422);
            tabAgendamento.TabIndex = 1;
            tabAgendamento.Text = "Agendamento";
            // 
            // numericValorMaximo
            // 
            numericValorMaximo.Location = new Point(788, 99);
            numericValorMaximo.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericValorMaximo.Name = "numericValorMaximo";
            numericValorMaximo.Size = new Size(81, 23);
            numericValorMaximo.TabIndex = 27;
            numericValorMaximo.ValueChanged += EventoDaCaixaNumericaValorMaximo;
            // 
            // numericValorMinimo
            // 
            numericValorMinimo.Location = new Point(788, 52);
            numericValorMinimo.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericValorMinimo.Name = "numericValorMinimo";
            numericValorMinimo.Size = new Size(81, 23);
            numericValorMinimo.TabIndex = 26;
            numericValorMinimo.ValueChanged += EventoDaCaixaNumericaValorMinimo;
            // 
            // lblFiltrarPorValor
            // 
            lblFiltrarPorValor.AutoSize = true;
            lblFiltrarPorValor.Location = new Point(783, 18);
            lblFiltrarPorValor.Name = "lblFiltrarPorValor";
            lblFiltrarPorValor.Size = new Size(90, 15);
            lblFiltrarPorValor.TabIndex = 25;
            lblFiltrarPorValor.Text = "Filtrar por Valor:";
            // 
            // lblValorMaximo
            // 
            lblValorMaximo.AutoSize = true;
            lblValorMaximo.Location = new Point(788, 81);
            lblValorMaximo.Name = "lblValorMaximo";
            lblValorMaximo.Size = new Size(83, 15);
            lblValorMaximo.TabIndex = 23;
            lblValorMaximo.Text = "Valor Máximo:";
            // 
            // lblValorMinimo
            // 
            lblValorMinimo.AutoSize = true;
            lblValorMinimo.Location = new Point(788, 34);
            lblValorMinimo.Name = "lblValorMinimo";
            lblValorMinimo.Size = new Size(81, 15);
            lblValorMinimo.TabIndex = 22;
            lblValorMinimo.Text = "Valor Mínimo:";
            // 
            // lblFiltrarPorData
            // 
            lblFiltrarPorData.AutoSize = true;
            lblFiltrarPorData.Location = new Point(547, 18);
            lblFiltrarPorData.Name = "lblFiltrarPorData";
            lblFiltrarPorData.Size = new Size(88, 15);
            lblFiltrarPorData.TabIndex = 20;
            lblFiltrarPorData.Text = "Filtrar por Data:";
            // 
            // lblDataInicial
            // 
            lblDataInicial.AutoSize = true;
            lblDataInicial.Location = new Point(473, 34);
            lblDataInicial.Name = "lblDataInicial";
            lblDataInicial.Size = new Size(68, 15);
            lblDataInicial.TabIndex = 19;
            lblDataInicial.Text = "Data Inicial:";
            // 
            // lblDataFinal
            // 
            lblDataFinal.AutoSize = true;
            lblDataFinal.Location = new Point(473, 81);
            lblDataFinal.Name = "lblDataFinal";
            lblDataFinal.Size = new Size(62, 15);
            lblDataFinal.TabIndex = 18;
            lblDataFinal.Text = "Data Final:";
            // 
            // dataFinal
            // 
            dataFinal.Location = new Point(474, 99);
            dataFinal.Name = "dataFinal";
            dataFinal.Size = new Size(245, 23);
            dataFinal.TabIndex = 17;
            // 
            // dataInicial
            // 
            dataInicial.Location = new Point(473, 52);
            dataInicial.Name = "dataInicial";
            dataInicial.Size = new Size(246, 23);
            dataInicial.TabIndex = 16;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(986, 34);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
            label1.TabIndex = 14;
            label1.Text = "Estilo Musical";
            // 
            // cbEstiloMusical
            // 
            cbEstiloMusical.FormattingEnabled = true;
            cbEstiloMusical.Items.AddRange(new object[] { "Todos", "Blues", "Jazz", "Música Clássica", "Sertanejo", "Gospel", "Eletrônica", "Samba" });
            cbEstiloMusical.Location = new Point(962, 52);
            cbEstiloMusical.Name = "cbEstiloMusical";
            cbEstiloMusical.Size = new Size(121, 23);
            cbEstiloMusical.TabIndex = 12;
            cbEstiloMusical.SelectedIndexChanged += EventoDaComboBoxAoFiltrarPeloEstiloMusical;
            // 
            // txtBuscarAgendamento
            // 
            txtBuscarAgendamento.Location = new Point(6, 52);
            txtBuscarAgendamento.Name = "txtBuscarAgendamento";
            txtBuscarAgendamento.PlaceholderText = "Digite o nome do responsável";
            txtBuscarAgendamento.Size = new Size(239, 23);
            txtBuscarAgendamento.TabIndex = 10;
            txtBuscarAgendamento.TextChanged += EventoDeFiltroAoBuscarAgendamento;
            // 
            // btnDeletarAgendamento
            // 
            btnDeletarAgendamento.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDeletarAgendamento.Location = new Point(1170, 391);
            btnDeletarAgendamento.Name = "btnDeletarAgendamento";
            btnDeletarAgendamento.Size = new Size(75, 23);
            btnDeletarAgendamento.TabIndex = 8;
            btnDeletarAgendamento.Text = "Deletar";
            btnDeletarAgendamento.UseVisualStyleBackColor = true;
            // 
            // btnAtualizarAgendamento
            // 
            btnAtualizarAgendamento.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAtualizarAgendamento.Location = new Point(1089, 391);
            btnAtualizarAgendamento.Name = "btnAtualizarAgendamento";
            btnAtualizarAgendamento.Size = new Size(75, 23);
            btnAtualizarAgendamento.TabIndex = 7;
            btnAtualizarAgendamento.Text = "Atualizar";
            btnAtualizarAgendamento.UseVisualStyleBackColor = true;
            // 
            // btnAdicionarAgendamento
            // 
            btnAdicionarAgendamento.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAdicionarAgendamento.Location = new Point(1008, 391);
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
            dataGridAgendamento.AllowUserToResizeColumns = false;
            dataGridAgendamento.AllowUserToResizeRows = false;
            dataGridAgendamento.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridAgendamento.AutoGenerateColumns = false;
            dataGridAgendamento.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridAgendamento.BackgroundColor = SystemColors.Control;
            dataGridAgendamento.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridAgendamento.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridAgendamento.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn1, nomeResponsavelDataGridViewTextBoxColumn, cpfResponsavelDataGridViewTextBoxColumn, dataEHoraDeEntradaDataGridViewTextBoxColumn, dataEHoraDeSaidaDataGridViewTextBoxColumn, valorTotalDataGridViewTextBoxColumn, estiloMusicalDataGridViewTextBoxColumn, idEstudioDataGridViewTextBoxColumn });
            dataGridAgendamento.DataSource = agendamentoBindingSource;
            dataGridAgendamento.GridColor = Color.Black;
            dataGridAgendamento.Location = new Point(6, 128);
            dataGridAgendamento.Name = "dataGridAgendamento";
            dataGridAgendamento.ReadOnly = true;
            dataGridAgendamento.RowHeadersVisible = false;
            dataGridAgendamento.RowTemplate.Height = 25;
            dataGridAgendamento.Size = new Size(1242, 199);
            dataGridAgendamento.TabIndex = 0;
            dataGridAgendamento.CellFormatting += EventoDeFormatacaoDoDataGridAgendamento;
            // 
            // idDataGridViewTextBoxColumn1
            // 
            idDataGridViewTextBoxColumn1.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn1.HeaderText = "ID";
            idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
            idDataGridViewTextBoxColumn1.ReadOnly = true;
            idDataGridViewTextBoxColumn1.Visible = false;
            // 
            // nomeResponsavelDataGridViewTextBoxColumn
            // 
            nomeResponsavelDataGridViewTextBoxColumn.DataPropertyName = "NomeResponsavel";
            nomeResponsavelDataGridViewTextBoxColumn.HeaderText = "Nome do Responsável";
            nomeResponsavelDataGridViewTextBoxColumn.Name = "nomeResponsavelDataGridViewTextBoxColumn";
            nomeResponsavelDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cpfResponsavelDataGridViewTextBoxColumn
            // 
            cpfResponsavelDataGridViewTextBoxColumn.DataPropertyName = "CpfResponsavel";
            cpfResponsavelDataGridViewTextBoxColumn.HeaderText = "CPF do Responsável";
            cpfResponsavelDataGridViewTextBoxColumn.Name = "cpfResponsavelDataGridViewTextBoxColumn";
            cpfResponsavelDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataEHoraDeEntradaDataGridViewTextBoxColumn
            // 
            dataEHoraDeEntradaDataGridViewTextBoxColumn.DataPropertyName = "DataEHoraDeEntrada";
            dataEHoraDeEntradaDataGridViewTextBoxColumn.HeaderText = "Data e Hora de Entrada";
            dataEHoraDeEntradaDataGridViewTextBoxColumn.Name = "dataEHoraDeEntradaDataGridViewTextBoxColumn";
            dataEHoraDeEntradaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataEHoraDeSaidaDataGridViewTextBoxColumn
            // 
            dataEHoraDeSaidaDataGridViewTextBoxColumn.DataPropertyName = "DataEHoraDeSaida";
            dataEHoraDeSaidaDataGridViewTextBoxColumn.HeaderText = "Data e Hora de Saída";
            dataEHoraDeSaidaDataGridViewTextBoxColumn.Name = "dataEHoraDeSaidaDataGridViewTextBoxColumn";
            dataEHoraDeSaidaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // valorTotalDataGridViewTextBoxColumn
            // 
            valorTotalDataGridViewTextBoxColumn.DataPropertyName = "ValorTotal";
            valorTotalDataGridViewTextBoxColumn.HeaderText = "Valor Total";
            valorTotalDataGridViewTextBoxColumn.Name = "valorTotalDataGridViewTextBoxColumn";
            valorTotalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // estiloMusicalDataGridViewTextBoxColumn
            // 
            estiloMusicalDataGridViewTextBoxColumn.DataPropertyName = "EstiloMusical";
            estiloMusicalDataGridViewTextBoxColumn.HeaderText = "Estilo Musical";
            estiloMusicalDataGridViewTextBoxColumn.Name = "estiloMusicalDataGridViewTextBoxColumn";
            estiloMusicalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idEstudioDataGridViewTextBoxColumn
            // 
            idEstudioDataGridViewTextBoxColumn.DataPropertyName = "IdEstudio";
            idEstudioDataGridViewTextBoxColumn.HeaderText = "Estúdio";
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
            ClientSize = new Size(1262, 450);
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
            ((System.ComponentModel.ISupportInitialize)numericValorMaximo).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericValorMinimo).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridAgendamento).EndInit();
            ((System.ComponentModel.ISupportInitialize)agendamentoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)bdCod3rsGrowthBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnAdicionarEstudioMusical;
        private Button btnAtualizarEstudioMusical;
        private TextBox txtBuscarEstudio;
        private TabControl tabAgendamentoEmEstudioMusical;
        private TabPage tabEstudioMusical;
        private TabPage tabAgendamento;
        private Button btnDeletarEstudioMusical;
        private DataGridView dataGridEstudioMusical;
        private BindingSource bdCod3rsGrowthBindingSource;
        private BindingSource estudioMusicalBindingSource;
        private DataGridView dataGridAgendamento;
        private BindingSource agendamentoBindingSource;
        private Button btnDeletarAgendamento;
        private Button btnAtualizarAgendamento;
        private Button btnAdicionarAgendamento;
        private Label lblEstaAberto;
        private TextBox txtBuscarAgendamento;
        private ComboBox cbEstiloMusical;
        private Label label1;
        private Label lblFiltrarPorData;
        private Label lblDataInicial;
        private Label lblDataFinal;
        private DateTimePicker dataFinal;
        private DateTimePicker dataInicial;
        private Label lblValorMaximo;
        private Label lblValorMinimo;
        private Label lblFiltrarPorValor;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn nomeResponsavelDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cpfResponsavelDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dataEHoraDeEntradaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dataEHoraDeSaidaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn valorTotalDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn estiloMusicalDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idEstudioDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn estaAbertoDataGridViewCheckBoxColumn;
        private CheckBox checkBoxEstaAbertoSim;
        private CheckBox checkBoxNaoEstaAberto;
        private NumericUpDown numericValorMaximo;
        private NumericUpDown numericValorMinimo;
    }
}
