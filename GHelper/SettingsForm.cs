using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using static GHelper.Properties.Settings;

namespace GHelper
{
    public partial class SettingsForm : Form
    {
        static readonly string AssemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public SettingsForm()
        {
            InitializeComponent();

            Load += Settings_Load;

            GetSettings();

            StopGamingTimerBox.SelectedValueChanged += StopGamingTimerBox_SelectedValueChanged;
        }

        private void StopGamingTimerBox_SelectedValueChanged(object sender, EventArgs e)
        {
            System.Media.SoundPlayer soundPlayer = new System.Media.SoundPlayer(Environment.GetFolderPath(Environment.SpecialFolder.Windows) + "\\media\\" + StopGamingTimerBox.Text);

            BeginInvoke(new Action(() => soundPlayer.PlaySync()));
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            WindowState = FormWindowState.Normal;
        }

        private void GetSettings()
        {
            // Default - start at logon as user
            if (Default.StartupRequest == 1)
            {
                AsUserBox.Checked = true;
                AutoStartBox.Checked = true;
            }
            // start at logon as admin
            else if (Default.StartupRequest == 2)
            {
                AsAdminBox.Checked = true;
                AutoStartBox.Checked = true;
            }
            // start manually as admin
            else if (Default.StartupRequest == 3)
            {
                AsAdminBox.Checked = true;
                AutoStartBox.Checked = false;
            }
            // start manually as user
            else if (Default.StartupRequest == 4)
            {
                AsUserBox.Checked = true;
                AutoStartBox.Checked = false;
            }

            if (Default.GamePadDetection)
            {
                GamePadTextBox.Enabled = true;
                GamePadTextBox.Text = Default.GamepadConnected;
                GamepadBox.Checked = true;
            }
            else
            {
                GamePadTextBox.Text = "";
                GamePadTextBox.Enabled = false;
                GamepadBox.Checked = false;
            }

            if (Default.XpadderStartupEnabled)
            {
                XpadderStartBox.Enabled = true;
                XpadderStartBox.Text = Default.XpadderStartup.ToString();
                XpadderBox.Checked = true;
            }
            else
            {
                XpadderStartBox.Text = "";
                XpadderStartBox.Enabled = false;
                XpadderBox.Checked = false;
            }

            if (Default.XpadderLocation != "")
            {
                if (Default.XpadderLocation.StartsWith("\\"))
                {
                    XpadderTextBox.Text = AssemblyDirectory + Default.XpadderLocation;
                }
                else
                {
                    XpadderTextBox.Text = Environment.ExpandEnvironmentVariables(Default.XpadderLocation);
                }
            }
            if (Default.XpadderProfiles != "")
            {
                if (Default.XpadderProfiles.StartsWith("\\"))
                {
                    XPadderProfilesTextBox.Text = AssemblyDirectory + Default.XpadderProfiles;
                }
                else
                {
                    XPadderProfilesTextBox.Text = Environment.ExpandEnvironmentVariables(Default.XpadderProfiles);
                }
            }
            if (Default.GameShortcutsFolder != "" && Default.GameShortcutsFolder != @"%APPDATA%\Microsoft\Windows\Start Menu\Programs\Games\, %PROGRAMDATA%\Microsoft\Windows\Start Menu\Programs\Games\")
            {
                if (Default.GameShortcutsFolder.StartsWith("\\"))
                {
                    GamesTextBox.Text = AssemblyDirectory + Default.GameShortcutsFolder;
                }
                else
                {
                    GamesTextBox.Text = Environment.ExpandEnvironmentVariables(Default.GameShortcutsFolder);
                }
            }
            else if (Default.GameShortcutsFolder == @"%APPDATA%\Microsoft\Windows\Start Menu\Programs\Games\, %PROGRAMDATA%\Microsoft\Windows\Start Menu\Programs\Games\")
            {
                GamesTextBox.ForeColor = Color.Gray;
                GamesTextBox.Text = "Default Value - Start Menu\\Programs\\Games";
            }

            XpadderCustomProfileTextBox.Text = Default.CustomX;
            XpadderMouseProfileTextBox.Text = Default.MouseX;

            stopGamingTimer.Value = Default.StopGamingTimer;
            if (Default.StopGamingReminder)
            {
                stopGamingTimer.Enabled = true;
                StopGamingTimerBox.Enabled = true;
                StopGamingBox.Checked = true;
            }
            else
            {
                stopGamingTimer.Enabled = false;
                StopGamingTimerBox.Enabled = false;
                StopGamingBox.Checked = false;
            }

            if (Default.StartWithGame != null)
            {
                StringBuilder builtString = new StringBuilder();

                foreach (string value in Default.StartWithGame)
                {
                    builtString.Append(value + ", ");
                }

                StartWithGameBox.Text = builtString.ToString().TrimEnd().TrimEnd(',');
            }

            if (Default.AlarmSound != null)
            {
                StopGamingTimerBox.Text = Default.AlarmSound;
            }

            GamesTextBox.TextChanged += TextBox12_TextChanged;

            this.XpadderBox.CheckedChanged += new System.EventHandler(this.XpadderBox_CheckedChanged);

            this.StopGamingBox.CheckedChanged += new System.EventHandler(this.StopGamingBox_CheckedChanged);

            this.AsAdminBox.CheckedChanged += new System.EventHandler(this.AsAdminBox_CheckedChanged);

            this.AsUserBox.CheckedChanged += new System.EventHandler(this.AsUserBox_CheckedChanged);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Reset changes
            GamesTextBox.TextChanged -= TextBox12_TextChanged;
            this.AsAdminBox.CheckedChanged -= new System.EventHandler(this.AsAdminBox_CheckedChanged);
            this.AsUserBox.CheckedChanged -= new System.EventHandler(this.AsUserBox_CheckedChanged);
            this.XpadderBox.CheckedChanged -= new System.EventHandler(this.XpadderBox_CheckedChanged);
            this.StopGamingBox.CheckedChanged -= new System.EventHandler(this.StopGamingBox_CheckedChanged);
            GetSettings();
        }

        private void TextBox12_TextChanged(object sender, EventArgs e)
        {
            GamesTextBox.ForeColor = SystemColors.WindowText;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Cancel and exit
            GHelperEntryPoint.ChangesMade = false;

            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (XpadderStartBox.Text != "")
            {
                Default.XpadderStartup = Convert.ToInt32(XpadderStartBox.Text);
            }
            else
            {
                Default.XpadderStartup = 0;
            }

            if (XpadderBox.Checked)
            {
                Default.XpadderStartupEnabled = true;
            }
            else
            {
                Default.XpadderStartupEnabled = false;
            }

            if (GamepadBox.Checked)
            {
                Default.GamePadDetection = true;
            }
            else
            {
                Default.GamePadDetection = false;
            }
            if (AsUserBox.Checked && AutoStartBox.Checked)
            {
                Default.StartupRequest = 1;
            }
            if (AsAdminBox.Checked && AutoStartBox.Checked)
            {
                Default.StartupRequest = 2;
            }
            if (AsAdminBox.Checked && !AutoStartBox.Checked)
            {
                Default.StartupRequest = 3;
            }
            if (AsUserBox.Checked && !AutoStartBox.Checked)
            {
                Default.StartupRequest = 4;
            }

            Default.GamepadConnected = GamePadTextBox.Text;
            Default.XpadderLocation = XpadderTextBox.Text;
            Default.XpadderProfiles = XPadderProfilesTextBox.Text;

            if (GamesTextBox.Text != "Default Value - Start Menu\\Programs\\Games")
            {
                Default.GameShortcutsFolder = GamesTextBox.Text;
            }
            Default.CustomX = XpadderCustomProfileTextBox.Text;
            Default.MouseX = XpadderMouseProfileTextBox.Text;

            if (StartWithGameBox.Text != string.Empty)
            {
                string[] SplitstartWithGameCollection = StartWithGameBox.Text.Split(',');
                Default.StartWithGame.Clear();
                foreach (string item in SplitstartWithGameCollection)
                {
                    Default.StartWithGame.Add(item.Trim());
                }
            }

            Default.StopGamingTimer = stopGamingTimer.Value;
            if (StopGamingBox.Checked)
            {
                Default.StopGamingReminder = true;
            }
            else
            {
                Default.StopGamingReminder = false;
            }

            Default.AlarmSound = StopGamingTimerBox.Text;

            Default.Save();

            GHelperEntryPoint.ChangesMade = true;

            Close();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "exe files (*.exe)|*.exe|All files (*.*)|*.*";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                XpadderTextBox.Text = openFileDialog1.FileName;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = "C:\\";
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                XPadderProfilesTextBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = "C:\\";
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                GamesTextBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void AsAdminBox_CheckedChanged(object sender, EventArgs e)
        {
            if (AsAdminBox.Checked)
            {
                AsUserBox.Checked = false;
            }
            else
            {
                AsUserBox.Checked = true;
            }
        }

        private void AsUserBox_CheckedChanged(object sender, EventArgs e)
        {
            if (AsUserBox.Checked)
            {
                AsAdminBox.Checked = false;
            }
            else
            {
                AsAdminBox.Checked = true;
            }
        }

        private void XpadderBox_CheckedChanged(object sender, EventArgs e)
        {
            if (XpadderBox.Checked)
            {
                XpadderStartBox.Enabled = true;
            }
            else
            {
                XpadderStartBox.Text = "";
                XpadderStartBox.Enabled = false;
            }
        }

        private void StopGamingBox_CheckedChanged(object sender, EventArgs e)
        {
            if (StopGamingBox.Checked)
            {
                stopGamingTimer.Enabled = true;
                StopGamingTimerBox.Enabled = true;
            }
            else
            {
                stopGamingTimer.Enabled = false;
                StopGamingTimerBox.Enabled = false;
            }
        }

        private void GamepadBox_CheckedChanged(object sender, EventArgs e)
        {
            if (GamepadBox.Checked)
            {
                GamePadTextBox.Enabled = true;
                GamePadTextBox.Text = Default.GamepadConnected;
            }
            else
            {
                GamePadTextBox.Text = "";
                GamePadTextBox.Enabled = false;
            }
        }
    }
}
