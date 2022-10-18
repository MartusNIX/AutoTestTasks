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
	Then products have following
	| Parameter   | Value                |
	| Color1      | White                |
	| Size1       | L                    |
	| Title1      | Blouse               |
	| QTY1        | 3                    |
	| TotalPrice1 | 81.00                |
	| Price1      | 27.00                |
	| Color2      | Orange               |
	| Size2       | M                    |
	| Title2      | Printed Summer Dress |
	| QTY2        | 5                    |
	| TotalPrice2 | 144.90               |
	| Price2      | 28.98                |
	