Feature: Feature6

Searching and open 2 products, pick amount, size, color and add to cart and delete one.

@Browser_Chrome
Scenario: Deleate one product
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
		And the Proceed_to_checkout is clicked
	When the user clicks Delete btn
	Then the chosen product is deleted

