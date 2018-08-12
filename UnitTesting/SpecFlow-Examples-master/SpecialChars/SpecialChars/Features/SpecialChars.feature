Feature: SpecialChars
	

Scenario Outline: From GitHub Issue 1221
	Then the special char '<char>' is working

Examples: 
	| char |
	| Å    |
	| ô    |
	| é    |

Scenario Outline: From GitHub Issue 1205
	Then the special char '<char>' is working

Examples: 
	| char |
	| á    |
	| ã    |


Scenario Outline: Currency symbols
	Then the special char '<char>' is working

Examples: 
	| char |
	| €    |
	| $    |
	| £    |