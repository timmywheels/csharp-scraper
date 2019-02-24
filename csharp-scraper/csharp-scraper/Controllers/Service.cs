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
		public static void run(IWebDriver driver, WebDriverWait wait)
		{

			try
			{

			Console.WriteLine("Collecting data...");
			var dataTable = wait.Until(webDriver =>
				webDriver.FindElement(By.XPath(
					"/html/body/div[1]/div/div/div[1]/div/div[3]/div[2]/div/div/div/div/div/div[3]/div/div/section/div/section[1]/table/tbody/tr[1]")));
			ReadOnlyCollection<IWebElement> stockData =
				driver.FindElements(By.CssSelector("#data-util-col > section:nth-child(1) > table > tbody > tr > td"));

			var stockList = new List<string>();

			var singleStock = new List<string>();

			var totalDataPointsPerStock = 4;

			foreach (IWebElement stockDataCell in stockData) {


				if (singleStock.Count() != totalDataPointsPerStock) continue;

				stockList.AddRange(singleStock);

				var companyNameAndSymbol = singleStock[0].Split(
					new[] { "\r\n", "\r", "\n" },
					StringSplitOptions.None
				);

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

//					Store.data(timeStamp, symbol, companyName, lastPrice, change, percentChange);

				singleStock.Add(stockDataCell.Text.Trim());
				singleStock = new List<string>();
			}

			foreach (var stock in stockList)
			{
				Console.WriteLine("stock: {0}", stock);
			}
			{

			}

			driver.Quit();

			} catch (Exception e) {
				Console.WriteLine("Could not collect data!");
				Console.WriteLine(e.ToString());
				driver.Quit();
			}
		}
	}
}


