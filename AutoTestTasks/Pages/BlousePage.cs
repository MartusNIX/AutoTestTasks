﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public IWebElement dropdownSize => driver.FindElement(By.CssSelector("#group_1 > option:nth-child(3)"));
        public IWebElement listColorPicer => driver.FindElement(By.CssSelector("#color_to_pick_list > li:nth-child(1)"));
        public IWebElement btnAddToCard => driver.FindElement(By.Name("Submit"));
        public IWebElement modalWindow => driver.FindElement(By.CssSelector("#layer_cart > div.clearfix"));
        public IWebElement btnContinueShopping => driver.FindElement(By.CssSelector("span[title = 'Continue shopping']"));
        public IWebElement searchField => driver.FindElement(By.Id("search_query_top"));
        public IWebElement searchBtn => driver.FindElement(By.Name("submit_search"));

        public void ClearPreviousDataFromQuantity() => searchField.Clear();
        public void ClearPreviousDataFromSearch() => insertQuantityField.Clear();
        public void InsertWordInInputField(string text) => insertQuantityField.SendKeys(text);
        public void SelectLargeSize() => dropdownSize.Click();
        public void SelectColor() => listColorPicer.Click();
        public void ClickAddToCardBtn() => btnAddToCard.Click();
        public void ClickContinueShoppingBtn() => btnContinueShopping.Click();
        public bool ModalWindowIsShown()
        {
            return driver.FindElement(By.CssSelector("#layer_cart > div.clearfix")).Enabled;
        }
        public void InsertWordInSearchfield(string text) => searchField.SendKeys(text);
        public void ClickSearchBtn() => searchBtn.Click();
    }
}
