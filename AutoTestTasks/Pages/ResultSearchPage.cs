using OpenQA.Selenium;

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
        public IWebElement elementPrice1 => driver.FindElement(By.CssSelector("#center_column > ul > li.ajax_block_product.col-xs-12.col-sm-6.col-md-4.first-in-line.first-item-of-tablet-line.first-item-of-mobile-line > div > div.right-block > div.content_price > span.price.product-price"));
        public IWebElement elementPriceOld1 => driver.FindElement(By.CssSelector("#center_column > ul > li.ajax_block_product.first-in-line.first-item-of-tablet-line.first-item-of-mobile-line.col-xs-12.col-sm-6.col-md-4 > div > div.right-block > div.content_price > span.old-price.product-price"));
        public IWebElement elementPrice2 => driver.FindElement(By.CssSelector("#center_column > ul > li:nth-child(2) > div > div.right-block > div.content_price > span"));
        public IWebElement elementPriceOld3 => driver.FindElement(By.CssSelector("#center_column > ul > li.ajax_block_product.last-in-line.first-item-of-tablet-line.last-item-of-mobile-line.col-xs-12.col-sm-6.col-md-4 > div > div.right-block > div.content_price > span.old-price.product-price"));
        public IWebElement elementPrice4 => driver.FindElement(By.CssSelector("#center_column > ul > li.ajax_block_product.first-in-line.last-line.last-item-of-tablet-line.first-item-of-mobile-line.last-mobile-line.col-xs-12.col-sm-6.col-md-4 > div > div.right-block > div.content_price > span"));
        public IWebElement btnAddToCardFirstProductOnResultPage => driver.FindElement(By.CssSelector("a.button.ajax_add_to_cart_button.btn.btn-default"));
        public IWebElement btnProceedToCheckout => driver.FindElement(By.CssSelector("#layer_cart > div.clearfix > div.layer_cart_cart.col-xs-12.col-md-6 > div.button-container > a"));
        public IWebElement titleFirstProductOnResultPage => driver.FindElement(By.CssSelector("#center_column > ul > li.ajax_block_product.col-xs-12.col-sm-6.col-md-4.first-in-line.first-item-of-tablet-line.first-item-of-mobile-line > div > div.right-block > h5 > a"));
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
        public void ClickOnMoreOnResultPage () => btnMoreOnResultPage.Click();

    }
}
