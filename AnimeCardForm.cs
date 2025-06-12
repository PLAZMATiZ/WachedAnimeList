using System.ComponentModel;
using System.Data;

namespace WachedAnimeList
{
    public partial class AnimeCardForm : Form
    {
        #region Main
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Size InheritedSize { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Point InheritedLocation { get; set; }

        WachedAnimeData animeData;
        public AnimeCardForm(WachedAnimeData animeData)
        {
            InitializeComponent();
            Anime_Image.Image = animeData.animeImage;
            AnimeNameLable.Text = animeData.animeName;
            this.animeData = animeData;

            banana = Properties.Resources.banana;
            bananaLight = Properties.Resources.bananaLight;
            InitializeRaiting();
        }

        private void AnimeCardForm_Load(object sender, EventArgs e)
        {
            if (InheritedSize == Size.Empty || InheritedLocation == Point.Empty)
                return;
            this.Size = InheritedSize;
            this.Location = InheritedLocation;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true; // клавіша оброблена
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        #region Raiting
        private Image banana;
        private Image bananaLight;
        private Label ratingLabel;
        public void InitializeRaiting()
        {
            for (int i = 0; i < 10; i++)
            {
                var picture = new PictureBox
                {
                    Width = 26,
                    Height = 26,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Location = new Point(10, 20 * i),
                    Image = banana,
                    Tag = i
                };
                RaitingBox.Controls.Add(picture);
                picture.Click += SetRaiting;
                picture.MouseEnter += UpdateRating;
                picture.MouseLeave += RefreshRaiting;
            }
            ratingLabel = new Label
            {
                Text = $"{animeData.rating}/10",
                Width = 50,
                Height = 20,
                ForeColor = Color.White,
                Location = new Point(5, 5),
                TextAlign = ContentAlignment.MiddleCenter
            };
            RaitingBox.Controls.Add(ratingLabel);
            if (animeData.rating != 0)
            {
                var picture = RaitingBox.Controls[animeData.rating - 1] as PictureBox;
                picture.Image = bananaLight;
            }
            RefreshRaiting();
        }

        private void UpdateRating(int rating)
        {
            if (rating < 0)
                rating = 0;
            if (rating > 10)
                rating = 10;

            for (int i = 0; i < 10; i++)
            {
                var picture = RaitingBox.Controls[i] as PictureBox;
                if (i < rating)
                {
                    picture.Image = banana;
                }
                else
                {
                    picture.Image = bananaLight;
                }
            }
            ratingLabel.Text = $"{animeData.rating}/10";
        }

        private void UpdateRating(object sender, EventArgs e)
        {
            var picture = sender as PictureBox;
            int rating = (int)picture.Tag + 1;
            UpdateRating(rating);
        }

        private void RefreshRaiting() => UpdateRating(animeData.rating);

        private void RefreshRaiting(object sender, EventArgs e)
        {
            UpdateRating(animeData.rating);
        }

        private void SetRaiting(object sender, EventArgs e)
        {
            var picture = sender as PictureBox;
            animeData.rating = (int)picture.Tag + 1;
            UpdateRating(animeData.rating);
        }
        #endregion
        private void ClearRatingControls()
        {
            var controls = RaitingBox.Controls.Cast<Control>().ToArray(); // копія списку

            foreach (Control control in controls)
            {
                if (control is PictureBox picture)
                {
                    picture.Click -= SetRaiting;
                    picture.MouseEnter -= UpdateRating;
                    picture.MouseLeave -= RefreshRaiting;

                    picture.Dispose();
                }
                else if (control is Label label)
                {
                    label.Dispose();
                    banana.Dispose();
                    bananaLight.Dispose();
                }
            }
            RaitingBox.Controls.Clear();
        }

    }
}
