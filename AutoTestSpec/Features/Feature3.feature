Feature: Feature3

After searching, check that the first product name correspond to product name in shopping cart after adding it in shopping cart.

@Browser_Chrome
Scenario: 3. Checking product name corresponding
	Given the browser is opened on the main page
		And the word <Summer> is inserted in the search field
		And the magnifier is clicked
		And the price sorted by downgrade
	When the user added first product in cart
	Then the user go to product card page
	Then the name of product on result page and chart page are equal