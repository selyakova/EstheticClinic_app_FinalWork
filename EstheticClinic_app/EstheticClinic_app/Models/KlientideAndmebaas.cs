using SQLite;
using System.Collections.Generic;

namespace EstheticClinic_app.Models
{
    public class KlientideAndmebaas
    {
        SQLiteConnection database;
        public KlientideAndmebaas(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Klient>();
            database.CreateTable<Teenus>(); 
        }
        public IEnumerable<Klient> GetItems()
        {
            return database.Table<Klient>().ToList();
        }
        public Klient GetItem(int id)
        {
            return database.Get<Klient>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<Klient>(id);
        }
        public int DeleteAllItems()
        {
            return database.DeleteAll<Klient>();
        }
        public int SaveItem(Klient item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
        public IEnumerable<Teenus> GetTeenusList()
        {
            return database.Table<Teenus>().ToList();
        }
    }
}
