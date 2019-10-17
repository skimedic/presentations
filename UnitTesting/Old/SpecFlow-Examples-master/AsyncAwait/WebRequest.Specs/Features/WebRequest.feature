Feature: Web request

Scenario: Request example page
	Given I have a web client
	When I want to get the web page 'http://example.com'
	Then the result should have status code '200'
