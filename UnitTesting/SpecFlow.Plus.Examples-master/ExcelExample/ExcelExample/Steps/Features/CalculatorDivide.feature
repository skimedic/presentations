Feature: Calculator Divide feature
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the quotient of two numbers

Scenario Outline: Add two numbers
	Given I have entered <Divident> into the calculator
	And I have also entered <Divisor> into the calculator
	When I press divide
	Then The result should be <Result> on the screen

Examples:
	| Divident | Divisor | Result |
	| 70       | 50      | 1      |
	| 1        | 2       | 0      |
	| -10      | 10      | -1     |
	| 42       | 13      | 3      |