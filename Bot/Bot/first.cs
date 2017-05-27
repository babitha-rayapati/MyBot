using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Windows.Forms;

namespace Bot
{
    public partial class first : Form
    {
        public first()
        {
            InitializeComponent();
        }


        
        StreamReader commandsReader = new StreamReader(@"G:\projects\Bot\commands.txt");
        SpeechSynthesizer sSynth = new SpeechSynthesizer();
        PromptBuilder pBuilder = new PromptBuilder();
        SpeechRecognitionEngine sRecognize = new SpeechRecognitionEngine();
        

        private void first_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            initializeSpeech();
        }

        GrammarBuilder gbuilder = new GrammarBuilder();
        public void initializeSpeech()
        {

            Choices sList = new Choices();

            //Add the words

            try
            {
                gbuilder.Append(new Choices(System.IO.File.ReadAllLines(@"G:\projects\Bot\commands.txt")));
            }
            catch
            {
                MessageBox.Show("empty lines.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                /*Process pr = new Process();          
pr.StartInfo.FileName = @"C:\users\" + Environment.UserName.ToString() + @"\documents\commands.txt";
                pr.Start(); Application.Exit(); return; */

            }// end of catch

            Grammar gr = new Grammar(gbuilder);
            try
            {
                sRecognize.UnloadAllGrammars();
                sRecognize.RecognizeAsyncCancel();
                sRecognize.RequestRecognizerUpdate();
                sRecognize.LoadGrammar(gr);

                sRecognize.SpeechRecognized += SRecognize_SpeechRecognized;

                sRecognize.SetInputToDefaultAudioDevice();
                sRecognize.RecognizeAsync(RecognizeMode.Multiple);

            }
            catch
            {
                MessageBox.Show("Grammar Builder Error");
                return;
            }

        }

        Process pr = new Process();
        public void lockComputer()
        {

            System.Diagnostics.Process.Start(@"C:\WINDOWS\system32\rundll32.exe", "user32.dll,LockWorkStation");
            return;
        }


        public void speakText(string textSpeak)
        {
            sRecognize.RecognizeAsyncCancel();
            sRecognize.RecognizeAsyncStop();
            pBuilder.ClearContent();
            pBuilder.AppendText(textSpeak.ToString());
           // sSynth.SelectVoice(name);
            sSynth.SpeakAsync(pBuilder);
            sRecognize.RecognizeAsyncCancel();
            sRecognize.RecognizeAsyncStop();
            sRecognize.RecognizeAsync(RecognizeMode.Multiple);
        }//speak text end

        bool exitCondition = false;
        private void SRecognize_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            //throw new NotImplementedException();
            if (exitCondition)
            {
                //Thread.Sleep(100);
                if (e.Result.Text == "yes")
                {
                    sSynth.SpeakAsyncCancelAll();
                    sRecognize.RecognizeAsyncCancel();
                    Application.Exit();
                    return;
                }
                else { exitCondition = false; speakText("Exit Cancelled"); return; }
            }//if

            if (e.Result.Confidence >= 0.9)
            {//checks the confidence of whether it has the words recognised are in the commands.txt
                switch (e.Result.Text)
                {
                    /*case "hello":
                        speakText("heyy Babiitha" );
                        break;*/
                    case "invisible":
                        if (ActiveForm.Visible == true)
                        {

                            ActiveForm.WindowState = FormWindowState.Minimized;
                            speakText("I am now invisible. You can access me by clicking on the icon down here in the tray.");
                            break;
                        }
                        else
                            break;
                    case "hello":
                        speakText("heyy Babeetha");
                        break;
                    case "exit":
                        speakText("Are you sure you want to exit?");
                        exitCondition = true;
                        break;
                    case "facebook":
                        sSynth.SpeakAsync("here is your facebook");
                        Process.Start("chrome", "https://www.facebook.com");
                        break;
                    case "chrome":
                        sSynth.SpeakAsync("here is your chrome");
                        Process.Start("chrome", "https://www.google.com");
                        break;
                    case "time":
                        sSynth.SpeakAsync("time is " + DateTime.Now.ToLongTimeString());
                        break;
                    case "show commands":
                        bool worrking = true;
                        while (worrking)
                        {
                            try
                            {
                                listBox1.Show();
                                listBox1.Items.Add(commandsReader.ReadLine());
                            }
                            catch { worrking = false; break; }
                        }
                        break;
                    case "hide commands":
                        listBox1.Hide();
                        sSynth.SpeakAsync("hidden");
                        break;
                    case "maximize":
                        try
                        {
                            ActiveForm.WindowState = FormWindowState.Maximized;
                            sSynth.SpeakAsync("maximized");
                            break;
                        }
                        catch
                        {
                            MessageBox.Show("no forms active");
                            break;
                        }
                    case "minimize":
                        try
                        {
                            ActiveForm.WindowState = FormWindowState.Minimized;
                            sSynth.SpeakAsync("minimized");
                            break;
                        }
                        catch
                        {
                            MessageBox.Show("minimized already");
                            break;
                        }
                    case "stop":
                        speakText("Ok miss.");
                        sRecognize.RecognizeAsyncCancel();
                        sRecognize.RecognizeAsyncStop();
                        break;
                    case "lock":
                        lockComputer();
                        break;
                    case "internet":
                        speakText("in a  moment.");
                        Process pr = new Process();
                        pr.StartInfo.FileName = "http://www.google.com/";
                        pr.Start();
                        break;
                    case "quiet":
                        /*cancelSpeech();
                        sSynth.SpeakAsyncCancelAll();
                        sSynth.SpeakAsyncCancelAll();
                        break;*/
                        speakText("Ok miss.");
                        sRecognize.RecognizeAsyncCancel();
                        sRecognize.RecognizeAsyncStop();
                        break;
                    case "new commands":
                        add_commands ad = new add_commands();
                        ad.Show();
                        break;
                    case "thankyou":
                        sSynth.SpeakAsync("you're welcome");
                        break;
                    case "files":
                        OpenFileDialog opfd = new OpenFileDialog();
                        opfd.ShowDialog();
                        MessageBox.Show(opfd.FileName);
                        break;


                }//end of switch
            }//end of if confidence
        }//end of SRecognize_SpeechRecognized method
    }
}
