using GHelper.Helper;
using GHelperFanNotifier.Properties;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace GHelperFanNotifier
{
    public partial class NotifyForm : Form
    {
        static readonly string AssemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public NotifyForm()
        {
            Load += Form1_Load;

            InitializeComponent();

            if (File.Exists(AssemblyDirectory + "\\FanControl.exe"))
            {
                using (Process proc2 = new Process())
                {
                    proc2.StartInfo.Arguments = "ON";
                    proc2.StartInfo.FileName = AssemblyDirectory + Resources.FanControl;
                    proc2.Start();
                }
            }

            Thread th = new Thread(GHelperWatcher)
            {
                IsBackground = true
            };
            th.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Visible = false;

            Hide();
        }

        private void GHelperWatcher()
        {
            while (true)
            {
                if (Process.GetProcessesByName("GHelper").Length == 0)
                {
                    notifyIcon1_MouseDoubleClick(null, null);
                }
                Thread.Sleep(2000);
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            using (Process proc2 = new Process())
            {
                proc2.StartInfo.Arguments = "OFF";
                proc2.StartInfo.FileName = AssemblyDirectory + Resources.FanControl;
                proc2.Start();
            }

            foreach (Process process in Process.GetProcessesByName(Resources.Xpadder))
            {
                foreach (ProcessThread thread in process.Threads)
                {
                    NativeMethods.CriticalHandle.PostThreadMessage(thread.Id, NativeMethods.CriticalHandle.WM_QUIT, IntPtr.Zero, IntPtr.Zero);
                }
                process.WaitForExit(1000);
            }
            notifyIcon1.Visible = false;
            Environment.Exit(0);
        }
    }
}
