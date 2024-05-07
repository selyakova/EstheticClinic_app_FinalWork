using System;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EstheticClinic_app.Models;
using Xamarin.Essentials;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EstheticClinic_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ABKlient : ContentPage
    {
        public ObservableCollection<Teenus> Teenused { get; set; }

        public ABKlient(ObservableCollection<Teenus> teenused)
        {
            InitializeComponent();
            BackgroundColor = Color.FromHex("#F2F8E3");
            Teenused = teenused;
            servicePicker.ItemsSource = Teenused.Select(t => t.Nimetus).ToList();
            this.BindingContext = new Klient(); 
        }

        private async void Button_Clicked_Salvesta(object sender, EventArgs e)
        {
            var klient = (Klient)BindingContext;
            if (klient != null && !string.IsNullOrEmpty(klient.Name) && !string.IsNullOrEmpty(klient.Email) && !string.IsNullOrEmpty(klient.Phone))
            {
                try
                {
                    klient.TeenuseNimetus = servicePicker.SelectedItem.ToString();
                    klient.DateTime = DateTime.Now;
                    App.Database.SaveItem(klient);
                    await DisplayAlert("Õnnestus", "Broneering on salvestatud! Ja teavitus on saadetud administraatorile!", "OK");
                    this.Navigation.PopAsync();

                    string emailBody = $"Nimi: {klient.Name}\n" +
                                       $"Email: {klient.Email}\n" +
                                       $"Telefon: {klient.Phone}\n" +
                                       $"Teenuse nimetus: {klient.TeenuseNimetus}\n" +
                                       $"Kuupäev ja kellaaeg: {klient.DateTime.ToString("g")}";

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

        private void Button_Clicked_Kustuta(object sender, EventArgs e)
        {
            var klient = (Klient)BindingContext;
            if (klient != null && klient.Id != 0)
            {
                App.Database.DeleteItem(klient.Id);
                DisplayAlert("Teade", "Kustutamine õnnestus!", "OK");
                this.Navigation.PopAsync();
            }
        }

        private void Button_Clicked_Loobu(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext == null)
            {
                BindingContext = new Klient();
            }
        }
    }
}
