using System;
using System.IO;
using EstheticClinic_app.Models;
using EstheticClinic_app.Views;
using Xamarin.Forms;

namespace EstheticClinic_app
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "klient.db";
        public static string DatabasePath
        {
            get
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME);
            }
        }
        public static KlientideAndmebaas Database
        {
            get
            {
                if (database == null)
                {
                    database = new KlientideAndmebaas(DatabasePath);
                }
                return database;
            }
        }
        private static KlientideAndmebaas database;

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Nimekiri());
        }
        protected override void OnStart()
        {
            //BackgroundColor = Color.LightBlue;
            //var backgroundImageSource = ImageSource.FromFile("tulp.png");
            //Application.Current.MainPage.BackgroundImageSource = backgroundImageSource;
        }

        protected override void OnSleep()
        {
        }
        protected override void OnResume()
        {
        }
    }
}


