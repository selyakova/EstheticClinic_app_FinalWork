using SQLite; // Подключение библиотеки для работы с SQLite
using System; // Подключение стандартной библиотеки .NET

namespace EstheticClinic_app.Models
{
    // Атрибут, указывающий, что данный класс будет связан с таблицей "Kliendid" в базе данных
    [Table("Kliendid")]
    public class Klient
    {
        // Атрибуты, указывающие, что это первичный ключ, автоматически увеличивающийся, и будет храниться в столбце "_id"
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; } // Идентификатор клиента

        public string Name { get; set; } // Имя клиента
        public string Email { get; set; } // Электронная почта клиента
        public string Phone { get; set; } // Телефонный номер клиента
        public DateTime DateTime { get; set; } // Дата и время записи клиента
        public TimeSpan Time { get; set; } // Продолжительность записи
        public string TeenuseNimetus { get; set; } // Название услуги, на которую записан клиент
    }
}