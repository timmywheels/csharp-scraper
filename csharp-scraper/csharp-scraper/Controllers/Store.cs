using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SQLite;
using System.Transactions;

namespace csharp_scraper.Controllers
{
    public class Store : Data
    {
        public static void Data(DateTime timeStamp, string symbol, string companyName, string lastPrice, string
            change, string percentChange)
        {
            var sql = new SQLiteCommand("INSERT INTO stocks(timeStamp, symbol, companyName, lastPrice, change, percentChange) VALUES(?,?,?,?,?,?)", connect());

            try
            {
                Console.WriteLine("Saving data...");
                sql.Parameters.AddWithValue("timeStamp", timeStamp);
                sql.Parameters.AddWithValue("symbol", symbol);
                sql.Parameters.AddWithValue("companyName", companyName);
                sql.Parameters.AddWithValue("lastPrice", lastPrice);
                sql.Parameters.AddWithValue("change", change);
                sql.Parameters.AddWithValue("percentChange", percentChange);
                sql.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }
    }
}