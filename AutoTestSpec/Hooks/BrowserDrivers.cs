using OpenQA.Selenium;

namespace AutoTestSpec.Hooks
{
    [Binding]
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

        [BeforeScenario("Browser_Chrome")]
        public void BeforeScenario_Browser_Chrome()
        {
            var stubbedLineForDebugOnly = "";
        }

        [BeforeScenario("Browser_Edge")]
        public void BeforeScenario_Browser_Edge()
        {
            var stubbedLineForDebugOnly = "";
        }

        [BeforeScenario("Browser_Firefox")]
        public void BeforeScenario_Browser_Firefox()
        {
            var stubbedLineForDebugOnly = "";
        }

        public IWebDriver Current => _currentWebDriverLazy.Value;

        private IWebDriver CreateWebDriver()
        {
            string browserId = "Browser_Chrome";//ConfigurationManager.AppSettings["Browser_Chrome"];
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
