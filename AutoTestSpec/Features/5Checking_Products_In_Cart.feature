Feature: Feature5

Searching and open specified product, pick amount, size, color, add to cart and check that information is right.

@Browser_Chrome
Scenario: Checkout 2 product
	Given the browser is opened on the home page
		And the word <Blouse> is inserted in the search field
		And the magnifier is clicked
		And the first displayed product is opened
		And the first product added to card
		And the Printed_summer_dress is inserted in search
		And the magnifier is clicked on the product page
		And the first displayed product is opened
		And the second product added to card
	When the user clicks the Proceed_to_checkout btn
	Then products have following result
	|Color  |Size|Title               |Quantity|Price|TotalPrice|
	|White  |L   |Blouse              |3       |27.00|81.00     |
	|Orange |M   |Printed Summer Dress|5       |28.98|144.90    | 
	