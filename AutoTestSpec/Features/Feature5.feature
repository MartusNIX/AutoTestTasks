Feature: Feature5

A short summary of the feature

@Browser_Chrome
Scenario: Checkout 2 product
	Given The browser is opened on the home page
		And The word Blouse is inserted in search field
		And The magnifier button is clicked
		And The first product page is opened
		And The product properties is checked
		And The Add_to_cart button clicked
		And the Continue_shopping bttn is clicked
		And the Printed_summer_dress is inserted in search
		And The magnifier is Clicked
		And the More bttn is clicked
		And the properties for second product is checked
		And The Add_to_cart button clicked
	When the Proceed_to_checkout is clicked
	Then two product displayed correctly
