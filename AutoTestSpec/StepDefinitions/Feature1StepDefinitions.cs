using AutoTestTasks.Pages;
using AutoTestSpec.Drivers;
using NUnit.Framework;

namespace AutoTestSpec.StepDefinitions
{
    [Binding]
    public class Feature1StepDefinitions
    {
        private readonly HomePage _homePage;
        private readonly ResultPage _resultPage;

        public Feature1StepDefinitions(BrowserDrivers browserDriver)
        {
            _homePage = new HomePage(browserDriver.Current);
            _resultPage = new ResultPage(browserDriver.Current);
        }

        [Given(@"The browser is opened on the main page")]
        public void GivenTheBrowserIsOpenedOnTheMainPage()
        {
            var expectedTitle = "My Store";
            var actualTitle = _homePage.pageTitle;
            Assert.AreEqual(expectedTitle, actualTitle);

        }

        [Given(@"The word is inserted in search field (.*)")]
        public void GivenTheWordIsInsertedInSearchField(string fieldValue)
        {;
            _homePage.InsertWordInSearchfield(fieldValue);
        }

        [When(@"The user clicks on the magnifier")]
        public void WhenTheUserClicksOnTheMagnifier()
        {
            _homePage.ClickSearchBtn();
        }

        [Then(@"The user see the same words in search field and the search header")]
        public void ThenTheUserSeeTheSameWordsInSearchFieldAndTheSearchHeader()
        {
            var insertedWord = _resultPage.GetInsertedWord();
            var displayedWordInHeader = _resultPage.GetDisplayedWord();
            Assert.AreEqual(insertedWord, displayedWordInHeader);
        }
    }
}
