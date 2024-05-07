using System;
using System.Collections.ObjectModel;
using EstheticClinic_app.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EstheticClinic_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ABNimekiri : ContentPage
    {
        public ABNimekiri()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            klientideList.ItemsSource = App.Database.GetItems(); 
            base.OnAppearing();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            ObservableCollection<Teenus> teenused = (ObservableCollection<Teenus>)App.Database.GetTeenusList(); 
            Klient klient = new Klient();
            ABKlient klientPage = new ABKlient(teenused);
            klientPage.BindingContext = klient;
            await Navigation.PushAsync(klientPage);
        }

        private async void klientideList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ObservableCollection<Teenus> teenused = (ObservableCollection<Teenus>)App.Database.GetTeenusList(); 
            Klient selectedKlient = (Klient)e.SelectedItem;
            ABKlient klientPage = new ABKlient(teenused);
            klientPage.BindingContext = selectedKlient;
            await Navigation.PushAsync(klientPage);
        }
    }
}

