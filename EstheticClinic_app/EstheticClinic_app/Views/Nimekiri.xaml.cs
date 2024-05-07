using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EstheticClinic_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Nimekiri : ContentPage
    {
        ObservableCollection<Teenus> teenuss = new ObservableCollection<Teenus>();
        ListView listView;

        Label titleLabel = new Label
        {
            Text = "Esthetic Clinic",
            FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
            FontAttributes = FontAttributes.Bold,
            TextColor = Color.Black,
            HorizontalOptions = LayoutOptions.CenterAndExpand
        };

        public Nimekiri()
        {
            InitializeComponent();
            this.BackgroundColor = Color.FromHex("#E2E8D3");

            teenuss = new ObservableCollection<Teenus>
            {
                new Teenus { Nimetus = "Raadiosageduslik (RF)", Kirjeldus = "Avastage enda jaoks ideaalne lahendus, kui eesmärgiks on:" +
                "Naha noorendamine ja sügav 3D-remodelleerimine" +
                "Naha tugevdamine ja kortsude silumine" +
                "Postakne atroofiliste armide, traumade tagajärjel tekkinud armide ning venitusarmide ravi" +
                "Hüperpigmentatsioonialade vähendamine" +
                "Kollageeni ning naha rakkudevahelise maatriksi uuendamine" +
                "Fraktsioon RF noorendus on üks uusimaid ilutööstuse instrumente, mis võimaldab " +
                "näo-, kaela-, dekoltee-, käte- ja teiste kehapiirkondade nahka kiiresti ja efektiivselt uuendada ja noorendada", Hind = 90, Pilt="Botox.jpg" },
                new Teenus { Nimetus = "PRX-T33", Kirjeldus = "PRX-T33 on atraumaatiline protseduur, mille eesmärgiks on näo, kaela, dekolteepiirkonna" +
                " + ja käte intensiivne noorendamine. PRX-T33 ei näe ette taastusaega, seda tänu preparaadi ainulaadsele koostisele, milleks on 33% trikloroäädikhape " +
                "ja vesinikperoksiid. Need kaks komponenti toimivad rakutasandil, pakkudes ülivõimsat biorevitaliseerivat toimet, kusjuures naha pealmisi kihte kahjustamata." +
                "Protseduuri tulemusena saavutatakse kohene lifting-efekt, paraneb naha toonus, kaovad armid, striiad ja postakne", Hind = 50, Pilt="Piling.jpg" },
                new Teenus { Nimetus = "Krüoteraapia ehk Krüolipolüüs", Kirjeldus = "Krüolipolüüs sobib ideaalselt normaalse kehakaaluga, aga ka kergelt " +
                "ülekaalulistele inimestele. CoolTechi aparaatne metoodika võimaldab kujundada peaaegu kogu keha, kaasa arvatud ka selle probleemseid piirkondasid." +
                "Krüoteraapia on ohutu ja valutu protseduur, mis ei vaja kirurgilist sekkumist. CoolTech ravi on alternatiiv rasvaimule", Hind = 179, Pilt="krio.jpg" },
                new Teenus { Nimetus = "Endospheres", Kirjeldus = "Endospheres on ülemaailmselt tunnustatud ja aktsepteeritud näo- ja kehahooldus, " +
                "mis kasutab kompresseeritava mikrovibratsiooni jõudu", Hind = 70, Pilt="endo.jpg" },
                new Teenus { Nimetus = "Laserepilatsioon", Kirjeldus = "Laserepilatsioon on protseduur, mis eemaldab soovimatud karvad laserimpulsi abil.", Hind = 30, Pilt="lazer.jpg" },
                new Teenus { Nimetus = "Massaaž", Kirjeldus = "Massaaž mõjub positiivselt inimese füüsilisele seisundile, vähendab pinget ja leevendab valu. " +
                "Massaaž aitab teadaolevalt tugevdada nii immuunsust kui ka tasakaalustada närvisüsteemi. Kliinikus vipMedicum on valida üle 10 massaažiliigi vahel" +
                "Koos aparaatse tehnikaga võimaldab massaaž mitte ainult lõõgastuda ja vabaneda kahas tekkivatest pingetest, " +
                "vaid avaldab soodsat mõju ka keha üldisele seidundile: paranevad vereringe ja lümfivool, kaovad tursed, paraneb ka naha seis. " +
                "Kombineerides aparaatseid metoodikaid käsitsi massaažiga, ennetate tselluliiti, vabanete rasvaladestustest ja korrigeerite figuuri", Hind = 50, Pilt="massage.jpg" },
                new Teenus { Nimetus = "APPeex koorimine", Kirjeldus = "APPeex – näo-, kaela-, dekoltee- ja kätenaha intensiivsele noorendamisele suunatud atraumaatiline protseduur", Hind = 50, Pilt="appeex.jpg" },
                new Teenus { Nimetus = "Mesoterrapia TOSKANIMED", Kirjeldus = "Innovaatiline lahendus igat tüüpi alopeetsia raviks", Hind = 250, Pilt="hair.jpg" },
                //new Teenus { Nimetus = "", Kirjeldus = "", Hind = 50, Pilt="" },
                //new Teenus { Nimetus = "", Kirjeldus = "", Hind = 50, Pilt="" }
            };

            Label descriptionLabel = new Label
            {
                Text = "Meie Esteetiline erakliinik pakkub palju erinevaid protseduure. Vali ja kohe broneeri aega!",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Margin = new Thickness(10),
                FontAttributes = FontAttributes.Italic
            };

            Frame frame = new Frame
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Padding = new Thickness(10),
                BackgroundColor = Color.FromHex("#F2F8E3"), 
                HasShadow = true,
                CornerRadius = 10,
                Content = descriptionLabel
            };

            listView = new ListView
            {
                Header = "Teenused",
                HasUnevenRows = true,
                ItemsSource = teenuss,
                ItemTemplate = new DataTemplate(() =>
                {
                    ImageCell imageCell = new ImageCell { TextColor = Color.Black, DetailColor = Color.Black };
                    imageCell.SetBinding(ImageCell.TextProperty, "Nimetus");
                    Binding companyBinding = new Binding { Path = "Kirjeldus", StringFormat = "" };
                    imageCell.SetBinding(ImageCell.DetailProperty, companyBinding);
                    imageCell.SetBinding(ImageCell.ImageSourceProperty, "Pilt");
                    return imageCell;
                }),
            };

            listView.ItemTapped += List_ItemTapped;

            Button broneeriButton = new Button
            {
                Text = "Broneeri aeg!",
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(10, 0, 10, 10)
            };

            broneeriButton.Clicked += async (sender, e) =>
            {
                ABKlient abKlient = new ABKlient(teenuss); 
                await Navigation.PushAsync(abKlient);
            };


            Button myBookingsButton = new Button
            {
                Text = "Minu broneeringud",
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(10)
            };

            myBookingsButton.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new Broneeringud());
            };

            StackLayout stackLayout = new StackLayout
            {
                Padding = new Thickness(10),
                Children = { titleLabel, frame, broneeriButton, myBookingsButton, listView }
            };

            this.Content = stackLayout;
        }

        private async void List_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Teenus selectedTenus = e.Item as Teenus;
            if (selectedTenus != null)
                await DisplayAlert("Valitud teenus", $"{selectedTenus.Kirjeldus} - {selectedTenus.Hind} eur", "OK");
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            Button btn = (Button)sender;
            var selectedTeenuss = (Teenus)listView.SelectedItem;
            if (selectedTeenuss != null)
            {
                ABKlient abKlient = new ABKlient(teenuss);
                await Navigation.PushAsync(abKlient);
            }
        }
    }
}