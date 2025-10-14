using OxyPlot.Series;
using OxyPlot;
using System.IO.Ports;

namespace Medidor_de_Temperatura
{
    public partial class FormularioPrincipal : Form
    {
        #region Propriedades


        private SerialPort _portaSerial;

        private List<double> ValoresDeTemperatura;
        private List<double> ValoresDeTempo;

        private int contadorDeSegundos = 1;
        private string nomeDoArquivo = "";
        private string diretorioDoArquivo = "";

        #endregion Propriedades


        #region Construtor


        public FormularioPrincipal()
        {
            InitializeComponent();
            ValoresDeTemperatura = new List<double>();
            ValoresDeTempo = new List<double>();
            _portaSerial = new SerialPort();

            txtNomeDoArquivo.Text = $"Temperatura_{DataFormatada()}";

            MessageBox.Show("Para o funcionamento do software é necessário informar um diretório" +
                " para salvar as aquisições de temperatura realizada e também conectar o arduino.", "Funcionamento do Software");

            _portaSerial.DataReceived += new SerialDataReceivedEventHandler(IniciarLeituraPortaSerial);
            tmpTempo.Enabled = true;
        }

        #endregion Construtor


        #region Metodos


        private void BtnExibirFormularioDoGraficoComFuncoes_Click(object sender, EventArgs e)
        {
            FormularioGraficoComFuncoes FormularioGrafico = new FormularioGraficoComFuncoes();
            FormularioGrafico.Show();
        }

        private void BtnDefinirDiretorioDoArquivo_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog _escolherPasta = new FolderBrowserDialog();

            if (_escolherPasta.ShowDialog() == DialogResult.OK)
            {

                diretorioDoArquivo = _escolherPasta.SelectedPath;
                txtDiretorioDefinidoDoArquivo.Text = diretorioDoArquivo;
            }
        }

        private void BtnDefinirNomeDoArquivo_Click(object sender, EventArgs e)
        {
            nomeDoArquivo = Convert.ToString(txtNomeDoArquivo.Text);

            if (!string.IsNullOrEmpty(nomeDoArquivo))
            {
                MessageBox.Show($"  Nome do arquivo: {nomeDoArquivo} foi definido com sucesso.", "Nome do arquivo", MessageBoxButtons.OK);
                txtNomeDoArquivo.Clear();
            }
            else
                MessageBox.Show($"  Informe um nome para o arquivo.", "Nome do arquivo", MessageBoxButtons.OK);
        }

        private void BtnFinalizarComunicacao_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (_portaSerial.IsOpen == true)
                    _portaSerial.Write("d");

                using (StreamWriter _escreverArquivo = new StreamWriter($@"{diretorioDoArquivo}\\{nomeDoArquivo}.txt"))
                {
                    for (int i = 0; i < ValoresDeTemperatura.Count; i++)
                        _escreverArquivo.WriteLine($"{ValoresDeTemperatura[i]};{ValoresDeTempo[i]}\n");
                }

                diretorioDoArquivo = string.Empty;
                nomeDoArquivo = string.Empty;
                ValoresDeTemperatura.Clear();
                ValoresDeTempo.Clear();
                contadorDeSegundos = 1;

            }
            catch { }
        }

        private void BtnIniciarAquisicao_Click(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrEmpty(nomeDoArquivo) && !string.IsNullOrEmpty(diretorioDoArquivo))
            {
                if (_portaSerial.IsOpen)
                    _portaSerial.Write("b");
            }

            else if (string.IsNullOrEmpty(nomeDoArquivo) && string.IsNullOrEmpty(diretorioDoArquivo))
                MessageBox.Show("  Informe um nome para o arquivo e o diretório para o arquivo ser salvo.", "Nome e caminho do arquivo", MessageBoxButtons.OK);


            else if (string.IsNullOrEmpty(diretorioDoArquivo))
            {
                MessageBox.Show("  Informe um diretório para o arquivo ser salvo.", "Diretorio do arquivo", MessageBoxButtons.OK);

                FolderBrowserDialog _definirDiretorio = new FolderBrowserDialog();

                if (_definirDiretorio.ShowDialog() == DialogResult.OK)
                    diretorioDoArquivo = _definirDiretorio.SelectedPath; //Colocando o endereço físico (caminho do arquivo texto)
            }
            else
                MessageBox.Show("  Informe um nome para o arquivo", "Nome do arquivo", MessageBoxButtons.OK);
        }

        private void BtnSelecionarPorta_Click(object sender, EventArgs e)
        {
            if (_portaSerial.IsOpen == false)
            {
                try

                {
                    _portaSerial.PortName = cmbPortasSeriais.Items[cmbPortasSeriais.SelectedIndex].ToString();
                    _portaSerial.Open();

                }
                catch
                {
                    return;

                }
                if (_portaSerial.IsOpen)
                {
                    btnSelecionarPorta.Text = "Desconectar";
                    cmbPortasSeriais.Enabled = false;

                }
            }
            else
            {
                try
                {
                    _portaSerial.Close();
                    cmbPortasSeriais.Enabled = true;
                    btnSelecionarPorta.Text = "Conectar";
                }
                catch
                {
                }
            }
        }

        private void TslblSalvarGrafico_Click(object sender, EventArgs e)
        {
            Bitmap _capcturaDoPlot = new Bitmap(pltvSpectra.Width, pltvSpectra.Height);

            pltvSpectra.DrawToBitmap(_capcturaDoPlot, pltvSpectra.Bounds);

            using (SaveFileDialog _salvarImagem = new SaveFileDialog())
            {
                _salvarImagem.Filter = "Arquivos de Imagem|.png;.jpg;.jpeg;.bmp";
                _salvarImagem.Title = "Salvar Gráfico";

                if (_salvarImagem.ShowDialog() == DialogResult.OK)
                    _capcturaDoPlot.Save(_salvarImagem.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        private void TmpTempo_Tick(object sender, EventArgs e)
        {
            AtualizarListaDePortasSeriais();

        }

        private void IniciarLeituraPortaSerial(object sender, SerialDataReceivedEventArgs e)
        {
            string leituraDaPortaSerial = (string)_portaSerial.ReadLine().Trim();
            double valorLido = 0;
            string[] numeroDePontosNaLeituraDaPortaSerial = leituraDaPortaSerial.Split('.');

            if ((numeroDePontosNaLeituraDaPortaSerial.Length - 1) == 2)
            {
                leituraDaPortaSerial = leituraDaPortaSerial.Substring(leituraDaPortaSerial.IndexOf(".") + 2);
                valorLido = Convert.ToDouble(leituraDaPortaSerial.Replace('.', ','));
                valorLido += 130;

            }

            else if (leituraDaPortaSerial.Length >= 6 && leituraDaPortaSerial.Length <= 8)
            {
               
                    leituraDaPortaSerial = leituraDaPortaSerial.Substring(0);
                    string lpds = leituraDaPortaSerial.Replace(";", "");
                    valorLido = Convert.ToDouble(lpds.Replace('.', ','));
               
            }

            ValoresDeTemperatura.Add(valorLido);
            ValoresDeTempo.Add(contadorDeSegundos);
            contadorDeSegundos += 1;

            Invoke
            (
                new MethodInvoker
                (
                  delegate ()
                  {

                      LineSeries? grafico = new LineSeries()
                      {
                          Color = OxyColors.Red,
                          Title = $"Medidor de temperatura -  (°C/min)",
                          StrokeThickness = 2,

                      };

                      for (int i = 0; i < ValoresDeTemperatura.Count; i++)
                          grafico.Points.Add(new DataPoint(ValoresDeTempo[i] / 60, ValoresDeTemperatura[i]));  //o segredo é esse

                      PlotModel? modeloDoGrafico = new PlotModel
                      {
                          Title = $"Gráfico de temperatura -  (°C/min) ",

                      };

                      modeloDoGrafico.Series.Add(grafico);
                      pltvSpectra.Model = modeloDoGrafico;

                  }
                )
            );



        }

        private void AtualizarListaDePortasSeriais()
        {
            int i = 0;
            bool quantidadeDiferenteDePortasSeriais = false;

            if (cmbPortasSeriais.Items.Count == SerialPort.GetPortNames().Length)
            {
                foreach (string nameThePort in SerialPort.GetPortNames())
                {
                    if (cmbPortasSeriais.Items[i++].Equals(nameThePort) == false)
                        quantidadeDiferenteDePortasSeriais = true;
                }
            }
            else
                quantidadeDiferenteDePortasSeriais = true;


            if (quantidadeDiferenteDePortasSeriais == false)
                return;


            cmbPortasSeriais.Items.Clear();

            foreach (string nomeDaPorta in SerialPort.GetPortNames())
                cmbPortasSeriais.Items.Add(nomeDaPorta);

            if (cmbPortasSeriais.Items.Count == 1)
                cmbPortasSeriais.SelectedIndex = 0;

        }

        private static string DataFormatada()
        {

            DateTime diaAtual = DateTime.Today;
            string complementoDoNomeDoArquivo = string.Empty;

            if (Convert.ToInt32(diaAtual.Day) < 10)
                complementoDoNomeDoArquivo = complementoDoNomeDoArquivo + "0" + diaAtual.Day + "_";

            else if (Convert.ToInt32(diaAtual.Day) > 10)
                complementoDoNomeDoArquivo = complementoDoNomeDoArquivo + diaAtual.Day + "_";

            if (Convert.ToInt32(diaAtual.Month) < 10)
                complementoDoNomeDoArquivo = complementoDoNomeDoArquivo + "0" + diaAtual.Month;

            else if (Convert.ToInt32(diaAtual.Month) > 10)
                complementoDoNomeDoArquivo = complementoDoNomeDoArquivo + diaAtual.Month;

            return complementoDoNomeDoArquivo;
        }


        private void FormularioPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_portaSerial.IsOpen == true)
                _portaSerial.Write("d");

            using (StreamWriter _escrevarArquivo = new StreamWriter($@"{Environment.CurrentDirectory}\\{nomeDoArquivo}.txt"))
            {
                for (int i = 0; i < ValoresDeTemperatura.Count; i++)
                    _escrevarArquivo.WriteLine($"{ValoresDeTemperatura[i]};{ValoresDeTempo[i]}\n");
            }

            if (_portaSerial.IsOpen == true)
                _portaSerial.Close();
        }

        #endregion Metodos

    }
}