namespace WachedAnimeList
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            NavBox = new PictureBox();
            animeListPanel = new FlowLayoutPanel();
            button1 = new Button();
            Search = new TextBox();
            LogoBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)NavBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LogoBox).BeginInit();
            SuspendLayout();
            // 
            // NavBox
            // 
            NavBox.BackColor = Color.FromArgb(24, 24, 24);
            NavBox.Dock = DockStyle.Top;
            NavBox.Location = new Point(0, 0);
            NavBox.Name = "NavBox";
            NavBox.Size = new Size(1902, 60);
            NavBox.TabIndex = 3;
            NavBox.TabStop = false;
            // 
            // animeListPanel
            // 
            animeListPanel.AutoScroll = true;
            animeListPanel.BackColor = Color.Transparent;
            animeListPanel.Dock = DockStyle.Bottom;
            animeListPanel.Location = new Point(0, 90);
            animeListPanel.Name = "animeListPanel";
            animeListPanel.Size = new Size(1902, 943);
            animeListPanel.TabIndex = 1;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.BackColor = Color.FromArgb(22, 153, 118);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button1.Location = new Point(1702, 0);
            button1.Name = "button1";
            button1.Size = new Size(200, 60);
            button1.TabIndex = 4;
            button1.Text = "Взяти з буферу обміна";
            button1.UseVisualStyleBackColor = false;
            // 
            // Search
            // 
            Search.AcceptsReturn = true;
            Search.Anchor = AnchorStyles.Top;
            Search.BackColor = Color.FromArgb(34, 34, 34);
            Search.BorderStyle = BorderStyle.None;
            Search.Cursor = Cursors.IBeam;
            Search.Font = new Font("Segoe Print", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Search.ForeColor = Color.White;
            Search.Location = new Point(416, 0);
            Search.MinimumSize = new Size(0, 60);
            Search.Name = "Search";
            Search.PlaceholderText = "Для пошуку пиши тут";
            Search.Size = new Size(950, 60);
            Search.TabIndex = 5;
            // 
            // LogoBox
            // 
            LogoBox.BackColor = Color.Transparent;
            LogoBox.BackgroundImage = Properties.Resources.Безымянный_1;
            LogoBox.BackgroundImageLayout = ImageLayout.Zoom;
            LogoBox.Location = new Point(0, 0);
            LogoBox.Name = "LogoBox";
            LogoBox.Size = new Size(60, 60);
            LogoBox.TabIndex = 6;
            LogoBox.TabStop = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.Black;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1902, 1033);
            Controls.Add(LogoBox);
            Controls.Add(Search);
            Controls.Add(button1);
            Controls.Add(NavBox);
            Controls.Add(animeListPanel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1280, 720);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "WachedAnimeList";
            FormClosed += Main_FormClosed;
            ((System.ComponentModel.ISupportInitialize)NavBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)LogoBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox NavBox;
        private FlowLayoutPanel animeListPanel;
        private Button button1;
        private TextBox Search;
        private PictureBox LogoBox;
    }
}