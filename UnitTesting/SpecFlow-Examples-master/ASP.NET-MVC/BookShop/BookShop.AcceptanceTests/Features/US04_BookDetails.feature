@automated
Feature: US04 - Book details
	As a potential customer
	I want to see the details of a book
	So that I can better decide to buy it.

Background:
	Given the following books
		|Author			|Title								|Price	|
		|Martin Fowler	|Analysis Patterns					|50.20	|
		|Eric Evans		|Domain Driven Design				|46.34	|
		|Ted Pattison	|Inside Windows SharePoint Services	|31.49	|
		|Gojko Adzic	|Bridging the Communication Gap		|24.75	|

Scenario: The author, the title and the price of a book can be seen
	When I open the details of 'Analysis Patterns'
	Then the book details should show
		|Author			|Title				|Price	|
		|Martin Fowler	|Analysis Patterns	|50.20	|
