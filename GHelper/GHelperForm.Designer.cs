using GHelper.Properties;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static GHelper.BuildNotifyMenu;

namespace GHelper
{
    partial class GHelperForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GHelperForm));
            notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BoostHeatSinkMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShadowExMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NotesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.XpadderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RestartMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GamesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            // 
            // BoostHeatSinkMenuItem
            // 
            this.BoostHeatSinkMenuItem.Name = "BoostHeatSinkMenuItem";
            this.BoostHeatSinkMenuItem.Size = new System.Drawing.Size(241, 22);
            this.BoostHeatSinkMenuItem.Text = "Boost Heatsink Fan";
            this.BoostHeatSinkMenuItem.Click += new System.EventHandler(this.BoostHeatSinkMenuItem_Click);
            // 
            // ShadowExMenuItem
            // 
            this.ShadowExMenuItem.Name = "ShadowExMenuItem";
            this.ShadowExMenuItem.Size = new System.Drawing.Size(241, 22);
            this.ShadowExMenuItem.Text = "ShadowEx";
            this.ShadowExMenuItem.Click += new System.EventHandler(this.ShadowExMenuItem_Click);
            // 
            // NotesMenuItem
            // 
            this.NotesMenuItem.Name = "NotesMenuItem";
            this.NotesMenuItem.Size = new System.Drawing.Size(241, 22);
            this.NotesMenuItem.Text = "Notes and Guides";
            this.NotesMenuItem.Click += new System.EventHandler(this.NotesMenuItem_Click);
            // 
            // XpadderMenuItem
            // 
            this.XpadderMenuItem.Name = "XpadderMenuItem";
            this.XpadderMenuItem.Size = new System.Drawing.Size(241, 22);
            this.XpadderMenuItem.Text = "Xpadder";
            this.XpadderMenuItem.Click += new System.EventHandler(this.XpadderMenuItem_Click);
            // 
            // SettingsMenuItem
            // 
            this.SettingsMenuItem.Name = "SettingsMenuItem";
            this.SettingsMenuItem.Size = new System.Drawing.Size(241, 22);
            this.SettingsMenuItem.Text = "Settings";
            this.SettingsMenuItem.Click += new System.EventHandler(this.SettingsMenuItem_Click);
            // 
            // RestartMenuItem
            // 
            this.RestartMenuItem.Name = "RestartMenuItem";
            this.RestartMenuItem.Size = new System.Drawing.Size(241, 22);
            this.RestartMenuItem.Text = "Restart";
            this.RestartMenuItem.Click += new System.EventHandler(RestartMenuItem_Click);
            // 
            // ExitMenuItem
            // 
            this.ExitMenuItem.Name = "ExitMenuItem";
            this.ExitMenuItem.Size = new System.Drawing.Size(241, 22);
            this.ExitMenuItem.Text = "Exit";
            this.ExitMenuItem.Click += new System.EventHandler(this.ExitMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator";
            this.toolStripSeparator1.Size = new System.Drawing.Size(238, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator";
            this.toolStripSeparator2.Size = new System.Drawing.Size(238, 6);
            // 
            // GamesMenuItem
            // 
            this.GamesMenuItem.Name = "GamesMenuItem";
            this.GamesMenuItem.Size = new System.Drawing.Size(241, 22);
            this.GamesMenuItem.Text = "Games";
            // 
            // GHelperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GHelperForm";
            this.Opacity = 0D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "USBDetect";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);


            this.GamesMenuItem.ForeColor = Color.FromArgb(230, 230, 230);
            this.NotesMenuItem.ForeColor = Color.FromArgb(230, 230, 230);
            this.contextMenuStrip1.ForeColor = Color.FromArgb(230, 230, 230);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = ToolStripRenderMode.ManagerRenderMode;
            this.contextMenuStrip1.ShowCheckMargin = false;
            this.contextMenuStrip1.ShowImageMargin = true;
            this.contextMenuStrip1.Size = new Size(242, 204);

            this.contextMenuStrip1.Renderer = new MyRenderer();

            if (GHelperEntryPoint.GameShortcuts != null)
            {
                foreach (string game in GHelperEntryPoint.GameShortcuts)
                {
                    gameItem = new ToolStripMenuItem();
                    gameItem.ForeColor = Color.FromArgb(230, 230, 230);
                    gameItem.Name = Path.GetFileNameWithoutExtension(game);
                    gameItem.Text = Path.GetFileNameWithoutExtension(game);
                    try
                    {
                        if (File.Exists(game))
                        {
                            IWshRuntimeLibrary.WshShell shell = new IWshRuntimeLibrary.WshShell();

                            IWshRuntimeLibrary.IWshShortcut link = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(game);

                            gameItem.Image = Icon.ExtractAssociatedIcon(link.TargetPath).ToBitmap();
                        }
                    }
                    catch (Exception)
                    {
                        // ignore
                    }
                    gameItem.Click += OpenGame_Click;

                    GamesMenuItem.DropDownItems.Add(gameItem);
                }
                this.contextMenuStrip1.Items.Add(GamesMenuItem);
                this.contextMenuStrip1.Items.Add(toolStripSeparator1);
            }
            if (!Directory.Exists(AssemblyDirectory + "\\Notes"))
            {
                Directory.CreateDirectory(AssemblyDirectory + "\\Notes");
            }

            foreach (string item in Directory.GetFiles(AssemblyDirectory + "\\Notes"))
            {
                try
                {
                    if (!File.GetAttributes(item).HasFlag(FileAttributes.Hidden) && !File.GetAttributes(item).HasFlag(FileAttributes.System))
                    {
                        note = new ToolStripMenuItem
                        {
                            ForeColor = Color.FromArgb(230, 230, 230),
                            Name = Path.GetFileNameWithoutExtension(item),
                            Text = Path.GetFileNameWithoutExtension(item)
                        };

                        note.Click += Note_Click;

                        NotesMenuItem.DropDownItems.Add(note);
                    }
                }
                catch (Exception)
                {
                    // ignore
                }
            }

            this.contextMenuStrip1.Items.Add(NotesMenuItem);

            this.contextMenuStrip1.Items.AddRange(new ToolStripItem[] {
            this.BoostHeatSinkMenuItem,
            this.ShadowExMenuItem,
            this.NotesMenuItem,
            this.XpadderMenuItem,
            this.toolStripSeparator2,
            this.SettingsMenuItem,
            this.RestartMenuItem,
            this.ExitMenuItem});

            contextMenuStrip1.Opacity = 0.8;
            GamesMenuItem.DropDown.Opacity = 0.8;
            NotesMenuItem.DropDown.Opacity = 0.8;
        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ShadowExMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NotesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem XpadderMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SettingsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RestartMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem BoostHeatSinkMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem GamesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gameItem;
        private System.Windows.Forms.ToolStripMenuItem note;
        static internal System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}