namespace WachedAnimeList
{
    public partial class Form2 : Form
    {
        WachedAnimeData animeData;
        public Form2(WachedAnimeData animeData)
        {
            InitializeComponent();
            Anime_Image.Image = animeData.animeImage;
            AnimeNameLable.Text = animeData.animeName + " / " + animeData.animeNameEN;
            this.animeData = animeData;
            this.BackColor = Color.FromArgb(43, 43, 43);
        }

        private void Reject_button_Click(object sender, EventArgs e)
        {
            MainForm.Global.RejectAnime();
            animeData = null;
            this.Close();
        }

        private void Accept_button_Click(object sender, EventArgs e)
        {
            MainForm.Global.AcceptAnime(animeData);
            this.Close();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                MainForm.Global.RejectAnime();
                this.Close();
                return true;
            }
            if (keyData == Keys.Enter)
            {
                MainForm.Global.AcceptAnime(animeData);
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }


}
