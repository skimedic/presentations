Feature: Calculator Divide feature
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the quotient of two numbers

Scenario Outline: Divide two numbers
	Given I have entered <Number1> into the calculator
	And I have also entered <Number2> into the calculator
	When I press divide
	Then The result should be <Result> on the screen

#This example does not use an Excel file
Examples:
	| Number1  | Number2 | Result |
	| 70       | 50      | 1      |
	| 1        | 2       | 0      |
	| -10      | 10      | -1     |
	| 42       | 13      | 3      |