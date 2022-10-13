Feature: Feature5

Searching and open specified product, pick amount, size, color, add to cart and check.

@Browser_Chrome
Scenario: Checkout 2 product
	Given the browser is opened on the home page
		And the word <Blouse> is inserted in the search field
		And the magnifier is clicked
		And the first displayed product is opened
		And the product properties are set
		And The Add_to_cart button clicked
		And the Continue_shopping bttn is clicked
		And the Printed_summer_dress is inserted in search
		And the magnifier is clicked on the product page
		And the first displayed product is opened
		And the properties for second product is checked
		And The Add_to_cart button clicked
	When the user clicks the Proceed_to_checkout btn
	Then two product displayed correctly
