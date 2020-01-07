using GHelper.Helper;
using GHelper.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static GHelper.GHelperEntryPoint;
using static GHelper.Properties.Settings;
using static Logger.Logging;

namespace GHelper
{
    public partial class GHelperForm : Form, IDisposable
    {
        static int NotifyThreads = 0;
        internal static string GameRunning = "NOGAME";

        static int ThreadOn = 0;
        static int Catch = 0;
        internal static bool connected = false;
        static bool Xbox = false;
        internal static TimeSpan SystemUpTime;
        internal static TimeSpan TimeCompare;
        static readonly string AssemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public GHelperForm()
        {
            GameWatcher.Watch();

            FormClosing += UsbDetect_FormClosing;

            if (File.Exists(ShadowExLocation))
            {
                Thread serverTalk = new Thread(SendGameUDP.ServerTalk)
                {
                    IsBackground = true
                };
                serverTalk.Start();
            }

            Info("Initializing GHelperForm", "GHelperForm");

            InitializeComponent();

            Visible = false;


            Info("Creating Notify icon", "GHelperForm");

            BuildNotifyArea();
        }

        private void BuildNotifyArea()
        {
            var Default = Settings.Default;

            TimeCompare = TimeSpan.FromMinutes(5);
            using (var uptime = new PerformanceCounter("System", "System Up Time"))
            {
                uptime.NextValue();
                SystemUpTime = TimeSpan.FromSeconds(uptime.NextValue());
            }
            if (Default.XpadderStartupEnabled)
            {
                if (!File.Exists(XpadderLocation))
                {
                    Thread thread = new Thread(StartXpadder)
                    {
                        IsBackground = true
                    };
                    thread.Start();
                }
            }
            int OptionalItems = 3;
            if (!File.Exists(AssemblyDirectory + Resources.ShadowEx))
            {
                OptionalItems--;
                ShadowExMenuItem.Visible = false;
            }
            if (!File.Exists(XpadderLocation))
            {
                OptionalItems--;
                XpadderMenuItem.Visible = false;
            }
            if (!File.Exists(AssemblyDirectory + Resources.FanControl))
            {
                OptionalItems--;
                this.BoostHeatSinkMenuItem.Visible = false;
            }
            if (OptionalItems == 0)
            {
                this.toolStripSeparator2.Visible = false;
            }

            notifyIcon1.DoubleClick += NotifyIcon1_DoubleClick;

            notifyIcon1.Visible = true;
            notifyIcon1.Text = "GHelper";
        }

        private void UsbDetect_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon1.Visible = false;
            Dispose(true);
        }

        protected override void WndProc(ref Message m)
        {
            var Default = Settings.Default;
            switch (m.Msg)
            {
                case NativeMethods.CurrentStateUsb.Wmdevicechange:
                    if (Default.GamePadDetection)
                    {
                        if (!NativeMethods.CriticalHandle.ScreenDetection.AreApplicationFullScreen())
                        {
                            Thread.Sleep(500);
                            Thread th = new Thread(DevCheck)
                            {
                                IsBackground = true
                            };
                            th.Start();
                        }
                    }
                    break;
            }
            base.WndProc(ref m);
        }

        static void DevCheck()
        {
            StringBuilder stringBuilder = new StringBuilder();
            var usbDevices = GetUSBDevices();
            foreach (var usbDevice in usbDevices)
            {
                stringBuilder.Append(usbDevice.Description);
            }
            if (stringBuilder.ToString().Contains(GamepadConnected))
            {
                if (ThreadOn == 0)
                {
                    stringBuilder.Clear();
                    ThreadOn++;
                    ThreadOn++;
                    Catcher();
                }
            }
            else if (!stringBuilder.ToString().Contains(GamepadConnected))
            {
                if (Xbox)
                {
                    ThreadOn = 0;
                    Catch = 0;
                    Xbox = false;
                    stringBuilder.Clear();
                    StopGaming();
                }
            }
        }
        static void Catcher()
        {
            if (Catch == 0)
            {
                Catch++;
                Xbox = true;
                StartGaming();
                RunXpadder();
            }
        }
        public static void StartGaming()
        {
            try
            {
                Info("Starting Fan booster", "GHelperForm");
                connected = true;
                if (File.Exists(AssemblyDirectory + Resources.ShadowEx))
                {
                    using (Process ShadowEx = new Process())
                    {
                        ShadowEx.StartInfo.Arguments = Resources.startShadowEx;
                        ShadowEx.StartInfo.FileName = AssemblyDirectory + Resources.ShadowEx;
                        ShadowEx.Start();
                    }
                }
                if (File.Exists(XpadderProfilesPath + "EmptyX.xpadderprofile"))
                {
                    using (Process proc2 = new Process())
                    {
                        proc2.StartInfo.FileName = XpadderProfilesPath + "EmptyX.xpadderprofile";
                        proc2.Start();
                        if (!proc2.Start())
                        {
                            try
                            {
                                Process.Start(XpadderLocation);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show(Resources.Associate);
                            }
                        }
                    }
                }
                if (File.Exists(AssemblyDirectory + Resources.FanControl))
                {
                    using (Process proc = new Process())
                    {
                        proc.StartInfo.Arguments = "ON";
                        proc.StartInfo.FileName = AssemblyDirectory + Resources.FanControl;
                        proc.Start();
                    }
                }
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                MessageBox.Show(ex.Message, "GHelper", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        static void StopGaming()
        {
            try
            {
                Info("Stopping Fan booster", "GHelperForm");
                connected = false;
                if (File.Exists(XpadderProfilesPath + "EmptyX.xpadderprofile"))
                {
                    using (Process proc2 = new Process())
                    {
                        proc2.StartInfo.FileName = XpadderProfilesPath + "EmptyX.xpadderprofile";
                        proc2.Start();
                    }
                }
                if (File.Exists(AssemblyDirectory + Resources.FanControl))
                {
                    using (Process pr = new Process())
                    {
                        pr.StartInfo.Arguments = Resources.OFF;
                        pr.StartInfo.FileName = AssemblyDirectory + Resources.FanControl;
                        pr.Start();
                    }
                }
                if (File.Exists(AssemblyDirectory + Resources.ShadowEx))
                {
                    using (Process ShadowEx = new Process())
                    {
                        ShadowEx.StartInfo.Arguments = Resources.ShutDown;
                        ShadowEx.StartInfo.FileName = AssemblyDirectory + Resources.ShadowEx;
                        ShadowEx.Start();
                    }
                }
                foreach (Process process in Process.GetProcessesByName(Resources.Xpadder))
                {
                    foreach (ProcessThread thread in process.Threads)
                    {
                        NativeMethods.CriticalHandle.PostThreadMessage(thread.Id, NativeMethods.CriticalHandle.WM_QUIT, IntPtr.Zero, IntPtr.Zero);
                    }
                    process.WaitForExit(1000);
                }
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                MessageBox.Show(ex.Message, "GHelper", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        static List<NativeMethods.USBDeviceInfo> GetUSBDevices()
        {
            List<NativeMethods.USBDeviceInfo> devices = new List<NativeMethods.USBDeviceInfo>();
            ManagementObjectCollection collection = null;
            try
            {
                using (var searcher = new ManagementObjectSearcher(@"Select * From Win32_PnPEntity"))
                    collection = searcher.Get();

                foreach (var device in collection)
                {
                    devices.Add(new NativeMethods.USBDeviceInfo(
                        (string)device.GetPropertyValue("Description")));
                }
            }
            catch (ManagementException ex)
            {
                MessageBox.Show(ex.Message + Resources.Reboot);
            }

            collection.Dispose();
            return devices;
        }

        public static void RunXpadder()
        {
            try
            {
                Info("Starting Xpadder", "GHelperForm");
                while (connected)
                {
                    bool MatchFound = false;
                    bool CustomFound = false;

                    if (GameRunning != "NOGAME")
                    {
                        if (Default != null)
                        {
                            if (Default.StartWithGame != null)
                            {
                                foreach (var ProgramValue in Default.StartWithGame)
                                {
                                    string GameValue = ProgramValue.Substring(0, ProgramValue.IndexOf(":") + 1).Replace(":", "").TrimStart();
                                    if (GameRunning == GameValue)
                                    {
                                        string prog = ProgramValue.Substring(ProgramValue.IndexOf(":"));
                                        string ProgramToStart = prog.Replace("::", "");
                                        using (Process proc = new Process())
                                        {
                                            proc.StartInfo.FileName = ProgramToStart;
                                            proc.Start();
                                        }
                                    }
                                }
                            }
                        }
                        string[] CustomXSplit = Default.CustomX.Split(',');
                        foreach (string item in CustomXSplit)
                        {
                            string game = item.Trim();
                            if (game == GameRunning)
                            {
                                MatchFound = true;
                                CustomFound = true;
                                if (File.Exists(XpadderProfilesPath + GameRunning + ".xpadderprofile"))
                                {
                                    using (Process proc2 = new Process())
                                    {
                                        proc2.StartInfo.FileName = XpadderProfilesPath + GameRunning + ".xpadderprofile";
                                        proc2.Start();
                                        GameRunning = "NOGAME";
                                    }
                                }
                            }
                        }
                        if (!CustomFound)
                        {
                            string[] MouseXSplit = Default.MouseX.Split(',');
                            foreach (string item in MouseXSplit)
                            {
                                string game = item.Trim();
                                if (game == GameRunning)
                                {
                                    MatchFound = true;
                                    if (File.Exists(XpadderProfilesPath + "MouseX.xpadderprofile"))
                                    {
                                        using (Process proc2 = new Process())
                                        {
                                            proc2.StartInfo.FileName = XpadderProfilesPath + "MouseX.xpadderprofile";
                                            proc2.Start();
                                            GameRunning = "NOGAME";
                                        }
                                    }
                                }
                            }
                        }
                        if (!MatchFound)
                        {
                            if (File.Exists(XpadderProfilesPath + "EmptyX.xpadderprofile"))
                            {
                                using (Process proc2 = new Process())
                                {
                                    proc2.StartInfo.FileName = XpadderProfilesPath + "EmptyX.xpadderprofile";
                                    proc2.Start();
                                    GameRunning = "NOGAME";
                                }
                            }
                        }
                    }
                    Thread.Sleep(1000);
                }
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                MessageBox.Show(ex.Message, "GHelper", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenGame_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem TSMI = (ToolStripMenuItem)sender;
            string GameToRun = TSMI.Text;

            Info("Opening Game: " + GameToRun, "GHelperForm");

            foreach (var file in GameShortcuts)
            {
                if (Path.GetFileNameWithoutExtension(file) == GameToRun)
                {
                    GameRunning = GameToRun;

                    if (!connected)
                    {
                        connected = true;
                        try
                        {
                            Thread th = new Thread(RunXpadder)
                            {
                                IsBackground = true
                            };
                            th.Start();
                        }
                        catch (System.ComponentModel.Win32Exception ex)
                        {
                            MessageBox.Show(ex.Message, "GHelper", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    using (Process proc = new Process())
                    {
                        proc.StartInfo.FileName = file;
                        proc.Start();
                    }
                    try
                    {
                        if (File.Exists(AssemblyDirectory + "\\FanControl.exe"))
                        {
                            Process[] pname = Process.GetProcessesByName("GHelperFanNotifier");
                            if (pname.Length == 0)
                            {
                                using (Process proc = new Process())
                                {
                                    proc.StartInfo.FileName = AssemblyDirectory + "\\GHelperFanNotifier.exe";
                                    proc.Start();
                                }
                            }
                            if (NotifyThreads == 0)
                            {
                                NotifyThreads++;
                                Thread th = new Thread(GHelperNotifyWatcher)
                                {
                                    IsBackground = true
                                };
                                th.Start();
                            }
                        }
                    }
                    catch (System.ComponentModel.Win32Exception ex)
                    {
                        MessageBox.Show(ex.Message, "GHelper", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Note_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem TSMI = (ToolStripMenuItem)sender;
            string ShortcutToRun = TSMI.Text;
            foreach (string noteToRun in Directory.GetFiles(AssemblyDirectory + "\\Notes"))
            {
                if (Path.GetFileNameWithoutExtension(noteToRun) == ShortcutToRun)
                {
                    try
                    {
                        using (Process proc = new Process())
                        {
                            proc.StartInfo.FileName = noteToRun;
                            proc.Start();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "GHelper", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void NotesMenuItem_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(AssemblyDirectory + "\\Notes"))
            {
                try
                {
                    using (Process proc = new Process())
                    {
                        proc.StartInfo.FileName = AssemblyDirectory + "\\Notes";
                        proc.Start();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "GHelper", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void NotifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            using (SettingsForm settings = new SettingsForm())
            {
                settings.ShowDialog();
            }
            if (ChangesMade)
            {
                RestartMenuItem_Click(null, null);
            }
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(AssemblyDirectory + "\\FanControl.exe") && BoostHeatSinkMenuItem.Checked)
            {
                BoostHeatSinkMenuItem_Click(null, null);
            }
            Close();

            notifyIcon1.Visible = false;

            if (GameWatcher.watcher != null)
            {
                GameWatcher.watcher.Dispose();
            }
            if (GameWatcher.watcher2 != null)
            {
                GameWatcher.watcher2.Dispose();
            }
            if (GameWatcher.watcher3 != null)
            {
                GameWatcher.watcher3.Dispose();
            }

            Warning("Exiting", "GHelperForm");

            Environment.Exit(0);
        }

        internal static void RestartMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                notifyIcon1.Visible = false;

                if (GameWatcher.watcher != null)
                {
                    GameWatcher.watcher.Dispose();
                }
                if (GameWatcher.watcher2 != null)
                {
                    GameWatcher.watcher2.Dispose();
                }
                if (GameWatcher.watcher3 != null)
                {
                    GameWatcher.watcher3.Dispose();
                }

                Warning("Exiting", "GHelperForm");

                if (TaskMaker.Taskexistance("GHelper"))
                {
                    using (Process GH = new Process())
                    {
                        GH.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        GH.StartInfo.Arguments = Resources.GHelperStart;
                        GH.StartInfo.FileName = AssemblyDirectory + Resources.argsHidden;
                        GH.Start();
                    }
                }
                else if (TaskMaker.Taskexistance("GHelper_Logon"))
                {
                    using (Process GH = new Process())
                    {
                        GH.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        GH.StartInfo.Arguments = Resources.GHelperStartLogon;
                        GH.StartInfo.FileName = AssemblyDirectory + Resources.argsHidden;
                        GH.Start();
                    }
                }
                else
                {
                    using (Process GH = new Process())
                    {
                        GH.StartInfo.FileName = AssemblyDirectory + Resources.GHelperExe;
                        GH.Start();
                    }
                }

                Environment.Exit(0);
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                MessageBox.Show("An error has occurred. Please check the log file in: " + Path.GetTempPath(), "GHelper", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                Error(ex, "GHelperForm");

                Environment.Exit(0);

            }
        }

        private void SettingsMenuItem_Click(object sender, EventArgs e)
        {
            using (SettingsForm settings = new SettingsForm())
            {
                settings.ShowDialog();
            }
            if (ChangesMade)
            {
                RestartMenuItem_Click(null, null);
            }
        }

        private void XpadderMenuItem_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(StartXpadder)
            {
                IsBackground = true
            };
            thread.Start();
        }

        private void ShadowExMenuItem_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(StartShadowEx)
            {
                IsBackground = true
            };
            thread.Start();
        }

        private void BoostHeatSinkMenuItem_Click(object sender, EventArgs e)
        {
            if (!BoostHeatSinkMenuItem.Checked)
            {
                try
                {
                    using (Process proc2 = new Process())
                    {
                        proc2.StartInfo.Arguments = "ON";
                        proc2.StartInfo.FileName = AssemblyDirectory + Resources.FanControl;
                        proc2.Start();
                    }
                }
                catch (System.ComponentModel.Win32Exception ex)
                {
                    MessageBox.Show(ex.Message, "GHelper", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                BoostHeatSinkMenuItem.Checked = true;
            }
            else
            {
                try
                {
                    using (Process proc2 = new Process())
                    {
                        proc2.StartInfo.Arguments = Resources.OFF;
                        proc2.StartInfo.FileName = AssemblyDirectory + Resources.FanControl;
                        proc2.Start();
                    }
                }
                catch (System.ComponentModel.Win32Exception ex)
                {
                    MessageBox.Show(ex.Message, "GHelper", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                BoostHeatSinkMenuItem.Checked = false;
            }
        }

        private void GHelperNotifyWatcher()
        {
            bool checking = true;
            while (checking)
            {
                if (Process.GetProcessesByName("GHelperFanNotifier").Length == 0)
                {
                    BoostHeatSinkMenuItem.Checked = false;
                    checking = false;
                    NotifyThreads--;
                    Console.WriteLine("Keeping the application alive by writing something to the console...");
                }
                Thread.Sleep(2000);
            }
        }

        internal static void StartXpadder()
        {
            try
            {
                if (SystemUpTime > TimeCompare)
                {
                    goto Startit;
                }
                bool waiting = true;
                int Sleep = 0;
                while (waiting)
                {
                    if (Sleep >= XpadderStartupTime)
                    {
                        waiting = false;
                    }
                    Sleep++;
                    Thread.Sleep(1000);
                }
            Startit:;
                if (Process.GetProcessesByName("Xpadder").Length == 0)
                {
                    try
                    {
                        if (File.Exists(XpadderProfilesPath + "EmptyX.xpadderprofile"))
                        {
                            using (Process proc = new Process())
                            {
                                proc.StartInfo.FileName = XpadderProfilesPath + "EmptyX.xpadderprofile";
                                proc.Start();
                            }
                        }
                    }
                    catch (System.ComponentModel.Win32Exception)
                    {
                        MessageBox.Show(Resources.Associate, "GHelper", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "GHelper", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        internal static void StartShadowEx()
        {
            try
            {
                if (SystemUpTime > TimeCompare)
                {
                    goto Startit;
                }
                bool waiting = true;
                int Sleep = 0;
                while (waiting)
                {
                    if (Sleep >= ShadowExStartupTime)
                    {
                        waiting = false;
                    }
                    Sleep++;
                    Thread.Sleep(1000);
                }
            Startit:;
                if (Process.GetProcessesByName("ShadowEx").Length == 0)
                {
                    try
                    {
                        if (File.Exists(ShadowExLocation))
                        {
                            using (Process proc = new Process())
                            {
                                proc.StartInfo.FileName = ShadowExLocation;
                                proc.Start();
                            }
                        }
                    }
                    catch (System.ComponentModel.Win32Exception ex)
                    {
                        MessageBox.Show(ex.Message, "GHelper", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "GHelper", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
