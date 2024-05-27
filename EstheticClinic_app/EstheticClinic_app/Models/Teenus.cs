using SQLite; // Подключение библиотеки для работы с SQLite

// Атрибут, указывающий, что данный класс будет связан с таблицей "Teenused" в базе данных
[Table("Teenused")]
public class Teenus
{
    // Атрибуты, указывающие, что это первичный ключ, автоматически увеличивающийся
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; } // Идентификатор услуги

    // Атрибут, указывающий, что это поле будет индексировано для ускорения поиска
    [Indexed]
    public string Nimetus { get; set; } // Название услуги

    public string Kirjeldus { get; set; } // Описание услуги
    public int Hind { get; set; } // Стоимость услуги
    public string Pilt { get; set; } // Изображение услуги (путь к файлу изображения)
}
