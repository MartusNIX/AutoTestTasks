using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AutoTestTasks.Pages
{
    public class CartPage
    {
        protected readonly IWebDriver driver;

        public CartPage(IWebDriver webDdriver)
        {
            driver = webDdriver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
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

        public By btnDeleteCssSelector = By.CssSelector("tbody>tr:nth-child(2)>td:nth-child(7)>div>a");
        public IWebElement btnDelete => driver.FindElement(btnDeleteCssSelector);
        public IWebElement iD1 => driver.FindElement(By.CssSelector("tbody>tr:nth-child(1)"));
        public IWebElement iD2 => driver.FindElement(By.CssSelector("tbody>tr:nth-child(2)"));

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
        public string Get1ProductID() => iD1.GetAttribute("id");
        public string Get2ProductID() => iD2.GetAttribute("id");
        public void ClickOnDelete() => btnDelete.Click();
        public void ClickOnDelete2()
        {
            btnDelete.Click();
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(btnDeleteCssSelector));
        }
        public bool IsDisplayedProduct() => driver.FindElement(By.CssSelector("tbody>tr:nth-child(2)")).Displayed;
        public bool IsSecondProductDisplayed()
        {
            try
            {
                return iD2.Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }

/*        public IList<IWebElement> GetProductsList()
        {
            return driver.FindElements(By.CssSelector("tbody>tr"));
        }*/
    }
}
