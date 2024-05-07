using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EstheticClinic_app.Models;

namespace EstheticClinic_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Broneeringud : ContentPage
    {
        ListView listView;

        public Broneeringud()
        {
            InitializeComponent();
            this.BackgroundColor = Color.FromHex("#E2E8D3");

            Label titleLabel = new Label
            {
                Text = "Minu broneeringud",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
                FontAttributes = FontAttributes.Bold,
                Margin = new Thickness(0, 20, 0, 10)
            };
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

            PopulateListView();

            StackLayout layout = new StackLayout
            {
                Padding = new Thickness(10),
                Children = { titleLabel, listView }
            };

            Content = layout;
        }

        private void PopulateListView()
        {
            var database = new KlientideAndmebaas(App.DatabasePath);
            listView.ItemsSource = database.GetItems().ToList();
        }

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
            ((ListView)sender).SelectedItem = null; 
        }
    }
}
