using System;
using System.Data.SQLite;

namespace csharp_scraper.Controllers
{
    public class Data
    {
        protected static SQLiteConnection connect()
        {
            const string url = "/Users/timothywheeler/RiderProjects/csharp-scraper/csharp-scraper/csharp-scraper/Models/stock_portfolio.db";

            var db = new SQLiteConnection("Data Source=" + url);
            
            try
            {
                Console.WriteLine("Connected to database...");
                db.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return db;
        }
    }
}