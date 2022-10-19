using OpenQA.Selenium;
using System.Diagnostics;
using System;
using AutoTestTasks.Pages;
using System.Reflection;

namespace AutoTestTasks.Pages
{
    public class ResultSearchPage
    {
        protected readonly IWebDriver driver;

        public ResultSearchPage(IWebDriver webDriver)
        {
            driver = webDriver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }
        public IWebElement searchField => driver.FindElement(By.Id("search_query_top"));
        public IWebElement headerText => driver.FindElement(By.ClassName("lighter"));
        public IWebElement dropdownProductSortHighFirst => driver.FindElement(By.CssSelector("#selectProductSort > option:nth-child(3)"));
        public IWebElement elementPrice1 => driver.FindElement(By.CssSelector("ul.product_list.grid.row>li>div>div:nth-child(2)>div.content_price>span.price.product-price"));
        public IWebElement elementPriceOld1 => driver.FindElement(By.CssSelector("ul.product_list.grid.row>li:nth-child(1)>div>div:nth-child(2)>div.content_price>span.old-price.product-price"));
        public IWebElement elementPrice2 => driver.FindElement(By.CssSelector("#center_column > ul > li:nth-child(2) > div > div.right-block > div.content_price > span"));
        public IWebElement elementPriceOld3 => driver.FindElement(By.CssSelector("ul.product_list.grid.row>li:nth-child(3)>div>div:nth-child(2)>div.content_price>span.old-price.product-price"));
        public IWebElement elementPrice4 => driver.FindElement(By.CssSelector("#center_column > ul > li:nth-child(4) > div > div.right-block > div.content_price > span"));
        public IWebElement btnAddToCardFirstProductOnResultPage => driver.FindElement(By.CssSelector("ul.product_list.grid.row>li:nth-child(1)>div>div:nth-child(2)>.button-container>a:nth-child(1)"));
        public IWebElement btnProceedToCheckout => driver.FindElement(By.CssSelector("#layer_cart > div.clearfix > div.layer_cart_cart.col-xs-12.col-md-6 > div.button-container > a"));
        public IWebElement titleFirstProductOnResultPage => driver.FindElement(By.CssSelector("ul.product_list.grid.row>li>div>div:nth-child(2)>h5>a"));
        public IWebElement btnMoreOnResultPage => driver.FindElement(By.CssSelector("a[title = 'View']"));
        public IWebElement searchBtn => driver.FindElement(By.Name("submit_search"));

        public string GetInsertedWord() => searchField.GetAttribute("value").ToLower();
        public string GetDisplayedWord() => headerText.Text.TrimStart('\"').TrimEnd('\"').ToLower();
        public void ClickDropdownProductSortHighFirst() => dropdownProductSortHighFirst.Click();
        public void ClickOnFirstProduct() => btnAddToCardFirstProductOnResultPage.Click();
        public void ClickOnLProceedToCheckoutBtn() => btnProceedToCheckout.Click();
        public void ClickSearchBtnOnResultPage() => searchBtn.Click();
        public string GetNewProductPrice() => elementPrice1.Text;
        public string GetOldProductPrice() => elementPriceOld1.Text;
        public string GetProductName() => titleFirstProductOnResultPage.Text;
        public void ClickOnMoreOnResultPage() => btnMoreOnResultPage.Click();

        
        public Pricezz GetPricezz(int index)
        {
            string currentPrice = GetCurrentPrice(index);
            string oldPrice = GetOldPrice(index);

            return new Pricezz
            {
                CurrentPrice = currentPrice,
                OldPrice = oldPrice
            };
        }

        private string GetCurrentPrice(int index)
        {
            IWebElement price = driver.FindElement(By.CssSelector($"ul.product_list.grid.row>li:nth-child({index})>div>div>div.content_price>span.price.product-price"));
            return price.Text;
        }

        private string GetOldPrice(int index)
        {
            try
            {
                var oldPrice = driver.FindElement(By.CssSelector($"ul.product_list.grid.row>li:nth-child({index})>div>div>div.content_price>span.old-price.product-price"));
                return oldPrice.Text;
            }
            catch (Exception)
            {
                return "";
            }
        }

        public List<string> AllPriceInfo()
        {
            List<string> priceList = new List<string>();

            int productsCount = GetProductListSize();
            for (var index = 1; index <= productsCount; index++)
            {
                Pricezz price = GetPricezz(index);
                string currentPrice = price.CurrentPrice;
                string oldPrice = price.OldPrice;
                Console.WriteLine("current price {0}", currentPrice);
                Console.WriteLine("    old price {0}", oldPrice);

                if (oldPrice != "")
                {
                    priceList.Add(oldPrice);
                } else
                {
                    priceList.Add(currentPrice);
                }
            }
            return priceList;
        }

        private int GetProductListSize()
        {
            IWebElement gridElement = driver.FindElement(By.CssSelector(".product_list.row.grid"));
            IList<IWebElement> productList = gridElement.FindElements(By.CssSelector("ul.product_list.grid.row>li>div>div>div.content_price>span.price.product-price"));
            return productList.Count;
        }
    }
}
