using SQLite;
using System;

namespace EstheticClinic_app.Models
{
    [Table("Kliendid")]
    public class Klient
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateTime { get; set; }
        public TimeSpan Time { get; set; }
        public string TeenuseNimetus { get; set; }
    }
}


