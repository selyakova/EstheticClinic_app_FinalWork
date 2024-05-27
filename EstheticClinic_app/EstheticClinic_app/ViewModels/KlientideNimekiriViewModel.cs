using EstheticClinic_app.Views; // Подключение пространства имен с представлениями
using System; // Подключение стандартной библиотеки .NET
using System.Collections.ObjectModel; // Подключение библиотеки для работы с ObservableCollection
using System.ComponentModel; // Подключение библиотеки для реализации интерфейсов INotifyPropertyChanged
using System.Windows.Input; // Подключение библиотеки для работы с командами
using Xamarin.Forms; // Подключение библиотеки Xamarin.Forms для разработки кроссплатформенных приложений

namespace EstheticClinic_app.ViewModels
{
    // Реализация интерфейса INotifyPropertyChanged для уведомления об изменении свойств
    public class KlientideNimekiriViewModel : INotifyPropertyChanged
    {
        // Событие для уведомления об изменении свойств
        public event PropertyChangedEventHandler PropertyChanged;

        // ObservableCollection для хранения списка клиентов
        public ObservableCollection<KlientViewModel> Kliendid { get; set; }

        // Команды для создания, удаления, сохранения клиентов и возврата назад
        public ICommand CreateKlientCommand { get; protected set; }
        public ICommand DeleteKlientCommand { get; protected set; }
        public ICommand SaveKlientCommand { get; protected set; }
        public ICommand BackCommand { get; protected set; }

        // Выбранный клиент
        KlientViewModel selectedKlient;

        // Свойство для навигации
        public INavigation Navigation { get; set; }

        // Конструктор ViewModel
        public KlientideNimekiriViewModel()
        {
            // Инициализация списка клиентов
            Kliendid = new ObservableCollection<KlientViewModel>();
            // Инициализация команд
            CreateKlientCommand = new Command(CreateKlient);
            DeleteKlientCommand = new Command(DeleteKlient);
            SaveKlientCommand = new Command(SaveKlient);
            BackCommand = new Command(Back);
        }

        // Метод для создания нового клиента (пока не реализован)
        private void CreateKlient(object obj)
        {
            throw new NotImplementedException();
        }

        // Свойство для получения и установки выбранного клиента
        public KlientViewModel SelectedKlient
        {
            get { return selectedKlient; }
            set
            {
                if (selectedKlient != value)
                {
                    // Временное хранение выбранного клиента
                    KlientViewModel tempKlient = value;
                    // Сброс выбранного клиента
                    selectedKlient = null;
                    // Уведомление об изменении свойства
                    OnPropertyChanged("SelectedKlient");
                    // Переход к новому представлению с выбранным клиентом
                    Navigation.PushAsync(new Kliendid(tempKlient));
                }
            }
        }

        // Метод для уведомления об изменении свойства
        private void OnPropertyChanged(string v)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }

        // Метод для сохранения клиента
        private void SaveKlient(object klientobject)
        {
            // Преобразование объекта в KlientViewModel
            KlientViewModel klient = (KlientViewModel)klientobject;
            // Проверка на валидность клиента и его отсутствие в списке
            if (klient != null && klient.IsValid && !Kliendid.Contains(klient))
            {
                // Добавление клиента в список
                Kliendid.Add(klient);
            }
            // Возврат назад
            Back();
        }

        // Метод для возврата назад
        public void Back()
        {
            Navigation.PopAsync();
        }

        // Метод для удаления клиента
        private void DeleteKlient(object klientobject)
        {
            // Преобразование объекта в KlientViewModel
            KlientViewModel klient = (KlientViewModel)klientobject;
            // Проверка на наличие клиента
            if (klient != null)
            {
                // Удаление клиента из списка
                Kliendid.Remove(klient);
                // Возврат назад
                Back();
            }
        }

        // Метод для создания нового клиента (аналогичный CreateKlient)
        private void CreateFriend()
        {
            Navigation.PushAsync(new Kliendid(new KlientViewModel() { ListViewModel = this }));
        }
    }
}
