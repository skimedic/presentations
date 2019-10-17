Feature: Calculator Add Feature
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@Simple @Feature_1 @Stable
Scenario Outline: Add Two Numbers
	Given I have entered <SummandOne> into the calculator
	And I have also entered <SummandTwo> into the calculator
	When I press add
	Then The result should be <Result> on the screen

Examples: 
	| SummandOne | SummandTwo | Result |
	| 70         | 50         | 120    |
	| 1          | 2          | 3      |
	| 10         | 10         | 20     |
	| 42         | 13         | 55     |

