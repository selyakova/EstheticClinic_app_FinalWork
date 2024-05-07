using EstheticClinic_app.Views;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace EstheticClinic_app.ViewModels
{
    public class KlientideNimekiriViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<KlientViewModel> Kliendid { get; set; }
        public ICommand CreateKlientCommand { get; protected set; }
        public ICommand DeleteKlientCommand { get; protected set; }
        public ICommand SaveKlientCommand { get; protected set; }
        public ICommand BackCommand { get; protected set; }
        KlientViewModel selectedKlient;
        public INavigation Navigation { get; set; }

        public KlientideNimekiriViewModel()
        {
            Kliendid = new ObservableCollection<KlientViewModel>();
            CreateKlientCommand = new Command(CreateKlient);
            DeleteKlientCommand = new Command(DeleteKlient);
            SaveKlientCommand = new Command(SaveKlient);
            BackCommand = new Command(Back);
        }

        private void CreateKlient(object obj)
        {
            throw new NotImplementedException();
        }

        public KlientViewModel SelectedKlient
        {
            get { return selectedKlient; }
            set
            {
                if (selectedKlient != value)
                {
                    KlientViewModel tempKlient = value;
                    selectedKlient = null;
                    OnPropertyChanged("SelectedKlient");
                    Navigation.PushAsync(new Kliendid(tempKlient));
                }
            }
        }
        private void OnPropertyChanged(string v)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(v)); }
        }
        private void SaveKlient(object klientobject)
        {
            KlientViewModel klient = (KlientViewModel)klientobject;
            if (klient != null && klient.IsValid && !Kliendid.Contains(klient))
            {
                Kliendid.Add(klient);
            }
            Back();
        }

        public void Back()
        {
            Navigation.PopAsync();
        }
        private void DeleteKlient(object klientobject)
        {
            KlientViewModel klient = (KlientViewModel)klientobject;
            if (klient != null)
            {
                Kliendid.Remove(klient);
                Back();
            }
        }

        private void CreateFriend()
        {
            Navigation.PushAsync(new Kliendid(new KlientViewModel() { ListViewModel = this }));
        }
    }
}
