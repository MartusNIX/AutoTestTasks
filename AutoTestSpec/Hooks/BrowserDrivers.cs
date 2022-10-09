using OpenQA.Selenium;

namespace AutoTestSpec.Hooks
{
    [Binding]
    public class BrowserDrivers : IDisposable
    {
        private readonly BrowserDriverFactory browserDriverFactory;
        private Lazy<IWebDriver> _currentWebDriverLazy;
        private bool _isDisposed;

        public BrowserDrivers()
        {
            browserDriverFactory = new BrowserDriverFactory();
        }

        [BeforeScenario("Browser_Chrome")]
        public void BeforeScenarioChrome_Browser_Chrome()
        {
            _currentWebDriverLazy = new Lazy<IWebDriver>(CreateWebDriver("Browser_Chrome"));
        }

        [BeforeScenario("Browser_Edge")]
        public void BeforeScenarioFirefox_Browser_Edge()
        {
            _currentWebDriverLazy = new Lazy<IWebDriver>(CreateWebDriver("Browser_Edge"));
        }

        [BeforeScenario("Browser_Firefox")]
        public void BeforeScenario_Browser_Firefox()
        {
            _currentWebDriverLazy = new Lazy<IWebDriver>(CreateWebDriver("Browser_Firefox"));
        }

        public IWebDriver Current => _currentWebDriverLazy.Value;
        
        private IWebDriver CreateWebDriver(string browserName)
        {
            return browserDriverFactory.GetWebDriver(browserName);
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
