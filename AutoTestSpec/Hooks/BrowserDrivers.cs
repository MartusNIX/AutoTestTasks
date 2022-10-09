using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Configuration;
using System.Formats.Asn1;
using System.Xml;

namespace AutoTestSpec.Hooks
{
    [Binding]
    public class BrowserDrivers : IDisposable
    {
        private readonly BrowserDriverFactory browserDriverFactory;
        private readonly Lazy<IWebDriver> _currentWebDriverLazy;
        private bool _isDisposed;

        public BrowserDrivers(ScenarioContext context)
        {
            var tags = context.ScenarioInfo.Tags;
            browserDriverFactory = new BrowserDriverFactory();
            _currentWebDriverLazy = new Lazy<IWebDriver>(CreateWebDriver);
        }

        [BeforeScenario("Browser_Chrome")]
        public void BeforeScenario()
        {
            var tags = ScenarioContext.Current.ScenarioInfo.Tags;
            var temmp = "";
        }

        [BeforeScenario("Browser_Chrome2222")]
        public void BeforeScenari2o()
        {
            var tags = ScenarioContext.Current.ScenarioInfo.Tags;
            var temmp = "";
        }

        public IWebDriver Current => _currentWebDriverLazy.Value;

        private IWebDriver CreateWebDriver()
        {
            var tags = ScenarioContext.Current.ScenarioInfo.Tags;
            var tag2 = ConfigurationManager.GetSection("environment");
            var temmp = "";
            var envVar = Environment.GetEnvironmentVariable("Test_Browser");
            var envVar2 = Environment.GetEnvironmentVariable("browserName");
            var varConf = ConfigurationManager.AppSettings["ChromeBrowser"];
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
