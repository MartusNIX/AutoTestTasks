Feature: Feature2

Checking the price sorting downgrade after searching required word.

@Browser_Edge
Scenario: 2. Checking the price sorting downgrade
	Given the browser is opened on the main page
		And the word <Summer> is inserted in the search field
		And the magnifier is clicked
	When the user pressed sorting price by downgrade
	Then the elements are displayed sorted
