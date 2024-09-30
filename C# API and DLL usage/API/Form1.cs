using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using System.Diagnostics;

namespace API_Kullanımı
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("shell32.Dll")]
        public static extern int ShellExecute(int hWnd,
                                              string lpOperation,
                                              string lpFile,
                                              string lpDirectory,
                                              string lpParameters,
                                              int snShowCmd);

        [DllImport("shell32.Dll", EntryPoint = "ShellExecute")]
        public static extern int çalıştır(int hWnd,
                                              string lpOperation,
                                              string lpFile,
                                              string lpDirectory,
                                              string lpParameters,
                                              int snShowCmd);

        [DllImport("User32.Dll")]
        internal static extern bool ReleaseCapture();

        [DllImport("User32.Dll")]
        internal static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParm, int IParam);

        [DllImport("User32.Dll")]
        public static extern int ExitWindowsEx(int hFlags, int dwReserved);

        [DllImport("kernel32.Dll")]
        public static extern int WinExec(string lpCmdLine, int mCmdShow);

        [DllImport("kernel32.Dll")]
        public static extern int CopyFile(string lpExistingFile,
                                          string lpNewFile,
                                          bool bFailfExist);

        [DllImport("kernel32.Dll")] // Dosya Silen ifade
        public static extern int DeleteFile(string lpFileName);

        [DllImport("kernel32.Dll", EntryPoint = "GetWindowsDirectory")]
        public static extern int WinDiziniAl(StringBuilder lpFileName, int nSize);

        [DllImport("kernel32.Dll")]
        public static extern long GetTickCount();

        [DllImport("kernel32.Dll")]
        public static extern int GetComputerName(StringBuilder lpBuffer, ref int nSize);

        [DllImport("winmm.dll")]
        protected static extern int mciSendString(string lpstrCommand, StringBuilder lpstrReturnString, int uReturnLength, IntPtr hwndCallback);

        [DllImport("Shell32.dll", CharSet = CharSet.Unicode)]
        static extern uint SHEmptyRecycleBin(IntPtr hwnd, string pszRootPath, RecycleFlags dwFlags);

        enum RecycleFlags : uint
        {
            SHERB_NOCONFIRMATION = 0x00000001,
            SHERB_NOPROGRESSUI = 0x00000001,
            SHERB_NOSOUND = 0x00000004
        }

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]

        [return: MarshalAs(UnmanagedType.Bool)]

        static extern bool GetDiskFreeSpaceEx(string lpDirectoryName,
                                              out ulong lpFreeBytesAvailable,
                                              out ulong lpTotalNumberOfBytes,
                                              out ulong lpTotalNumberOfFreeBytes);

        private void button1_Click(object sender, EventArgs e)
        {
            ShellExecute(0, "open", "d:\\örnek.txt", "", "", 1);
            //çalıştır(0, "Open", "d:\\örnek.txt", "", "", 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShellExecute(0, "Open", "http://www.kayseri.edu.tr", "", "", 1);
            //çalıştır(0, "Open", "http://www.kayseri.edu.tr", "", "", 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //ShellExecute(0, "Open", "calc.exe", "", "", 1);
            çalıştır(0, "Open", "calc.exe", "", "", 1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            WinExec("c:\\windows\\NotePad.Exe", 1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //çalıştır(0, "Explore", "c:\\windows", "", "", 1);
            ShellExecute(0, "Explore", "c:\\windows", "", "", 1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ExitWindowsEx(0, 0);
            
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage((sender as Form).Handle, 0x0112, (IntPtr)0xF012, 0);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage((sender as PictureBox).Handle, 0x0112, (IntPtr)0xF012, 0);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            StringBuilder str = new StringBuilder(255);
            int sayı = str.Capacity;
            
            GetComputerName(str, ref sayı);

            label1.Text = str.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            StringBuilder str = new StringBuilder(50);
            WinDiziniAl(str, 50);
            label2.Text = str.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            long süre = GetTickCount() / 1000;
            
            int gg, ss, dd, nn;
            
            //label3.Text = süre.ToString();
            
            gg = (int) süre / 86400;
            süre = süre % 86400;

            ss = (int)süre / 3600;
            süre = süre % 3600;

            dd = (int)süre / 60;
            süre = süre % 60;

            nn = (int)süre;
            
            label3.Text = gg.ToString() + " gün, " + ss.ToString() + " saat, " + dd.ToString() + " dakika, " + nn.ToString() + " saniye";
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int sonuç = CopyFile(textBox1.Text, textBox2.Text, true);

            if (sonuç == 1) MessageBox.Show("Kopyalama Başarılı");
            else MessageBox.Show("Kopyalama Başarısız");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            int sonuç = DeleteFile(textBox1.Text);

            if (sonuç == 1) MessageBox.Show("Silme Başarılı");
            else MessageBox.Show("Silme Başarısız");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            mciSendString("set cdaudio door open", null, 0, IntPtr.Zero);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            mciSendString("set cdaudio door closed", null, 0, IntPtr.Zero);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            SHEmptyRecycleBin(IntPtr.Zero, null, 0);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            ulong toplamalan;
            ulong kullanılabilirboşalan;
            ulong toplamboşalan;

            bool sonuc = GetDiskFreeSpaceEx("D:", out kullanılabilirboşalan, out toplamalan, out toplamboşalan);
           
            if (!sonuc)
            {
                throw new System.ComponentModel.Win32Exception();
            }

            label4.Text = (toplamboşalan / (1024 * 1024 * 1024) ).ToString();

            label5.Text = (toplamalan / (1024 * 1024 * 1024) ).ToString();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            foreach (Process gorev in Process.GetProcesses())
            {
                listBox1.Items.Add(gorev.ProcessName);
            }

        }

        private void button17_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage((sender as Button).Handle, 0x0112, (IntPtr)0xF012, 0);
        }
    }
}
