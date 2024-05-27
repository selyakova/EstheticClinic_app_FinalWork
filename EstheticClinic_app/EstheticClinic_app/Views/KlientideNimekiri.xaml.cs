using EstheticClinic_app.ViewModels; // Подключение пространства имен с ViewModel
using Xamarin.Forms; // Подключение библиотеки Xamarin.Forms для разработки кроссплатформенных приложений
using Xamarin.Forms.Xaml; // Подключение библиотеки для работы с XAML

namespace EstheticClinic.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)] // Указание на необходимость компиляции XAML
    public partial class KlientideNimekiri : ContentPage
    {
        // Конструктор страницы
        public KlientideNimekiri()
        {
            InitializeComponent(); // Инициализация компонентов XAML
            // Установка контекста данных для страницы
            BindingContext = new KlientideNimekiriViewModel() { Navigation = this.Navigation };
        }
    }
}