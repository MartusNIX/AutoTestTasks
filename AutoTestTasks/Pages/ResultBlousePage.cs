using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTestTasks.Pages
{
    public class ResultBlousePage
    {
        protected readonly IWebDriver driver;

        public ResultBlousePage(IWebDriver webDriver)
        {
            driver = webDriver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }
        public IWebElement btnMore => driver.FindElement(By.CssSelector(" a.button.lnk_view.btn.btn-default"));

        public void ClickMoreBtn() => btnMore.Click();
    }
}
