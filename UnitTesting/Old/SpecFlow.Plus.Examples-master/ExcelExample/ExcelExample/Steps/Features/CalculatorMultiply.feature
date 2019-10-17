Feature: Calculator Multiply Feature
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the product of two numbers

Scenario Outline: Add two numbers
	Given I have entered <FactorOne> into the calculator
	And I have also entered <FactorTwo> into the calculator
	When I press multiply
	Then The result should be <Result> on the screen

@source:MultiplyTwoNumbers.part.examples.xlsx
Examples:
	| FactorOne | FactorTwo | Result |
	| -10       | 10        | -100   |
	| 42        | 13        | 546    |