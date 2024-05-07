using System.ComponentModel;
using EstheticClinic_app.Models;

namespace EstheticClinic_app.ViewModels
{
    public class KlientViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        KlientideNimekiriViewModel lvm;
        public Klient Klient { get; set; }
        public KlientViewModel() { Klient = new Klient(); }
        public KlientideNimekiriViewModel ListViewModel
        {
            get { return lvm; }
            set
            {
                if (lvm != value)
                {
                    lvm = value;
                    OnPropertyChanged("ListViewModel");
                }
            }
        }
        public string Name
        {
            get { return Klient.Name; }
            set
            {
                if (Klient.Name != value)
                {
                    Klient.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        public string Email
        {
            get { return Klient.Email; }
            set
            {
                if (Klient.Email != value)
                {
                    Klient.Email = value;
                    OnPropertyChanged("Email");
                }
            }
        }
        public string Phone
        {
            get { return Klient.Phone; }
            set
            {
                if (Klient.Phone != value)
                {
                    Klient.Phone = value;
                    OnPropertyChanged("Phone");
                }
            }
        }
        public bool IsValid
        {
            get
            {
                return
                    (!string.IsNullOrEmpty(Name.Trim())) || (!string.IsNullOrEmpty(Phone.Trim())) || (!string.IsNullOrEmpty(Email.Trim()));
            }
        }
        private void OnPropertyChanged(string v)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(v)); }
        }
    }
}
