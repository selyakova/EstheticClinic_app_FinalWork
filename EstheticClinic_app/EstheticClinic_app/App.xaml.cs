using System; // Подключение стандартной библиотеки .NET
using System.IO; // Подключение библиотеки для работы с файловой системой
using EstheticClinic_app.Models; // Подключение пространства имен с моделями данных
using EstheticClinic_app.Views; // Подключение пространства имен с представлениями
using Xamarin.Forms; // Подключение библиотеки Xamarin.Forms для разработки кроссплатформенных приложений

namespace EstheticClinic_app
{
    public partial class App : Application
    {
        // Константа для имени базы данных
        public const string DATABASE_NAME = "klient.db";

        // Свойство для получения пути к базе данных
        public static string DatabasePath
        {
            get
            {
                // Возвращает путь к базе данных в локальном каталоге приложения
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME);
            }
        }

        // Свойство для работы с базой данных
        public static KlientideAndmebaas Database
        {
            get
            {
                // Если объект базы данных не инициализирован, создаем его
                if (database == null)
                {
                    database = new KlientideAndmebaas(DatabasePath);
                }
                return database;
            }
        }
        private static KlientideAndmebaas database; // Поле для хранения экземпляра базы данных

        // Конструктор приложения
        public App()
        {
            InitializeComponent(); // Инициализация компонентов XAML
            MainPage = new NavigationPage(new Nimekiri()); // Установка начальной страницы приложения
        }

        // Метод, вызываемый при запуске приложения
        protected override void OnStart()
        {
            
        }

        // Метод, вызываемый при переходе приложения в спящий режим
        protected override void OnSleep()
        {
            
        }

        // Метод, вызываемый при возобновлении работы приложения
        protected override void OnResume()
        {
            
        }
    }
}
