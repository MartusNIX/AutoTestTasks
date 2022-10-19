using AutoTestSpec.Hooks;
using AutoTestTasks.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using AutoTestSpec.Utils;
using TechTalk.SpecFlow.Assist;
using System.Runtime.ConstrainedExecution;

namespace AutoTestSpec.StepDefinitions
{
    [Binding]
    public class ProductSteps
    {
        private readonly ResultSearchPage _resultSearchPage;
        private readonly CartPage _cartPage;
        private readonly ProductPage _productPage;

        private string productPriceNew;
        private string productName;

        public ProductSteps(BrowserDrivers browserDrivers)
        {
            _resultSearchPage = new ResultSearchPage(browserDrivers.Current);
            _cartPage = new CartPage(browserDrivers.Current);
            _productPage = new ProductPage(browserDrivers.Current);
        }

        [Then(@"the user goes to product card page")]
        public void ThenTheUserGoToProductCardPage()
        {
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

        [When(@"the user clicks Add_to_cart btn")]
        public void WhenTheAdd_To_CartButtonClicked()
        {
            _productPage.ClickAddToCardBtn();
        }

        [Then(@"the user sees that products successfully added to the shopping cart in pop-up")]
        public void ThenTheUserSeeThatProductsSuccessfullyAddedToTheShoppingCartInPop_Up()
        {
            bool actualResult = _productPage.ModalWindowIsShown();
            Assert.True(actualResult);
        }

        [When(@"the user clicks the Proceed_to_checkout btn")]
        public void WhenTheUserClicksTheProceed_To_CheckoutBtn()
        {
            _productPage.ClickCheckoutBtn();
        }

        [Given(@"the second product added to card")]
        public void GivenTheSecondProductAddedToCard()
        {
            _productPage.ClearPreviousDataFromQuantity();
            _productPage.InsertWordInInputField("5");
            _productPage.SelectMediumSize();
            _productPage.SelectOrangeColor();
            Task.Delay(4000).Wait();
            _productPage.ClickAddToCardBtn();
        }

        [Then(@"the elements are displayed sorted")]
        public void ThenTheElementsAreDisplayedSorted()
        {
            List<string> currentPriceList = _resultSearchPage.GetPriceList();

            List<string> expectedPriceList = new List<string>(currentPriceList);
            expectedPriceList = expectedPriceList.OrderByDescending(x => x).ToList();

            Console.WriteLine(" currentPriceList {0}", string.Join(" | ", currentPriceList));
            Console.WriteLine("expectedPriceList {0}", string.Join(" | ", expectedPriceList));

            CollectionAssert.AreEqual(expectedPriceList, currentPriceList);
        }

        [When(@"the user adds first product in cart")]
        public void WhenTheUserAddedFirstProductInCart()
        {
            productPriceNew = _resultSearchPage.GetNewProductPrice();
            productName = _resultSearchPage.GetProductName();
            _resultSearchPage.ClickOnFirstProduct();
        }

        [Then(@"the user sees the same words in the search field and the search header")]
        public void ThenTheUserSeeTheSameWordsInSearchFieldAndTheSearchHeader()
        {
            var insertedWord = _resultSearchPage.GetInsertedWord();
            var displayedWordInHeader = _resultSearchPage.GetDisplayedWord();
            Assert.AreEqual(insertedWord, displayedWordInHeader);
        }

        [Given(@"the first displayed product is opened")]
        public void GivenTheFirstProductPageIsOpened()
        {
            _resultSearchPage.ClickOnMoreOnResultPage();
        }

        [Given(@"the first product added to card")]
        public void GivenTheFirstProductAddedToCard()
        {
            _productPage.ClearPreviousDataFromQuantity();
            _productPage.InsertWordInInputField("3");
            _productPage.SelectLargeSize();
            _productPage.SelectBlackColor();
            Task.Delay(4000).Wait();
            _productPage.ClickAddToCardBtn();
            Task.Delay(4000).Wait();
            _productPage.ClickContinueShoppingBtn();
        }

        [Given(@"the product properties are set")]
        public void GivenTheProductPropertiesIsChecked()
        {
            _productPage.ClearPreviousDataFromQuantity();
            _productPage.InsertWordInInputField("3");
            _productPage.SelectLargeSize();
            _productPage.SelectBlackColor();
        }

        [Then(@"products have following")]
        public void ThenProductsHaveFollowing(Table table)
        {
            Paramss paramss = table.CreateInstance<Paramss>();

            var colorProductCart1 = _cartPage.Get1ProductColorCartPage();
            StringAssert.Contains(paramss.Color1, colorProductCart1);
            var colorProductCart2 = _cartPage.Get2ProductColorCartPage();
            StringAssert.Contains(paramss.Color2, colorProductCart2);

            var sizeProductCart1 = _cartPage.Get1ProductSizeCartPage();
            StringAssert.Contains(paramss.Size1, sizeProductCart1);
            var sizeProductCart2 = _cartPage.Get2ProductSizeCartPage();
            StringAssert.Contains(paramss.Size2, sizeProductCart2);

            var titleProductCart1 = _cartPage.Get1ProductTitleOnCartPage();
            StringAssert.IsMatch(paramss.Title1, titleProductCart1);
            var titleProductCart2 = _cartPage.Get2ProductTitleOnCartPage();
            StringAssert.IsMatch(paramss.Title2, titleProductCart2);

            var qtyProduct1 = _cartPage.Get1ProductQtyCardPage();
            Assert.AreEqual(paramss.QTY1, qtyProduct1);
            var qtyProduct2 = _cartPage.Get2ProductQtyCardPage();
            Assert.AreEqual(paramss.QTY2, qtyProduct2);

            char[] toTrim = { '$', ' ' };

            var totalPrice1 = _cartPage.GetTotal1ProductCartPage();
            string trimedTotalPriceCart1 = totalPrice1.Trim(toTrim);
            float newTotalPrice1 = float.Parse(trimedTotalPriceCart1);
            Assert.AreEqual(paramss.TotalPrice1, newTotalPrice1);
            var totalPrice2 = _cartPage.GetTotal2ProductCartPage();
            string trimedTotalPriceCart2 = totalPrice2.Trim(toTrim);
            float newTotalPrice2 = float.Parse(trimedTotalPriceCart2);
            Assert.AreEqual(paramss.TotalPrice2, newTotalPrice2);

            var priceProductCart1 = _cartPage.Get1PriceProductPriceOnCartPage();
            string trimedUnitPriceCart1 = priceProductCart1.Trim(toTrim);
            float newUnitPrice1=float.Parse(trimedUnitPriceCart1);
            Assert.AreEqual(paramss.Price1, newUnitPrice1);
            var priceProductCart2 = _cartPage.Get2PriceProductPriceOnCartPage();
            string trimedUnitPriceCart2 = priceProductCart2.Trim(toTrim);
            float newUnitPrice2 = float.Parse(trimedUnitPriceCart2);
            Assert.AreEqual(paramss.Price2, newUnitPrice2);
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
