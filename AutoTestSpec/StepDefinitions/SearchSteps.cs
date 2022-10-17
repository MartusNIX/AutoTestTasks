using AutoTestSpec.Hooks;
using AutoTestTasks.Pages;
using NUnit.Framework;

namespace AutoTestSpec.StepDefinitions
{
    [Binding]
    public class SearchSteps
    {
        private readonly HomePage _homePage;
        private readonly ResultSearchPage _resultSearchPage;
        private readonly ProductPage _productPage;

        public SearchSteps(BrowserDrivers browserDrivers)
        {
            _homePage = new HomePage(browserDrivers.Current);
            _resultSearchPage = new ResultSearchPage(browserDrivers.Current);
            _productPage = new ProductPage(browserDrivers.Current);
        }

        [Given(@"the browser is opened on the home page")]
        public void GivenTheBrowserIsOpenedOnTheMainPage()
        {
            var expectedTitle = "My Store";
            var actualTitle = _homePage.pageTitle;
            Assert.AreEqual(expectedTitle, actualTitle);
        }

        [Given(@"the word <Summer> is inserted in the search field")]
        public void GivenTheWordEnteredWordIsInsertedInSearchField()
        {
            _homePage.InsertWordInSearchfield("Summer");
        }

        [Given(@"the word <Blouse> is inserted in the search field")]
        public void GivenTheWordBlouseIsInsertedInSearchField()
        {
            _homePage.InsertWordInSearchfield("Blouse");
        }

        [Given(@"the magnifier is clicked")]
        public void GivenTheMagnifierIsClicked()
        {
            _homePage.ClickSearchBtnOnSearchPage();
        }

        [Given(@"the first displayed product is opened")]
        public void GivenTheFirstProductPageIsOpened()
        {
            _resultSearchPage.ClickOnMoreOnResultPage();
        }

        [When(@"the user clicks on the magnifier")]
        public void WhenTheUserClicksOnTheMagnifier()
        {
            _homePage.ClickSearchBtnOnSearchPage();
        }
        
        [Given(@"the price sorted by downgrade")]
        public void GivenTheUserPressedSortingPriceByDowngrade()
        {
            _resultSearchPage.ClickDropdownProductSortHighFirst();
        }

        [When(@"the user pressed sorting price by downgrade")]
        public void WhenTheUserPressedSortingPriceByDowngrade()
        {
            _resultSearchPage.ClickDropdownProductSortHighFirst();
        }
        [Given(@"the Printed_summer_dress is inserted in search")]
        public void GivenThePrinted_Summe_DressIsInsertedInSearch()
        {
            _productPage.ClearPreviousDataFromSearch();
            _productPage.InsertWordInSearchfield("Printed summer dress");
        }

        [Given(@"the magnifier is clicked on the product page")]
        public void GivenTheMagnifierIsClickedOnProductPage()
        {
            _productPage.ClickSearchBtn();
        }
    }
}
