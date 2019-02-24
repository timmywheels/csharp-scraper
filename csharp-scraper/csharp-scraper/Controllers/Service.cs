using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using Microsoft.CodeAnalysis.Text;
using Microsoft.VisualBasic.CompilerServices;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace csharp_scraper.Controllers
{
    public class Service : Auth
    {
        public static void Run(IWebDriver driver, DefaultWait<IWebDriver> wait)
        {
            try
            {
                ReadOnlyCollection<IWebElement> stockData = wait.Until(element =>
                    element.FindElements(
                        By.CssSelector("#data-util-col > section:nth-child(1) > table > tbody > tr > td")));

                Console.WriteLine("Collecting data...");

                var stockList = new List<string>();

                var singleStock = new List<string>();

                const int totalDataPointsPerStock = 4;

                foreach (var stockDataCell in stockData)
                {
                    singleStock.Add(stockDataCell.Text.Trim());

                    if (singleStock.Count() == totalDataPointsPerStock)
                    {
                        var companyNameAndSymbol =
                            singleStock[0].Split(new[] {"\r\n", "\r", "\n"}, StringSplitOptions.None);

                        var symbol = companyNameAndSymbol[0];
                        Console.WriteLine("symbol: {0}", symbol);

                        var companyName = companyNameAndSymbol[1];
                        Console.WriteLine("companyName: {0}", companyName);

                        var lastPrice = singleStock[1];
                        Console.WriteLine("lastPrice: {0}", lastPrice);

                        var change = singleStock[2];
                        Console.WriteLine("change: {0}", change);

                        var percentChange = singleStock[3];
                        Console.WriteLine("percentChange: {0}", percentChange);

                        Console.WriteLine("====================");

                        //Store.data(timeStamp, symbol, companyName, lastPrice, change, percentChange);

                        stockList.AddRange(singleStock);
                        singleStock = new List<string>();
                    }
                }

                driver.Quit();
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not collect data!");
                Console.WriteLine(e.ToString());
                //driver.Quit();
            }
        }
    }
}