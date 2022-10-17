using OpenQA.Selenium;

namespace AutoTestTasks.Pages
{
    public class HomePage
    {
        private const string AutopracticeUrl = "http://automationpractice.com/index.php";
        private readonly IWebDriver driver;

        public HomePage(IWebDriver webDriver)
        {
            driver = webDriver;
            driver.Navigate().GoToUrl(AutopracticeUrl);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        public IWebElement searchField => driver.FindElement(By.Id("search_query_top"));
        public IWebElement searchBtn => driver.FindElement(By.Name("submit_search"));
        public string pageTitle => driver.Title;

        public void InsertWordInSearchfield(string text) => searchField.SendKeys(text);
        public void ClickSearchBtnOnSearchPage() => searchBtn.Click();
    }
}