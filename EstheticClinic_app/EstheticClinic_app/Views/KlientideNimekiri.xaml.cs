using EstheticClinic_app.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EstheticClinic.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KlientideNimekiri : ContentPage
    {
        public KlientideNimekiri()
        {
            InitializeComponent();
            BindingContext = new KlientideNimekiriViewModel() { Navigation = this.Navigation };
        }
    }
}