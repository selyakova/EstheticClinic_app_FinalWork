using SQLite;

[Table("Teenused")]
public class Teenus
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    [Indexed]
    public string Nimetus { get; set; }
    public string Kirjeldus { get; set; }
    public int Hind { get; set; }
    public string Pilt { get; set; }
}


