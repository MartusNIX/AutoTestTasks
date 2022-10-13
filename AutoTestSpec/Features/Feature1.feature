Feature: Feature1

Compearing entered word in search field with word that displayed in header

@Browser_Chrome
Scenario: 1. Comparing the searched word with the word that is displayed
	Given the browser is opened on the main page
		And the word <Summer> is inserted in the search field
	When the user clicks on the magnifier
	Then the user see the same words in the search field and the search header