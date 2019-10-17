#add @web tag to run the search tests with Selenium automation
#add @web tag to run the search tests with CodedUI automation

#@webCodedUI
#@web
Feature: US01 - Book Search
	As a potential customer
	I want to search for books by a simple phrase
	So that I can easily allocate books by something I remember from them.

Background:
	Given the following books
		|Author			|Title								|
		|Martin Fowler	|Analysis Patterns					|
		|Eric Evans		|Domain Driven Design				|
		|Ted Pattison	|Inside Windows SharePoint Services	|
		|Gojko Adzic	|Bridging the Communication Gap		|


Scenario: Title should be matched
	When I search for books by the phrase 'Domain'
	Then the list of found books should contain only: 'Domain Driven Design'


Scenario: Author should be matched
	When I search for books by the phrase 'Fowler'
	Then the list of found books should contain only: 'Analysis Patterns'


Scenario: Space should be treated as multiple OR search
	When I search for books by the phrase 'Windows Communication'
	Then the list of found books should contain only: 'Bridging the Communication Gap', 'Inside Windows SharePoint Services'


Scenario: Search result should be ordered by book title
	When I search for books by the phrase 'id'
	Then the list of found books should be:
		| Title                              |
		| Bridging the Communication Gap     |
		| Inside Windows SharePoint Services |


@alternative_syntax
Scenario Outline: Simple search (scenario outline syntax)
	When I search for books by the phrase '<search phrase>'
	Then the list of found books should contain only: <books>

	Examples:
		|search phrase			|books																	|
		|Domain					|'Domain Driven Design'													|
		|Windows Communication	|'Bridging the Communication Gap', 'Inside Windows SharePoint Services'	|
