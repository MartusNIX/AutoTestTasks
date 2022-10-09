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
            //string browserName = browserId.ToUpper();
            switch (browserId)
            {
                case "CHROME": return GetChromeDriver();
                case "EDGE": return GetEdgeDriver();
                case "FIREFOX": return GetFireFoxDriver();
                default: throw new NotSupportedException("Not supported browser: <null>");
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
