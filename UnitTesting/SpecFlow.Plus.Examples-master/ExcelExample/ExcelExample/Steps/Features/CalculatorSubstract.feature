Feature: Calculator Subtract Feature
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the difference of two numbers

Scenario Outline: Subtract Two Numbers
	Given I have entered <Minuend> into the calculator
	And I have also entered <Subtrahend> into the calculator
	When I press substract
	Then The result should be <Result> on the screen

@source:SubtractTwoNumbers.examples.xlsx
Examples: 
	| Minuend | Subtrahend | Result |