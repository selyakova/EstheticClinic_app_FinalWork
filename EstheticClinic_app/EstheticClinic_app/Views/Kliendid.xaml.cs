using EstheticClinic_app.ViewModels; // Подключение пространства имен с ViewModel
using Xamarin.Forms; // Подключение библиотеки Xamarin.Forms для разработки кроссплатформенных приложений
using Xamarin.Forms.Xaml; // Подключение библиотеки для работы с XAML

namespace EstheticClinic_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)] // Указание на необходимость компиляции XAML
    public partial class Kliendid : ContentPage
    {
        // Свойство для хранения ViewModel
        public KlientViewModel ViewModel { get; set; }

        // Конструктор страницы, принимающий ViewModel в качестве параметра
        public Kliendid(KlientViewModel viewModel)
        {
            InitializeComponent(); // Инициализация компонентов XAML
            ViewModel = viewModel; // Присваивание переданного ViewModel свойству ViewModel
            this.BindingContext = ViewModel; // Установка контекста данных для страницы
        }
    }
}