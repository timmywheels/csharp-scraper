using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;


namespace csharp_scraper.Controllers
{
    public class Service
    {
        private IWebDriver driver;
        
        public void startBrowser()
        {
            driver = new FirefoxDriver("/Library/Java/Extensions");
            driver.Url = "https://www.timwheeler.com";
        }
        
        
        
    }
}