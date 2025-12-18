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
        private List<String> ValoresDateTime;

        private int contadorDeSegundos = 1;
        private string nomeDoArquivo = "";
        private string diretorioDoArquivo = "";
        private int intervalo = 5000; // Equivale a 5 segundos
        private string diretorio = "";
        private bool ativo = false;

        #endregion Propriedades


        #region Construtor


        public FormularioPrincipal()
        {
            InitializeComponent();
            ValoresDeTemperatura = new List<double>();
            ValoresDeTempo = new List<double>();
            ValoresDateTime = new List<String>();
            _portaSerial = new SerialPort();

            txtNomeDoArquivo.Text = NomeArquivo();

            MessageBox.Show("Para o funcionamento do software é necessário informar um diretório" +
                " para salvar as aquisições de temperatura realizada e também conectar o arduino.", "Funcionamento do Software");

            _portaSerial.DataReceived += new SerialDataReceivedEventHandler(IniciarLeituraPortaSerial);
            tmpTempo.Enabled = true;
        }

        #endregion Construtor


        #region Metodos

        private string TransformarEmTempo(double Valor)
        {

            int Minutos = 0;
            string MinutoString = "";
            string SegundoString = "";
            string TempoString = "";

            Valor *= (intervalo / 1000);

            if (Valor >= 60)
            {
                while (Valor >= 60)
                {
                    Valor -= 60;
                    Minutos += 1;
                }
            }

            if (Valor < 10)
            {
                SegundoString = "0" + Convert.ToString(Valor);
            }

            else
            {
                SegundoString = Convert.ToString(Valor);
            }

            if (Minutos < 10)
            {
                MinutoString = "0" + Convert.ToString(Minutos);
            }
            else
            {
                MinutoString = Convert.ToString(Minutos);
            }

            TempoString = MinutoString + ":" + SegundoString;

            return TempoString;
        }


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
                diretorio = diretorioDoArquivo;

            }
        }

        private void BtnDefinirNomeDoArquivo_Click(object sender, EventArgs e)
        {
            nomeDoArquivo = Convert.ToString(txtNomeDoArquivo.Text);

            if (string.IsNullOrEmpty(diretorioDoArquivo))
            {
                MessageBox.Show($"Informe um diretório para o arquivo ser salvo.", "Diretorio do arquivo", MessageBoxButtons.OK);
                return;
            }

            else if (!string.IsNullOrEmpty(nomeDoArquivo))
            {
                MessageBox.Show($"Nome do arquivo: {nomeDoArquivo} foi definido com sucesso.", "Nome do arquivo", MessageBoxButtons.OK);
                txtNomeDoArquivo.Clear();
            }
            else
                MessageBox.Show($"Informe um nome para o arquivo.", "Nome do arquivo", MessageBoxButtons.OK);
        }

        private bool arquivoJaSalvo = false;

        private void testeescrito()
        {

            if (arquivoJaSalvo)
                return;

            try
            {

                if (ValoresDeTemperatura.Count == 0 || string.IsNullOrEmpty(diretorioDoArquivo) || string.IsNullOrEmpty(nomeDoArquivo))
                    return;

                if (_portaSerial != null)
                {
                    try
                    {
                        if (_portaSerial.IsOpen)
                        {
                            _portaSerial.DiscardInBuffer();
                            _portaSerial.Write("d");
                            ativo = false;
                            Thread.Sleep(200);
                            
                        }
                    }
                    catch (IOException) { }
                    catch (UnauthorizedAccessException) { }
                    catch (InvalidOperationException) { }
                }

                using (StreamWriter _escreverArquivo = new StreamWriter($@"{diretorioDoArquivo}\{nomeDoArquivo}.txt"))
                {
                    for (int i = 0; i < ValoresDeTemperatura.Count; i++)
                    {
                        _escreverArquivo.WriteLine($"{ValoresDeTemperatura[i]};{TransformarEmTempo(ValoresDeTempo[i])}");
                    }
                }

                MessageBox.Show($"Arquivo salvo com sucesso em:\n{diretorioDoArquivo}\\{nomeDoArquivo}.txt",
                                "Salvamento concluído", MessageBoxButtons.OK, MessageBoxIcon.Information);


                arquivoJaSalvo = true;

                nomeDoArquivo = string.Empty;
                ValoresDeTemperatura.Clear();
                ValoresDeTempo.Clear();
                contadorDeSegundos = 1;


                if (_portaSerial != null && _portaSerial.IsOpen)
                {
                    try {
                        _portaSerial.DataReceived -= IniciarLeituraPortaSerial;

                        if (_portaSerial.IsOpen) { _portaSerial.Close(); }
                            
                    } 
                    catch { }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar arquivo: {ex.Message}",
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void BtnFinalizarComunicacao_Click(object sender, EventArgs e)
        {
            txtNomeDoArquivo.Text = NomeArquivo();
            ativo = false;
            LimparGrafico();
            testeescrito();
        }

        private void BtnIniciarAquisicao_Click(object sender, EventArgs e)
        {
            int arquivo = 1;
            int diretorio = 1;
            int porta = 1;

            if (string.IsNullOrEmpty(nomeDoArquivo)) { arquivo = 0; }
            if (string.IsNullOrEmpty(diretorioDoArquivo)) { diretorio = 0; }
            if (btnSelecionarPorta.Text != "Desconectar") { porta = 0; }

            List<string> mensagens = new List<string>();

            if (arquivo == 0) { mensagens.Add("Informe um nome para o arquivo."); }
            if (diretorio == 0) { mensagens.Add("Informe um diretório para o arquivo ser salvo."); }
            if (porta == 0) { mensagens.Add("A porta de comunicação é inválida, confira se está selecionada corretamente."); }

            if (mensagens.Count > 0)
            {
                string mensagemFinal = string.Join(Environment.NewLine, mensagens);
                MessageBox.Show(mensagemFinal, "Não foi possivel concluir a ação", MessageBoxButtons.OK);
                return;
            }
            else
            {

                arquivoJaSalvo = false;

                if (!_portaSerial.IsOpen)
                {
                    try
                    {
                        _portaSerial.Open();
                        _portaSerial.DataReceived += IniciarLeituraPortaSerial;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao abrir a porta serial: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                if (_portaSerial.IsOpen)
                {
                    _portaSerial.WriteLine("b");
                    System.Threading.Thread.Sleep(3000);
                    _portaSerial.WriteLine("d");
                    _portaSerial.DiscardInBuffer();
                    _portaSerial.DiscardOutBuffer();
                    ativo = true;
                    //_portaSerial.WriteLine("intervalo:" + ((intervalo.ToString()).Replace(".", "").Replace(",", "")));
                    System.Threading.Thread.Sleep(30);
                    _portaSerial.WriteLine("b");
                }
            }
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
                    _portaSerial.DataReceived += IniciarLeituraPortaSerial;
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
            if (ativo == true)
            {
                try
                {
                    string leituraDaPortaSerial = _portaSerial.ReadLine().Trim();
                    double valorLido = 0;


                    leituraDaPortaSerial = leituraDaPortaSerial.Replace(";", "");


                    if (!string.IsNullOrEmpty(leituraDaPortaSerial))
                    {

                        valorLido = Convert.ToDouble(leituraDaPortaSerial.Replace('.', ','));

                    }
                    else
                    {
                        return;
                    }

                    ValoresDeTemperatura.Add(valorLido);
                    ValoresDeTempo.Add(contadorDeSegundos);
                    contadorDeSegundos += 1;

                    GerarGrafico();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Erro na leitura serial: {ex.Message}");
                }
            }
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

        private static string NomeArquivo()
        {
            string complementoDoNomeDoArquivo = $"Temperatura_{DateTime.Now.ToString("dd_MM_yyyy__HH_mm")}";
            return complementoDoNomeDoArquivo;
        }

        private void FormularioPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            testeescrito();
        }

        private void LimparGrafico()
        {
            Invoke(new MethodInvoker(delegate ()
            {
                pltvSpectra.Model = new PlotModel
                {
                    Title = "Gráfico limpo"
                };
                pltvSpectra.InvalidatePlot(true);
            }));
        }

        private void GerarGrafico()
        {
            Invoke(
                    new MethodInvoker(
                        delegate ()
                        {
                            LineSeries grafico = new LineSeries()
                            {
                                Color = OxyColors.Red,
                                Title = $"Medidor de temperatura - (°C/min)",
                                StrokeThickness = 2,
                            };

                            for (int i = 0; i < ValoresDeTemperatura.Count; i++)
                                grafico.Points.Add(new DataPoint(((ValoresDeTempo[i] * (intervalo / 1000) / 60)), ValoresDeTemperatura[i]));

                            PlotModel modeloDoGrafico = new PlotModel
                            {
                                Title = $"Gráfico de temperatura - (°C/min)",
                            };

                            modeloDoGrafico.Series.Add(grafico);
                            pltvSpectra.Model = modeloDoGrafico;
                        }
                    )
                );
        }

        #endregion Metodos

        #region ElementosInterface
        private void lblNomeDoArquivo_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pltvSpectra_Click(object sender, EventArgs e)
        {

        }

        #endregion


    }
}