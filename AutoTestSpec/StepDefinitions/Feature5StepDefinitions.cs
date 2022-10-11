using AutoTestSpec.Hooks;
using AutoTestTasks.Pages;
using System;
using TechTalk.SpecFlow;

namespace AutoTestSpec.StepDefinitions
{
    [Binding]
    public class Feature5StepDefinitions
    {
        private readonly HomePage _homePage;
        private readonly ResultBlousePage _resultBlousePage;
        private readonly CartPage _cartPage;
        private readonly BlousePage _blousePage;
        private readonly ResultPage _resultPage;
        public Feature5StepDefinitions(BrowserDrivers browserDrivers)
        {
            _homePage = new HomePage(browserDrivers.Current);
            _resultBlousePage = new ResultBlousePage(browserDrivers.Current);
            _cartPage = new CartPage(browserDrivers.Current);
            _blousePage = new BlousePage(browserDrivers.Current);
            _resultPage = new ResultPage(browserDrivers.Current);
        }



        [Given(@"the Printed_summer_dress is inserted in search")]
        public void GivenThePrinted_Summe_DressIsInsertedInSearch()
        {
            _blousePage.ClearPreviousDataFromSearch();
            _blousePage.InsertWordInSearchfield("Printed summer dress");
        }

        [Given(@"the More bttn is clicked")]
        public void GivenTheMoreBttnIsClicked()
        {
            _resultPage.ClickOnMoreOnResultPage();
        }

        [Given(@"the properties for second product is checked")]
        public void GivenThePropertiesForSecondProductIsChecked()
        {
            throw new PendingStepException();
        }

        [When(@"the Proceed_to_checkout is clicked")]
        public void WhenTheProceed_To_CheckoutIsClicked()
        {
            throw new PendingStepException();
        }

        [Then(@"two product displayed correctly")]
        public void ThenTwoProductDisplayedCorrectly()
        {
            throw new PendingStepException();
        }
    }
}
