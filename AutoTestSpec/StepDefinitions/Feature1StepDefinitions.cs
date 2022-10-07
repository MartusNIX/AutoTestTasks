using System;
using TechTalk.SpecFlow;

namespace AutoTestSpec.StepDefinitions
{
    [Binding]
    public class Feature1StepDefinitions
    {
        [Given(@"The browser is opened on the main page")]
        public void GivenTheBrowserIsOpenedOnTheMainPage()
        {
            throw new PendingStepException();
        }

        [Given(@"The word is inserted in search field")]
        public void GivenTheWordIsInsertedInSearchField()
        {
            throw new PendingStepException();
        }

        [When(@"The user clicks on the magnifier")]
        public void WhenTheUserClicksOnTheMagnifier()
        {
            throw new PendingStepException();
        }

        [Then(@"The user see the same words in search field and the search header")]
        public void ThenTheUserSeeTheSameWordsInSearchFieldAndTheSearchHeader()
        {
            throw new PendingStepException();
        }
    }
}
