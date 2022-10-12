using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AutoTestTasks.Pages
{
    public class BlousePage
    {
        protected readonly IWebDriver driver;
        public BlousePage(IWebDriver webDdriver)
        {
            driver = webDdriver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        public IWebElement insertQuantityField => driver.FindElement(By.Id("quantity_wanted"));
        public IWebElement dropdownMediumSize => driver.FindElement(By.CssSelector("#group_1 > option:nth-child(2)"));
        public IWebElement dropdownLargeSize => driver.FindElement(By.CssSelector("#group_1 > option:nth-child(3)"));
        public IWebElement listColorBlack => driver.FindElement(By.Name("White"));
        public IWebElement listColorOrange => driver.FindElement(By.CssSelector("a[name = 'Orange']"));

        public IWebElement btnAddToCard => driver.FindElement(By.Name("Submit"));
        public IWebElement modalWindow => driver.FindElement(By.CssSelector("#layer_cart > div.clearfix"));
        public IWebElement btnContinueShopping => driver.FindElement(By.CssSelector("span[title = 'Continue shopping']"));
        public IWebElement btnCheckout => driver.FindElement(By.CssSelector("a[title = 'Proceed to checkout']"));
        public IWebElement searchField => driver.FindElement(By.Id("search_query_top"));
        public IWebElement searchBtn => driver.FindElement(By.Name("submit_search"));

        public void ClearPreviousDataFromSearch() => searchField.Clear();
        public void ClearPreviousDataFromQuantity() => insertQuantityField.Clear();
        public void InsertWordInInputField(string text) => insertQuantityField.SendKeys(text);
        public void InsertWordInSearchfield(string text) => searchField.SendKeys(text);
        public void SelectLargeSize() => dropdownLargeSize.Click();
        public void SelectMediumSize() => dropdownMediumSize.Click();
        public void SelectBlackColor() => listColorBlack.Click();
        public void SelectOrangeColor() => listColorOrange.Click();
        public void ClickAddToCardBtn() => btnAddToCard.Click();
        public void ClickContinueShoppingBtn() => btnContinueShopping.Click();
        public void ClickCheckoutBtn() => btnCheckout.Click();
        public void ClickSearchBtn() => searchBtn.Click();
        public bool ModalWindowIsShown()
        {
            return driver.FindElement(By.CssSelector("#layer_cart > div.clearfix")).Enabled;
        }
    }
}
