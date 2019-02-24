using System;
using Microsoft.CodeAnalysis.Text;
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

            WebDriverWait wait =
                new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            var options = new FirefoxOptions();
//            options.SetLoggingPreference(null, LogLevel.Severe);

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
                var usernameInput = wait.Until(webDriver => webDriver.FindElement(By.CssSelector("#login-username")));
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
                var nextButton = wait.Until(webDriver => webDriver.FindElement(By.CssSelector("#login-signin")));
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
                var passwordInput = wait.Until(webDriver => webDriver.FindElement(By.CssSelector("#login-passwd")));
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
                var signInButton = wait.Until(webDriver => webDriver.FindElement(By.CssSelector("#login-signin")));
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
                Service.run(driver, wait);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }
    }
}