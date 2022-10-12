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

        private string titleProduct;
        private string priceProduct;
        private string amountProduct;

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

            product1Title = 
        }

        [Given(@"the Continue_shopping bttn is clicked")]
        public void GivenTheContinue_ShoppingBttnIsClicked()
        {
            _blousePage.ClickContinueShoppingBtn();
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

            

        }

        [When(@"the Proceed_to_checkout is clicked")]
        public void WhenTheProceed_To_CheckoutIsClicked()
        {
            _blousePage.ClickCheckoutBtn();
        }

        [Then(@"two product displayed correctly")]
        public void ThenTwoProductDisplayedCorrectly()
        {
            var titleProductCart1 = _cartPage.Get1ProductTitleOnCartPage();
            var titleProductCart2 = _cartPage.Get2ProductTitleOnCartPage();

            var colorProductCart1 = _cartPage.Get1ProductColorCartPage();
            var colorProductCart2 = _cartPage.Get2ProductColorCartPage();

            var priceProductCart1 = _cartPage.Get1PriceProductPriceOnCartPage();
            var priceProductCart2 = _cartPage.Get2PriceProductOnCartPage();

            var qtyProduct1 = _cartPage.Get1ProductQtyCardPage();
            var qtyProduct2 = _cartPage.Get2ProductQtyCardPage();

            var generalPrice = _cartPage.GetTotalProductsCartPage();






        }
    }
}
