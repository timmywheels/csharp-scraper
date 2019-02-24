using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            Console.WriteLine("Collecting data...");
            var dataTable = wait.Until(webDriver => webDriver.FindElement(By.XPath("/html/body/div[1]/div/div/div[1]/div/div[3]/div[2]/div/div/div/div/div/div[3]/div/div/section/div/section[1]/table/tbody/tr[1]")));
            ReadOnlyCollection<IWebElement> stockData = driver.FindElements(By.CssSelector("#data-util-col > section:nth-child(1) > table > tbody > tr > td"));
//            Console.WriteLine("stockData:", stockData);
            foreach(var stock in stockData)
            {
                Console.Write("{0}\n", stock.Text);
            }



        }

    }
}