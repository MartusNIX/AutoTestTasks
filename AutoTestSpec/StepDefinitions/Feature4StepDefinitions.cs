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
        private readonly BlousePage _blausePage;
        public Feature4StepDefinitions(BrowserDrivers browserDrivers)
        {
            _homePage = new HomePage(browserDrivers.Current);
            _resultBlousePage = new ResultBlousePage(browserDrivers.Current);
            _cartPage = new CartPage(browserDrivers.Current);
            _blausePage = new BlousePage(browserDrivers.Current);
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
            _blausePage.ClearPreviousData();
            _blausePage.InsertWordInInputField("3");
            _blausePage.SelectLargeSize();
            _blausePage.SelectColor();
        }

        [When(@"The  Add_to_cart button clicked")]
        public void WhenTheAdd_To_CartButtonClicked()
        {
            _blausePage.ClickAddToCardBtn();
        }

        [Then(@"The user see the Product successfully added to your shopping cart pop-up")]
        public void ThenTheUserSeeTheProductSuccessfullyAddedToYourShoppingCartPop_Up()
        {
            bool actualResult = _blausePage.ModalWindowIsShown();
            Assert.True(actualResult);
            Console.WriteLine(actualResult);
            /*Assert.AreEqual(true, actualResult);*/
        }

    }
}
