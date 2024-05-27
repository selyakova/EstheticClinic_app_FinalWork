using System; // Подключение стандартной библиотеки .NET
using System.Collections.Generic; // Подключение библиотеки для работы с коллекциями
using System.Linq; // Подключение библиотеки для работы с LINQ
using Xamarin.Forms; // Подключение библиотеки Xamarin.Forms для разработки кроссплатформенных приложений
using Xamarin.Forms.Xaml; // Подключение библиотеки для работы с XAML
using EstheticClinic_app.Models; // Подключение пространства имен с моделями данных

namespace EstheticClinic_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Broneeringud : ContentPage
    {
        ListView listView; // Объявление списка ListView

        // Конструктор страницы
        public Broneeringud()
        {
            InitializeComponent();
            this.BackgroundColor = Color.FromHex("#E2E8D3"); // Установка фона страницы

            // Создание заголовка страницы
            Label titleLabel = new Label
            {
                Text = "Minu broneeringud",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
                FontAttributes = FontAttributes.Bold,
                Margin = new Thickness(0, 20, 0, 10)
            };

            // Создание ListView для отображения списка бронирований
            listView = new ListView
            {
                Margin = new Thickness(10, 0, 10, 10),
                ItemTemplate = new DataTemplate(() =>
                {
                    var nameLabel = new Label();
                    nameLabel.SetBinding(Label.TextProperty, new Binding("TeenuseNimetus", stringFormat: "{0} - {1:d}"));
                    nameLabel.HorizontalOptions = LayoutOptions.StartAndExpand;

                    var deleteButton = new Button { Text = "х", BackgroundColor = Color.LightGray, TextColor = Color.White };
                    deleteButton.SetBinding(Button.CommandParameterProperty, "Id");
                    deleteButton.Clicked += DeleteButton_Clicked;
                    deleteButton.HorizontalOptions = LayoutOptions.End;

                    var itemLayout = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        Children = { nameLabel, deleteButton }
                    };

                    return new ViewCell { View = itemLayout };
                })
            };

            listView.ItemTapped += ListView_ItemTapped;

            // Заполнение ListView данными
            PopulateListView();

            // Создание макета страницы
            StackLayout layout = new StackLayout
            {
                Padding = new Thickness(10),
                Children = { titleLabel, listView }
            };

            Content = layout;
        }

        // Метод для заполнения ListView данными из базы данных
        private void PopulateListView()
        {
            var database = new KlientideAndmebaas(App.DatabasePath);
            listView.ItemsSource = database.GetItems().ToList();
        }

        // Обработчик события нажатия кнопки удаления
        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                int id = (int)button.CommandParameter;
                var database = new KlientideAndmebaas(App.DatabasePath);
                database.DeleteItem(id);
                PopulateListView();
                await DisplayAlert("Teade", "Broneering on kustutatud", "OK");
            }
        }

        // Обработчик события выбора элемента в ListView
        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as Klient;
            if (item != null)
            {
                var message = $"Nimi: {item.Name}\n" +
                              $"E-post: {item.Email}\n" +
                              $"Telefon: {item.Phone}\n" +
                              $"Teenuse nimetus: {item.TeenuseNimetus}\n" +
                              $"Kuupäev: {item.DateTime.ToString("d")}\n" +
                              $"Kellaaeg: {item.DateTime.ToString("t")}";
                await DisplayAlert("Valitud broneering", message, "OK");
            }
            ((ListView)sender).SelectedItem = null; // Сброс выбора элемента
        }
    }
}
