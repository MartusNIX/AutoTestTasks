using System;
using TechTalk.SpecFlow;
using AutoTestTasks.Pages;
using NUnit.Framework;
using AutoTestSpec.Hooks;

namespace AutoTestSpec.StepDefinitions
{
    [Binding]
    public class Feature2StepDefinitions
    {
        private readonly HomePage _homePage;
        private readonly ResultPage _resultPage;

        public Feature2StepDefinitions(BrowserDrivers browserDriver)
        {
            _homePage = new HomePage(browserDriver.Current);
            _resultPage = new ResultPage(browserDriver.Current);
        }

        [Given(@"The browser is opened on the Main page")]
        public void GivenTheBrowserIsOpenedOnTheMainPage()
        {
            var expectedTitle = "My Store";
            var actualTitle = _homePage.pageTitle;
            Assert.AreEqual(expectedTitle, actualTitle);
        }

        [Given(@"The word is inserted in Search field (.*)")]
        public void GivenTheWordIsInsertedInSearchField(string fieldValue)
        {
            _homePage.InsertWordInSearchfield(fieldValue);
        }

        [Given(@"The magnifier is clicked")]
        public void GivenTheMagnifierIsClicked()
        {
            _homePage.ClickSearchBtn();
        }

        [When(@"The user pressed sorting price by downgrade")]
        public void WhenTheUserPressedSortingPriceByDowngrade()
        {
            _resultPage.ClickDropdownProductSortHighFirst();
        }

        [Then(@"The elements are displayed sorted")]
        public void ThenTheElementsAreDisplayedSorted()
        {
            var price1 = _resultPage.elementPrice1;
            var price2 = _resultPage.elementPrice2;
            var price3 = _resultPage.elementPrice3;
            var price4 = _resultPage.elementPrice4;
            Console.WriteLine("{0} {1} {2} {3}", price1.Text, price2.Text, price3.Text, price4.Text);
        }
    }
}
