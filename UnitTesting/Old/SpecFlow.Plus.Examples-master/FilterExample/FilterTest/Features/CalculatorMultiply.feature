Feature: Calculator Multiply Feature
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the product of two numbers

@Multiply @Complex @Feature_3 @Flickering
Scenario Outline: Multiply two numbers
	Given I have entered <FactorOne> into the calculator
	And I have also entered <FactorTwo> into the calculator
	When I press multiply
	Then The result should be <Result> on the screen

Examples:
	| FactorOne | FactorTwo | Result |
	| 70        | 50        | 3500   |
	| 1         | 2         | 2      |
	| -10       | 10        | -100   |
	| 42        | 13        | 546    |