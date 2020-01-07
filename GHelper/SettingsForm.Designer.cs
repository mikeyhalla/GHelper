namespace GHelper
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.button1 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.XpadderMouseProfileTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.XpadderCustomProfileTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.GamePadTextBox = new System.Windows.Forms.TextBox();
            this.GamesTextBox = new System.Windows.Forms.TextBox();
            this.XPadderProfilesTextBox = new System.Windows.Forms.TextBox();
            this.XpadderTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.StartWithGameBox = new System.Windows.Forms.TextBox();
            this.XpadderStartBox = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AutoStartBox = new System.Windows.Forms.CheckBox();
            this.AsUserBox = new System.Windows.Forms.CheckBox();
            this.AsAdminBox = new System.Windows.Forms.CheckBox();
            this.XpadderBox = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button9 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.GamepadBox = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.StopGamingTimerBox = new System.Windows.Forms.ComboBox();
            this.StopGamingBox = new System.Windows.Forms.CheckBox();
            this.stopGamingTimer = new System.Windows.Forms.DateTimePicker();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button1.Location = new System.Drawing.Point(309, 537);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 25);
            this.button1.TabIndex = 1;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 0;
            this.toolTip1.AutoPopDelay = 0;
            this.toolTip1.InitialDelay = 0;
            this.toolTip1.ReshowDelay = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Location = new System.Drawing.Point(11, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 15);
            this.label5.TabIndex = 50;
            this.label5.Text = "Xpadder";
            this.toolTip1.SetToolTip(this.label5, "The value is the amount of time in seconds in which to start the programs.\r\n0 = S" +
        "tart immediately\r\nOFF = Do Not Start");
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label13.Location = new System.Drawing.Point(11, 71);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 15);
            this.label13.TabIndex = 36;
            this.label13.Text = "Games";
            this.toolTip1.SetToolTip(this.label13, "Directory locations\r\nEnvironment Variables are supported\r\n  \\ = current directory" +
        "\r\n  %PROGRAMFILES(X86)% for 64 bit os\r\n  %PROGRAMFILES% for 32 bit os\r\nSeperate " +
        "entries with a comma");
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label14.Location = new System.Drawing.Point(29, 46);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 15);
            this.label14.TabIndex = 34;
            this.label14.Text = "Profiles";
            this.toolTip1.SetToolTip(this.label14, "Directory locations\r\nEnvironment Variables are supported\r\n  \\ = current directory" +
        "\r\n  %PROGRAMFILES(X86)% for 64 bit os\r\n  %PROGRAMFILES% for 32 bit os");
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label16.Location = new System.Drawing.Point(11, 20);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(54, 15);
            this.label16.TabIndex = 30;
            this.label16.Text = "Xpadder";
            this.toolTip1.SetToolTip(this.label16, "Directory locations\r\nEnvironment Variables are supported\r\n  \\ = current directory" +
        "\r\n  %PROGRAMFILES(X86)% for 64 bit os\r\n  %PROGRAMFILES% for 32 bit os");
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label11.Location = new System.Drawing.Point(11, 42);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 15);
            this.label11.TabIndex = 32;
            this.label11.Text = "Mouse";
            this.toolTip1.SetToolTip(this.label11, "Games that use the MouseX Xpadder Profile\r\n(Must have a profile in the profiles f" +
        "older name MouseX)");
            // 
            // XpadderMouseProfileTextBox
            // 
            this.XpadderMouseProfileTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.XpadderMouseProfileTextBox.Location = new System.Drawing.Point(108, 41);
            this.XpadderMouseProfileTextBox.Name = "XpadderMouseProfileTextBox";
            this.XpadderMouseProfileTextBox.Size = new System.Drawing.Size(303, 20);
            this.XpadderMouseProfileTextBox.TabIndex = 1;
            this.toolTip1.SetToolTip(this.XpadderMouseProfileTextBox, "Games that use the MouseX Xpadder Profile\r\n(Must have a profile in the profiles f" +
        "older name MouseX)");
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label12.Location = new System.Drawing.Point(11, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 15);
            this.label12.TabIndex = 30;
            this.label12.Text = "Custom";
            this.toolTip1.SetToolTip(this.label12, "Games that use a Custom Xpadder Profile by name of the game by value");
            // 
            // XpadderCustomProfileTextBox
            // 
            this.XpadderCustomProfileTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.XpadderCustomProfileTextBox.Location = new System.Drawing.Point(108, 15);
            this.XpadderCustomProfileTextBox.Name = "XpadderCustomProfileTextBox";
            this.XpadderCustomProfileTextBox.Size = new System.Drawing.Size(303, 20);
            this.XpadderCustomProfileTextBox.TabIndex = 0;
            this.toolTip1.SetToolTip(this.XpadderCustomProfileTextBox, "Games that use a Custom Xpadder Profile by name of the game by value");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Location = new System.Drawing.Point(11, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 15);
            this.label6.TabIndex = 35;
            this.label6.Text = "Connected";
            this.toolTip1.SetToolTip(this.label6, "Name of Gamepad connected (default is \"Xbox 360 Controller\")");
            // 
            // GamePadTextBox
            // 
            this.GamePadTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.GamePadTextBox.Location = new System.Drawing.Point(108, 19);
            this.GamePadTextBox.Name = "GamePadTextBox";
            this.GamePadTextBox.Size = new System.Drawing.Size(282, 20);
            this.GamePadTextBox.TabIndex = 0;
            this.toolTip1.SetToolTip(this.GamePadTextBox, "Name of Gamepad connected (default is \"Xbox 360 Controller\")\r\nYou can find the na" +
        "me in Windows Device Manager.");
            // 
            // GamesTextBox
            // 
            this.GamesTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.GamesTextBox.Location = new System.Drawing.Point(108, 70);
            this.GamesTextBox.Name = "GamesTextBox";
            this.GamesTextBox.Size = new System.Drawing.Size(227, 20);
            this.GamesTextBox.TabIndex = 6;
            this.toolTip1.SetToolTip(this.GamesTextBox, "Directory locations\r\nEnvironment Variables are supported\r\n  \\ = current directory" +
        "\r\n  %PROGRAMFILES(X86)% for 64 bit os\r\n  %PROGRAMFILES% for 32 bit os\r\nSeperate " +
        "entries with a comma");
            // 
            // XPadderProfilesTextBox
            // 
            this.XPadderProfilesTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.XPadderProfilesTextBox.Location = new System.Drawing.Point(108, 44);
            this.XPadderProfilesTextBox.Name = "XPadderProfilesTextBox";
            this.XPadderProfilesTextBox.Size = new System.Drawing.Size(227, 20);
            this.XPadderProfilesTextBox.TabIndex = 2;
            this.toolTip1.SetToolTip(this.XPadderProfilesTextBox, "Directory locations\r\nEnvironment Variables are supported\r\n  \\ = current directory" +
        "\r\n  %PROGRAMFILES(X86)% for 64 bit os\r\n  %PROGRAMFILES% for 32 bit os");
            // 
            // XpadderTextBox
            // 
            this.XpadderTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.XpadderTextBox.Location = new System.Drawing.Point(108, 18);
            this.XpadderTextBox.Name = "XpadderTextBox";
            this.XpadderTextBox.Size = new System.Drawing.Size(227, 20);
            this.XpadderTextBox.TabIndex = 0;
            this.toolTip1.SetToolTip(this.XpadderTextBox, "Directory locations\r\nEnvironment Variables are supported\r\n  \\ = current directory" +
        "\r\n  %PROGRAMFILES(X86)% for 64 bit os\r\n  %PROGRAMFILES% for 32 bit os");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(11, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 30;
            this.label2.Text = "Stop Gaming";
            this.toolTip1.SetToolTip(this.label2, "Games that use a Custom Xpadder Profile by name of the game by value");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(338, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 15);
            this.label1.TabIndex = 59;
            this.label1.Text = ":Seconds";
            this.toolTip1.SetToolTip(this.label1, "The value is the amount of time in seconds in which to start the programs.\r\n0 = S" +
        "tart immediately\r\nOFF = Do Not Start");
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label9.Location = new System.Drawing.Point(11, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 15);
            this.label9.TabIndex = 30;
            this.label9.Text = "Game::Program";
            this.toolTip1.SetToolTip(this.label9, "Start Program with game\r\nGAMENAME::PATHTOPROGRAM\r\nEx. EVE Online::C:\\ProgramData\\" +
        "Microsoft\\Windows\\Start Menu\\Programs\\Mumble\\Mumble.lnk\r\nSeperate entries with a" +
        " comma");
            // 
            // StartWithGameBox
            // 
            this.StartWithGameBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.StartWithGameBox.Location = new System.Drawing.Point(108, 15);
            this.StartWithGameBox.Name = "StartWithGameBox";
            this.StartWithGameBox.Size = new System.Drawing.Size(303, 20);
            this.StartWithGameBox.TabIndex = 0;
            this.toolTip1.SetToolTip(this.StartWithGameBox, "Start Program with game\r\nGAMENAME::PATHTOPROGRAM\r\nEx. EVE Online::C:\\ProgramData\\" +
        "Microsoft\\Windows\\Start Menu\\Programs\\Mumble\\Mumble.lnk\r\nSeperate entries with a" +
        " comma");
            // 
            // XpadderStartBox
            // 
            this.XpadderStartBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.XpadderStartBox.Location = new System.Drawing.Point(138, 46);
            this.XpadderStartBox.Name = "XpadderStartBox";
            this.XpadderStartBox.Size = new System.Drawing.Size(197, 20);
            this.XpadderStartBox.TabIndex = 5;
            this.toolTip1.SetToolTip(this.XpadderStartBox, "Directory locations\r\nEnvironment Variables are supported\r\n  \\ = current directory" +
        "\r\n  %PROGRAMFILES(X86)% for 64 bit os\r\n  %PROGRAMFILES% for 32 bit os");
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label20.Location = new System.Drawing.Point(100, 47);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(35, 15);
            this.label20.TabIndex = 64;
            this.label20.Text = "Time";
            this.toolTip1.SetToolTip(this.label20, "The value is the amount of time in seconds in which to start the programs.\r\n0 = S" +
        "tart immediately\r\nOFF = Do Not Start");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label8.Location = new System.Drawing.Point(11, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 15);
            this.label8.TabIndex = 65;
            this.label8.Text = "GHelper:";
            this.toolTip1.SetToolTip(this.label8, "The value is the amount of time in seconds in which to start the programs.\r\n0 = S" +
        "tart immediately\r\nOFF = Do Not Start");
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button2.Location = new System.Drawing.Point(161, 537);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(131, 25);
            this.button2.TabIndex = 0;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.groupBox1.Controls.Add(this.AutoStartBox);
            this.groupBox1.Controls.Add(this.AsUserBox);
            this.groupBox1.Controls.Add(this.AsAdminBox);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.XpadderStartBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.XpadderBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Location = new System.Drawing.Point(12, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(426, 82);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Startup";
            // 
            // AutoStartBox
            // 
            this.AutoStartBox.AutoSize = true;
            this.AutoStartBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.AutoStartBox.Location = new System.Drawing.Point(108, 20);
            this.AutoStartBox.Name = "AutoStartBox";
            this.AutoStartBox.Size = new System.Drawing.Size(93, 17);
            this.AutoStartBox.TabIndex = 66;
            this.AutoStartBox.TabStop = false;
            this.AutoStartBox.Text = "Start at Logon";
            this.AutoStartBox.UseVisualStyleBackColor = false;
            // 
            // AsUserBox
            // 
            this.AsUserBox.AutoSize = true;
            this.AsUserBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.AsUserBox.Location = new System.Drawing.Point(327, 20);
            this.AsUserBox.Name = "AsUserBox";
            this.AsUserBox.Size = new System.Drawing.Size(63, 17);
            this.AsUserBox.TabIndex = 2;
            this.AsUserBox.TabStop = false;
            this.AsUserBox.Text = "As User";
            this.AsUserBox.UseVisualStyleBackColor = false;
            // 
            // AsAdminBox
            // 
            this.AsAdminBox.AutoSize = true;
            this.AsAdminBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.AsAdminBox.Location = new System.Drawing.Point(231, 20);
            this.AsAdminBox.Name = "AsAdminBox";
            this.AsAdminBox.Size = new System.Drawing.Size(70, 17);
            this.AsAdminBox.TabIndex = 1;
            this.AsAdminBox.TabStop = false;
            this.AsAdminBox.Text = "As Admin";
            this.AsAdminBox.UseVisualStyleBackColor = false;
            // 
            // XpadderBox
            // 
            this.XpadderBox.AutoSize = true;
            this.XpadderBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.XpadderBox.Location = new System.Drawing.Point(405, 49);
            this.XpadderBox.Name = "XpadderBox";
            this.XpadderBox.Size = new System.Drawing.Size(15, 14);
            this.XpadderBox.TabIndex = 6;
            this.XpadderBox.TabStop = false;
            this.XpadderBox.UseVisualStyleBackColor = false;
            this.XpadderBox.CheckedChanged += new System.EventHandler(this.XpadderBox_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.groupBox3.Controls.Add(this.GamesTextBox);
            this.groupBox3.Controls.Add(this.XPadderProfilesTextBox);
            this.groupBox3.Controls.Add(this.XpadderTextBox);
            this.groupBox3.Controls.Add(this.button9);
            this.groupBox3.Controls.Add(this.button7);
            this.groupBox3.Controls.Add(this.button6);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox3.Location = new System.Drawing.Point(12, 218);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(426, 106);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Locations";
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button9.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button9.Location = new System.Drawing.Point(341, 70);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 20);
            this.button9.TabIndex = 7;
            this.button9.Text = "Browse";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button7.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button7.Location = new System.Drawing.Point(341, 44);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 20);
            this.button7.TabIndex = 3;
            this.button7.Text = "Browse";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button6.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button6.Location = new System.Drawing.Point(341, 18);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 20);
            this.button6.TabIndex = 1;
            this.button6.Text = "Browse";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.XpadderMouseProfileTextBox);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.XpadderCustomProfileTextBox);
            this.groupBox5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox5.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox5.Location = new System.Drawing.Point(12, 328);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(426, 75);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Xpadder";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.groupBox2.Controls.Add(this.GamepadBox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.GamePadTextBox);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox2.Location = new System.Drawing.Point(12, 161);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(426, 51);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gamepad";
            // 
            // GamepadBox
            // 
            this.GamepadBox.AutoSize = true;
            this.GamepadBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.GamepadBox.Location = new System.Drawing.Point(405, 22);
            this.GamepadBox.Name = "GamepadBox";
            this.GamepadBox.Size = new System.Drawing.Size(15, 14);
            this.GamepadBox.TabIndex = 1;
            this.GamepadBox.TabStop = false;
            this.GamepadBox.UseVisualStyleBackColor = false;
            this.GamepadBox.CheckedChanged += new System.EventHandler(this.GamepadBox_CheckedChanged);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button3.Location = new System.Drawing.Point(14, 537);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(131, 25);
            this.button3.TabIndex = 3;
            this.button3.Text = "Reset";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.groupBox4.Controls.Add(this.StopGamingTimerBox);
            this.groupBox4.Controls.Add(this.StopGamingBox);
            this.groupBox4.Controls.Add(this.stopGamingTimer);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox4.Location = new System.Drawing.Point(12, 468);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(426, 53);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Reminder";
            // 
            // StopGamingTimerBox
            // 
            this.StopGamingTimerBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.StopGamingTimerBox.Enabled = false;
            this.StopGamingTimerBox.FormattingEnabled = true;
            this.StopGamingTimerBox.Items.AddRange(new object[] {
            "Alarm01.wav",
            "Alarm02.wav",
            "Alarm03.wav",
            "Alarm04.wav",
            "Alarm05.wav",
            "Alarm06.wav",
            "Alarm07.wav",
            "Alarm08.wav",
            "Alarm09.wav",
            "Alarm10.wav"});
            this.StopGamingTimerBox.Location = new System.Drawing.Point(207, 15);
            this.StopGamingTimerBox.Name = "StopGamingTimerBox";
            this.StopGamingTimerBox.Size = new System.Drawing.Size(183, 21);
            this.StopGamingTimerBox.TabIndex = 1;
            // 
            // StopGamingBox
            // 
            this.StopGamingBox.AutoSize = true;
            this.StopGamingBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.StopGamingBox.Location = new System.Drawing.Point(405, 18);
            this.StopGamingBox.Name = "StopGamingBox";
            this.StopGamingBox.Size = new System.Drawing.Size(15, 14);
            this.StopGamingBox.TabIndex = 2;
            this.StopGamingBox.TabStop = false;
            this.StopGamingBox.UseVisualStyleBackColor = false;
            this.StopGamingBox.CheckedChanged += new System.EventHandler(this.StopGamingBox_CheckedChanged);
            // 
            // stopGamingTimer
            // 
            this.stopGamingTimer.CalendarMonthBackground = System.Drawing.Color.Gray;
            this.stopGamingTimer.Enabled = false;
            this.stopGamingTimer.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.stopGamingTimer.Location = new System.Drawing.Point(108, 15);
            this.stopGamingTimer.Name = "stopGamingTimer";
            this.stopGamingTimer.ShowUpDown = true;
            this.stopGamingTimer.Size = new System.Drawing.Size(93, 20);
            this.stopGamingTimer.TabIndex = 0;
            this.stopGamingTimer.Value = new System.DateTime(2017, 12, 21, 22, 0, 0, 0);
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.groupBox6.Controls.Add(this.StartWithGameBox);
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox6.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox6.Location = new System.Drawing.Point(12, 409);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(426, 53);
            this.groupBox6.TabIndex = 8;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Start with game";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GHelper.Properties.Resources.ICON;
            this.pictureBox1.Location = new System.Drawing.Point(20, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F);
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(88, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(350, 51);
            this.label3.TabIndex = 0;
            this.label3.Text = "GHelper Settings";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(450, 580);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GHelper Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox XpadderMouseProfileTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox XpadderCustomProfileTextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox GamePadTextBox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox GamesTextBox;
        private System.Windows.Forms.TextBox XPadderProfilesTextBox;
        private System.Windows.Forms.TextBox XpadderTextBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DateTimePicker stopGamingTimer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox StopGamingBox;
        private System.Windows.Forms.ComboBox StopGamingTimerBox;
        private System.Windows.Forms.CheckBox XpadderBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox StartWithGameBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox XpadderStartBox;
        private System.Windows.Forms.CheckBox GamepadBox;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox AsUserBox;
        private System.Windows.Forms.CheckBox AsAdminBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox AutoStartBox;
    }
}