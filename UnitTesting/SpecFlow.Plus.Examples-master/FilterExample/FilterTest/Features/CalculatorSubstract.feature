Feature: Calculator Subtract Feature
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the difference of two numbers

@Substract @Simple @Feature_4 @Failing
Scenario Outline: Subtract Two Numbers
	Given I have entered <Minuend> into the calculator
	And I have also entered <Subtrahend> into the calculator
	When I press substract
	Then The result should be <Result> on the screen

Examples: 
	| Minuend | Subtrahend | Result |
	| 70      | 50         | 20     |
	| 1       | 2          | -1     |
	| -10     | 10         | -20    |
	| 42      | 13         | 29     |