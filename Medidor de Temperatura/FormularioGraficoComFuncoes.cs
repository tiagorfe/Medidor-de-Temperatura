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

            temperaturaInicialComMenosUm = new LineSeries() { Title = "T = t + (T0 - 1)" };
            temperaturaInicialComMaisUm = new LineSeries() { Title = "T = t + (T0 + 1)" };
            temperaturaInicialSemAlteracao = new LineSeries() { Title = "T = t + T0" };
            graficoEmFuncaoDoTempop = new LineSeries() { Title = "Gráfico em função do tempo" };

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
                                string[] partes = linhaDoArquivoLido.Split(';');

                                string temperaturaString = partes[0];
                                double temperatura = double.Parse(temperaturaString);
                                double tempo = TransformarEmNumero(partes[1]);

                                valoresDeTemperatura.Add(temperatura);
                                valoresDeTempo.Add(tempo);
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
                temperaturaInicialComMenosUm.Points.Add(new DataPoint((valoresDeTempo[i]), (valoresDeTempo[i]) + (temperaturaInicial - 1)));
                temperaturaInicialComMaisUm.Points.Add(new DataPoint((valoresDeTempo[i]), (valoresDeTempo[i]) + (temperaturaInicial + 1)));
                temperaturaInicialSemAlteracao.Points.Add(new DataPoint((valoresDeTempo[i]), (valoresDeTempo[i]) + temperaturaInicial));
                graficoEmFuncaoDoTempop.Points.Add(new DataPoint((valoresDeTempo[i]), valoresDeTemperatura[i]));
            }

            eixoX.AbsoluteMaximum = valoresDeTempo.Max() + (valoresDeTempo.Max() /10);
            eixoY.AbsoluteMaximum = valoresDeTemperatura.Max() + (valoresDeTemperatura.Max() / 4);

            ModeloDoPlot.ResetAllAxes();
            ModeloDoPlot.InvalidatePlot(true);
        }
        private double TransformarEmNumero(string Minuto)
        {
            double ValorGrafico = 0;
            double Segundos;
            double Minutos;

            string[] partes = Minuto.Split(':');

            double MinutoParte = double.Parse(partes[0]);
            double SegundoParte = double.Parse(partes[1]);

            if (SegundoParte > 0)
            {
                Segundos = SegundoParte / 5;
                ValorGrafico += Segundos;
            }

            if (MinutoParte > 0)
            {
                Minutos = (MinutoParte * 60) / 5;
                ValorGrafico += Minutos;
            }


            ValorGrafico *= 5;
            ValorGrafico = ValorGrafico / 60;
            return ValorGrafico;

        }

        #endregion Metodos
    }
}