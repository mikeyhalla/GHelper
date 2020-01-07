using Microsoft.Win32.TaskScheduler;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Security.Principal;
using System.Windows.Forms;
using static GHelper.Properties.Settings;

namespace GHelper
{
    public class TaskMaker
    {
        static readonly string CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;

        public static void CreateTask()
        {
            // Default - start at logon as user
            if (Default.StartupRequest == 1)
            {
                CreateShortcut(false);

                if (Taskexistance("GHelper") || Taskexistance("GHelper_Logon"))
                {
                    using (TaskService ts = new TaskService())
                    {
                        ts.RootFolder.DeleteTask(@"GHelper_Logon", false);
                        ts.RootFolder.DeleteTask(@"GHelper", false);
                    }
                }
            }
            // start at logon as admin
            else if (Default.StartupRequest == 2)
            {
                CreateShortcut(true);

                if (Taskexistance("GHelper") || !Taskexistance("GHelper_Logon"))
                {
                    using (TaskService ts = new TaskService())
                    {
                        ts.RootFolder.DeleteTask(@"GHelper", false);
                    }

                    if (IsAdministrator())
                    {
                        using (TaskService ts = new TaskService())
                        {
                            TaskDefinition td = ts.NewTask();
                            td.RegistrationInfo.Description = "GHelper_Logon";
                            td.Principal.RunLevel = TaskRunLevel.Highest;
                            td.Triggers.Add(new LogonTrigger { Enabled = true });

                            td.Actions.Add(Assembly.GetEntryAssembly().Location, null, CurrentDirectory);

                            ts.RootFolder.RegisterTaskDefinition(@"GHelper_Logon", td);
                        }

                        if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\GHelper.lnk"))
                        {
                            File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\GHelper.lnk");
                        }
                    }
                    else
                    {
                        using (Process proc = new Process())
                        {
                            proc.StartInfo.FileName = Assembly.GetEntryAssembly().Location;
                            proc.StartInfo.Verb = "runas";
                            proc.Start();
                        }

                        Environment.Exit(0);
                    }
                }
            }
            // start manually as admin
            else if (Default.StartupRequest == 3)
            {
                CreateShortcut(true, true);

                if (!Taskexistance("GHelper") || Taskexistance("GHelper_Logon"))
                {
                    using (TaskService ts = new TaskService())
                    {
                        ts.RootFolder.DeleteTask(@"GHelper_Logon", false);
                    }
                    if (IsAdministrator())
                    {
                        using (TaskService ts = new TaskService())
                        {
                            TaskDefinition td = ts.NewTask();
                            td.RegistrationInfo.Description = "GHelper";
                            td.Principal.RunLevel = TaskRunLevel.Highest;

                            td.Actions.Add(Assembly.GetEntryAssembly().Location, null, CurrentDirectory);

                            ts.RootFolder.RegisterTaskDefinition(@"GHelper", td);
                        }

                        if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\GHelper.lnk"))
                        {
                            File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\GHelper.lnk");
                        }
                    }
                    else
                    {
                        using (Process proc = new Process())
                        {
                            proc.StartInfo.FileName = Assembly.GetEntryAssembly().Location;
                            proc.StartInfo.Verb = "runas";
                            proc.Start();
                        }

                        Environment.Exit(0);
                    }
                }
            }
            // start manually as user
            else if (Default.StartupRequest == 4)
            {
                CreateShortcut(false, false);

                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\GHelper.lnk"))
                {
                    File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\GHelper.lnk");
                }

                if (Taskexistance("GHelper") || Taskexistance("GHelper_Logon"))
                {
                    using (TaskService ts = new TaskService())
                    {
                        ts.RootFolder.DeleteTask(@"GHelper_Logon", false);
                        ts.RootFolder.DeleteTask(@"GHelper", false);
                    }
                }
            }
        }

        private static void CreateShortcut(bool AsTask, bool NoStartup = false)
        {
            try
            {
                IWshRuntimeLibrary.WshShell lib = new IWshRuntimeLibrary.WshShell();

                IWshRuntimeLibrary.IWshShortcut _shortcut;

                if (AsTask)
                {
                    if (File.Exists(CurrentDirectory + "\\ArgsHidden.exe"))
                    {
                        string target = CurrentDirectory + "\\ArgsHidden.exe";
                        string args = null;
                        if (NoStartup)
                        {
                            args = "/task " + @"C:\Windows\System32\schtasks.exe" + " /run /tn " + "GHelper";
                        }
                        else
                        {
                            args = "/task " + @"C:\Windows\System32\schtasks.exe" + " /run /tn " + "GHelper_Logon";
                        }

                        string _programs = Environment.GetFolderPath(Environment.SpecialFolder.Programs);

                        _shortcut = (IWshRuntimeLibrary.IWshShortcut)lib.CreateShortcut(_programs + "\\GHelper.lnk");
                        _shortcut.TargetPath = target;
                        _shortcut.Arguments = args;
                        _shortcut.WorkingDirectory = CurrentDirectory;
                        _shortcut.IconLocation = Assembly.GetEntryAssembly().Location;
                        _shortcut.Description = "GHelper";
                        _shortcut.Save();
                    }
                }
                if (!AsTask)
                {
                    string _programs = Environment.GetFolderPath(Environment.SpecialFolder.Programs);
                    string _startup = Environment.GetFolderPath(Environment.SpecialFolder.Startup);

                    _shortcut = (IWshRuntimeLibrary.IWshShortcut)lib.CreateShortcut(_programs + "\\GHelper.lnk");
                    _shortcut.TargetPath = Assembly.GetEntryAssembly().Location;
                    _shortcut.WorkingDirectory = Path.GetDirectoryName(Application.ExecutablePath);
                    _shortcut.Description = "GHelper";
                    _shortcut.Arguments = null;
                    _shortcut.Save();
                    if (!NoStartup)
                    {
                        _shortcut = (IWshRuntimeLibrary.IWshShortcut)lib.CreateShortcut(_startup + "\\GHelper.lnk");
                        _shortcut.TargetPath = Assembly.GetEntryAssembly().Location;
                        _shortcut.WorkingDirectory = Path.GetDirectoryName(Application.ExecutablePath);
                        _shortcut.Description = "GHelper";
                        _shortcut.Arguments = null;
                        _shortcut.Save();
                    }
                }
            }
            catch (Exception)
            {
                // ignore
            }
        }

        public static bool Taskexistance(string taskname)
        {
            ProcessStartInfo start = new ProcessStartInfo()
            {
                FileName = "schtasks.exe",
                UseShellExecute = false,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                Arguments = "/query /TN " + taskname,
                RedirectStandardOutput = true
            };
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string stdout = reader.ReadToEnd();
                    if (stdout.Contains(taskname))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public static bool IsAdministrator()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}
