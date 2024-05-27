using System; // Подключение стандартной библиотеки .NET
using System.Collections.ObjectModel; // Подключение библиотеки для работы с ObservableCollection
using System.Linq; // Подключение библиотеки для работы с LINQ
using Xamarin.Forms; // Подключение библиотеки Xamarin.Forms для разработки кроссплатформенных приложений
using Xamarin.Forms.Xaml; // Подключение библиотеки для работы с XAML
using EstheticClinic_app.Models; // Подключение пространства имен с моделями данных
using Xamarin.Essentials; // Подключение библиотеки Xamarin.Essentials для работы с функциональностью устройства
using System.Collections.Generic; // Подключение библиотеки для работы с коллекциями
using System.Threading.Tasks; // Подключение библиотеки для работы с асинхронностью

namespace EstheticClinic_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ABKlient : ContentPage
    {
        // Свойство для хранения списка услуг
        public ObservableCollection<Teenus> Teenused { get; set; }

        // Конструктор страницы, принимающий список услуг
        public ABKlient(ObservableCollection<Teenus> teenused)
        {
            InitializeComponent();
            BackgroundColor = Color.FromHex("#F2F8E3"); // Установка фона страницы
            Teenused = teenused; // Инициализация списка услуг
            servicePicker.ItemsSource = Teenused.Select(t => t.Nimetus).ToList(); // Установка источника данных для Picker
            this.BindingContext = new Klient(); // Установка контекста данных для страницы
        }

        // Обработчик события нажатия кнопки для сохранения данных клиента
        private async void Button_Clicked_Salvesta(object sender, EventArgs e)
        {
            var klient = (Klient)BindingContext;
            if (klient != null && !string.IsNullOrEmpty(klient.Name) && !string.IsNullOrEmpty(klient.Email) && !string.IsNullOrEmpty(klient.Phone))
            {
                try
                {
                    klient.TeenuseNimetus = servicePicker.SelectedItem.ToString(); // Установка выбранной услуги
                    klient.DateTime = DateTime.Now; // Установка текущей даты и времени
                    App.Database.SaveItem(klient); // Сохранение клиента в базе данных
                    await DisplayAlert("Õnnestus", "Broneering on salvestatud! Ja teavitus on saadetud administraatorile!", "OK");
                    this.Navigation.PopAsync(); // Возврат на предыдущую страницу

                    // Формирование текста письма
                    string emailBody = $"Nimi: {klient.Name}\n" +
                                       $"Email: {klient.Email}\n" +
                                       $"Telefon: {klient.Phone}\n" +
                                       $"Teenuse nimetus: {klient.TeenuseNimetus}\n" +
                                       $"Kuupäev ja kellaaeg: {klient.DateTime.ToString("g")}";

                    // Отправка письма
                    await SendEmailAsync("Uus broneering", emailBody, new List<string> { "anastassiaseljakova@gmail.com" });
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Viga", "Salvestamisel tekkis viga: " + ex.Message, "OK");
                }
            }
            else
            {
                await DisplayAlert("Viga", "Palun täitke kõik väljad!", "OK");
            }
        }

        // Метод для отправки письма
        private async Task SendEmailAsync(string subject, string body, List<string> recipients)
        {
            try
            {
                var message = new EmailMessage
                {
                    Subject = subject,
                    Body = body,
                    To = recipients
                };
                await Email.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException)
            {
                await DisplayAlert("Funktsioon pole saadaval", "Teie seade ei toeta meili saatmist. Veenduge, et meiliklient oleks installitud ja konfigureeritud", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Viga", $"Meili saatmisel ilmnes viga: {ex.Message}", "OK");
            }
        }

        // Обработчик события нажатия кнопки для удаления клиента
        private void Button_Clicked_Kustuta(object sender, EventArgs e)
        {
            var klient = (Klient)BindingContext;
            if (klient != null && klient.Id != 0)
            {
                App.Database.DeleteItem(klient.Id); // Удаление клиента из базы данных
                DisplayAlert("Teade", "Kustutamine õnnestus!", "OK");
                this.Navigation.PopAsync(); // Возврат на предыдущую страницу
            }
        }

        // Обработчик события нажатия кнопки для отмены действий и возврата на предыдущую страницу
        private void Button_Clicked_Loobu(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }

        // Метод, который вызывается при появлении страницы на экране
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext == null)
            {
                BindingContext = new Klient(); // Установка контекста данных, если он не был установлен
            }
        }
    }
}
