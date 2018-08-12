Feature: Calculator Multiply Feature
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the product of two numbers

Scenario Outline: Multiply two numbers
	Given I have entered <Number1> into the calculator
	And I have also entered <Number2> into the calculator
	When I press multiply
	Then The result should be <Result> on the screen

#The following line references the examples in MultiplyTwoNumbers.part.examples.xlsx
@source:MultiplyTwoNumbers.part.examples.xlsx
#The examples in the table below are ALSO used
Examples:
	| Number1 | Number2 | Result |
	| -10       | 10        | -100   |
	| 42        | 13        | 546    |