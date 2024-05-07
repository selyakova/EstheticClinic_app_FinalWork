using EstheticClinic_app.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EstheticClinic_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Kliendid : ContentPage
    {
        public KlientViewModel ViewModel { get; set; }
        public Kliendid(KlientViewModel viewModel)

        {
            InitializeComponent();
            ViewModel = viewModel;
            this.BindingContext = ViewModel;

        }
    }
}