using SQLite; // Подключение библиотеки для работы с SQLite
using System.Collections.Generic; // Подключение стандартной библиотеки для работы с коллекциями

namespace EstheticClinic_app.Models
{
    public class KlientideAndmebaas
    {
        SQLiteConnection database; // Переменная для хранения соединения с базой данных

        // Конструктор, который принимает путь к базе данных
        public KlientideAndmebaas(string databasePath)
        {
            // Создание соединения с базой данных
            database = new SQLiteConnection(databasePath);
            // Создание таблицы Klient в базе данных, если она еще не существует
            database.CreateTable<Klient>();
            // Создание таблицы Teenus в базе данных, если она еще не существует
            database.CreateTable<Teenus>();
        }

        // Метод для получения всех записей из таблицы Klient
        public IEnumerable<Klient> GetItems()
        {
            // Возвращает список всех клиентов из таблицы Klient
            return database.Table<Klient>().ToList();
        }

        // Метод для получения конкретной записи из таблицы Klient по идентификатору
        public Klient GetItem(int id)
        {
            // Возвращает клиента по идентификатору
            return database.Get<Klient>(id);
        }

        // Метод для удаления конкретной записи из таблицы Klient по идентификатору
        public int DeleteItem(int id)
        {
            // Удаляет клиента по идентификатору и возвращает количество удаленных записей (обычно 1)
            return database.Delete<Klient>(id);
        }

        // Метод для удаления всех записей из таблицы Klient
        public int DeleteAllItems()
        {
            // Удаляет всех клиентов и возвращает количество удаленных записей
            return database.DeleteAll<Klient>();
        }

        // Метод для сохранения записи в таблице Klient
        public int SaveItem(Klient item)
        {
            // Если у клиента есть идентификатор, обновляет существующую запись
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id; // Возвращает идентификатор обновленного клиента
            }
            else
            {
                // Если идентификатора нет, создает новую запись и возвращает идентификатор новой записи
                return database.Insert(item);
            }
        }

        // Метод для получения всех записей из таблицы Teenus
        public IEnumerable<Teenus> GetTeenusList()
        {
            // Возвращает список всех услуг из таблицы Teenus
            return database.Table<Teenus>().ToList();
        }
    }
}
