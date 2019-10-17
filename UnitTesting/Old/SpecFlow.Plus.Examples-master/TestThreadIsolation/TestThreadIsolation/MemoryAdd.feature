@Memory
Feature: Memory Add
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two number

Scenario Outline: Add two numbers
	Given I have entered <Number1> into the calculator
	And I have entered <Number2> into the calculator
	When I press add
	Then the result should be <Result> on the screen

Examples: 
	| Number1 | Number2 | Result |
	| 1       | 2       | 3      |
	| 4       | 5       | 9      |
	| 10      | 11      | 21     |
	| 22      | 23      | 45     |
	| 46      | 47      | 93     |
	| 94      | 95      | 189    |