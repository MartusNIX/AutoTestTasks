using System;
using TechTalk.SpecFlow;
using AutoTestTasks.Pages;
using AutoTestSpec.Drivers;
using NUnit.Framework;

namespace AutoTestSpec.StepDefinitions
{
    [Binding]
    public class Feature1StepDefinitions
    {
        private readonly Homepaje _homepaje;
        public Feature1StepDefinitions(BrowserDrivers browserDriver)
        {
            _homepaje = new Homepaje(browserDriver.Current);
        }

        [Given(@"The browser is opened on the main page")]
        public void GivenTheBrowserIsOpenedOnTheMainPage()
        {
            //проверить что открітая страница =наша страница
        }

        [Given(@"The word is inserted in search field")]
        public void GivenTheWordIsInsertedInSearchField()
        {
            _homepaje.InsertWordInSearchfield("Summer");
        }

        [When(@"The user clicks on the magnifier")]
        public void WhenTheUserClicksOnTheMagnifier()
        {
            _homepaje.ClickSearchBtn();
        }

        [Then(@"The user see the same words in search field and the search header")]
        public void ThenTheUserSeeTheSameWordsInSearchFieldAndTheSearchHeader()
        {
            var insertedWord = resultPage.GetInsertedWord();
            var displayedWordInHeader = resultPage.GetDisplayedWord();
            Assert.AreEqual(insertedWord, displayedWordInHeader);
        }
    }
}
