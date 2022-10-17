using AutoTestSpec.Hooks;
using AutoTestTasks.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AutoTestSpec.StepDefinitions
{
    [Binding]
    public class ProductSteps
    {
        private readonly ResultSearchPage _resultSearchPage;
        private readonly CartPage _cartPage;
        private readonly ProductPage _productPage;

        public string productPriceNew;
        public string productName;
        public string title1Product;
        public string title2Product;
        public string price1Product;
        public string price2Product;
        public string qty1Product;
        public string qty2Product;
        public string total1Product;
        public string total2Product;
        public string color1Product;
        public string color2Product;
        public string size1Product;
        public string size2Product;
        public string removeProductID;

        public ProductSteps(BrowserDrivers browserDrivers)
        {
            _resultSearchPage = new ResultSearchPage(browserDrivers.Current);
            _cartPage = new CartPage(browserDrivers.Current);
            _productPage = new ProductPage(browserDrivers.Current);
        }

        [Then(@"the user go to product card page")]
        public void ThenTheUserGoToProductCardPage()
        {
            productPriceNew = _resultSearchPage.GetNewProductPrice();
            productName = _resultSearchPage.GetProductName();
            _resultSearchPage.ClickOnLProceedToCheckoutBtn();
        }

        [Then(@"the name of product on result page and cart page are equal")]
        public void ThenTheNameOfProductOnResultPageAndChartPageAreEqual()
        {
            var priceFromFirstProductOnCartPage = _cartPage.Get1PriceProductPriceOnCartPage();
            var titleProductCartPage = _cartPage.Get1ProductTitleOnCartPage();
            Assert.AreEqual(priceFromFirstProductOnCartPage, productPriceNew);
            Assert.AreEqual(titleProductCartPage, productName);
        }

        [When(@"the Add_to_cart button is clicked")]
        public void WhenTheAdd_To_CartButtonClicked()
        {
            _productPage.ClickAddToCardBtn();
        }

        [Then(@"the user see that products successfully added to the shopping cart in pop-up")]
        public void ThenTheUserSeeThatProductsSuccessfullyAddedToTheShoppingCartInPop_Up()
        {
            bool actualResult = _productPage.ModalWindowIsShown();
            Assert.True(actualResult);
        }

        [Given(@"the Add_to_cart btn is clicked")]
        public void GivenTheAdd_To_CartButtonClicked()
        {
            _productPage.ClickAddToCardBtn();
        }

        [When(@"the user clicks the Proceed_to_checkout btn")]
        public void WhenTheUserClicksTheProceed_To_CheckoutBtn()
        {
            Thread.Sleep(4000);
            Task.Delay(4000).Wait();
            qty2Product = _productPage.GetProductQty();
            total2Product = _productPage.GetProductTotal();
            _productPage.ClickCheckoutBtn();
        }

        [Then(@"the elements are displayed sorted")]
        public void ThenTheElementsAreDisplayedSorted()
        {
            var price1 = GetPrice(_resultSearchPage.elementPriceOld1);
            var price2 = GetPrice(_resultSearchPage.elementPrice2);
            var price3 = GetPrice(_resultSearchPage.elementPriceOld3);
            var price4 = GetPrice(_resultSearchPage.elementPrice4);

            Console.WriteLine("{0} {1} {2} {3}", price1, price2, price3, price4);

            Assert.Multiple(() =>
            {
                Assert.Greater(price1, price2);
                Assert.Greater(price2, price3);
                Assert.Greater(price3, price4);
            });
        }
        private float GetPrice(IWebElement element)
        {
            return float.Parse(element.Text.Trim('$'));
        }

        [Given(@"the Continue_shopping btn is clicked")]
        public void GivenTheContinue_ShoppingBttnIsClicked()
        {
            _productPage.ClickContinueShoppingBtn();
            qty1Product = _productPage.GetProductQty();
            total1Product = _productPage.GetProductTotal();
        }

        [Given(@"the properties for second product is checked")]
        public void GivenThePropertiesForSecondProductIsChecked()
        {
            _productPage.ClearPreviousDataFromQuantity();
            _productPage.InsertWordInInputField("5");
            _productPage.SelectMediumSize();
            _productPage.SelectOrangeColor();

            title2Product = _productPage.GetProductTitle();
            price2Product = _productPage.GetProductPrice();
            color2Product = _productPage.GetChosedColor();
            size2Product = _productPage.GetChosedSize();
        }

        [When(@"the user added first product in cart")]
        public void WhenTheUserAddedFirstProductInCart()
        {
            _resultSearchPage.ClickOnFirstProduct();
        }

        [Then(@"the user see the same words in the search field and the search header")]
        public void ThenTheUserSeeTheSameWordsInSearchFieldAndTheSearchHeader()
        {
            var insertedWord = _resultSearchPage.GetInsertedWord();
            var displayedWordInHeader = _resultSearchPage.GetDisplayedWord();
            Assert.AreEqual(insertedWord, displayedWordInHeader);
        }

        [Given(@"the product properties are set")]
        public void GivenTheProductPropertiesIsChecked()
        {
            _productPage.ClearPreviousDataFromQuantity();
            _productPage.InsertWordInInputField("3");
            _productPage.SelectLargeSize();
            _productPage.SelectBlackColor();
            Thread.Sleep(4000);
            title1Product = _productPage.GetProductTitle();
            price1Product = _productPage.GetProductPrice();
            color1Product = _productPage.GetChosedColor();
            size1Product = _productPage.GetChosedSize();
        }

        [Then(@"two product displayed correctly")]
        public void ThenTwoProductDisplayedCorrectly()
        {
            var colorProductCart1 = _cartPage.Get1ProductColorCartPage();
            StringAssert.Contains(color1Product, colorProductCart1);
            Console.WriteLine("Color_cart1= {0} Color_product1= {1}", colorProductCart1, color1Product);
            var colorProductCart2 = _cartPage.Get2ProductColorCartPage();
            StringAssert.Contains(color2Product, colorProductCart2);
            Console.WriteLine("Color_cart2= {0} Color_product2= {1}", colorProductCart2, color2Product);

            var sizeProductCart1 = _cartPage.Get1ProductSizeCartPage();
            StringAssert.Contains(size1Product, sizeProductCart1);
            Console.WriteLine("Size_cart1= {0} Size_product1= {1}", sizeProductCart1, size1Product);
            var sizeProductCart2 = _cartPage.Get2ProductSizeCartPage();
            StringAssert.Contains(size2Product, sizeProductCart2);
            Console.WriteLine("Size_cart2= {0} Size_product2= {1}", sizeProductCart2, size2Product);

            var titleProductCart1 = _cartPage.Get1ProductTitleOnCartPage();
            StringAssert.IsMatch(titleProductCart1, title1Product);
            Console.WriteLine("Title_cart1= {0} Title_product1= {1}", titleProductCart1, title1Product);
            var titleProductCart2 = _cartPage.Get2ProductTitleOnCartPage();
            Console.WriteLine("Title_cart2= {0} Title_product2= {1}", titleProductCart2, title2Product);
            StringAssert.IsMatch(titleProductCart2, title2Product);

            var qtyProduct1 = _cartPage.Get1ProductQtyCardPage();
            StringAssert.IsMatch(qtyProduct1, qty1Product);
            Console.WriteLine("QTY_cart1= {0} QTY_product1= {1}", qtyProduct1, qty1Product);
            var qtyProduct2 = _cartPage.Get2ProductQtyCardPage();
            StringAssert.IsMatch(qtyProduct2, qty2Product);
            Console.WriteLine("QTY_cart2= {0} QTY_product2= {1}", qtyProduct2, qty2Product);

            char[] toTrim = { '$', ' ' };

            var totalPrice1 = _cartPage.GetTotal1ProductCartPage();
            string trimedTotalPriceCart1 = totalPrice1.Trim(toTrim);
            string trimedTotalProduct1 = total1Product.Trim(toTrim);
            Console.WriteLine("Total_cart1= {0} Total_product1= {1}", trimedTotalPriceCart1, trimedTotalProduct1);
            StringAssert.IsMatch(trimedTotalPriceCart1, trimedTotalProduct1);
            var totalPrice2 = _cartPage.GetTotal2ProductCartPage();
            string trimedTotalPriceCart2 = totalPrice2.Trim(toTrim);
            string trimedTotalProduct2 = total2Product.Trim(toTrim);
            Console.WriteLine("Total_cart2= {0} Total_product2= {1}", trimedTotalPriceCart2, trimedTotalProduct2);
            StringAssert.IsMatch(trimedTotalPriceCart2, trimedTotalProduct2);

            var priceProductCart1 = _cartPage.Get1PriceProductPriceOnCartPage();
            string trimedUnitPriceCart1 = priceProductCart1.Trim(toTrim);
            string trimedUnitPriceProduct1 = price1Product.Trim(toTrim);
            StringAssert.IsMatch(trimedUnitPriceCart1, trimedUnitPriceProduct1);
            Console.WriteLine("Price_cart1= {0} Price_product1= {1}", trimedUnitPriceCart1, trimedUnitPriceProduct1);
            var priceProductCart2 = _cartPage.Get2PriceProductOnCartPage();
            string trimedUnitPriceCart2 = priceProductCart2.Trim(toTrim);
            string trimedUnitPriceProduct2 = price2Product.Trim(toTrim);
            StringAssert.IsMatch(trimedUnitPriceCart2, trimedUnitPriceProduct2);
            Console.WriteLine("Price_cart2= {0} Price_product2= {1}", trimedUnitPriceCart2, trimedUnitPriceProduct2);
        }

        [Given(@"the Proceed_to_checkout is clicked")]
        public void GivenTheProceed_To_CheckoutIsClicked()
        {
            _productPage.ClickCheckoutBtn();
        }

        [When(@"the user clicks Delete btn")]
        public void WhenTheUserClicksDeleteBtn()
        {
            _cartPage.ClickOnDelete2();
        }

        [Then(@"the chosen product is deleted")]
        public void ThenTheChosenProductIsDeleted()
        {
            var isSecondProductDisplayed = _cartPage.IsSecondProductDisplayed();
            Console.WriteLine("isSecondProductDisplayed : {0}", isSecondProductDisplayed);
        }
    }
}
