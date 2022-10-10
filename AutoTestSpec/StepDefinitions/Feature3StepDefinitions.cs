using AutoTestSpec.Hooks;
using AutoTestTasks.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace AutoTestSpec.StepDefinitions
{
    [Binding]
    public class Feature3StepDefinitions
    {
        private readonly HomePage _homePage;
        private readonly ResultPage _resultPage;
        private readonly CartPage _cartPage;

/*        private string productPriceNew;*/
        private string productName;
        private string productOld;

        public Feature3StepDefinitions(BrowserDrivers browserDrivers)
        {
            _homePage = new HomePage(browserDrivers.Current);
            _resultPage = new ResultPage(browserDrivers.Current);
            _cartPage = new CartPage(browserDrivers.Current);
        }

        [Given(@"Given The browser is opened on the Main Page")]
        public void GivenGivenTheBrowserIsOpenedOnTheMainPage()
        {
            var expectedTitle = "My Store";
            var actualTitle = _homePage.pageTitle;
            Assert.AreEqual(expectedTitle, actualTitle);
        }

        [Given(@"The word is inserted in search Field (.*)")]
        public void GivenTheWordIsInsertedInSearchFieldSummer(string fieldValue)
        {
            _homePage.InsertWordInSearchfield(fieldValue);
        }

        [Given(@"The magnifier is Clicked")]
        public void GivenTheMagnifierIsClicked()
        {
            _homePage.ClickSearchBtn();
        }

        [Given(@"The user pressed sorting price by downgrade")]
        public void GivenTheUserPressedSortingPriceByDowngrade()
        {
            _resultPage.ClickDropdownProductSortHighFirst();
        }

        [When(@"The user added first product in cart")]
        public void WhenTheUserAddedFirstProductInCart()
        {
            _resultPage.ClickOnFirstProduct();
        }

        [Then(@"The user go to product card page")]
        public void ThenTheUserGoToProductCardPage()
        {
/*            productPriceNew = _resultPage.GetNewProductPrice();*/
            productName = _resultPage.GetProductName();
            productOld = _resultPage.GetOldProductPrice();
            _resultPage.ClickOnLProceedToCheckoutBtn();
        }

        [Then(@"The name of product on Result Page and chart page are equal")]
        public void ThenTheNameOfProductOnResultPageAndChartPageAreEqual()
        {
            var priceFromFirstProductOnCartPage = _cartPage.GetPriceFirstProductNameOnCartPage();
            var titleProductCartPage = _cartPage.GetFirstProductTitleOnCartPage();
            Assert.AreEqual(priceFromFirstProductOnCartPage, productOld);
            Assert.AreEqual(titleProductCartPage, productName);
        }
    }
}
