namespace WachedAnimeList
{
    partial class AnimeCardForm
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
            ClearRatingControls();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Anime_Image = new PictureBox();
            AnimeNameLable = new Label();
            RaitingBox = new FlowLayoutPanel();
            textBox1 = new TextBox();
            ConnectedBufferButton = new Button();
            ((System.ComponentModel.ISupportInitialize)Anime_Image).BeginInit();
            SuspendLayout();
            // 
            // Anime_Image
            // 
            Anime_Image.BackColor = Color.Transparent;
            Anime_Image.Location = new Point(80, 90);
            Anime_Image.Name = "Anime_Image";
            Anime_Image.Size = new Size(280, 366);
            Anime_Image.SizeMode = PictureBoxSizeMode.StretchImage;
            Anime_Image.TabIndex = 3;
            Anime_Image.TabStop = false;
            // 
            // AnimeNameLable
            // 
            AnimeNameLable.AllowDrop = true;
            AnimeNameLable.AutoEllipsis = true;
            AnimeNameLable.Dock = DockStyle.Top;
            AnimeNameLable.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            AnimeNameLable.ForeColor = Color.FromArgb(255, 128, 0);
            AnimeNameLable.Location = new Point(0, 0);
            AnimeNameLable.Name = "AnimeNameLable";
            AnimeNameLable.Size = new Size(768, 87);
            AnimeNameLable.TabIndex = 2;
            AnimeNameLable.Text = "label1awawawawawaw";
            AnimeNameLable.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // RaitingBox
            // 
            RaitingBox.Location = new Point(12, 90);
            RaitingBox.Name = "RaitingBox";
            RaitingBox.Size = new Size(60, 366);
            RaitingBox.TabIndex = 4;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 483);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 5;
            // 
            // ConnectedBufferButton
            // 
            ConnectedBufferButton.BackColor = Color.Gray;
            ConnectedBufferButton.FlatStyle = FlatStyle.Flat;
            ConnectedBufferButton.Location = new Point(617, 481);
            ConnectedBufferButton.Name = "ConnectedBufferButton";
            ConnectedBufferButton.Size = new Size(94, 29);
            ConnectedBufferButton.TabIndex = 6;
            ConnectedBufferButton.Text = "ConnectedBufferButton";
            ConnectedBufferButton.UseVisualStyleBackColor = false;
            // 
            // AnimeCardForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.Black;
            ClientSize = new Size(768, 764);
            Controls.Add(ConnectedBufferButton);
            Controls.Add(textBox1);
            Controls.Add(RaitingBox);
            Controls.Add(Anime_Image);
            Controls.Add(AnimeNameLable);
            MinimumSize = new Size(600, 600);
            Name = "AnimeCardForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Form1";
            Load += AnimeCardForm_Load;
            ((System.ComponentModel.ISupportInitialize)Anime_Image).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox Anime_Image;
        private Label AnimeNameLable;
        private FlowLayoutPanel RaitingBox;
        private TextBox textBox1;
        private Button ConnectedBufferButton;
    }
}