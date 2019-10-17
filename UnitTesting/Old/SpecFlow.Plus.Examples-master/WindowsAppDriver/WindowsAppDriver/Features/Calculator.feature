Feature: CalculatorFeature
	 In order to avoid silly mistakes 
	As a math idiot
	I want to be told the sum of two numbers

Scenario: Basepage is Calculator
	Given I navigated to Standard Calculator
	Then Calculator title is Standard

Scenario Outline: Add Two Numbers
	Given I navigated to Standard Calculator
	And I have entered <SummandOne> into calculator
	And I press plus
	And I have entered <SummandTwo> into calculator
	When I press equal
	Then the result should be <Result> on the screen

Scenarios: 
		| SummandOne | SummandTwo | Result |       
		| 50         | 70         | 120    | 
		| 1          | 10         | 11     |