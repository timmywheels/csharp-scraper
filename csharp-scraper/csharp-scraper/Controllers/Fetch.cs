using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;

namespace csharp_scraper.Controllers
{
    public class Fetch : Data
    {
        private struct Stock
        {
            public object timeStamp;
            public string symbol;
            public string companyName;
            public string lastPrice;
            public string change;
            public string percentChange;
        }

        public static string data()
        {
            List<Stock> stocks = new List<Stock>();
            var json = "";
            var db = connect();
            try
            {
                const string sql = "SELECT timeStamp, symbol, companyName, lastPrice, change, percentChange FROM stocks";
                var command = new SQLiteCommand(sql, db);
                var reader = command.ExecuteReader();
                Console.WriteLine("Fetching data...");

                while (reader.Read())
                {
                    Stock stock = new Stock();
                    stock.timeStamp = reader["timeStamp"];
                    stock.symbol = reader["symbol"].ToString();
                    stock.companyName = reader["companyName"].ToString();
                    stock.lastPrice = reader["lastPrice"].ToString();
                    stock.change = reader["change"].ToString();
                    stock.percentChange = reader["percentChange"].ToString();

                    stocks.Add(stock);
                }
                json = JsonConvert.SerializeObject(stocks, Formatting.Indented);
                Console.WriteLine("JSON: {0}", json);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return json;
        }


    }
}