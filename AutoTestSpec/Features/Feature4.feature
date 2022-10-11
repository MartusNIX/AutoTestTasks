Feature: Feature4

Searching and open specified product, pick amount, size, color and add to cart.

@Browser_Chrome
Scenario: Adding product to cart with Quantity = 3, Size = L, Color = white
	Given The browser is opened on the home page
	Given The word Blouse is inserted in search field
	Given The magnifier button is clicked
	Given The first product page is opened
	Given The product properties is checked
	When The Add_to_cart button clicked
	Then The user see the Product successfully added to your shopping cart pop-up
