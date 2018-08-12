Feature: Calculator Subtract Feature
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the difference of two numbers

Scenario Outline: Subtract two numbers
	Given I have entered <Number1> into the calculator
	And I have also entered <Number2> into the calculator
	When I press substract
	Then The result should be <Result> on the screen

#The following line references the examples in SubtractTwoNumbers.examples.xlsx
@source:SubtractTwoNumbers.examples.xlsx
#You can also extend the table below with additional examples
Examples: 
	| Number1 | Number2 | Result |