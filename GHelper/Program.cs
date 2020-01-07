using GHelper.Helper;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using static GHelper.Properties.Settings;
using static Logger.Logging;

[assembly: CLSCompliant(true)]
namespace GHelper
{
    public partial class GHelperEntryPoint
    {
        static readonly string CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;

        internal static string GamepadConnected;

        internal static GHelperForm ghelperForm;

        internal static int ShadowExStartupTime = 0;
        internal static int XpadderStartupTime = 0;

        internal static string XpadderProfilesPath = CurrentDirectory + @"\Utilities\Xpadder\Controller Profiles\";
        internal static string ShadowExLocation = CurrentDirectory + @"\ShadowEx.exe";
        internal static string XpadderLocation = CurrentDirectory + @"\Utilities\Xpadder\Xpadder.exe";
        internal static string[] GameShortcuts = null;

        internal static bool ChangesMade;

        [STAThread]
        public static void Main()
        {
            try
            {
                using (Mutex mutex = new Mutex(true, Assembly.GetExecutingAssembly().GetName().Name, out bool createdNew))
                {
                    if (createdNew)
                    {
                        Starter();
                    }
                    else
                    {
                        Process current = Process.GetCurrentProcess();

                        foreach (Process process in Process.GetProcessesByName(current.ProcessName))
                        {
                            if (process.Id != current.Id)
                            {
                                process.Kill();
                            }
                        }

                        NativeMethods.RefreshTrayArea();

                        Starter();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "GHelper", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void Starter()
        {

            if (Default.UpgradeRequired)
            {
                Default.Upgrade();
                Default.UpgradeRequired = false;
                Default.Save();
                Default.Reload();
            }

            Log();

            Info("Starting Application...", "Program");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                if (Directory.Exists(CurrentDirectory + "\\Games"))
                {
                    string[] fileEntries = Directory.GetFiles(CurrentDirectory + "\\Games");
                    foreach (string fileName in fileEntries)
                    {
                        try
                        {
                            if (!ShortcutInfo.ShortcutExists(fileName))
                            {
                                try
                                {
                                    File.Delete(fileName);
                                }
                                catch (Exception)
                                {
                                    //continue
                                }
                            }
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }
                }
            }
            catch (Exception)
            {
                //continue
            }

            TaskMaker.CreateTask();

            GetSettings();

            GetLocations();

            BuildGamesList();

            if (Default.StopGamingReminder)
            {
                Thread gameTimer = new Thread(GameStopTimerMethod)
                {
                    IsBackground = true
                };
                gameTimer.Start();
            }

            Info("Opening GHelperForm", "Program");

            ghelperForm = new GHelperForm();
            ghelperForm.Show();
            ghelperForm.Hide();

            Application.Run();
        }

        private static void GetSettings()
        {
            if (Default.XpadderStartupEnabled)
            {
                XpadderStartupTime = Convert.ToInt32(Default.XpadderStartup);
            }
            if (Default.GamepadConnected != "")
            {
                GamepadConnected = Default.GamepadConnected;
            }
            else
            {
                GamepadConnected = "Xbox 360 Controller";
            }
            if (Default.XpadderProfiles != "")
            {
                if (Default.XpadderProfiles.StartsWith("\\"))
                {
                    XpadderProfilesPath = CurrentDirectory + Default.XpadderProfiles;
                }
                else
                {
                    XpadderProfilesPath = Environment.ExpandEnvironmentVariables(Default.XpadderProfiles);
                }
            }
        }

        private static void GetLocations()
        {
            if (Default.XpadderLocation != "")
            {
                if (Default.XpadderLocation.StartsWith("\\"))
                {
                    XpadderLocation = CurrentDirectory + Default.XpadderLocation;
                }
                else
                {
                    XpadderLocation = Environment.ExpandEnvironmentVariables(Default.XpadderLocation);
                }
            }
        }

        private static void BuildGamesList()
        {
            if (Default.GameShortcutsFolder != "")
            {
                string GameShortcutsValue = null;
                string DirectoriesValue = Environment.ExpandEnvironmentVariables(Default.GameShortcutsFolder);

                if (DirectoriesValue != "" && Default.GameShortcutsFolder != @"%APPDATA%\Microsoft\Windows\Start Menu\Programs\Games\, %PROGRAMDATA%\Microsoft\Windows\Start Menu\Programs\Games\")
                {
                    GameShortcutsValue = DirectoriesValue;
                }
                if (GameShortcutsValue == null)
                {
                    int UserGameShortcuts = 0;
                    int AllUserGameShortcuts = 0;
                    try
                    {
                        try
                        {
                            if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Programs) + @"\Games\"))
                            {
                                foreach (string file in Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Programs) + @"\Games\"))
                                {
                                    UserGameShortcuts++;
                                }
                            }
                        }
                        catch (Exception)
                        {
                            //continue;
                        }
                        try
                        {
                            if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.CommonPrograms) + @"\Games\"))
                            {
                                foreach (string file in Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.CommonPrograms) + @"\Games\"))
                                {
                                    AllUserGameShortcuts++;
                                }
                            }
                        }
                        catch (Exception)
                        {
                            //continue;
                        }

                        if (UserGameShortcuts > 0 && AllUserGameShortcuts > 0)
                        {
                            Directory.CreateDirectory(CurrentDirectory + "\\Games");

                            foreach (string file in Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Programs) + @"\Games\"))
                            {
                                if (!File.Exists(CurrentDirectory + "\\Games\\" + Path.GetFileName(file)))
                                {
                                    File.Copy(file, CurrentDirectory + "\\Games\\" + Path.GetFileName(file));
                                }
                            }
                            foreach (string file in Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.CommonPrograms) + @"\Games\"))
                            {
                                if (!File.Exists(CurrentDirectory + "\\Games\\" + Path.GetFileName(file)))
                                {
                                    File.Copy(file, CurrentDirectory + "\\Games\\" + Path.GetFileName(file));
                                }
                            }
                            GameShortcuts = Directory.GetFiles(CurrentDirectory + "\\Games");
                        }
                        else if (UserGameShortcuts > 0)
                        {
                            GameShortcuts = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Programs) + @"\Games\");
                        }
                        else if (AllUserGameShortcuts > 0)
                        {
                            GameShortcuts = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.CommonPrograms) + @"\Games\");
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
                else
                {
                    try
                    {
                        if (Directory.Exists(GameShortcutsValue))
                        {
                            GameShortcuts = Directory.GetFiles(GameShortcutsValue);
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }

        private static void GameStopTimerMethod()
        {
            var StopTimeValue = Default.StopGamingTimer;
            var _stopGamingTimer = DateTimeToTimeSpan(StopTimeValue);
            while (true)
            {
                if (DateTimeToTimeSpan(DateTime.Now) == _stopGamingTimer)
                {
                    TimesUp timesUp = new TimesUp();
                    timesUp.Visible = false;
                    timesUp.ShowDialog();
                    Console.WriteLine("Keeping the application alive by writing something to the console...");
                    Thread.Sleep(60000);
                }
                Thread.Sleep(60000);
            }
        }

        private static TimeSpan DateTimeToTimeSpan(DateTime? ts)
        {
            if (!ts.HasValue) return TimeSpan.Zero;
            else return new TimeSpan(0, ts.Value.Hour, ts.Value.Minute);
        }
    }
}