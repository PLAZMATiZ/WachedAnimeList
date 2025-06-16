using WachedAnimeList.Properties;

namespace WachedAnimeList
{
    public partial class BackgroundForm : Form
    {
        private NotifyIcon trayIcon;
        private MainForm mainForm;

        public BackgroundForm()
        {
            // Ховаємо форму при запуску
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            this.Visible = false;

            trayIcon = new NotifyIcon()
            {
                Icon = Icon.FromHandle(Properties.Resources.Icon.GetHicon()),
                Visible = true,
                Text = "Wached Anime List DoNotClose",
            };

            var contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add(new ToolStripMenuItem("Відкрити", null, (s, e) => ShowMainForm()));
            contextMenu.Items.Add(new ToolStripMenuItem("Вихід", null, (s, e) =>
            {
                trayIcon.Visible = false;
                this.Close();
                Application.Exit();
            }));

            trayIcon.ContextMenuStrip = contextMenu;
            trayIcon.Click += (s, e) =>
            {
                if (e is MouseEventArgs me && me.Button == MouseButtons.Left)
                {
                    ShowMainForm();
                }
            };

            ShowMainForm();
        }

        private void ShowMainForm()
        {
            if (mainForm == null || mainForm.IsDisposed)
            {
                mainForm = new MainForm();
            }

            if (WachedAnimeSaveLoad.Global.wachedAnimeDict.Count == 0)
                MainForm.Global.ReloadAnimeCards();

            mainForm.Show();
            mainForm.BringToFront();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Hide(); // одразу ховаємо
        }
    }
}