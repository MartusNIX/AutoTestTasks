using AutoTestSpec.Hooks;
using AutoTestTasks.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace AutoTestSpec.StepDefinitions
{
    [Binding]
    public class Feature4StepDefinitions
    {
        private readonly HomePage _homePage;
        private readonly ResultBlousePage _resultBlousePage;
        private readonly CartPage _cartPage;
        private readonly BlousePage _blousePage;
        private readonly ResultPage _resultPage;

        private string title1Product;
        private string title2Product;
        private string color1Product;
        private string color2Product;
        private string price1Product;
        private string price2Product;
        private string qty1Product;
        private string qty2Product;
        private string total1Product;
        private string total2Product;

        public Feature4StepDefinitions(BrowserDrivers browserDrivers)
        {
            _homePage = new HomePage(browserDrivers.Current);
            _resultBlousePage = new ResultBlousePage(browserDrivers.Current);
            _cartPage = new CartPage(browserDrivers.Current);
            _blousePage = new BlousePage(browserDrivers.Current);
            _resultPage = new ResultPage(browserDrivers.Current);
        }

        [Given(@"The browser is opened on the home page")]
        public void GivenTheBrowserIsOpenedOnTheHomePage()
        {
            var expectedTitle = "My Store";
            var actualTitle = _homePage.pageTitle;
            Assert.AreEqual(expectedTitle, actualTitle);
        }

        [Given(@"The word Blouse is inserted in search field")]
        public void GivenTheWordBlouseIsInsertedInSearchField()
        {
            _homePage.InsertWordInSearchfield("Blouse");
        }


        [Given(@"The magnifier button is clicked")]
        public void GivenTheMagnifierButtonIsClicked()
        {
            _homePage.ClickSearchBtn();
        }

        [Given(@"The first product page is opened")]
        public void GivenTheFirstProductPageIsOpened()
        {
            _resultBlousePage.ClickMoreBtn();
        }

        [Given(@"The product properties is checked")]
        public void GivenTheProductPropertiesIsChecked()
        {
            _blousePage.ClearPreviousDataFromQuantity();
            _blousePage.InsertWordInInputField("3");
            _blousePage.SelectLargeSize();
            _blousePage.SelectBlackColor();

            title1Product = _blousePage.GetProductTitle();
            price1Product = _blousePage.GetProductPrice();
        }

        [Given(@"The Add_to_cart button clicked")]
        public void GivenTheAdd_To_CartButtonClicked()
        {
            _blousePage.ClickAddToCardBtn();

            
        }

        [When(@"The Add_to_cart button clicked")]
        public void WhenTheAdd_To_CartButtonClicked()
        {
            _blousePage.ClickAddToCardBtn();
        }

        [Then(@"The user see the Product successfully added to your shopping cart pop-up")]
        public void ThenTheUserSeeTheProductSuccessfullyAddedToYourShoppingCartPop_Up()
        {
            bool actualResult = _blousePage.ModalWindowIsShown();
            Assert.True(actualResult);
        }

        [Given(@"the Continue_shopping bttn is clicked")]
        public void GivenTheContinue_ShoppingBttnIsClicked()
        {
            _blousePage.ClickContinueShoppingBtn();
            color1Product = _blousePage.GetProductColor();
            qty1Product = _blousePage.GetProductQty();
            total1Product = _blousePage.GetProductTotal();
        }

        [Given(@"the Printed_summer_dress is inserted in search")]
        public void GivenThePrinted_Summe_DressIsInsertedInSearch()
        {
            _blousePage.ClearPreviousDataFromSearch();
            _blousePage.InsertWordInSearchfield("Printed summer dress");
        }

        [Given(@"The magnifier is Clicked on product page")]
        public void GivenTheMagnifierIsClickedOnProductPage()
        {
            _blousePage.ClickSearchBtn();
        }

        [Given(@"the More bttn is clicked")]
        public void GivenTheMoreBttnIsClicked()
        {
            _resultPage.ClickOnMoreOnResultPage();
        }

        [Given(@"the properties for second product is checked")]
        public void GivenThePropertiesForSecondProductIsChecked()
        {
            _blousePage.ClearPreviousDataFromQuantity();
            _blousePage.InsertWordInInputField("5");
            _blousePage.SelectMediumSize();
            _blousePage.SelectOrangeColor();

            title2Product = _blousePage.GetProductTitle();
            price2Product = _blousePage.GetProductPrice();
        }

        [When(@"the Proceed_to_checkout is clicked")]
        public void WhenTheProceed_To_CheckoutIsClicked()
        {
            _blousePage.ClickCheckoutBtn();
            color2Product = _blousePage.GetProductColor();
            qty2Product = _blousePage.GetProductQty();
            total2Product = _blousePage.GetProductTotal();
        }

        [Then(@"two product displayed correctly")]
        public void ThenTwoProductDisplayedCorrectly()
        {
            var titleProductCart1 = _cartPage.Get1ProductTitleOnCartPage();
            StringAssert.IsMatch(titleProductCart1, title1Product);
            Console.WriteLine("1:{0} 2:{1}", titleProductCart1, title1Product);
            var titleProductCart2 = _cartPage.Get2ProductTitleOnCartPage();
            Console.WriteLine("1:{0} 2:{1}", titleProductCart2, title2Product);
            StringAssert.IsMatch(titleProductCart2, title2Product);

            var colorProductCart1 = _cartPage.Get1ProductColorCartPage();
            Console.WriteLine("1:{0} 2:{1}", colorProductCart1, color1Product);
            var colorProductCart2 = _cartPage.Get2ProductColorCartPage();
            Console.WriteLine("1:{0} 2:{1}", colorProductCart2, color2Product);

            var priceProductCart1 = _cartPage.Get1PriceProductPriceOnCartPage();
            Console.WriteLine("1:{0} 2:{1}", priceProductCart1, price1Product);
            var priceProductCart2 = _cartPage.Get2PriceProductOnCartPage();
            Console.WriteLine("1:{0} 2:{1}", priceProductCart2, price2Product);

            var qtyProduct1 = _cartPage.Get1ProductQtyCardPage();
            Console.WriteLine("1:{0} 2:{1}", qtyProduct1, qty1Product);
            var qtyProduct2 = _cartPage.Get2ProductQtyCardPage();
            Console.WriteLine("1:{0} 2:{1}", qtyProduct2, qty2Product);

            var totalPrice1 = _cartPage.GetTotal1ProductCartPage();
            Console.WriteLine("1:{0} 2:{1}", totalPrice1, total1Product);
            var totalPrice2 = _cartPage.GetTotal2ProductCartPage();
            Console.WriteLine("1:{0} 2:{1}", totalPrice2, total2Product);

        }
    }
}
