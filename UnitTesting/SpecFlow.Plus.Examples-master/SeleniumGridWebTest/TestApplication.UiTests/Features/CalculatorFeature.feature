Feature: CalculatorFeature
	 In order to avoid silly mistakes 
	As a math idiot
	I want to be told the sum of two numbers

@Browser_Chrome
@Browser_IE
@Browser_Firefox
Scenario: Basepage is Calculator
	Given I navigated to /
	Then browser title is Calculator

@Browser_IE 
@Browser_Chrome
@Browser_Firefox
Scenario Outline: Add Two Numbers
	Given I navigated to /
	And I have entered <SummandOne> into summandOne calculator
	And I have entered <SummandTwo> into summandTwo calculator
	When I press add
	Then the result should be <Result> on the screen

Scenarios: 
		| SummandOne | SummandTwo | Result |
		| 50         | 70         | 120    |
		| 1          | 10         | 11     |
		| 43         | 12         | 55     |
		| 19         | 73         | 92     |
		| 26         | 12         | 38     |
		| 49         | 15         | 64     |
		| 11         | 26         | 37     |
		| 81         | 93         | 174    |
		| 69         | 90         | 159    |
		| 91         | 52         | 143    |
		| 38         | 52         | 90     |
		| 73         | 6          | 79     |
		| 64         | 40         | 104    |
		| 48         | 8          | 56     |
		| 93         | 25         | 118    |
		| 83         | 40         | 123    |
		| 56         | 1          | 57     |
		| 70         | 88         | 158    |
		| 67         | 78         | 145    |
		| 53         | 94         | 147    |
		| 49         | 95         | 144    |
		| 88         | 22         | 110    |
		| 66         | 11         | 77     |
		| 98         | 13         | 111    |
		| 47         | 67         | 114    |
		| 99         | 87         | 186    |
		| 91         | 3          | 94     |
		| 85         | 100        | 185    |
		| 75         | 94         | 169    |
		| 37         | 74         | 111    |
		| 35         | 33         | 68     |
		| 32         | 59         | 91     |

