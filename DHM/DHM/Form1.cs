using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Globalization;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;



namespace DHM
{
    public partial class Form1 : Form
    {
        SpeechSynthesizer speaker = new SpeechSynthesizer();
        SpeechSynthesizer MySynthesizer = new SpeechSynthesizer();
        bool flag = false;

        public Form1()
        {
            try
            {
                InitializeComponent();
                WindowState = FormWindowState.Maximized;
                speaker.SpeakCompleted += new EventHandler<SpeakCompletedEventArgs>
                    (speaker_SpeakCompleted);
                btnPause.Enabled = false;
                foreach (InstalledVoice voice in speaker.GetInstalledVoices())
                {
                    cbVoice.Items.Add(voice.VoiceInfo.Name);
                }
                
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);

            }
            
        }

        void speaker_SpeakCompleted(object sender, SpeakCompletedEventArgs e)
        {
            btnPlay.Enabled = true;
            btnPause.Enabled = false;
        }

        private void Play(string words)
        {
            speaker.SelectVoice(cbVoice.Text);
            speaker.SpeakAsync(words);
            
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbVoice.SelectedIndex >= 0)
                {
                    btnPlay.Enabled = false;
                    btnPause.Enabled = true;   
                    speaker.Volume = Convert.ToInt16(trackBar1.Value);
                    Play(txtWords.Text);
                }
                else
                {
                    MessageBox.Show("Please select a voice", "Text to Speech",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbVoice.Focus();
                }
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);

            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (speaker != null)
            {
                if (flag == false)
                {
                    speaker.Pause();
                    btnPause.Text = "Resume";
                    flag = true;
                }
                else
                {
                    speaker.Resume();
                    btnPause.Text = "Pause";
                    flag = false;
                }
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {

            try
            {
                
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Wav files (*.wav)|*.wav";
                
                if(save.ShowDialog()==DialogResult.OK)
                {
                    MySynthesizer.SpeakCompleted += new EventHandler<SpeakCompletedEventArgs>
                        (MySynthesizer_SpeakCompleted);

                    MySynthesizer.SetOutputToWaveFile(string.Concat(save.FileName.ToString()));
                    PromptBuilder builder = new PromptBuilder(); 

                    if (cbVoice.SelectedIndex==0)
                    {

                        builder.StartVoice("Microsoft David Desktop");
                    
                    }

                    else if (cbVoice.SelectedIndex == 1)
                    {
                        
                   
                        builder.StartVoice("Microsoft Hazel Desktop");
                    }

                    else {


                        builder.StartVoice("Microsoft Zira Desktop");
                    
                    }


                    if (radiobutton1.Checked)
                    {
                        MySynthesizer.Rate = -5;
                    }

                    else if (radioButton2.Checked)
                    {
                        MySynthesizer.Rate = 0;
                    }
                    else
                        MySynthesizer.Rate = 5;

                    MySynthesizer.Volume = trackBar1.Value;

                    
                    builder.AppendText(txtWords.Text);
                    builder.EndVoice();
                    MySynthesizer.SpeakAsync(builder);
                }
            }

            catch (Exception f)
            {
                MessageBox.Show(f.Message);

            }
        }

        void MySynthesizer_SpeakCompleted(object sender, SpeakCompletedEventArgs e)
        {
            MessageBox.Show("Audio saved sucessfully", "Natural Reader",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


       

        private void Low_CheckedChanged(object sender, EventArgs e)
        {
            speaker.Rate = -5;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            speaker.Rate = 0;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            speaker.Rate = 5;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            speaker.SpeakAsyncCancelAll();
            btnPause.Enabled = false;
            btnPlay.Enabled = true;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            string filepath;
            dlg.Filter = "PDF Files(*.PDF)|*.PDF|All Files(*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {

                filepath = dlg.FileName.ToString();


                string strtext = string.Empty;
                try
                {
                    PdfReader reader = new PdfReader(filepath);
                    for (int page = 1; page<= reader.NumberOfPages; page++)
                    {
                        ITextExtractionStrategy its = new iTextSharp.text.pdf.parser.LocationTextExtractionStrategy();
                        string s = PdfTextExtractor.GetTextFromPage(reader,page,its);
                        s = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(s)));
                        strtext = strtext + s;
                        txtWords.Text = strtext;
                    }
                    reader.Close();

                }

                catch (Exception f)
                {
                    MessageBox.Show(f.Message);
                }
            }
            
        }

      

        
    }
}
