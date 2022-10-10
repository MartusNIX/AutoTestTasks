Feature: Feature3

After searching, check that the first product name correspond to product name in shopping cart after adding it in shopping cart.

@Browser_Chrome
Scenario: 3. Checking product name corresponding using browser - Firefox
	Given Given The browser is opened on the Main Page
	Given The word is inserted in search Field <Entered word>
	Given The magnifier is Clicked
	Given The user pressed sorting price by downgrade
	When The user added first product in cart
	Then The user go to product card page
	Then The name of product on Result Page and chart page are equal

		Examples: 
	| Entered word | Expected heder word |
	| Summer       | SUMMER              |