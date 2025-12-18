namespace Medidor_de_Temperatura
{
    partial class FormularioPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormularioPrincipal));
            pnlSuperior = new Panel();
            pnlLiscomp = new Panel();
            picLiscomp = new PictureBox();
            pnlNomeProjeto = new Panel();
            lblTitulo = new Label();
            lblSubtitulo = new Label();
            picImageLogo = new PictureBox();
            pnlGrafico = new Panel();
            pltvSpectra = new OxyPlot.WindowsForms.PlotView();
            pnlGraficoExterno = new Panel();
            grpControles = new GroupBox();
            lblIniciarAquisicao = new Label();
            btnIniciarAquisicao = new Button();
            btnExibirFormularioDoGraficoComFuncoes = new Button();
            lblGraficoComEquacao = new Label();
            lblNomeDoArquivo = new Label();
            btnDefinirNomeDoArquivo = new Button();
            btnFinalizarComunicacao = new Button();
            btnDefinirDiretorioDoArquivo = new Button();
            lblFinalizeAcquisition = new Label();
            txtDiretorioDefinidoDoArquivo = new TextBox();
            lblDefinirDiretorioDoArquivo = new Label();
            txtNomeDoArquivo = new TextBox();
            btnSelecionarPorta = new Button();
            cmbPortasSeriais = new ComboBox();
            lblSelecionarPortaSerial = new Label();
            lblDesenvolvedores = new Label();
            pnlControles = new Panel();
            stsDesenvolvedores = new StatusStrip();
            tslblDesenvolvedores = new ToolStripStatusLabel();
            tslblVazio = new ToolStripStatusLabel();
            tslblSalvarGrafico = new ToolStripStatusLabel();
            tmpTempo = new System.Windows.Forms.Timer(components);
            timer1 = new System.Windows.Forms.Timer(components);
            pnlSuperior.SuspendLayout();
            pnlLiscomp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLiscomp).BeginInit();
            pnlNomeProjeto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picImageLogo).BeginInit();
            pnlGrafico.SuspendLayout();
            pnlGraficoExterno.SuspendLayout();
            grpControles.SuspendLayout();
            pnlControles.SuspendLayout();
            stsDesenvolvedores.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSuperior
            // 
            pnlSuperior.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlSuperior.BackColor = SystemColors.Control;
            pnlSuperior.Controls.Add(pnlLiscomp);
            pnlSuperior.Controls.Add(pnlNomeProjeto);
            pnlSuperior.Controls.Add(picImageLogo);
            pnlSuperior.Location = new Point(0, 0);
            pnlSuperior.Name = "pnlSuperior";
            pnlSuperior.Size = new Size(1176, 98);
            pnlSuperior.TabIndex = 2;
            // 
            // pnlLiscomp
            // 
            pnlLiscomp.Anchor = AnchorStyles.Right;
            pnlLiscomp.Controls.Add(picLiscomp);
            pnlLiscomp.Location = new Point(937, 12);
            pnlLiscomp.Name = "pnlLiscomp";
            pnlLiscomp.Size = new Size(222, 71);
            pnlLiscomp.TabIndex = 5;
            // 
            // picLiscomp
            // 
            picLiscomp.BackgroundImage = (Image)resources.GetObject("picLiscomp.BackgroundImage");
            picLiscomp.BackgroundImageLayout = ImageLayout.Stretch;
            picLiscomp.Location = new Point(13, 10);
            picLiscomp.Name = "picLiscomp";
            picLiscomp.Size = new Size(199, 50);
            picLiscomp.TabIndex = 3;
            picLiscomp.TabStop = false;
            // 
            // pnlNomeProjeto
            // 
            pnlNomeProjeto.Anchor = AnchorStyles.None;
            pnlNomeProjeto.Controls.Add(lblTitulo);
            pnlNomeProjeto.Controls.Add(lblSubtitulo);
            pnlNomeProjeto.Location = new Point(246, 7);
            pnlNomeProjeto.Name = "pnlNomeProjeto";
            pnlNomeProjeto.Size = new Size(685, 87);
            pnlNomeProjeto.TabIndex = 4;
            // 
            // lblTitulo
            // 
            lblTitulo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitulo.Location = new Point(104, 19);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(512, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Laboratório de Instrumentação e Simulação Computacional";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lblSubtitulo.Location = new Point(207, 44);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(312, 25);
            lblSubtitulo.TabIndex = 2;
            lblSubtitulo.Text = "Medidor de Temperatura - Arduino ";
            // 
            // picImageLogo
            // 
            picImageLogo.Anchor = AnchorStyles.Left;
            picImageLogo.BackColor = SystemColors.Control;
            picImageLogo.Image = (Image)resources.GetObject("picImageLogo.Image");
            picImageLogo.InitialImage = (Image)resources.GetObject("picImageLogo.InitialImage");
            picImageLogo.Location = new Point(24, 8);
            picImageLogo.Name = "picImageLogo";
            picImageLogo.Size = new Size(193, 86);
            picImageLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            picImageLogo.TabIndex = 1;
            picImageLogo.TabStop = false;
            // 
            // pnlGrafico
            // 
            pnlGrafico.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlGrafico.BackColor = Color.White;
            pnlGrafico.Controls.Add(pltvSpectra);
            pnlGrafico.Location = new Point(17, 16);
            pnlGrafico.Name = "pnlGrafico";
            pnlGrafico.Size = new Size(822, 545);
            pnlGrafico.TabIndex = 4;
            // 
            // pltvSpectra
            // 
            pltvSpectra.Dock = DockStyle.Fill;
            pltvSpectra.Location = new Point(0, 0);
            pltvSpectra.Name = "pltvSpectra";
            pltvSpectra.PanCursor = Cursors.Hand;
            pltvSpectra.Size = new Size(822, 545);
            pltvSpectra.TabIndex = 0;
            pltvSpectra.Text = "pltvSpectra";
            pltvSpectra.ZoomHorizontalCursor = Cursors.SizeWE;
            pltvSpectra.ZoomRectangleCursor = Cursors.SizeNWSE;
            pltvSpectra.ZoomVerticalCursor = Cursors.SizeNS;
            pltvSpectra.Click += pltvSpectra_Click;
            // 
            // pnlGraficoExterno
            // 
            pnlGraficoExterno.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlGraficoExterno.Controls.Add(pnlGrafico);
            pnlGraficoExterno.Location = new Point(320, 113);
            pnlGraficoExterno.Name = "pnlGraficoExterno";
            pnlGraficoExterno.Size = new Size(856, 576);
            pnlGraficoExterno.TabIndex = 5;
            // 
            // grpControles
            // 
            grpControles.Controls.Add(lblIniciarAquisicao);
            grpControles.Controls.Add(btnIniciarAquisicao);
            grpControles.Controls.Add(btnExibirFormularioDoGraficoComFuncoes);
            grpControles.Controls.Add(lblGraficoComEquacao);
            grpControles.Controls.Add(lblNomeDoArquivo);
            grpControles.Controls.Add(btnDefinirNomeDoArquivo);
            grpControles.Controls.Add(btnFinalizarComunicacao);
            grpControles.Controls.Add(btnDefinirDiretorioDoArquivo);
            grpControles.Controls.Add(lblFinalizeAcquisition);
            grpControles.Controls.Add(txtDiretorioDefinidoDoArquivo);
            grpControles.Controls.Add(lblDefinirDiretorioDoArquivo);
            grpControles.Controls.Add(txtNomeDoArquivo);
            grpControles.Controls.Add(btnSelecionarPorta);
            grpControles.Controls.Add(cmbPortasSeriais);
            grpControles.Controls.Add(lblSelecionarPortaSerial);
            grpControles.Location = new Point(12, 16);
            grpControles.Name = "grpControles";
            grpControles.Size = new Size(291, 554);
            grpControles.TabIndex = 4;
            grpControles.TabStop = false;
            grpControles.Text = "Controles";
            // 
            // lblIniciarAquisicao
            // 
            lblIniciarAquisicao.AutoSize = true;
            lblIniciarAquisicao.Location = new Point(96, 338);
            lblIniciarAquisicao.Name = "lblIniciarAquisicao";
            lblIniciarAquisicao.Size = new Size(92, 15);
            lblIniciarAquisicao.TabIndex = 11;
            lblIniciarAquisicao.Text = "Iniciar aquisição";
            // 
            // btnIniciarAquisicao
            // 
            btnIniciarAquisicao.Location = new Point(12, 355);
            btnIniciarAquisicao.Name = "btnIniciarAquisicao";
            btnIniciarAquisicao.Size = new Size(261, 23);
            btnIniciarAquisicao.TabIndex = 12;
            btnIniciarAquisicao.Text = "Iniciar";
            btnIniciarAquisicao.UseVisualStyleBackColor = true;
            btnIniciarAquisicao.Click += BtnIniciarAquisicao_Click;
            // 
            // btnExibirFormularioDoGraficoComFuncoes
            // 
            btnExibirFormularioDoGraficoComFuncoes.Location = new Point(12, 475);
            btnExibirFormularioDoGraficoComFuncoes.Name = "btnExibirFormularioDoGraficoComFuncoes";
            btnExibirFormularioDoGraficoComFuncoes.Size = new Size(261, 23);
            btnExibirFormularioDoGraficoComFuncoes.TabIndex = 16;
            btnExibirFormularioDoGraficoComFuncoes.Text = "Exibir";
            btnExibirFormularioDoGraficoComFuncoes.UseVisualStyleBackColor = true;
            btnExibirFormularioDoGraficoComFuncoes.Click += BtnExibirFormularioDoGraficoComFuncoes_Click;
            // 
            // lblGraficoComEquacao
            // 
            lblGraficoComEquacao.AutoSize = true;
            lblGraficoComEquacao.Location = new Point(59, 457);
            lblGraficoComEquacao.Name = "lblGraficoComEquacao";
            lblGraficoComEquacao.Size = new Size(167, 15);
            lblGraficoComEquacao.TabIndex = 15;
            lblGraficoComEquacao.Text = "Gráfico com equação aplicada";
            // 
            // lblNomeDoArquivo
            // 
            lblNomeDoArquivo.AutoSize = true;
            lblNomeDoArquivo.Location = new Point(91, 246);
            lblNomeDoArquivo.Name = "lblNomeDoArquivo";
            lblNomeDoArquivo.Size = new Size(102, 15);
            lblNomeDoArquivo.TabIndex = 6;
            lblNomeDoArquivo.Text = "Nome do Arquivo";
            lblNomeDoArquivo.Click += lblNomeDoArquivo_Click;
            // 
            // btnDefinirNomeDoArquivo
            // 
            btnDefinirNomeDoArquivo.Location = new Point(12, 294);
            btnDefinirNomeDoArquivo.Name = "btnDefinirNomeDoArquivo";
            btnDefinirNomeDoArquivo.Size = new Size(261, 23);
            btnDefinirNomeDoArquivo.TabIndex = 4;
            btnDefinirNomeDoArquivo.Text = "Enviar";
            btnDefinirNomeDoArquivo.UseVisualStyleBackColor = true;
            btnDefinirNomeDoArquivo.Click += BtnDefinirNomeDoArquivo_Click;
            // 
            // btnFinalizarComunicacao
            // 
            btnFinalizarComunicacao.Location = new Point(12, 412);
            btnFinalizarComunicacao.Name = "btnFinalizarComunicacao";
            btnFinalizarComunicacao.Size = new Size(261, 23);
            btnFinalizarComunicacao.TabIndex = 14;
            btnFinalizarComunicacao.Text = "Finalizar";
            btnFinalizarComunicacao.UseVisualStyleBackColor = true;
            btnFinalizarComunicacao.Click += BtnFinalizarComunicacao_Click;
            // 
            // btnDefinirDiretorioDoArquivo
            // 
            btnDefinirDiretorioDoArquivo.Location = new Point(12, 205);
            btnDefinirDiretorioDoArquivo.Name = "btnDefinirDiretorioDoArquivo";
            btnDefinirDiretorioDoArquivo.Size = new Size(261, 23);
            btnDefinirDiretorioDoArquivo.TabIndex = 10;
            btnDefinirDiretorioDoArquivo.Text = "Definir";
            btnDefinirDiretorioDoArquivo.UseVisualStyleBackColor = true;
            btnDefinirDiretorioDoArquivo.Click += BtnDefinirDiretorioDoArquivo_Click;
            // 
            // lblFinalizeAcquisition
            // 
            lblFinalizeAcquisition.AutoSize = true;
            lblFinalizeAcquisition.Location = new Point(91, 395);
            lblFinalizeAcquisition.Name = "lblFinalizeAcquisition";
            lblFinalizeAcquisition.Size = new Size(103, 15);
            lblFinalizeAcquisition.TabIndex = 13;
            lblFinalizeAcquisition.Text = "Finalizar aquisição";
            // 
            // txtDiretorioDefinidoDoArquivo
            // 
            txtDiretorioDefinidoDoArquivo.Location = new Point(13, 176);
            txtDiretorioDefinidoDoArquivo.Name = "txtDiretorioDefinidoDoArquivo";
            txtDiretorioDefinidoDoArquivo.Size = new Size(260, 23);
            txtDiretorioDefinidoDoArquivo.TabIndex = 9;
            // 
            // lblDefinirDiretorioDoArquivo
            // 
            lblDefinirDiretorioDoArquivo.AutoSize = true;
            lblDefinirDiretorioDoArquivo.Location = new Point(63, 158);
            lblDefinirDiretorioDoArquivo.Name = "lblDefinirDiretorioDoArquivo";
            lblDefinirDiretorioDoArquivo.Size = new Size(159, 15);
            lblDefinirDiretorioDoArquivo.TabIndex = 8;
            lblDefinirDiretorioDoArquivo.Text = "Definir diretório da aquisição";
            // 
            // txtNomeDoArquivo
            // 
            txtNomeDoArquivo.Location = new Point(12, 264);
            txtNomeDoArquivo.Name = "txtNomeDoArquivo";
            txtNomeDoArquivo.Size = new Size(260, 23);
            txtNomeDoArquivo.TabIndex = 7;
            // 
            // btnSelecionarPorta
            // 
            btnSelecionarPorta.Location = new Point(12, 110);
            btnSelecionarPorta.Name = "btnSelecionarPorta";
            btnSelecionarPorta.Size = new Size(260, 23);
            btnSelecionarPorta.TabIndex = 4;
            btnSelecionarPorta.Text = "Conectar";
            btnSelecionarPorta.UseVisualStyleBackColor = true;
            btnSelecionarPorta.Click += BtnSelecionarPorta_Click;
            // 
            // cmbPortasSeriais
            // 
            cmbPortasSeriais.FormattingEnabled = true;
            cmbPortasSeriais.Location = new Point(12, 81);
            cmbPortasSeriais.Name = "cmbPortasSeriais";
            cmbPortasSeriais.Size = new Size(260, 23);
            cmbPortasSeriais.TabIndex = 5;
            // 
            // lblSelecionarPortaSerial
            // 
            lblSelecionarPortaSerial.AutoSize = true;
            lblSelecionarPortaSerial.Location = new Point(48, 60);
            lblSelecionarPortaSerial.Name = "lblSelecionarPortaSerial";
            lblSelecionarPortaSerial.Size = new Size(188, 15);
            lblSelecionarPortaSerial.TabIndex = 4;
            lblSelecionarPortaSerial.Text = "Selecione a porta de comunicação";
            // 
            // lblDesenvolvedores
            // 
            lblDesenvolvedores.AutoSize = true;
            lblDesenvolvedores.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblDesenvolvedores.Location = new Point(50, 555);
            lblDesenvolvedores.Name = "lblDesenvolvedores";
            lblDesenvolvedores.Size = new Size(0, 15);
            lblDesenvolvedores.TabIndex = 5;
            // 
            // pnlControles
            // 
            pnlControles.Controls.Add(lblDesenvolvedores);
            pnlControles.Controls.Add(grpControles);
            pnlControles.Location = new Point(0, 113);
            pnlControles.Name = "pnlControles";
            pnlControles.Size = new Size(317, 656);
            pnlControles.TabIndex = 3;
            // 
            // stsDesenvolvedores
            // 
            stsDesenvolvedores.Items.AddRange(new ToolStripItem[] { tslblDesenvolvedores, tslblVazio, tslblSalvarGrafico });
            stsDesenvolvedores.Location = new Point(0, 695);
            stsDesenvolvedores.Name = "stsDesenvolvedores";
            stsDesenvolvedores.Size = new Size(1176, 22);
            stsDesenvolvedores.TabIndex = 6;
            stsDesenvolvedores.Text = "statusStrip1";
            // 
            // tslblDesenvolvedores
            // 
            tslblDesenvolvedores.Margin = new Padding(10, 3, 0, 2);
            tslblDesenvolvedores.Name = "tslblDesenvolvedores";
            tslblDesenvolvedores.Size = new Size(353, 17);
            tslblDesenvolvedores.Text = "Desenvolvido por: Matheus Oliveira, Lucas Cotta e André Pimenta";
            // 
            // tslblVazio
            // 
            tslblVazio.Name = "tslblVazio";
            tslblVazio.Size = new Size(710, 17);
            tslblVazio.Spring = true;
            // 
            // tslblSalvarGrafico
            // 
            tslblSalvarGrafico.Margin = new Padding(10, 3, 0, 2);
            tslblSalvarGrafico.Name = "tslblSalvarGrafico";
            tslblSalvarGrafico.Size = new Size(78, 17);
            tslblSalvarGrafico.Text = "Salvar gráfico";
            tslblSalvarGrafico.Click += TslblSalvarGrafico_Click;
            // 
            // tmpTempo
            // 
            tmpTempo.Tick += TmpTempo_Tick;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // FormularioPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1176, 717);
            Controls.Add(stsDesenvolvedores);
            Controls.Add(pnlGraficoExterno);
            Controls.Add(pnlControles);
            Controls.Add(pnlSuperior);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1192, 756);
            Name = "FormularioPrincipal";
            Text = "Medidor de Temperatura";
            FormClosed += FormularioPrincipal_FormClosed;
            pnlSuperior.ResumeLayout(false);
            pnlLiscomp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLiscomp).EndInit();
            pnlNomeProjeto.ResumeLayout(false);
            pnlNomeProjeto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picImageLogo).EndInit();
            pnlGrafico.ResumeLayout(false);
            pnlGraficoExterno.ResumeLayout(false);
            grpControles.ResumeLayout(false);
            grpControles.PerformLayout();
            pnlControles.ResumeLayout(false);
            pnlControles.PerformLayout();
            stsDesenvolvedores.ResumeLayout(false);
            stsDesenvolvedores.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel pnlSuperior;
        private Label lblTitulo;
        private PictureBox picImageLogo;
        private Label lblSubtitulo;
        private Panel pnlGrafico;
        private Panel pnlGraficoExterno;
        private GroupBox grpControles;
        private Button btnExibirFormularioDoGraficoComFuncoes;
        private Label lblGraficoComEquacao;
        private Button btnFinalizarComunicacao;
        private Label lblFinalizeAcquisition;
        private Button btnIniciarAquisicao;
        private Label lblIniciarAquisicao;
        private Button btnDefinirDiretorioDoArquivo;
        private TextBox txtDiretorioDefinidoDoArquivo;
        private Label lblDefinirDiretorioDoArquivo;
        private Button btnDefinirNomeDoArquivo;
        private TextBox txtNomeDoArquivo;
        private Label lblNomeDoArquivo;
        private Button btnSelecionarPorta;
        private ComboBox cmbPortasSeriais;
        private Label lblSelecionarPortaSerial;
        private Label lblDesenvolvedores;
        private Panel pnlControles;
        private PictureBox picLiscomp;
        private Panel pnlNomeProjeto;
        private Panel pnlLiscomp;
        private StatusStrip stsDesenvolvedores;
        private ToolStripStatusLabel tslblDesenvolvedores;
        private System.Windows.Forms.Timer tmpTempo;
        private OxyPlot.WindowsForms.PlotView pltvSpectra;
        private ToolStripStatusLabel tslblVazio;
        private ToolStripStatusLabel tslblSalvarGrafico;
        private System.Windows.Forms.Timer timer1;
    }
}