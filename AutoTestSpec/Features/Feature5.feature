Feature: Feature5

A short summary of the feature

@Browser_Chrome
Scenario: Checkout 2 product
	Given the browser is opened on the main page
		And the word <Blouse> is inserted in the search field
		And the magnifier is clicked
		And the first displayed product is opened
		And the product properties are set
		And The Add_to_cart button clicked
		And the Continue_shopping bttn is clicked
		And the Printed_summer_dress is inserted in search
		And The magnifier is Clicked on product page
		And the More bttn is clicked
		And the properties for second product is checked
		And The Add_to_cart button clicked
	When the Proceed_to_checkout is clicked
	Then two product displayed correctly
