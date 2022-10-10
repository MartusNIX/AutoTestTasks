Feature: Feature2

Checking the price sorting downgrade after searching required word.

@Browser_Chrome 
Scenario: 2. Checking the price sorting downgrade using browser - Chrome
	Given The browser is opened on the Main page
	Given The word is inserted in Search field <Entered word>
	Given The magnifier is clicked
	When The user pressed sorting price by downgrade
	Then The elements are displayed sorted 

		Examples: 
	| Entered word | Expected heder word |
	| Summer       | SUMMER              |

@Browser_Edge
Scenario: 2. Checking the price sorting downgrade using browser - Edge
	Given The browser is opened on the Main page
	Given The word is inserted in Search field <Entered word>
	Given The magnifier is clicked
	When The user pressed sorting price by downgrade
	Then The elements are displayed sorted 

		Examples: 
	| Entered word | Expected heder word |
	| Summer       | SUMMER              |

@Browser_FireFox
Scenario: 2. Checking the price sorting downgrade using browser - FireFox
	Given The browser is opened on the Main page
	Given The word is inserted in Search field <Entered word>
	Given The magnifier is clicked
	When The user pressed sorting price by downgrade
	Then The elements are displayed sorted 

		Examples: 
	| Entered word | Expected heder word |
	| Summer       | SUMMER              |