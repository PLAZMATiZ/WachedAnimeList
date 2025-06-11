namespace WachedAnimeList
{
    partial class Form2
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
            AnimeNameLable = new Label();
            Anime_Image = new PictureBox();
            Accept_button = new Button();
            Reject_button = new Button();
            ((System.ComponentModel.ISupportInitialize)Anime_Image).BeginInit();
            SuspendLayout();
            // 
            // AnimeNameLable
            // 
            AnimeNameLable.AllowDrop = true;
            AnimeNameLable.Anchor = AnchorStyles.Top;
            AnimeNameLable.AutoEllipsis = true;
            AnimeNameLable.BackColor = Color.Transparent;
            AnimeNameLable.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            AnimeNameLable.ForeColor = Color.FromArgb(255, 128, 0);
            AnimeNameLable.Location = new Point(1, 9);
            AnimeNameLable.Name = "AnimeNameLable";
            AnimeNameLable.Size = new Size(698, 88);
            AnimeNameLable.TabIndex = 0;
            AnimeNameLable.Text = "label1";
            AnimeNameLable.TextAlign = ContentAlignment.BottomCenter;
            // 
            // Anime_Image
            // 
            Anime_Image.BackColor = Color.Transparent;
            Anime_Image.Location = new Point(20, 100);
            Anime_Image.Name = "Anime_Image";
            Anime_Image.Size = new Size(280, 366);
            Anime_Image.SizeMode = PictureBoxSizeMode.AutoSize;
            Anime_Image.TabIndex = 1;
            Anime_Image.TabStop = false;
            // 
            // Accept_button
            // 
            Accept_button.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            Accept_button.BackColor = Color.FromArgb(0, 192, 0);
            Accept_button.FlatStyle = FlatStyle.Popup;
            Accept_button.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Accept_button.Location = new Point(20, 531);
            Accept_button.Name = "Accept_button";
            Accept_button.Size = new Size(143, 56);
            Accept_button.TabIndex = 2;
            Accept_button.Text = "Воно";
            Accept_button.UseVisualStyleBackColor = false;
            Accept_button.Click += Accept_button_Click;
            // 
            // Reject_button
            // 
            Reject_button.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Reject_button.BackColor = Color.FromArgb(192, 0, 0);
            Reject_button.FlatStyle = FlatStyle.Flat;
            Reject_button.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Reject_button.Location = new Point(545, 531);
            Reject_button.Name = "Reject_button";
            Reject_button.Size = new Size(143, 56);
            Reject_button.TabIndex = 3;
            Reject_button.Text = "Не Воно";
            Reject_button.UseVisualStyleBackColor = false;
            Reject_button.Click += Reject_button_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.White;
            BackgroundImage = Properties.Resources._5354782255207282339;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(700, 600);
            Controls.Add(Reject_button);
            Controls.Add(Accept_button);
            Controls.Add(Anime_Image);
            Controls.Add(AnimeNameLable);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form2";
            StartPosition = FormStartPosition.CenterParent;
            Text = "WachedAnimeList";
            ((System.ComponentModel.ISupportInitialize)Anime_Image).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label AnimeNameLable;
        private PictureBox Anime_Image;
        private Button Accept_button;
        private Button Reject_button;
    }
}