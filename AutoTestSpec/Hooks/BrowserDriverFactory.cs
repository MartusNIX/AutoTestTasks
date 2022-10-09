using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

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
                case "Browser_Firefox": return GetFirefoxDriver();
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
            var edgeDriverService = EdgeDriverService.CreateDefaultService();
            var edgeOptions = new EdgeOptions();
            var edgeDriver = new EdgeDriver(edgeDriverService, edgeOptions);
            return edgeDriver;

        }

        private IWebDriver GetFirefoxDriver()
        {
            var firefoxDriverService = FirefoxDriverService.CreateDefaultService();
            var firefoxOptions = new FirefoxOptions();
            var firefoxDriver = new FirefoxDriver(firefoxDriverService, firefoxOptions);
            return firefoxDriver;
        }
    }
}
