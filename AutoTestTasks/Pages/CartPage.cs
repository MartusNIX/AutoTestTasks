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

        public IWebElement titleFirstProductOnCartPage => driver.FindElement(By.CssSelector("#product_5_19_0_0 > td.cart_description > p > a"));
        public IWebElement priceFirstProductNameOnCartPage => driver.FindElement(By.CssSelector("#product_price_5_19_0 > span.price.special-price"));

        public string GetFirstProductTitleOnCartPage() => titleFirstProductOnCartPage.Text;
        public string GetPriceFirstProductNameOnCartPage() => priceFirstProductNameOnCartPage.Text;
    }
}
