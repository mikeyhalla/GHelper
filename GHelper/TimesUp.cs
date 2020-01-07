using System;
using System.Threading;
using System.Windows.Forms;

namespace GHelper
{
    public partial class TimesUp : Form
    {
        System.Media.SoundPlayer soundPlayer;

        public TimesUp()
        {
            InitializeComponent();

            Hide();

            soundPlayer = new System.Media.SoundPlayer(Environment.GetFolderPath(Environment.SpecialFolder.Windows) + "\\media\\" + Properties.Settings.Default.AlarmSound);
            soundPlayer.PlaySync();

            Thread th = new Thread(ExitTimer)
            {
                IsBackground = true
            };
            th.Start();
        }

        private void ExitTimer()
        {
            Thread.Sleep(5000);

            soundPlayer.Dispose();

            Close();
        }
    }
}
