using OpenQA.Selenium;
using System.Diagnostics;

namespace AutoTestTasks.Pages
{
    public class ResultPage
    {
        protected readonly IWebDriver driver;

        public ResultPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public IWebElement searchField => driver.FindElement(By.Id("search_query_top"));
        public IWebElement headerText => driver.FindElement(By.ClassName("lighter"));
        public IWebElement dropdownProductSortHighFirst => driver.FindElement(By.CssSelector("#selectProductSort > option:nth-child(3)"));
        
      

        public string GetInsertedWord() => searchField.GetAttribute("value").ToLower();
        public string GetDisplayedWord() => headerText.Text.TrimStart('\"').TrimEnd('\"').ToLower();
        public void ClickDropdownProductSortHighFirst() => dropdownProductSortHighFirst.Click();
/*        public void GetPrice()
        {
            IWebElement webElement = driver.FindElement(By.CssSelector(".product_list.row.grid"));
            IList<IWebElement> webElementList = webElement.FindElements(By.CssSelector(".price.product-price"));
            foreach (IWebElement price in webElementList)
            {
                System.Console.WriteLine(price.Text);
            }
        }
        public void GetOldPrice()
        {
            IWebElement webElementOld = driver.FindElement(By.CssSelector(".product_list.row.grid"));
            IList<IWebElement> webElementListOld = webElementOld.FindElements(By.CssSelector(".old-price.product-price"));
            foreach (IWebElement priceld in webElementListOld)
            {
                System.Console.WriteLine(priceld.Text);
            }
        }

        public void GetPrice1()
        {
            IWebElement webElement = driver.FindElement(By.CssSelector(".product_list.row.grid"));
            IList<IWebElement> webElementList = webElement.FindElements(By.CssSelector("div > div.right-block > div.content_price>span:nth-of-type(2)"));
            foreach (IWebElement price in webElementList)
            {
                System.Console.WriteLine(price.Text);
            }
        }*/
        
        public IWebElement elementPrice1 => driver.FindElement(By.CssSelector("#center_column > ul > li.ajax_block_product.first-in-line.first-item-of-tablet-line.first-item-of-mobile-line.col-xs-12.col-sm-6.col-md-4 > div > div.right-block > div.content_price > span.old-price.product-price"));
        public IWebElement elementPrice2 => driver.FindElement(By.CssSelector("#center_column > ul > li:nth-child(2) > div > div.right-block > div.content_price > span"));
        public IWebElement elementPrice3 => driver.FindElement(By.CssSelector("#center_column > ul > li.ajax_block_product.last-in-line.first-item-of-tablet-line.last-item-of-mobile-line.col-xs-12.col-sm-6.col-md-4 > div > div.right-block > div.content_price > span.old-price.product-price"));
        public IWebElement elementPrice4 => driver.FindElement(By.CssSelector("#center_column > ul > li.ajax_block_product.first-in-line.last-line.last-item-of-tablet-line.first-item-of-mobile-line.last-mobile-line.col-xs-12.col-sm-6.col-md-4 > div > div.right-block > div.content_price > span"));
    }
}
