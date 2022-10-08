using OpenQA.Selenium;

namespace AutoTestTasks.Pages
{
    public class Homepaje
    {
        private const string AutopracticeUrl = "http://automationpractice.com/index.php";
        private readonly IWebDriver driver;
        public const int DefaultWaitInSeconds = 5;
        public Homepaje(IWebDriver webDriver)
        {
            driver = webDriver;
            driver.Navigate().GoToUrl(AutopracticeUrl);
        }

        public IWebElement searchField => driver.FindElement(By.Id("search_query_top"));
        public IWebElement searchBtn => driver.FindElement(By.Name("submit_search"));
        public string pageTitle => driver.Title;

        public void InsertWordInSearchfield(string text) => searchField.SendKeys(text);
        public void ClickSearchBtn() => searchBtn.Click();
        
    }
}