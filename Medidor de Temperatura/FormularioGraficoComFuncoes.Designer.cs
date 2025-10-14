namespace Medidor_de_Temperatura
{
    partial class FormularioGraficoComFuncoes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlFundoDoGrafico = new Panel();
            pltvSpectra = new OxyPlot.WindowsForms.PlotView();
            pnlFundoDoGrafico.SuspendLayout();
            SuspendLayout();
            // 
            // pnlFundoDoGrafico
            // 
            pnlFundoDoGrafico.Controls.Add(pltvSpectra);
            pnlFundoDoGrafico.Dock = DockStyle.Fill;
            pnlFundoDoGrafico.Location = new Point(0, 0);
            pnlFundoDoGrafico.Name = "pnlFundoDoGrafico";
            pnlFundoDoGrafico.Size = new Size(800, 450);
            pnlFundoDoGrafico.TabIndex = 0;
            // 
            // pltvSpectra
            // 
            pltvSpectra.Dock = DockStyle.Fill;
            pltvSpectra.Location = new Point(0, 0);
            pltvSpectra.Name = "pltvSpectra";
            pltvSpectra.PanCursor = Cursors.Hand;
            pltvSpectra.Size = new Size(800, 450);
            pltvSpectra.TabIndex = 0;
            pltvSpectra.Text = "pltvSpectra";
            pltvSpectra.ZoomHorizontalCursor = Cursors.SizeWE;
            pltvSpectra.ZoomRectangleCursor = Cursors.SizeNWSE;
            pltvSpectra.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // FormularioGraficoComFuncoes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlFundoDoGrafico);
            Name = "FormularioGraficoComFuncoes";
            Text = "Gráfico proviniente da função aplicada";
            pnlFundoDoGrafico.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlFundoDoGrafico;
        private OxyPlot.WindowsForms.PlotView pltvSpectra;
    }
}