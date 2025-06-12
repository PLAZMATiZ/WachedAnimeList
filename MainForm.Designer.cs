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
            button1 = new Button();
            animeListPanel = new FlowLayoutPanel();
            Search = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button1.Location = new Point(1050, 41);
            button1.Name = "button1";
            button1.Size = new Size(200, 80);
            button1.TabIndex = 0;
            button1.Text = "Взяти з буферу обміна";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // animeListPanel
            // 
            animeListPanel.AutoScroll = true;
            animeListPanel.BackColor = Color.Transparent;
            animeListPanel.Dock = DockStyle.Bottom;
            animeListPanel.Location = new Point(0, 253);
            animeListPanel.Name = "animeListPanel";
            animeListPanel.Size = new Size(1262, 420);
            animeListPanel.TabIndex = 1;
            // 
            // Search
            // 
            Search.AcceptsReturn = true;
            Search.BackColor = SystemColors.MenuText;
            Search.BorderStyle = BorderStyle.FixedSingle;
            Search.Cursor = Cursors.IBeam;
            Search.ForeColor = Color.White;
            Search.Location = new Point(103, 200);
            Search.MaximumSize = new Size(600, 0);
            Search.Name = "Search";
            Search.PlaceholderText = "Для пошуку пиши тут";
            Search.Size = new Size(600, 27);
            Search.TabIndex = 2;
            Search.TextChanged += Search_TextChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.Black;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1262, 673);
            Controls.Add(Search);
            Controls.Add(animeListPanel);
            Controls.Add(button1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "WachedAnimeList";
            FormClosed += Main_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private FlowLayoutPanel animeListPanel;
        private TextBox Search;
    }
}