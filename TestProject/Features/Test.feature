Feature: Test
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers


	@test1
	Scenario: Verify latest news section
	Given I am on Valtech Homepage
	Then I should be able to see the latest news section

	@test2
	Scenario Outline: Verify all menu links
	Given I am on Valtech Homepage
	When I choose to navigate to a <menu_link> 
	Then I should be directed to the <menu_link>
	Examples: 
	| menu_link  |  
	| cases       |
	| services   |
	| industries |
	| blog		 |
	| jobs	     |
	| investors  |