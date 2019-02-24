using System;

namespace csharp_scraper.Controllers
{
    public class Credentials
    {
        public string LoginUrl { get; } = "https://login.yahoo.com/config/login?.intl=us&.lang=en-US&.src=finance&.done=https%3A%2F%2Ffinance.yahoo.com%2F";

        public string Username { get; } = "tim@timwheeler.com";

        public string Password { get; } = "Scraper2019!!";
    }
}