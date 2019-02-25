using System;
using System.Data;
using System.Data.SQLite;

namespace csharp_scraper.Controllers
{
    public class Fetch : Data
    {
        public static void Data()
        {
            var sql = new SQLiteCommand("SELECT timeStamp, symbol, companyName, lastPrice, change, percentChange FROM stocks");

            try
            {
                var db = connect();
                db.Open();
                var reader = sql.ExecuteReader();
                Console.WriteLine("Fetching data...");

                while (reader.Read())
                {
                    Console.WriteLine(reader["timeStamp"].ToString());
                    Console.WriteLine(reader["symbol"].ToString());
                    Console.WriteLine(reader["companyName"].ToString());
                    Console.WriteLine(reader["lastPrice"].ToString());
                    Console.WriteLine(reader["change"].ToString());
                    Console.WriteLine(reader["percentChange"].ToString());
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        
        
    }
}