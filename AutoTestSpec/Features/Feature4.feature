Feature: Feature4

Searching and open specified product, pick amount, size, color and add to cart.

@Browser_Chrome
Scenario: Adding product to cart with Quantity = 3, Size = L, Color = white
	Given the browser is opened on the main page
		And the word <Blouse> is inserted in the search field
		And the magnifier is clicked
		And the first displayed product is opened
		And the product properties are set
	When the Add_to_cart button is clicked
	Then the user see that products successfully added to the shopping cart in pop-up
