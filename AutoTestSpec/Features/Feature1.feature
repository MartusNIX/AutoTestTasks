Feature: Feature1

Compearing entered word in search field with word that displayed in header

@Browser_Chrome
Scenario: 1. Comparing the searched word with the word that is displayed using browser - Edge
	Given The browser is opened on the main page
	Given The word is inserted in search field <Entered word>
	When The user clicks on the magnifier
	Then The user see the same words in search field and the search header

	Examples: 
	| Entered word | Expected heder word |
	| Summer       | SUMMER              |
	| sleeve       | SLEEVE              |

@Browser_Edge
Scenario: 1. Comparing the searched word with the word that is displayed using browser - Chrome
	Given The browser is opened on the main page
	Given The word is inserted in search field <Entered word>
	When The user clicks on the magnifier
	Then The user see the same words in search field and the search header

	Examples: 
	| Entered word | Expected heder word |
	| Summer       | SUMMER              |
	| sleeve       | SLEEVE              |

@Browser_Firefox
Scenario: 1. Comparing the searched word with the word that is displayed using browser - FireFox
	Given The browser is opened on the main page
	Given The word is inserted in search field <Entered word>
	When The user clicks on the magnifier
	Then The user see the same words in search field and the search header

	Examples: 
	| Entered word | Expected heder word |
	| Summer       | SUMMER              |
	| sleeve       | SLEEVE              |