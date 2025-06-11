using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using System.Net.Http;
using System.IO;
using JikanDotNet;
using DeepL;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using Image = System.Drawing.Image;
using FuzzySharp;
using System.Reflection;
using System.Runtime.InteropServices;

namespace WachedAnimeList
{
    public partial class MainForm : Form
    {
        public static MainForm Global;
        public MainForm()
        {
            Global = this;

            InitializeComponent();

            new WachedAnimeSaveLoad().Initialize();
            new Settings().Initialize();


            SetupSearchDelay();
            this.BackColor = Color.FromArgb(10, 10, 10);
            this.Resize += (s, e) => ResizeAnimeListPanel();
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        #region Add Anime

        private string AnimeName;
        private string AnimeNameEN;

        #region Buffer Button
        private void button1_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                string text = Clipboard.GetText();

                if (TextVerify(text))
                {
                    AnimeNameFormating(text);
                }
                else
                {
                    MessageBox.Show("Даун шо за хуйня а не текст");
                }
            }
            else
            {
                MessageBox.Show("Даун скопіюй нормально");
            }
        }
        private static bool TextVerify(string text)
        {
            int letters = 0;
            int slash = 0;

            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    letters++;
                }
                else if (c == '/')
                {
                    slash++;
                }
            }

            if (letters < 3)
                return false;
            if (slash > 1)
                return false;
            return true;
        }

        private async void AnimeNameFormating(string text)
        {
            string name = "";
            string eng_Name = "";

            string[] parts = text.Split('/', 2, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 2)
            {
                name = parts[0].Trim();
                eng_Name = parts[1].Trim();
            }
            else
            {
                var(eng, other) = SplitByEnglish(text);
                if (eng != "" && other != "")
                {
                    name = other.Trim();
                    eng_Name = eng.Trim();
                }
                else
                {
                    name = text;

                    var client = new Translator("49d710dd-2897-4129-b171-2ea0548043c8:fx");
                    var translatedText = await client.TranslateTextAsync(
                    text,
                    LanguageCode.Russian,
                    LanguageCode.EnglishAmerican);
                    eng_Name = translatedText.ToString();
                }
            }
            

            AnimeName = name;
            AnimeNameEN = eng_Name;

            GetAnimeTitle(eng_Name, name);
        }
        static bool IsEnglish(string word)
        {
            return Regex.IsMatch(word, "^[a-zA-Z]+$");
        }

        static (string eng, string other) SplitByEnglish(string input)
        {
            string[] words = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            List<string> beforeEnglish = new();
            List<string> englishWords = new();

            bool foundEnglish = false;

            foreach (var word in words)
            {
                if (!foundEnglish && IsEnglish(word))
                {
                    foundEnglish = true;
                }

                if (foundEnglish)
                    englishWords.Add(word);
                else
                    beforeEnglish.Add(word);
            }

            return (string.Join(' ', englishWords), string.Join(' ', beforeEnglish));
        }
        #endregion

        #region Load Anime Icon

        public async void GetAnimeTitle(string animeNameEN, string animeName)
        {
            var jikan = new Jikan();

            try
            {
                var searchResult = await jikan.SearchAnimeAsync(animeNameEN);
                var filtered = searchResult.Data.Where(a => a.Type != "Music").ToList();

                if (filtered?.Count > 0)
                {
                    var first = filtered.First();

                    await CreateWachedAnimeData(first, animeName);
                }
                else
                {
                    Console.WriteLine("Аніме не знайдено.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка: " + ex.Message);
            }
        }


        private Panel card;

        private async Task CreateWachedAnimeData(Anime anime, string animeName)
        {
            var wachedAnimeData = new WachedAnimeData();

            var title = anime.Titles.FirstOrDefault(t => t.Type == "English")?.Title
                     ?? anime.Titles.FirstOrDefault()?.Title
                     ?? "Unnamed";

            string imageUrl = anime.Images.JPG.ImageUrl;

            wachedAnimeData.animeNameEN = title; 
            wachedAnimeData.animeName = animeName;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var imgData = await client.GetByteArrayAsync(imageUrl);
                    using (var ms = new MemoryStream(imgData))
                    {
                        wachedAnimeData.animeImage = System.Drawing.Image.FromStream(ms);

                        using (var newForm = new Form2(wachedAnimeData))
                        {
                            newForm.ShowDialog();
                        }
                        this.Show();
                    }
                }
            }
            catch
            {
                wachedAnimeData.animeImage = Properties.Resources._5350447830046734641;

                var newForm = new Form2(wachedAnimeData);
                newForm.ShowDialog();
                this.Show();
            }
        }

        private Dictionary<string, Panel> cardCache = new();
        public void AddAnimeCardsAsync(WachedAnimeData[] animeArray)
        {
            if (animeArray == null || animeArray.Length == 0)
                return;

            bool isBulk = animeArray.Length > 1;

            if (isBulk)
            {
                animeListPanel.SuspendLayout();
                animeListPanel.Controls.Clear();
                cardCache.Clear();
            }

            foreach (var animeData in animeArray)
            {
                string key = animeData.animeNameEN.ToLowerInvariant();

                if (cardCache.ContainsKey(key))
                    continue;

                var card = new Panel
                {
                    Width = 160,
                    Height = 260,
                    Margin = new Padding(10),
                    BackColor = Color.FromArgb(23, 23, 23)
                };
                card.Paint += (s, e) =>
                {
                    Color borderColor = Color.FromArgb(46, 47, 47);
                    int borderWidth = 2;
                    Control p = (Control)s;
                    using (Pen pen = new Pen(borderColor, borderWidth))
                    {
                        e.Graphics.DrawRectangle(pen, 0, 0, p.Width - 1, p.Height - 1);
                    }
                };

                var picture = new PictureBox
                {
                    Width = 140,
                    Height = 200,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Location = new Point(10, 10),
                    Image = animeData.animeImage,
                    Tag = animeData.animeNameEN
                };
                picture.Click += Card_Click;

                var label = new Label
                {
                    Text = animeData.animeName,
                    Width = 140,
                    Height = 40,
                    Location = new Point(5, 210),
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.Transparent,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    ForeColor = Color.FromArgb(229, 229, 229),
                    AutoEllipsis = true
                };

                card.Controls.Add(picture);
                card.Controls.Add(label);

                animeListPanel.Controls.Add(card);
                cardCache[key] = card;
            }

            if (isBulk)
                animeListPanel.ResumeLayout();
        }


        public void Card_Click(object sender, EventArgs e)
        {
            var clickedCard = sender as PictureBox;
            var name = clickedCard.Tag as string;

            var data = WachedAnimeSaveLoad.Global.wachedAnimeDict[name];
            if (data == null)
                return;

            using (var newForm = new AnimeCardForm(data))
            {
                newForm.ShowDialog();
            }
            this.Show();
        }
        public void AcceptAnime(WachedAnimeData animeData)
        {
            WachedAnimeSaveLoad.Global.AddAnime(animeData);

            AddAnimeCardsAsync(new WachedAnimeData[1] { animeData });
        }
        public void RejectAnime()
        {
            card = null;
        }

        #endregion

        #endregion

        #region Search

        private System.Windows.Forms.Timer searchDelayTimer;

        private void SetupSearchDelay()
        {
            searchDelayTimer = new System.Windows.Forms.Timer
            {
                Interval = 600
            };

            searchDelayTimer.Tick += (s, e) =>
            {
                searchDelayTimer.Stop();
                SearchAnime(Search.Text.ToLowerInvariant().Trim());
            };
        }

        private void Search_TextChanged(object sender, EventArgs e)
        {
            searchDelayTimer.Stop();
            searchDelayTimer.Start();
        }


        private void SearchAnime(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
                return;

            var sourceDict = WachedAnimeSaveLoad.Global.wachedAnimeDict;

            // Використання FuzzySharp для пошуку
            var results = sourceDict
                .Select(x => new
                {
                    Data = x.Value, // беремо значення з KeyValuePair
                    Score = Fuzz.Ratio(x.Value.animeName.ToLowerInvariant(), searchText)
                })
                .OrderByDescending(x => x.Score)
                .ToList();

            foreach (var result in results)
            {
                var data = result.Data;
                // Тут можеш оновити UI, якщо потрібно
            }

            ReorderCards(results.Select(x => x.Data.animeNameEN).ToArray());
        }

        #endregion

        private Size NormalFormSize = new Size(1280, 720);

        private Size NormalAnimeListPanel = new Size(100, 420);
        public void ResizeAnimeListPanel()
        {
            float multiplayer = this.Size.Height / NormalFormSize.Height;
            animeListPanel.Size = new Size(animeListPanel.Width, (int)(NormalAnimeListPanel.Height * multiplayer));
        }
        public void ReorderCards(string[] orderedNames)
        {
            if (orderedNames == null || orderedNames.Length == 0)
                return;

            animeListPanel.SuspendLayout();
            animeListPanel.Controls.Clear();

            foreach (var name in orderedNames)
            {
                var key = name.ToLowerInvariant();
                if (cardCache.TryGetValue(key, out var panel))
                {
                    animeListPanel.Controls.Add(panel);
                }
            }

            animeListPanel.ResumeLayout();
        }
        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            WachedAnimeSaveLoad.Global.Save();
            Settings.Global.SaveSettings();
        }
    }

    public class Settings
    {
        public static Settings Global { get; set; }
        private readonly MainForm mainForm = MainForm.Global;

        public void Initialize()
        {
            Global = this;
            LoadSettings();
        }
        public void SaveSettings()
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string folderPath = Path.Combine(documentsPath, "RE ZERO", "WachedAnimeList");
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            string filePath = Path.Combine(folderPath, "Settings.ini");
            var config = new IniFile(filePath);

            if (mainForm.WindowState.ToString() != "Maximized")
            {
                string position = $"{mainForm.Location.X.ToString()}/{mainForm.Location.Y.ToString()}";
                config.Write("Position", position, "MainForm");

                string size = $"{mainForm.Size.Width.ToString()}/{mainForm.Size.Height.ToString()}";
                config.Write("Size", size, "MainForm");
            }

            if(mainForm.WindowState.ToString() != "Minimized")
                config.Write("WindowState", mainForm.WindowState.ToString(), "MainForm");
        }
        public void LoadSettings()
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(documentsPath, "RE ZERO", "WachedAnimeList", "Settings.ini");

            if (!File.Exists(filePath)) return;

            var config = new IniFile(filePath);

            // Читаємо позицію
            string position = config.Read("Position", "MainForm");

            var pos = position.Split('/');
            mainForm.Location = new Point(int.Parse(pos[0]), int.Parse(pos[1]));

            // Читаємо Width і Height
            string Size = config.Read("Size", "MainForm");
            var size = Size.Split('/');
            mainForm.Size = new Size(int.Parse(size[0]), int.Parse(size[1]));

            // Читаємо WindowState
            string windowStateStr = config.Read("WindowState", "MainForm");
            if (Enum.TryParse(windowStateStr, out FormWindowState windowState))
            {
                mainForm.WindowState = windowState;
            }
        }
    }
    class IniFile
    {
        string Path;
        string EXE = Assembly.GetExecutingAssembly().GetName().Name;

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

        public IniFile(string IniPath = null)
        {
            Path = new FileInfo(IniPath ?? EXE + ".ini").FullName;
        }

        public string Read(string Key, string Section = null)
        {
            var RetVal = new StringBuilder(255);
            GetPrivateProfileString(Section ?? EXE, Key, "", RetVal, 255, Path);
            return RetVal.ToString();
        }

        public void Write(string Key, string Value, string Section = null)
        {
            WritePrivateProfileString(Section ?? EXE, Key, Value, Path);
        }

        public void DeleteKey(string Key, string Section = null)
        {
            Write(Key, null, Section ?? EXE);
        }

        public void DeleteSection(string Section = null)
        {
            Write(null, null, Section ?? EXE);
        }

        public bool KeyExists(string Key, string Section = null)
        {
            return Read(Key, Section).Length > 0;
        }
    }

    public class WachedAnimeSaveLoad
    {
        public static WachedAnimeSaveLoad Global;
        private string folderPath;
        public readonly Dictionary<string, WachedAnimeData> wachedAnimeDict = new();
        public void Initialize()
        {
            if (Global != null && Global != this)
            {
                return;
            }
            Global = this;

            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            folderPath = Path.Combine(documentsPath, "RE ZERO", "WachedAnimeList");

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            string path = Path.Combine(folderPath, "Anime Icons");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            Load();
        }

        public WachedAnimeData GetAnimeByName(string name)
        {
            if (wachedAnimeDict.TryGetValue(name, out var animeData))
                return animeData;
            return null;
        }

        public void AddAnime(WachedAnimeData animeData)
        {
            if (animeData == null || string.IsNullOrEmpty(animeData.animeName))
                return;

            wachedAnimeDict[animeData.animeName] = animeData; // Додасть або оновить
        }

        public bool RemoveAnimeByName(string name)
        {
            return wachedAnimeDict.Remove(name);
        }


        public void Save()
        {
            if (folderPath == null)
                Initialize();
            if (wachedAnimeDict.Count == 0)
                return;

            string path = Path.Combine(folderPath, "anime_data.json");

            var data = new WachedAnimeSaveDataCollection()
            {
                dataCollection = [.. wachedAnimeDict.Values]
            };
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
            var json = JsonSerializer.Serialize(data, options);

            File.WriteAllText(path, json);

            foreach (var item in wachedAnimeDict.Values)
            {
                string finalPath = Path.Combine(folderPath, "Anime Icons" ,GetSafeImageFileName(item.animeName));
                if (!File.Exists(finalPath))
                {
                    System.Drawing.Image image = new Bitmap(item.animeImage);
                    image.Save(finalPath);
                }
            }
        }


        public void Load()
        {
            string path = Path.Combine(folderPath, "anime_data.json");

            if (!File.Exists(path))
                return;

            string json = File.ReadAllText(path);
            if (string.IsNullOrWhiteSpace(json))
                return;

            var data = JsonSerializer.Deserialize<WachedAnimeSaveDataCollection>(json);
            if (data == null || data.dataCollection == null)
                return;

            wachedAnimeDict.Clear(); // очищуємо словник перед завантаженням

            foreach (var x in data.dataCollection)
            {
                var animeData = new WachedAnimeData
                {
                    connectedAnimeName = x.connectedAnimeName,
                    rating = x.rating,
                    animeName = x.animeName,
                    animeNameEN = x.animeNameEN
                };

                wachedAnimeDict[animeData.animeNameEN] = animeData;
            }

            // Завантаження картинок
            foreach (var item in wachedAnimeDict.Values)
            {
                string finalPath = Path.Combine(folderPath, "Anime Icons", GetSafeImageFileName(item.animeName));
                if (File.Exists(finalPath))
                {
                    var image = System.Drawing.Image.FromFile(finalPath);
                    item.animeImage = image;
                }
            }

            // Викликаємо додавання карток одним масивом (оптимізація)
            MainForm.Global.AddAnimeCardsAsync(wachedAnimeDict.Values.ToArray());
        }

        public static string GetSafeImageFileName(string animeTitle)
        {
            foreach (char c in Path.GetInvalidFileNameChars())
                animeTitle = animeTitle.Replace(c, '_');

            return animeTitle + ".jpg";
        }
    }

    public class WachedAnimeData
    {
        [JsonIgnore]
        public System.Drawing.Image animeImage;
        public string animeName { get; set; }
        public string animeNameEN { get; set; }
        public string connectedAnimeName { get; set; }

        public int rating { get; set; }
    }

    public class WachedAnimeSaveDataCollection
    {
        public WachedAnimeData[] dataCollection { get; set; }
    }
    public class Resizer()
    { 

        
    }

}
