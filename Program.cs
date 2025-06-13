namespace WachedAnimeList
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        static Mutex mutex = null;
        [STAThread]
        static void Main()
        {
            const string appName = "WachedAnimeList";
            bool createdNew;

            mutex = new Mutex(true, appName, out createdNew);

            if (!createdNew)
            {
                MessageBox.Show("Програма вже запущена.", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new BackgroundForm());
        }
    }
}