Feature: Define the culture format for numbers and dates
	In order to write my features in english but specify my numbers and dates in another culture format
	As an author of features
	I want to have an option to plug in custom conversions

Scenario: Use english as feature language but numbers and dates have Austrian format
	Given I have entered 1050,1 into the system
	And the date is 22.12.2010
