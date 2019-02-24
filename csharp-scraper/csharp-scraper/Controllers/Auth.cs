using System;
using Microsoft.CodeAnalysis.Text;
using Microsoft.IdentityModel.Xml;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace csharp_scraper.Controllers
{
    public class Auth
    {
          
        public static void WebClient(string loginUrl, string username, string password)
        {
            
            var driver = new FirefoxDriver("/Library/Java/Extensions");


//            var wait = new DefaultWait<IWebDriver>(driver)
//            {
//                Timeout = TimeSpan.FromSeconds(10),
//                PollingInterval = TimeSpan.FromMilliseconds(1000)
//            };
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.PollingInterval = TimeSpan.FromMilliseconds(500);
            //wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            //var options = new FirefoxOptions();
            //options.SetLoggingPreference(LogType.Browser, LogLevel.Severe);

            try
            {
                // 1. NAVIGATE TO YAHOO FINANCE
                driver.Navigate().GoToUrl(loginUrl);
                Console.WriteLine("Page Title: " + driver.Title);
                Console.WriteLine("URL: " + driver.Url);
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not navigate to url!");
                Console.WriteLine(e.ToString());
                driver.Quit();
            }

            try
            {
                // 2. ENTER USERNAME
                var usernameInput = wait.Until(element => element.FindElement(By.CssSelector("#login-username")));
                usernameInput.SendKeys(username);
                Console.WriteLine("Entering username...");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error entering username!");
                Console.WriteLine(e.ToString());
            }

            try
            {
                // 3. CLICK NEXT BUTTON
                var nextButton = wait.Until(element => element.FindElement(By.CssSelector("#login-signin")));
                nextButton.Click();
                Console.WriteLine("'Next' button clicked...");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error clicking 'Next' button!");
                Console.WriteLine(e.ToString());
            }

            try
            {
                // 4. ENTER PASSWORD
                var passwordInput = wait.Until(element => element.FindElement(By.CssSelector("#login-passwd")));
                //var passwordInput = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("#login-passwd")));

                passwordInput.SendKeys(password);
                Console.WriteLine("Entering password...");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error entering password!");
                Console.WriteLine(e.ToString());
            }

            try
            {
                // 5. CLICK 'SIGN-IN' BUTTON
                var signInButton = wait.Until(element => element.FindElement(By.CssSelector("#login-signin")));
                signInButton.Click();
                Console.WriteLine("'Sign-in' button clicked...");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error clicking 'Sign-in' button!");
                Console.WriteLine(e.ToString());
            }

            try
            {
                // 6. SCRAPE DATA
                Service.Run(driver, wait);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }
    }
}