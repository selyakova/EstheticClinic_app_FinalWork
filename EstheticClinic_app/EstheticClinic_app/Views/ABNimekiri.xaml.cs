using System; // Подключение стандартной библиотеки .NET
using System.Collections.ObjectModel; // Подключение библиотеки для работы с ObservableCollection
using EstheticClinic_app.Models; // Подключение пространства имен с моделями данных
using Xamarin.Forms; // Подключение библиотеки Xamarin.Forms для разработки кроссплатформенных приложений
using Xamarin.Forms.Xaml; // Подключение библиотеки для работы с XAML

namespace EstheticClinic_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ABNimekiri : ContentPage
    {
        // Конструктор страницы
        public ABNimekiri()
        {
            InitializeComponent();
        }

        // Метод, который вызывается при появлении страницы на экране
        protected override void OnAppearing()
        {
            // Установка источника данных для списка клиентов из базы данных
            klientideList.ItemsSource = App.Database.GetItems();
            base.OnAppearing();
        }

        // Обработчик события нажатия кнопки для добавления нового клиента
        private async void Button_Clicked(object sender, EventArgs e)
        {
            // Получение списка услуг из базы данных
            ObservableCollection<Teenus> teenused = new ObservableCollection<Teenus>(App.Database.GetTeenusList());
            // Создание нового клиента
            Klient klient = new Klient();
            // Создание новой страницы для добавления клиента
            ABKlient klientPage = new ABKlient(teenused);
            // Установка контекста данных для страницы
            klientPage.BindingContext = klient;
            // Переход на новую страницу
            await Navigation.PushAsync(klientPage);
        }

        // Обработчик события выбора клиента из списка
        private async void klientideList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // Получение списка услуг из базы данных
            ObservableCollection<Teenus> teenused = new ObservableCollection<Teenus>(App.Database.GetTeenusList());
            // Получение выбранного клиента
            Klient selectedKlient = (Klient)e.SelectedItem;
            // Создание новой страницы для редактирования клиента
            ABKlient klientPage = new ABKlient(teenused);
            // Установка контекста данных для страницы
            klientPage.BindingContext = selectedKlient;
            // Переход на новую страницу
            await Navigation.PushAsync(klientPage);
        }
    }
}
