Feature: AppVeyor Support
	

Scenario: Successful Test
	Given I have a passing SpecFlow project
	When an AppVeyor build is executed
	Then the tests are run and everything passed


Scenario: Failing Test
	Given I have a failing SpecFlow project
	When an AppVeyor build is executed
	Then the tests are run and it failed


Scenario: Inconclusive Test
	Given I have a SpecFlow project which has not all step bound
	When an AppVeyor build is executed
	Then the tests are run and it is inconclusive

