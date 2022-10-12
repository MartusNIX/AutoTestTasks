using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTestTasks.Pages
{
    public class CartPage
    {
        protected readonly IWebDriver driver;

        public CartPage(IWebDriver webDdriver)
        {
            driver = webDdriver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        public IWebElement titleFirstProductOnCartPage => driver.FindElement(By.CssSelector("tbody>tr>td:nth-child(2)>p"));
        public IWebElement titleSecondProductOnCartPage => driver.FindElement(By.CssSelector("tbody>tr:nth-child(2)>td:nth-child(2)>p"));
        public IWebElement priceFirstProductNameOnCartPage => driver.FindElement(By.CssSelector("tr:nth-child(1)>td>span>span:nth-child(1)"));
        public IWebElement priceSecondProductNameOnCartPage => driver.FindElement(By.CssSelector("tr:nth-child(2)>td>span>span:nth-child(1)"));
        public IWebElement colorFirstProductOnCartPage => driver.FindElement(By.PartialLinkText("Orange"));


        public string GetFirstProductTitleOnCartPage() => titleFirstProductOnCartPage.Text;
        public string GetSecondtProductTitleOnCartPage() => titleSecondProductOnCartPage.Text;
        public string GetPriceFirstProductNameOnCartPage() => priceFirstProductNameOnCartPage.Text;
        public string GetPriceSecondProductNameOnCartPage() => priceSecondProductNameOnCartPage.Text;
    }
}
