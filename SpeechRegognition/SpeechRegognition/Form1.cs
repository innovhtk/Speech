using System;
using System.Diagnostics;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Threading;
using System.Windows.Forms;

namespace SpeechRegognition
{
    public partial class Form1 : Form
    {

        SpeechSynthesizer ss = new SpeechSynthesizer();
        PromptBuilder pb = new PromptBuilder();
        SpeechRecognitionEngine sre = new SpeechRecognitionEngine();
        Choices clist;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            btStart.Enabled = false;
            btStop.Enabled = true;
            Recognize(); 
        }
        private void Recognize()
        {
            clist = new Choices(new string[] { "prende la luz", "como te va", "que hora es", "abre chrome", "adios" });
            Grammar gr = new Grammar(new GrammarBuilder(clist));
            try
            {
                sre.RequestRecognizerUpdate();
                sre.LoadGrammar(gr);
                sre.SpeechRecognized += sre_SpeechRecognized;
                sre.SetInputToDefaultAudioDevice();
                sre.RecognizeAsync(RecognizeMode.Single);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            sre.SpeechRecognized -= sre_SpeechRecognized;
            switch (e.Result.Text.ToString())
            {
                case "prende la luz":
                    ss.SpeakAsync("Aún no se hacer eso");
                    break;
                case "como te va":
                    ss.SpeakAsync("muy bien. ¿Y a ti?");
                    break;
                case "que hora es":
                    ss.SpeakAsync("son las " + DateTime.Now.ToLongTimeString());
                    break;
                case "abre chrome":
                    Process.Start("chrome", "http://www.google.com");
                    break;
                case "adios":
                    ss.SpeakAsync("Nos vemos pronto");
                    Thread.Sleep(2000);
                    Application.Exit();
                    break;
                default:
                    break;
            }
            textBox1.Text += e.Result.Text.ToString() + Environment.NewLine;
            Thread.Sleep(100);
            Recognize();
        }

        private void btStop_Click(object sender, EventArgs e)
        {
            sre.RecognizeAsyncStop();
            btStart.Enabled = true;
            btStop.Enabled = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
