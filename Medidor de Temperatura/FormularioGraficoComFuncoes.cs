using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot;
using System;
using System.Windows.Forms;


namespace Medidor_de_Temperatura
{
    public partial class FormularioGraficoComFuncoes : Form
    {

        #region Propriedades


        private PlotModel? ModeloDoPlot;

        private LineSeries temperaturaInicialSemAlteracao,
                           temperaturaInicialComMenosUm, 
                           temperaturaInicialComMaisUm, graficoEmFuncaoDoTempop;
        
        private LinearAxis? eixoX, eixoY;

        public string linhaDoArquivoLido;
        public string arquivoSelecionado;

        public List<double> valoresDeTemperatura;
        public List<double> valoresDeTempo;

        public double temperaturaInicial = 0;

        #endregion Propriedades


        #region Construtor


        public FormularioGraficoComFuncoes()
        {
            InitializeComponent();
            linhaDoArquivoLido = string.Empty;
            arquivoSelecionado = string.Empty;

            ModeloDoPlot = new PlotModel();

            temperaturaInicialComMenosUm   =   new LineSeries() { Title = "T = t + (T0 - 1)" };
            temperaturaInicialComMaisUm    =   new LineSeries() { Title = "T = t + (T0 + 1)" };
            temperaturaInicialSemAlteracao =   new LineSeries() { Title = "T = t + T0" };
            graficoEmFuncaoDoTempop        =   new LineSeries() { Title = "Gráfico em função do tempo" };

            valoresDeTemperatura = new List<double>();
            valoresDeTempo = new List<double>();
                       
            eixoX = (new LinearAxis { Position = AxisPosition.Bottom, Minimum = 0, AbsoluteMinimum = 0, AbsoluteMaximum = 100, AxislineThickness = 12, Title = "tempo (min)" });
            eixoY = (new LinearAxis { Position = AxisPosition.Left, Minimum = 0, AbsoluteMinimum = 0, AbsoluteMaximum = 100, AxislineThickness = 12, Title = "temperatura (°C)" });

            ModeloDoPlot.Axes.Add(eixoX);
            ModeloDoPlot.Axes.Add(eixoY);

            ModeloDoPlot.Series.Add(temperaturaInicialSemAlteracao);
            ModeloDoPlot.Series.Add(temperaturaInicialComMenosUm);
            ModeloDoPlot.Series.Add(temperaturaInicialComMaisUm);
            ModeloDoPlot.Series.Add(graficoEmFuncaoDoTempop);
            
            pltvSpectra.Model = ModeloDoPlot;
            
            SelecionarArquivo();
        }

        #endregion Construtor


        #region Metodos

        private void SelecionarArquivo()
        {

            OpenFileDialog _abrirArquivo = new OpenFileDialog();

            temperaturaInicialSemAlteracao.Points.Clear();
            temperaturaInicialComMenosUm.Points.Clear();
            temperaturaInicialComMaisUm.Points.Clear();
            graficoEmFuncaoDoTempop.Points.Clear();

            valoresDeTemperatura.Clear();
            valoresDeTempo.Clear();

            _abrirArquivo.Filter = "Text files (*.txt)|*.txt";
            _abrirArquivo.InitialDirectory = @"C:\";

            if (_abrirArquivo.ShowDialog() == DialogResult.OK)
            {
                arquivoSelecionado = _abrirArquivo.FileName;
                ModeloDoPlot.Title = Path.GetFileNameWithoutExtension(_abrirArquivo.FileName);
                
                if (File.Exists(arquivoSelecionado))
                {
                    using (StreamReader _leitorDeArquivo = new StreamReader(arquivoSelecionado))
                    {
                        while ((linhaDoArquivoLido = _leitorDeArquivo.ReadLine()) != null)
                        {
                            if (linhaDoArquivoLido.Contains(";"))
                            {
                                valoresDeTemperatura.Add(   Convert.ToDouble(linhaDoArquivoLido.Substring(0, linhaDoArquivoLido.LastIndexOf(";"))));
                                valoresDeTempo.Add(         Convert.ToDouble(linhaDoArquivoLido.Substring(linhaDoArquivoLido.LastIndexOf(";") + 1)));
                            }
                            else continue;
                        }
                    }

                }
                PlotDoGrafico();

            }
          
        }

       
        private void PlotDoGrafico()
        {
            temperaturaInicial = valoresDeTemperatura[0];

            for (int i = 0; i < valoresDeTempo.Count; i++)
            {
                temperaturaInicialComMenosUm.Points.Add(    new DataPoint((valoresDeTempo[i] / 60), (valoresDeTempo[i] / 60) + (temperaturaInicial - 1)));
                temperaturaInicialComMaisUm.Points.Add(     new DataPoint((valoresDeTempo[i] / 60), (valoresDeTempo[i] / 60) + (temperaturaInicial + 1)));
                temperaturaInicialSemAlteracao.Points.Add(  new DataPoint((valoresDeTempo[i] / 60),  (valoresDeTempo[i] / 60) + temperaturaInicial));
                graficoEmFuncaoDoTempop.Points.Add(         new DataPoint((valoresDeTempo[i] / 60), valoresDeTemperatura[i]));
            }

            ModeloDoPlot.ResetAllAxes();
            ModeloDoPlot.InvalidatePlot(true);
        }

        #endregion Metodos
    }
}
