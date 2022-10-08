using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Configuration;
using System.Xml;

namespace AutoTestSpec.Hooks
{
    public class BrowserDrivers : IDisposable
    {
        private readonly BrowserDriverFactory browserDriverFactory;
        private readonly Lazy<IWebDriver> _currentWebDriverLazy;
        private bool _isDisposed;

        public BrowserDrivers()
        {
            browserDriverFactory = new BrowserDriverFactory();
            _currentWebDriverLazy = new Lazy<IWebDriver>(CreateWebDriver);
        }

        public IWebDriver Current => _currentWebDriverLazy.Value;

        private IWebDriver CreateWebDriver()
        {
            string browserId = "CHROME";//ConfigurationManager.AppSettings["ChromeBrowser"];
            return browserDriverFactory.GetWebDriver(browserId); ;
        }

        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            if (_currentWebDriverLazy.IsValueCreated)
            {
                Current.Quit();
            }

            _isDisposed = true;
        }
    }
}
