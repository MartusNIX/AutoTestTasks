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
        public string Get2PriceProductPriceOnCartPage() => priceSecondProductOnCartPage.Text;
        public string Get1ProductColorCartPage() => colorFirstProductOnCartPage.Text;
        public string Get2ProductColorCartPage() => colorSecondProductOnCartPage.Text;
        public string Get1ProductSizeCartPage() => sizeFirstProductOnCartPage.Text;
        public string Get2ProductSizeCartPage() => sizeSecondProductOnCartPage.Text;
        public int Get1ProductQtyCardPage()
        {
            var quantityStringValue1 = qtyFirstProductOnCartPage.GetAttribute("value");
            return int.Parse(quantityStringValue1);
        }
        public int Get2ProductQtyCardPage()
        {
            var quantityStringValue2 = qtySecondProductOnCartPage.GetAttribute("value");
            return int.Parse(quantityStringValue2);
        }
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

        public IList<IWebElement> ProductContainers => driver.FindElements(By.CssSelector(".cart_item"));
        public Product GetProductInfo(int index)
        {
            var productContainer = ProductContainers[index];
            var product = new Product
            {
                Color = GetColor(productContainer.FindElement(By.CssSelector(".cart_description small a")).Text),
                Size = GetSize(productContainer.FindElement(By.CssSelector(".cart_description small a")).Text),
                Title = GetTitle(productContainer.FindElement(By.CssSelector(".cart_description p a")).Text),
                Quantity = GetQuantity(productContainer.FindElement(By.CssSelector(".cart_quantity.text-center input")).GetAttribute("value")),
                Price = GetPricee(productContainer.FindElement(By.CssSelector(".cart_unit span")).Text),
                TotalPrice = GetTotalPricee(productContainer.FindElement(By.CssSelector(".cart_total span")).Text)
            };
            return product;
        }

        public string GetColor(string rawText)
        {
            var arr = rawText.Split(",");
            var color = arr[0].Split(":")[1].Trim();

            return color;
        }

        public string GetSize(string rawText)
        {
            var arr = rawText.Split(",");
            var size = arr[1].Split(":")[1].Trim();

            return size;
        }

        public string GetTitle(string title)
        {
            return title;
        }

        public int GetQuantity(string quantity)
        {
            return int.Parse(quantity);
        }

        public float GetPricee(string price)
        {
            var arr = price.Split(" ");
            var trimmedPrice = arr[0].Trim('$');
            return float.Parse(trimmedPrice);
        }
        
        public float GetTotalPricee(string totalPrice)
        {
            return float.Parse(totalPrice.Trim('$'));
        }   
    }
}
