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

        public IWebElement titleFirstProductOnCartPage => driver.FindElement(By.CssSelector("tbody>tr:nth-child(1)>td:nth-child(2)>p"));
        public IWebElement titleSecondProductOnCartPage => driver.FindElement(By.CssSelector("tbody>tr:nth-child(2)>td:nth-child(2)>p"));
        public IWebElement priceFirstProductOnCartPage => driver.FindElement(By.CssSelector("tr:nth-child(1)>td>span>span:nth-child(1)"));
        public IWebElement priceSecondProductOnCartPage => driver.FindElement(By.CssSelector("tr:nth-child(2)>td>span>span:nth-child(1)"));
        public IWebElement colorFirstProductOnCartPage => driver.FindElement(By.CssSelector("tbody>tr:nth-child(1)>td:nth-child(2)>small>a"));
        public IWebElement colorSecondProductOnCartPage => driver.FindElement(By.CssSelector("tbody>tr:nth-child(2)>td:nth-child(2)>small>a"));
        public IWebElement sizeFirstProductOnCartPage => driver.FindElement(By.CssSelector("tbody>tr:nth-child(1)>td:nth-child(2)>small>a"));
        public IWebElement sizeSecondProductOnCartPage => driver.FindElement(By.CssSelector("tbody>tr:nth-child(2)>td:nth-child(2)>small>a"));
        public IWebElement qtyFirstProductOnCartPage => driver.FindElement(By.CssSelector("tbody>tr:nth-child(1)>td:nth-child(5)>input:nth-child(2)"));
        public IWebElement qtySecondProductOnCartPage => driver.FindElement(By.CssSelector("tbody>tr:nth-child(2)>td:nth-child(5)>input:nth-child(2)"));
        public IWebElement total1ProductOnCartPage => driver.FindElement(By.CssSelector("tbody>tr:nth-child(1)>td:nth-child(6)>span"));
        public IWebElement total2ProductOnCartPage => driver.FindElement(By.CssSelector("tbody>tr:nth-child(2)>td:nth-child(6)>span"));

        public string Get1ProductTitleOnCartPage() => titleFirstProductOnCartPage.Text;
        public string Get2ProductTitleOnCartPage() => titleSecondProductOnCartPage.Text;
        public string Get1PriceProductPriceOnCartPage() => priceFirstProductOnCartPage.Text;
        public string Get2PriceProductOnCartPage() => priceSecondProductOnCartPage.Text;
        public string Get1ProductColorCartPage() => colorFirstProductOnCartPage.Text;
        public string Get2ProductColorCartPage() => colorSecondProductOnCartPage.Text;
        public string Get1ProductSizeCartPage() => sizeFirstProductOnCartPage.Text;
        public string Get2ProductSizeCartPage() => sizeSecondProductOnCartPage.Text;
        public string Get1ProductQtyCardPage() => qtyFirstProductOnCartPage.GetAttribute("value");
        public string Get2ProductQtyCardPage() => qtySecondProductOnCartPage.GetAttribute("value");
        public string GetTotal1ProductCartPage() => total1ProductOnCartPage.Text;
        public string GetTotal2ProductCartPage() => total2ProductOnCartPage.Text;
    }
}
