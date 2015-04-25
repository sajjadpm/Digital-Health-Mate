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
using System.IO;

namespace DHM
{
    public partial class voice : Form
    {
       
        
        
        
        SpeechRecognitionEngine _recognizer = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
        SpeechSynthesizer JARVIS = new SpeechSynthesizer();
        string QEvent;
        string ProcWindow;
        double timer = 10;
       int count = 1;
        Random rnd = new Random();
        public voice()
        {
      
            InitializeComponent();
        }
        private void voice_Load(object sender, EventArgs e)
        {
            try
            {
                WindowState = FormWindowState.Maximized;
                _recognizer.SetInputToDefaultAudioDevice();
                _recognizer.LoadGrammar(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"C:\Test\command.txt")))));
                _recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(_recognizer_SpeechRecognized);
                _recognizer.RecognizeAsync(RecognizeMode.Multiple);
            }

            catch (Exception f)
            {

                MessageBox.Show(f.Message); 
            }
        
        }
        
        void _recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {

        //    try
          //  {
                int ranNum = rnd.Next(1, 10);
                string speech = e.Result.Text;
                switch (speech)
                {
                    //GREETINGS
                    
                    case "hello":
                    case "hello mate":
                        if (ranNum < 6) { JARVIS.Speak("Hello sir"); }
                        else if (ranNum > 5) { JARVIS.Speak("Hi"); }
                        break;
                    
                    case "Do you know bilgates":
                        JARVIS.Speak("I can't imagine a world without him");
                        break;
                    case "mate":
                        if (ranNum < 5) { QEvent = ""; JARVIS.Speak("Yes sir"); }
                        else if (ranNum > 4) { QEvent = ""; JARVIS.Speak("Yes?"); }
                        break;

                    //WEBSITES
                    case "open google":
                        JARVIS.Speak("Opening sir");
                        System.Diagnostics.Process.Start("http://www.google.co.in");
                        break;
                    case "open facebook":
                        System.Diagnostics.Process.Start("http://www.facebook.com");
                        break;
                    case "close chrome":
                        ProcWindow = "chrome";
                        StopWindow();
                        break;
                    case "close media player":
                        JARVIS.Speak("Surely closing sir");
                         ProcWindow = "wmplayer";
                        StopWindow();
                        break;
                    case "close skype":
                        JARVIS.Speak("Surely closing sir");
                        ProcWindow = "Skype";
                        StopWindow();
                        break;
                    case "open my computer":
                        System.Diagnostics.Process.Start("explorer.exe");
                        JARVIS.Speak("opening sir");
                        break;

                    case "open skype":
                        System.Diagnostics.Process.Start("C:/Program Files (x86)/Skype/Phone/skype.exe");
                        JARVIS.Speak("Loading");
                       
                        break;
                    //SHELL COMMANDS
                    case "run itunes":
                        System.Diagnostics.Process.Start("C:/Program Files/iTunes/iTunes.exe");
                        JARVIS.Speak("Loading");
                        break;
                    
                    case "favourite song":
                        System.Diagnostics.Process.Start("C:/Users/Sajjad Ali/Downloads/Songs/Android.mp3");
                        JARVIS.Speak("Opening the music sir");
                        break;


                    //CONDITION OF DAY
                    case "what time is it":
                        DateTime now = DateTime.Now;
                        string time = now.GetDateTimeFormats('t')[0];
                        JARVIS.Speak(time);
                        break;
                    case "what day is it":
                        JARVIS.Speak(DateTime.Today.ToString("dddd"));
                        break;
                    case "whats the date":
                    case "whats todays date":
                        JARVIS.Speak(DateTime.Today.ToString("d MMMM, yyyy"));
                        break;

                    //OTHER COMMANDS
                    case "go fullscreen":
                        FormBorderStyle = FormBorderStyle.None;
                        WindowState = FormWindowState.Maximized;
                        TopMost = true;
                        JARVIS.Speak("expanding");
                        break;
                    case "exit fullscreen":
                        FormBorderStyle = FormBorderStyle.Sizable;
                        WindowState = FormWindowState.Normal;
                        TopMost = false;
                        break;
                    case "switch window":
                        JARVIS.Speak("switching sir");
                        SendKeys.SendWait("%{TAB " + count + "}");
                        count += 1;
                        break;
                    case "reset":
                        //count = 1;
                        //timer = 11;
                        //lblTimer.Visible = false;
                        //ShutdownTimer.Enabled = false;
                        //lstCommands.Visible = false;
                        break;
                    case "out of the way":
                        if (WindowState == FormWindowState.Normal || WindowState == FormWindowState.Maximized)
                        {
                            WindowState = FormWindowState.Minimized;
                            JARVIS.Speak("My apologies");
                        }
                        break;
                    case "come back":
                        if (WindowState == FormWindowState.Minimized)
                        {
                            JARVIS.Speak("Alright?");
                            WindowState = FormWindowState.Normal;
                        }
                        break;
                    case "lets start":
                        string[] commands = (File.ReadAllLines(@"C:\Test\command.txt"));
                        JARVIS.Speak("Very well");
                        lstCommands.Items.Clear();
                        lstCommands.SelectionMode = SelectionMode.None;
                        lstCommands.Visible = true;
                        label1.Visible = false;
                        foreach (string command in commands)
                        {
                            lstCommands.Items.Add(command);
                        }
                        break;
                    case "hide listbox":
                        lstCommands.Visible = false;
                        break;

                    //shutdown restart log off
                    case "shutdown":
                        if (ShutdownTimer.Enabled == false)
                        {
                            QEvent = "shutdown";
                            JARVIS.Speak("i will shutdown shortly");
                            lblTimer.Visible = true;
                            ShutdownTimer.Enabled = true;
                        }
                        break;
                    case "log off":
                        if (ShutdownTimer.Enabled == false)
                        {
                            QEvent = "logoff";
                            JARVIS.Speak("Logging off");
                            lblTimer.Visible = true;
                            ShutdownTimer.Enabled = true;
                        }
                        break;
                    case "restart":
                        if (ShutdownTimer.Enabled == false)
                        {
                            QEvent = "restart";
                            JARVIS.Speak("I'll be back shortly");
                            lblTimer.Visible = true;
                            ShutdownTimer.Enabled = true;
                        }
                        break;
                    case "abort":
                        if (ShutdownTimer.Enabled == true)
                        {
                            QEvent = "abort";
                        }
                        break;
                    case "speed up":
                        if (ShutdownTimer.Enabled == true)
                        {
                            ShutdownTimer.Interval = ShutdownTimer.Interval / 10;
                        }
                        break;
                    case "slow down":
                        if (ShutdownTimer.Enabled == true)
                        {
                            ShutdownTimer.Interval = ShutdownTimer.Interval * 10;
                        }
                        break;
                }
      //     }

    //       catch (Exception f)
      //      {
        //        MessageBox.Show(f.Message);
            
          //  }
        }
        private void ShutdownTimer_Tick_1(object sender, EventArgs e)
        {
            try
            {

                if (timer == 0)
                {
                    lblTimer.Visible = false;
                    ComputerTermination();
                    ShutdownTimer.Enabled = false;
                }
                else if (QEvent == "abort")
                {
                    timer = 10;
                    lblTimer.Visible = false;
                    ShutdownTimer.Enabled = false;
                }
                else
                {
                    timer = timer - .01;
                    lblTimer.Text = timer.ToString();
                }
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);

            }
        }
        private void ComputerTermination()
        {

            try
            {
                switch (QEvent)
                {
                    case "shutdown":
                        System.Diagnostics.Process.Start("shutdown", "-s");
                        break;
                    case "logoff":
                        System.Diagnostics.Process.Start("shutdown", "-l");
                        break;
                    case "restart":
                        System.Diagnostics.Process.Start("shutdown", "-r");
                        break;
                }
            }

            catch (Exception f)
            {
                MessageBox.Show(f.Message);

            }
        }
        private void StopWindow()
        {
            try
            {
                System.Diagnostics.Process[] procs = System.Diagnostics.Process.GetProcessesByName(ProcWindow);
                foreach (System.Diagnostics.Process proc in procs)
                {
                    proc.CloseMainWindow();
                }

            }

            catch (Exception f)
            {
                MessageBox.Show(f.Message);

            }
        }

       

       
    }
}
