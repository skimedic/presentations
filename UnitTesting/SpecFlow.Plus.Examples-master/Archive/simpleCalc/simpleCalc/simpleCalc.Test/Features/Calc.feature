Feature: Calc

Scenario: Add two numbers
	Given the first operand is '5.00'
	And the function is 'plus'
	And the second operand is '7.00'
	When the calcuation is executed
	Then the result should be '12.00'
