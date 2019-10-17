Feature: Calc

Scenario: Add two numbers
	Given the first operand is '5.00'
	And the function is 'plus'
	And the second operand is '7.00'
	When the calculation is executed
	Then the result should be '12.00'


Scenario: Subtract two numbers
	Given the first operand is '12.00'
	And the function is 'minus'
	And the second operand is '7.00'
	When the calculation is executed
	Then the result should be '5.00'

Scenario Outline: Multiply two numbers
	Given the first operand is '<valueA>'
	And the function is 'multiply'
	And the second operand is '<valueB>'
	When the calculation is executed
	Then the result should be '<result>'

Examples: 
	| valueA | valueB | result |
	| 1.00   | 1.00   | 1.00   |
	| 1.00   | 2.00   | 2.00   |
	| 2.00   | 1.00   | 2.00   |
	| 1.00   | 0.00   | 0.00   |
