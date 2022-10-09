using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTestSpec.Hooks
{
    public class BrowserDriverFactory
    {
        public IWebDriver GetWebDriver(string browserId)
        {
            switch (browserId)
            {
                case "Browser_Chrome": return GetChromeDriver();
                case "Browser_Edge": return GetEdgeDriver();
                case "Browser_Firefox": return GetFireFoxDriver();
                default: throw new NotSupportedException("Browser is not supported by the BrowserDrivers");
            }
        }

        private IWebDriver GetChromeDriver()
        {
            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            var chromeOptions = new ChromeOptions();
            var chromeDriver = new ChromeDriver(chromeDriverService, chromeOptions);
            return chromeDriver;
        }

        private IWebDriver GetEdgeDriver()
        {
            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            var chromeOptions = new ChromeOptions();
            var chromeDriver = new ChromeDriver(chromeDriverService, chromeOptions);
            return chromeDriver;

        }

        private IWebDriver GetFireFoxDriver()
        {
            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            var chromeOptions = new ChromeOptions();
            var chromeDriver = new ChromeDriver(chromeDriverService, chromeOptions);
            return chromeDriver;
        }
    }
}
