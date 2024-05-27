using System.ComponentModel; // Подключение библиотеки для реализации интерфейсов INotifyPropertyChanged
using EstheticClinic_app.Models; // Подключение пространства имен с моделями данных

namespace EstheticClinic_app.ViewModels
{
    // Реализация интерфейса INotifyPropertyChanged для уведомления об изменении свойств
    public class KlientViewModel : INotifyPropertyChanged
    {
        // Событие для уведомления об изменении свойств
        public event PropertyChangedEventHandler PropertyChanged;

        // Переменная для хранения ссылки на ViewModel списка клиентов
        KlientideNimekiriViewModel lvm;

        // Свойство для хранения данных клиента
        public Klient Klient { get; set; }

        // Конструктор ViewModel
        public KlientViewModel()
        {
            // Инициализация свойства клиента новым экземпляром класса Klient
            Klient = new Klient();
        }

        // Свойство для получения и установки ViewModel списка клиентов
        public KlientideNimekiriViewModel ListViewModel
        {
            get { return lvm; }
            set
            {
                if (lvm != value)
                {
                    lvm = value;
                    // Уведомление об изменении свойства
                    OnPropertyChanged("ListViewModel");
                }
            }
        }

        // Свойство для получения и установки имени клиента
        public string Name
        {
            get { return Klient.Name; }
            set
            {
                if (Klient.Name != value)
                {
                    Klient.Name = value;
                    // Уведомление об изменении свойства
                    OnPropertyChanged("Name");
                }
            }
        }

        // Свойство для получения и установки электронной почты клиента
        public string Email
        {
            get { return Klient.Email; }
            set
            {
                if (Klient.Email != value)
                {
                    Klient.Email = value;
                    // Уведомление об изменении свойства
                    OnPropertyChanged("Email");
                }
            }
        }

        // Свойство для получения и установки телефонного номера клиента
        public string Phone
        {
            get { return Klient.Phone; }
            set
            {
                if (Klient.Phone != value)
                {
                    Klient.Phone = value;
                    // Уведомление об изменении свойства
                    OnPropertyChanged("Phone");
                }
            }
        }

        // Свойство для проверки валидности данных клиента
        public bool IsValid
        {
            get
            {
                // Проверка на то, что хотя бы одно из полей (Имя, Телефон, Электронная почта) не пустое
                return
                    (!string.IsNullOrEmpty(Name.Trim())) ||
                    (!string.IsNullOrEmpty(Phone.Trim())) ||
                    (!string.IsNullOrEmpty(Email.Trim()));
            }
        }

        // Метод для уведомления об изменении свойства
        private void OnPropertyChanged(string v)
        {
            // Если есть подписчики на событие PropertyChanged, вызываем его
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }
    }
}
