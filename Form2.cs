namespace WachedAnimeList
{
    public partial class Form2 : Form
    {
        private TaskCompletionSource<WachedAnimeData> _resultSource;
        private WachedAnimeData animeData;

        public Form2(WachedAnimeData animeData, TaskCompletionSource<WachedAnimeData> resultSource)
        {
            InitializeComponent();
            this.animeData = animeData;
            this._resultSource = resultSource;

            Anime_Image.Image = animeData.animeImage;
            AnimeNameLable.Text = animeData.animeName + " / " + animeData.animeNameEN;
            this.BackColor = Color.FromArgb(43, 43, 43);
        }

        private void Reject_button_Click(object sender, EventArgs e)
        {
            _resultSource.TrySetResult(null);
            this.Close();
        }

        private void Accept_button_Click(object sender, EventArgs e)
        {
            _resultSource.TrySetResult(animeData);
            this.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                _resultSource.TrySetResult(null);
                this.Close();
                return true;
            }

            if (keyData == Keys.Enter)
            {
                _resultSource.TrySetResult(animeData);
                this.Close();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }

}
