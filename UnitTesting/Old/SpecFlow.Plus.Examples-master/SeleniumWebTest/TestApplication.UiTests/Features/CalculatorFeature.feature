Feature: CalculatorFeature
	 In order to avoid silly mistakes 
	As a math idiot
	I want to be told the sum of two numbers

@Browser_Chrome
@Browser_IE
@Browser_Firefox
@BasePage
Scenario: Basepage is Calculator
	Given I navigated to /
	Then browser title is Calculator

@Browser_IE 
@Browser_Chrome
Scenario Outline: Add Two Numbers
	Given I navigated to /
	And I have entered <SummandOne> into summandOne calculator
	And I have entered <SummandTwo> into summandTwo calculator
	When I press add
	Then the result should be <Result> on the screen

Scenarios: 
		| SummandOne | SummandTwo | Result |       
		| 50         | 70         | 120    | 
		| 1          | 10         | 11     |
