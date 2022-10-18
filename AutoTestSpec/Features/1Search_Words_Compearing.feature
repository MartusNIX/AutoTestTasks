Feature: Feature1

Compearing entered word in search field with word that displayed in header

@Browser_Firefox
Scenario: 1. Comparing the searched word with the word that is displayed
	Given the browser is opened on the home page
		And the word is inserted in the search field
		| Key        | Value  |
		| SearchWord | Summer |
	When the user clicks on the magnifier
	Then the user sees the same words in the search field and the search header